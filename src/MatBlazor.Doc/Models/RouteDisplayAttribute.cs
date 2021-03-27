using System;

namespace MatBlazor.Demo.Models
{
    public class RouteDisplayAttribute :Attribute
    {
        public RouteDisplayAttribute(string text, string group = null, int  priority = int.MaxValue, bool visible = true)
        {
            Text = text;
            Group = group;
            Priority = priority;
            Visible = visible;
        }

        public string Text { get;  }

        public string Group { get;  }

        public int Priority { get; }
        public bool Visible { get; }
    }
}