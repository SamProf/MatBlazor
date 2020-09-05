using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Linq;
using MatBlazor.DevUtils.Core;

namespace MatBlazor.DevUtils
{
    [TestFixture]
    public class DemoContentGenerator
    {


        public void Run()
        {
            this.GenerateDocumentation();
            this.GenerateNews();
            this.GenerateSponsors();
            this.Generate();
        }


        [Test]
        public void GenerateDocumentation()
        {
            var config = Config.GetConfig();
            var gen = new MatDocumenationGenerator(typeof(BaseMatDomComponent).Assembly,
                Path.Combine(config.Path, "MatBlazor.Demo", "Doc"));
            {
            }
            ;
            gen.Generate();
        }


        [Test]
        public void GenerateNews()
        {
            var gen = new MDInfoGenerator()
            {
                Header = "News",
                TargetFile = "News.razor"
            };
            gen.Generate();
        }


        [Test]
        public void GenerateSponsors()
        {
            var gen = new MDInfoGenerator()
            {
                Header = "Sponsors & Backers",
                TargetFile = "Sponsors.razor"
            };
            gen.Generate();
        }


        [Test]
        public void Generate()
        {
            string filterFileName = null;


            var countAll = 0;
            var countChanged = 0;


            var config = Config.GetConfig();
            var dirInfo = new DirectoryInfo(config.Path);
            Console.WriteLine(dirInfo.FullName);

            var files = dirInfo.GetFiles(config.FileMask, SearchOption.AllDirectories);

            var demoContainerTag = config.DemoContainerTag;
            var contentTag = config.ContentTag;
            var sourceContentTag = config.SourceContentTag;

            var regex = new Regex(
                $@"<{demoContainerTag}(?<Attrs>[+\S\s]*?)>(?<Tabs>[\s]+)<{contentTag}>(?<Content>[\s\S]*?)</{contentTag}>[\s\S]*?</{demoContainerTag}>");


            foreach (var fileInfo in files)
            {
                if (filterFileName != null)
                {
                    if (!string.Equals(fileInfo.Name, filterFileName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        continue;
                    }
                }

                countAll++;
//                Console.WriteLine(fileInfo.FullName);

                var content = File.ReadAllText(fileInfo.FullName);
                var content2 = regex.Replace(content, (m) =>
                {
                    var doc = new XmlDocument();
                    doc.LoadXml($"<demoContainerTag{m.Groups["Attrs"]}></demoContainerTag>");
                    var sourceContent = m.Groups["Content"].Value;

                    if (doc.DocumentElement.Attributes != null && doc.DocumentElement.Attributes["SourcePath"] != null)
                    {
                        var sourcePath = new Uri(new Uri(fileInfo.FullName),
                            doc.DocumentElement.Attributes["SourcePath"].Value).LocalPath;
                        sourceContent = System.IO.File.ReadAllText(sourcePath);
                    }

                    return
                        $"<{demoContainerTag}{m.Groups["Attrs"]}>{m.Groups["Tabs"]}<{contentTag}>{m.Groups["Content"]}</{contentTag}>{m.Groups["Tabs"]}<{sourceContentTag}>{m.Groups["Tabs"]}\t{PrepareSourceCode(sourceContent)}{m.Groups["Tabs"]}</{sourceContentTag}>\r\n</{demoContainerTag}>";
                });


                if (content2 != content)
                {
                    File.WriteAllText(fileInfo.FullName, content2);
                    Console.WriteLine(fileInfo.FullName);
                    countChanged++;
                }
            }

            Console.WriteLine($"All: {countAll}");
            Console.WriteLine($"Changed: {countChanged}");
        }


        private string PrepareSourceCode(string s)
        {
            return $@"<BlazorFiddle Template=""MatBlazor"" Code=@(@""{s.Replace("\"", "\"\"")}"")></BlazorFiddle>";
        }
    }
}