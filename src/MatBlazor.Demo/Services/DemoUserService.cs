namespace MatBlazor.Demo.Services
{
    public class DemoUserService
    {
        public int activeTabIndex = 0;

        public int ActiveTabIndex
        {
            get { return activeTabIndex; }
            set { activeTabIndex = value; }
        }
    }
}