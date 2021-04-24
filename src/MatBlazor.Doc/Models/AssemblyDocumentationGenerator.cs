using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Xml.Linq;

namespace MatBlazor.DevUtils.Core
{
    public class AssemblyDocumentationGenerator
    {
        public Assembly Assembly;
        public string OutputPath { get; }

        public Lazy<XDocument> XmlDocumentation { get; }

        public AssemblyDocumentationGenerator(Assembly assembly,  string outputPath, Func<Type,bool> filter = null)
        : this(assembly,filter)
        {
            OutputPath = outputPath;
            this.XmlDocumentation = new Lazy<XDocument>(
                () =>
                {
                    var xmlPath = Path.ChangeExtension(this.Assembly.Location, ".xml");
                    if (!File.Exists(xmlPath))
                    {
                        throw new Exception("Xml not found");
                    }

                    if (!Directory.Exists(outputPath))
                    {
                        throw new Exception("OutputPath not exists");
                    }

                    var xml = XDocument.Load(xmlPath);
                    return xml;
                });
        }

        public AssemblyDocumentationGenerator(Assembly assembly, Assembly docFileContainer, Func<Type,bool> filter = null)
            : this(assembly,filter)
        {
            this.XmlDocumentation = new Lazy<XDocument>(() =>
            {
                using var docfileStream = docFileContainer.GetManifestResourceStream(
                    docFileContainer.GetManifestResourceNames().Single(rn => rn.EndsWith(this.Assembly.GetName().Name + ".xml")));
                var xml = XDocument.Load(docfileStream);
                return xml;
            });
        }
        public Lazy<TypeDocumentation[]> TypeDocumentations { get; }
        public Func<Type, bool> Filter { get; }

        private AssemblyDocumentationGenerator(Assembly assembly,Func<Type,bool> filter = null)
        {
            this.Assembly = assembly;
            Filter = filter;
            this.TypeDocumentations = new(() => this.GetTypeDocumentationContainers().ToArray());
        }

        public void Generate()
        {
            foreach (var fileInfo in new DirectoryInfo(this.OutputPath).GetFiles("*.razor", SearchOption.TopDirectoryOnly))
            {
                fileInfo.Delete();
            }
            try
            {
                foreach (var output in GetTypeDocumentationContainers())
                {
                    File.WriteAllText(output.OutputFilePath, output.Documentation.Value);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public TypeDocumentation[] GenerateDynamically()
        {
           var result =  GetTypeDocumentationContainers().ToArray();
            return result;
        }

        public TypeDocumentation GetDocumentationFor(Type type)
        {
            return this.TypeDocumentations.Value.Single(td => td.Type == type);
        }


        private IEnumerable<TypeDocumentation> GetTypeDocumentationContainers()
        {
            foreach (var type in Assembly.ExportedTypes)
            {
                if (this.Filter?.Invoke(type) ?? true)
                {
                    yield return new TypeDocumentation(this, type);
                }
            }
            

        }



        public XElement FindDocXml( Type type)
        {
            var xml = this.XmlDocumentation.Value;
            if (xml.Root != null)
            {
                var membersEl = xml.Root.Element("members");
                if (membersEl != null)
                {
                    while (type != null && type.Assembly == Assembly)
                    {
                        var key = $"T:{type.Namespace}.{type.Name}";
                        var el = membersEl.Elements("member").FirstOrDefault(i => i.Attribute("name").Value == key);
                        if (el != null)
                        {
                            return el;
                        }

                        if (type.IsGenericType)
                        {
                            type = type.BaseType;
                        }
                        else
                        {
                            type = type.BaseType;
                        }
                    }
                }
            }

            return null;
        }

        public XElement FindDocXml( MemberInfo member)
        {
            var xml = this.XmlDocumentation.Value;
            if (xml.Root != null)
            {
                var membersEl = xml.Root.Element("members");
                if (membersEl != null) 
                {
                    string key;
                    if (member.DeclaringType.IsGenericType)
                    {
                        key = $"P:{member.DeclaringType.GetGenericTypeDefinition().FullName}.{member.Name}";
                    }
                    else
                    {
                        key = $"P:{member.DeclaringType}.{member.Name}";
                    }

                    var el = membersEl.Elements("member").FirstOrDefault(i => i.Attribute("name").Value == key);
                    return el;
                }
            }

            return null;
        }



        
    }
    public class TypeDocumentation
    {
        public Lazy<string> TypeName { get; }
        public Lazy<string> Documentation { get; }

        public TypeDocumentation(AssemblyDocumentationGenerator assemblyDocumentation, Type type)
        {
            AssemblyDocumentation = assemblyDocumentation;
            Type = type;
            this.TypeName = new(() => this.GetTypeName(type, true));
            this.Documentation = new(() => this.GetDocumentationAsync());
        }
        public string OutputFilePath => Path.Combine(this.AssemblyDocumentation.OutputPath ?? "", $"Doc{GetFileName(this.TypeName.Value)}.razor");


        public AssemblyDocumentationGenerator AssemblyDocumentation { get; }
        public Type Type { get; }

        private string GetFileName(string n)
        {
            foreach (var ch in Path.GetInvalidFileNameChars())
            {
                n = n.Replace("" + ch, "");
            }

            return n;
        }
        private string ParseXmlMember(XElement xmlEl, string element = "summary", string name = null)
        {
            if (xmlEl != null)
            {
                var summaryXmlEls = xmlEl.Elements(element);

                if (name != null)
                {
                    summaryXmlEls = summaryXmlEls.Where(i => i.Attribute("name").Value == name);
                }

                return summaryXmlEls.FirstOrDefault()?.Value;
            }

            return null;
        }

        private string HtmlEncode(string v)
        {
            if (v == null)
            {
                return "";
            }

            return string.Join("<br/>",
                v.Trim().Split("\n").Select(i => i.Trim()).Select(i => HttpUtility.HtmlEncode(i)));
        }

        private string GetTypeName(Type t, bool disableGeneric)
        {
            if (!t.IsGenericType)
            {
                return t.Name;
            }

            string genericTypeName = t.GetGenericTypeDefinition().Name;
            genericTypeName = genericTypeName.Substring(0,
                genericTypeName.IndexOf('`'));

            if (disableGeneric)
            {
                return genericTypeName;
            }
            else
            {
                string genericArgs = string.Join(",",
                    t.GetGenericArguments()
                        .Select(ta => GetTypeName(ta, disableGeneric)).ToArray());
                return genericTypeName + "<" + genericArgs + ">";
            }
        }

        private string GetDocumentationAsync()
        {
            var type = this.Type;
            var typeName = this.TypeName.Value;

            Console.WriteLine(typeName);


            var generateComponentFrame = this.AssemblyDocumentation.OutputPath != null;
            var sb = new StringBuilder();
            if (generateComponentFrame)
            {
                sb.AppendLine($"@inherits MatBlazor.Demo.Components.BaseDocComponent");
                sb.AppendLine();
                sb.AppendLine("@* THIS FILE IS AUTOGENERATED FROM C# XML Comments! *@");
                sb.AppendLine("@* ALL MANUAL CHANGES WILL BE REMOVED! *@");
                sb.AppendLine();
                sb.AppendLine();
                //@if (Secondary) { <h3 class="mat-h3">MatProgressBar</h3> } else { <h3 class="mat-h3">MatProgressBar</h3> }
                sb.AppendLine(
                    $"@if (!Secondary) {{<h3 class=\"mat-h3\">@Header</h3> }} else {{ <h5 class=\"mat-h5\">@Header</h5> }}");
                sb.AppendLine();
            }
            var typeXml = this.AssemblyDocumentation.FindDocXml(type);
            if (typeXml != null)
            {
                sb.AppendLine($"<p>{HtmlEncode(ParseXmlMember(typeXml))}</p>");
                sb.AppendLine();
            }


            var includeFields = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        nameof(BaseMatDomComponent.Ref)
                    };

            var isBlazorComponent = type.IsSubclassOf(typeof(ComponentBase));
            var parameters = type
                .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(prop =>
                    isBlazorComponent &&
                    prop.GetCustomAttributes(typeof(ParameterAttribute)).Any()
                    ||
                    !isBlazorComponent &&
                    prop.DeclaringType.Assembly == this.AssemblyDocumentation.Assembly
                )
                .OrderBy(i => i.Name)
                .Union(
                    type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                        .Where(i => includeFields.Contains(i.Name))
                        .OrderBy(i => i.Name)
                )
                .ToArray();


            //                sb.AppendLine($"<h5 class=\"mat-h5\">Documentation</h5>");

            sb.AppendLine($"<div><table class=\"article-table mat-elevation-z5 mdc-theme--surface\">");
            sb.AppendLine($"\t<tr>");
            sb.AppendLine($"\t\t<th>Name</th>");
            sb.AppendLine($"\t\t<th>Type</th>");
            sb.AppendLine($"\t\t<th>Description</th>");
            sb.AppendLine($"\t</tr>");


            if (type.IsGenericType)
            {
                foreach (var genericArgument in type.GetGenericArguments())
                {
                    var propXml = this.AssemblyDocumentation.FindDocXml(type);

                    sb.AppendLine($"\t<tr>");
                    sb.AppendLine(
                        $"\t\t<td style=\"font-weight: bold;\">{HtmlEncode(genericArgument.Name)}</td>");
                    sb.AppendLine($"\t\t<td>Generic argument</td>");
                    sb.AppendLine(
                        $"\t\t<td>{HtmlEncode(ParseXmlMember(typeXml, "typeparam", genericArgument.Name))}</td>");
                    sb.AppendLine($"\t</tr>");
                }
            }


            foreach (var prop in parameters)
            {
                var propXml = this.AssemblyDocumentation.FindDocXml(prop);
                var propText = ParseXmlMember(propXml);

                if (prop.Name == "ChildContent" && string.IsNullOrEmpty(propText))
                {
                    propText = "Child content of " + typeName;
                }

                sb.AppendLine($"\t<tr>");
                sb.AppendLine($"\t\t<td>{HtmlEncode(prop.Name)}</td>");
                sb.AppendLine($"\t\t<td>{HtmlEncode(GetTypeName(prop.PropertyType, false))}</td>");
                sb.AppendLine($"\t\t<td>{HtmlEncode(propText)}</td>");
                sb.AppendLine($"\t</tr>");
            }

            sb.AppendLine($"</table></div>");

            if (generateComponentFrame)
            {
                sb.AppendLine("");
                sb.AppendLine("");
                sb.AppendLine("@code");
                sb.AppendLine("{");
                sb.AppendLine("");
                sb.AppendLine("\t[Parameter]");
                sb.AppendLine($"\tpublic string Header {{ get; set; }} = \"{typeName}\";");
                sb.AppendLine("");
                sb.AppendLine("}");
            }
            return sb.ToString();
        }
    }

}