using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using JetBrains.dotMemoryUnit.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace MatBlazor.DevUtils
{
//    [TestFixture()]
    public class MatThemesGenerator
    {
//        [Test]
        public void Generate()
        {
            var config = Config.GetConfig();
            var dataFile = Path.Combine(config.Path, "MatBlazor.Web", "node_modules", "@material", "theme",
                "_color-palette.scss");

            var data = File.ReadAllText(dataFile);

            var colors = new Dictionary<string, Dictionary<string, string>>();


            var regex = new Regex(
                "^\\$material-color-(?<color>\\S+?)-(?<shade>[^-]+?):(\\s+?)(?<value>[^-]+?);(\\s*?)$",
                RegexOptions.Multiline);

            foreach (Match line in regex.Matches(data))
            {
                Console.WriteLine($"{line.Groups["color"]} {line.Groups["shade"]} {line.Groups["value"]}");
                var colorName = line.Groups["color"].Value;
                if (!colors.TryGetValue(colorName, out var c))
                {
                    c = new Dictionary<string, string>();
                    colors.Add(colorName, c);
                }

                c[line.Groups["shade"].Value] = line.Groups["value"].Value;
            }


//
            var sb = new StringBuilder();
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine();
            sb.AppendLine("namespace MatBlazor");
            sb.AppendLine("{");


            sb.AppendLine("\tpublic static partial  class MatThemeColors");
            sb.AppendLine("\t{");
            foreach (var color in colors)
            {
                sb.AppendLine(
                    $"\t\tpublic static MatThemeColor{GetName(color.Key)} {GetName(color.Key)} {{get;}} = new MatThemeColor{GetName(color.Key)}();");
            }

            sb.AppendLine("\t\tstatic MatThemeColors()");
            sb.AppendLine("\t\t{");
            sb.AppendLine("\t\t\tItems = new Dictionary<string, MatThemeColor>()");
            sb.AppendLine("\t\t\t{");
            foreach (var color in colors)
            {
                sb.AppendLine($"\t\t\t\t{{{GetName(color.Key)}.Key, {GetName(color.Key)}}},");
            }

            sb.AppendLine("\t\t\t};");
            sb.AppendLine("\t\t}");

            sb.AppendLine("\t}");


            foreach (var color in colors)
            {
                sb.AppendLine($"\tpublic class MatThemeColor{GetName(color.Key)} : MatThemeColor");
                sb.AppendLine("\t{");
                foreach (var sh in color.Value)
                {
                    sb.AppendLine(
                        $"\t\tpublic MatThemeColorShadow {GetPropName(sh.Key)} {{get;}} = new MatThemeColorShadow(\"{sh.Key}\", \"{GetPropName(sh.Key)}\", \"{sh.Value}\");");
                }


                sb.AppendLine(
                    $"\t\tpublic MatThemeColor{GetName(color.Key)}() : base(\"{color.Key}\", \"{GetName(color.Key)}\")");
                sb.AppendLine($"\t\t{{");
                sb.AppendLine($"\t\t\tShadows = new Dictionary<string, MatThemeColorShadow>()");
                sb.AppendLine($"\t\t\t{{");
                foreach (var sh in color.Value)
                {
                    sb.AppendLine($"\t\t\t\t{{{GetPropName(sh.Key)}.Key, {GetPropName(sh.Key)}}},");
                }

                sb.AppendLine($"\t\t\t}};");
                sb.AppendLine($"\t\t}}");

                sb.AppendLine("\t}");
            }


            sb.AppendLine("}");

            File.WriteAllText(Path.Combine(config.Path, "MatBlazor", "Models", "MatThemeColors.cs"), sb.ToString());
        }


        private string GetName(string key)
        {
            return string.Concat(key.Split('-').Select(id => id[0].ToString().ToUpper() + id.Substring(1)));
        }

        private string GetPropName(string id)
        {
            id = GetName(id);
            if (Char.IsDigit(id[0]))
            {
                return '_' + id;
            }

            return id;
        }
    }
}