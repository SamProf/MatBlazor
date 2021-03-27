using System;

namespace MatBlazor.Demo.Models
{
    public class RouteDisplayAttribute :Attribute
    {
        public RouteDisplayAttribute(string group = null, string text = null, bool visible = true,int priority = int.MaxValue)
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