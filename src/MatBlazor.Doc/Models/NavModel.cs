namespace MatBlazor.Demo.Models
{
    public class NavBarLinkModel
    {
        public string Url { get;  }
        public string Text { get; }
        public NavBarLinkModel(string url,string text, string icon)
        {
            Url = url;
            Text = text;
            FontAwesomeIconId = icon;
        }

        public string FontAwesomeIconId { get;  }

        public static implicit operator NavBarLinkModel((string url, string text, string icon) x)
        {
            return new NavBarLinkModel(x.url, x.text, x.icon);
        }
    }
    public class NavModel
    {
        public string Title { get;  }

        public NavModel(string title, params NavBarLinkModel[] navBarLinks)
        {
            Title = title;
            this.NavBarLinks = navBarLinks;
        }

        public  NavBarLinkModel[] NavBarLinks { get;  }


        public NavGroupModel[] NavGroups { get; set; }
    }
}