namespace MatBlazor.Demo.Models
{
    public class NavGroup
    {
        public string Name;
        public int Order;

        public NavGroup(string name, int order = int.MaxValue)
        {
            Name = name;
            Order = order;
        }
    }
}