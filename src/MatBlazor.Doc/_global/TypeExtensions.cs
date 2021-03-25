using MatBlazor.DevUtils.Core;
using Microsoft.AspNetCore.Components;
using System;
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
        public static DocInfo GetDocInfo(this ComponentBase component, string uniqueSectionText)
        {
            var componentType = component.GetType();
            var resourceName = componentType.Assembly.GetManifestResourceNames().Single(
              n => n.EndsWith($".{componentType.Name}.razor"));
            using var stream = componentType.Assembly.GetManifestResourceStream(resourceName);
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
        }
    }
}
