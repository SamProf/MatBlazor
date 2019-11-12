using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatRadioGroupType<T> : BaseMatInputComponent<T>
    {
        [Parameter]
        public RenderFragment<T> ItemTemplate { get; set; }

        [Parameter]
        public IEnumerable<T> Items { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public void SetCurrentValue(T value)
        {
            this.CurrentValue = value;
        }
    }
}