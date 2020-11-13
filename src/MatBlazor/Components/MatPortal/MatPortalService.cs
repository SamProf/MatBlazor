using System;
using System.Collections.Generic;

namespace MatBlazor
{
    public class MatPortalService : IMatPortalService
    {
        private List<MatPortalReference> items = new List<MatPortalReference>();
        private object lockObj = new object();
        private int itemsCounter = 0;

        public event EventHandler StateChanged;


        public void Add(Type componentType, Dictionary<string, object> attributes)
        {
            var item = new MatPortalReference()
            {
                Id = ++itemsCounter,
                Attributes = attributes,
                ComponentType = componentType,
            };
            lock (lockObj)
            {
                items.Add(item);
            }

            this.StateHasChanged();
        }


        public void Remove(MatPortalReference item)
        {
            lock (lockObj)
            {
                items.Remove(item);
            }

            this.StateHasChanged();
        }


        private void StateHasChanged()
        {
            StateChanged?.Invoke(this, EventArgs.Empty);
        }

        public IEnumerable<MatPortalReference> GetItems()
        {
            lock (lockObj)
            {
                return items.ToArray();
            }
        }
    }


    public class MatPortalReference
    {
        public int Id { get; set; }

        public Type ComponentType { get; set; }

        public Dictionary<string, object> Attributes { get; set; }
    }


    public interface IMatPortalService
    {
        void Add(Type componentType, Dictionary<string, object> attributes);
        void Remove(MatPortalReference item);
        IEnumerable<MatPortalReference> GetItems();
        
        event EventHandler StateChanged;
    }
}