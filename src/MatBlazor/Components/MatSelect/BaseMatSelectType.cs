using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatSelectType<T> : MatSelectTypeKey<T, int>
    {
        
        [Parameter]
        public IEnumerable<T> Items { get; set; }
        
        [Parameter]
        public RenderFragment<T> ItemTemplate { get; set; }

        protected override int GetKeyFromValue(T value)
        {
            return Items.IndexOf(value);
        }

        protected override T GetValueFromKey(int key)
        {
            return Items.ElementAt(key);
        }
    }
}