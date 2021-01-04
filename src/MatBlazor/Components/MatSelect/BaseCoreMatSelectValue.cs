using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace MatBlazor
{
    public abstract class BaseCoreMatSelectValue<TValue, TItem> : CoreMatSelect<TValue, int>
    {
        [Parameter]
        public IReadOnlyList<TItem> Items { get; set; }

        [Parameter]
        public RenderFragment<TItem> ItemTemplate { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        protected override RenderFragment GetChildContent()
        {
            return ChildContent;
        }

        // protected override int GetKeyFromValue(TValue value)
        // {
        //     return Items.IndexOf(value);
        // }
        //
        // protected override TValue GetValueFromKey(int key)
        // {
        //     return Items[key];
        // }
    }
}