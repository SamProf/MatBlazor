using System;

namespace MatBlazor.Demo.Models
{
    public class RouteDisplayAttribute :Attribute
    {
        public RouteDisplayAttribute(string text, string group = null, int  priority = int.MaxValue)
        {
            Text = text;
            Group = group;
            Priority = priority;
        }

        public string Text { get;  }

        public string Group { get;  }

        public int Priority { get; }
    }
}