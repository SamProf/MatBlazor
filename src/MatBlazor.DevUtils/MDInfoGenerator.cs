using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MatBlazor.DevUtils
{
    public class MDInfoGenerator
    {

        public string SourceFile { get; set; } = "README.md";
        public string TargetFile { get; set; }
        public string Header { get; set; } 


        public void Generate()
        {
            var config = Config.GetConfig();
            var lines = File.ReadAllLines(Path.Combine(config.RepositoryPath, SourceFile));

            lines = lines.SkipWhile(i => !i.Trim().Equals("## "+Header, StringComparison.InvariantCultureIgnoreCase))
                .ToArray();

            lines = lines.TakeWhile((i, index) => !(i.Trim().StartsWith("## ") && index > 0)).ToArray();

            var text = string.Join("\r\n", lines);

            Console.WriteLine(text);

            var result = CommonMark.CommonMarkConverter.Convert(text);

            result = result.Replace("@", "@@").Replace(@"<h5>", @"<h5 class=""mat-h5"">")
                                              .Replace(@"<h4>", @"<h4 class=""mat-h4"">")
                                              .Replace(@"<h3>", @"<h3 class=""mat-h3"">")
                                              .Replace(@"<h2>", @"<h2 class=""mat-h2"">")
                                              .Replace(@"<h1>", @"<h1 class=""mat-h1"">"); ;

            Console.WriteLine(result);

            var newsFile = Path.Combine(config.Path, "MatBlazor.Demo", "Shared", TargetFile);

            result = "@* THIS IS AUTO GENERATED FILE!!! *@\r\n\r\n" + result;

            File.WriteAllText(newsFile, result);
        }
    }
}
