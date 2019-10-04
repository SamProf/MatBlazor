using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatBlazor
{
    public class StyleMapper
    {
        private List<Func<string>> actions = new List<Func<string>>();

        public void Get(Func<string> action)
        {
            actions.Add(action);
        }

        public override string ToString()
        {
            return AsString();
        }

        public string AsString()
        {
            return string.Join(";", actions.Select(i => i()));
        }
    }
}