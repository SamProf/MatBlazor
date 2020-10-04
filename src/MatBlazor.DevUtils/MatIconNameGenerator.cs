using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace MatBlazor.DevUtils
{
    //    [TestFixture()]
    public class MatIconNameGenerator
    {
//        [Test]
        public void Generate()
        {
            var config = Config.GetConfig();
            var dataFile = Path.Combine(config.Path, "MatBlazor.DevUtils", "Data", "data.json");

            var data = JsonConvert.DeserializeObject<Data>(File.ReadAllText(dataFile));


            var sb = new StringBuilder();
            sb.AppendLine("namespace MatBlazor.Models");
            sb.AppendLine("{");
            sb.AppendLine("\tpublic class MatIconNames");
            sb.AppendLine("\t{");
            foreach (var cat in data.Categories)
            {
                foreach (var icon in cat.Icons)
                {
                    var name = GetPropName(icon.Id);

                    sb.AppendLine($"\t\tpublic static string {name} {{ get; }}= \"{icon.Id}\";");
                }
            }

            sb.AppendLine("\t}");


            sb.AppendLine("\tpublic class MatIconCategories");
            sb.AppendLine("\t{");

            sb.AppendLine("\t\tpublic static MatIconDataCategory[] Data { get; } = new[]");
            sb.AppendLine("\t\t{");

            foreach (var cat in data.Categories)
            {
                sb.AppendLine("\t\t\tnew MatIconDataCategory()");
                sb.AppendLine("\t\t\t{");
                sb.AppendLine($"\t\t\t\tId = \"{cat.Name}\",");
                sb.AppendLine($"\t\t\t\tName = \"{GetName(cat.Name)}\",");
                sb.AppendLine($"\t\t\t\tIcons = new[]");
                sb.AppendLine("\t\t\t\t{");

                foreach (var icon in cat.Icons)
                {
                    sb.AppendLine("\t\t\t\t\tnew MatIconDataIcon()");
                    sb.AppendLine("\t\t\t\t\t{");
                    sb.AppendLine($"\t\t\t\t\t\tId = \"{icon.Id}\",");
                    sb.AppendLine($"\t\t\t\t\t\tName = \"{GetName(icon.Id)}\",");
                    sb.AppendLine($"\t\t\t\t\t\tPropName = \"{GetPropName(icon.Id)}\",");
                    sb.AppendLine("\t\t\t\t\t},");
                }

                sb.AppendLine("\t\t\t\t}");

                sb.AppendLine("\t\t\t},");
            }

            sb.AppendLine("\t\t};");

            sb.AppendLine("\t}");


            sb.AppendLine("}");

            File.WriteAllText(Path.Combine(config.Path, "MatBlazor", "Models", "MatIconNames.cs"), sb.ToString());
        }


        private string GetName(string id)
        {
            return id[0].ToString().ToUpper() + id.Substring(1);
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


    [JsonObject(MemberSerialization.OptIn)]
    public class Data
    {
        [JsonProperty("categories")]
        public DataCategory[] Categories { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class DataCategory
    {
        [JsonProperty("name")]
        public string Name { get; set; }


        [JsonProperty("icons")]
        public DataIcon[] Icons { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class DataIcon
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}