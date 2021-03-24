using System;
using System.Reflection;

namespace MatBlazor.Demo.Models
{
    public class NavItem
    {
        public NavGroup Group;
        public string Name;
        public string Url;
        public int Order;
    }

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

    public class NavModel
    {
        public NavGroupModel[] NavGroups { get; set; }
    }
    public class NavGroupModel
    {
        public NavGroup Group;
        public NavItem[] Items;
    }

    public class AppModel
    {
        private readonly object syncObj = new object();
        private int userCount = 0;

        public Assembly AppAssembly { get; }
        public NavModel NavModel { get; }

        public event EventHandler<int> UserCountChanged;

        public int GetUserCount()
        {
            lock (syncObj)
            {
                return userCount;
            }
        }

        public AppModel(Assembly appAssembly,NavModel navModel)
        {
            AppAssembly = appAssembly;
            NavModel = navModel;
        }


        public void AddUserCount(int value)
        {
            lock (syncObj)
            {
                userCount += value;
                OnUserCountChanged(userCount);
            }
        }

        protected virtual void OnUserCountChanged(int e)
        {
            UserCountChanged?.Invoke(this, e);
        }
    }
}