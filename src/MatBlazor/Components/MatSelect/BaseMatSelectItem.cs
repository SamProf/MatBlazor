using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatSelectItem<TValue> : CoreMatSelect<TValue, int>
    {
        [Parameter]
        public IReadOnlyList<TValue> Items { get; set; }

        [Parameter]
        public RenderFragment<TValue> ItemTemplate { get; set; }

        protected override int GetKeyFromValue(TValue value)
        {
            return Items.IndexOf(value);
        }

        protected override TValue GetValueFromKey(int key)
        {
            return Items[key];
        }
    }
}