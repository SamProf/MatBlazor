namespace MatBlazor.Demo.Models
{
    public class NavGroup
    {
        public string Name;
        public float Order;

        public NavGroup(string name, float order = float.MaxValue)
        {
            Name = name;
            Order = order;
        }
    }
}