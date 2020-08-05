using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatBlazor.Demo.Models
{
    public class AppModel
    {
        private readonly object syncObj = new object();
        private int userCount = 0;

        public event EventHandler<int> UserCountChanged;

        public int GetUserCount()
        {
            lock (syncObj)
            {
                return userCount;
            }
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