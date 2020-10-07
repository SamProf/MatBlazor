using System;
using System.Collections.Generic;

namespace MatBlazor
{
    public class BaseMapper
    {
        public List<Func<string>> Items = new List<Func<string>>();
    }


    public static class BaseMapperExtensions
    {
        public static T Add<T>(this T m, string name) where T : BaseMapper
        {
            m.Items.Add(() => name);
            return m;
        }


        public static T Get<T>(this T m, Func<string> funcName) where T : BaseMapper
        {
            m.Items.Add(funcName);
            return m;
        }

        public static T GetIf<T>(this T m, Func<string> funcName, Func<bool> func) where T : BaseMapper
        {
            m.Items.Add(() => func() ? funcName() : null);
            return m;
        }

        public static T If<T>(this T m, string name, Func<bool> func) where T : BaseMapper
        {
            m.Items.Add(() => func() ? name : null);
            return m;
        }
    }
}