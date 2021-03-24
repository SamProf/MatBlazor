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
    }
    public static class TypeExtensions
    {
        public static string GetTypeDocu(this Type docComponentType, Type typeToDocument)
        {
            var generator = new MatDocumenationGenerator(typeToDocument.Assembly);
            var allDocs = generator.GenerateDynamically(docComponentType.Assembly);
            var finalDoc = allDocs.Single(x => x.ComponentType == typeToDocument).HtmlDoc;
            return finalDoc;
        }
        public static DocInfo GetDocInfo(this ComponentBase component, int number)
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
                if (line.Contains($"{nameof(GetDocInfo)}({number}"))
                {
                    start = true;
                }
                else if (start)
                {
                    if (line.Contains($"</{nameof(AutoDemoContainer)}"))
                    {
                        break;
                    }
                    code += line + Environment.NewLine;
                }
            }
            return new DocInfo() { Code = code };
        }
    }
}
