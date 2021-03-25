using MatBlazor.DevUtils.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatBlazor.Doc.DemoContainer
{
    public record DocInfo
    {
        public string Code { get; set; }
        public string SectionText { get; internal set; }
    }
    public static class TypeExtensions
    {
        //public static string GetTypeDocu(this Type docComponentType, Type typeToDocument)
        //{
        //    var generator = new AssemblyDocumentationGenerator(typeToDocument.Assembly);
        //    var allDocs = generator.GenerateDynamically(docComponentType.Assembly);
        //    var finalDoc = allDocs.Single(x => x.Type == typeToDocument).Documentation;
        //    return finalDoc;
        //}

        private static ConcurrentDictionary<Type, DocInfo> Cache { get; } = new ConcurrentDictionary<Type, DocInfo>();
        public static DocInfo GetDocInfo(this ComponentBase component, string uniqueSectionText)
        {
            var componentType = component.GetType();
            return Cache.GetOrAdd(componentType, t =>
             {
                 var resourceName = t.Assembly.GetManifestResourceNames().SingleOrDefault(
                   n => n.EndsWith($".{t.Name}.razor"));
                 if (resourceName == null)
                 {
                     throw new ApplicationException(
                         $"The embedded resource for the documentation razor page " +
                         $"'{t.Name}' wasn't found. Make sure that the razor files " +
                         $"are embedded as resource by applying an item group in the project " +
                         $"file similar to <EmbeddedResoure Include=\"Pages\\**.*.razor\" LinkBase=\"Resources\" /> ");
                 }
                 using var stream = t.Assembly.GetManifestResourceStream(resourceName);
                 using var reader = new StreamReader(stream);
                 var code = string.Empty;
                 bool start = false;
                 while (true)
                 {
                     var line = reader.ReadLine();
                     if (line.Contains($"{nameof(GetDocInfo)}(\"{uniqueSectionText}\""))
                     {
                         start = true;
                     }
                     else if (start)
                     {
                         if (line.Contains($"</{nameof(RazorDocContainer)}"))
                         {
                             break;
                         }
                         code += line + Environment.NewLine;
                     }
                 }
                 return new DocInfo() { Code = code, SectionText = uniqueSectionText };
             });
        }
    }
}
