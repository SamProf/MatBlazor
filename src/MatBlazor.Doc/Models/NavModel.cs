namespace MatBlazor.Demo.Models
{
    public class NavModel
    {
        public string Title { get;  }

        public NavModel(string title)
        {
            Title = title;
        }

        public NavGroupModel[] NavGroups { get; set; }
    }
}