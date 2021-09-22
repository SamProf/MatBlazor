using System;

namespace MatBlazor.Demo.Models
{
    public class RouteDisplayAttribute :Attribute
    {
        public RouteDisplayAttribute(string group = null, string text = null, bool visible = true, float priority = float.MaxValue, float groupPriority = float.MaxValue)
        {
            Text = text;
            Group = group;
            Priority = priority;
            GroupPriority = groupPriority;
            Visible = visible;
        }

        public string Text { get;  }

        public string Group { get;  }

        public float Priority { get; }

        public float GroupPriority { get; }
        public bool Visible { get; }
    }
}