using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using NUnit.Framework;

namespace MatBlazor.DevUtils
{
    [TestFixture]
    public class DemoContentGenerator
    {
        [Test]
        public void Generate()
        {
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
                            doc.DocumentElement.Attributes["SourcePath"].Value).AbsolutePath;
                        sourceContent = System.IO.File.ReadAllText(sourcePath);
                    }

                    return
                        $"<{demoContainerTag}{m.Groups["Attrs"]}>{m.Groups["Tabs"]}<{contentTag}>{m.Groups["Content"]}</{contentTag}>{m.Groups["Tabs"]}<{sourceContentTag}>{m.Groups["Tabs"]}\t{EscapeString(sourceContent)}{m.Groups["Tabs"]}</{sourceContentTag}>\r\n</{demoContainerTag}>";
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


        private string EscapeString(string s)
        {
            //            XmlDocument doc = new XmlDocument();
            //            XmlAttribute attr = doc.CreateAttribute("attr");
            //            attr.InnerText = s;
            //            s = attr.InnerXml;
            //
            //            s = s.Replace("\r", "&#xD;").Replace("\n", "&#xA;").Replace("\"", "&quot;");
            //
            //            return $"<pre data=\"{s}\"></pre>";


            s = HttpUtility.HtmlEncode(s);
            var sb = new StringBuilder();
            if (s != null)
            {
                foreach (var ch in s)
                {
                    sb.Append("\\u" + ((int) ch).ToString("X4"));
                }
            }

            s = sb.ToString();


            return $"<div style=\"white-space: pre-wrap;\">@((MarkupString) \"{s}\")</div>";
        }
    }
}