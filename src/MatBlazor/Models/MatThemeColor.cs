using System.Collections.Generic;

namespace MatBlazor
{
    public class MatThemeColor
    {
        public string Key { get; }
        public string Name { get; }

        public Dictionary<string, MatThemeColorShadow> Shadows { get; protected set; }

        public MatThemeColor(string key, string name)
        {
            Key = key;
            Name = name;
        }
    }

    public class MatThemeColorShadow
    {
        public string Key { get; }
        public string Name { get; }
        public string Value { get; }

        public override string ToString()
        {
            return Value;
        }


        public MatThemeColorShadow(string key, string name, string value)
        {
            Key = key;
            Name = name;
            Value = value;
        }
    }


    public static partial class MatThemeColors
    {
        public static Dictionary<string, MatThemeColor> Items { get; set; }
    }
}