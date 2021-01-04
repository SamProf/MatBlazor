using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace MatBlazor
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TValue">any</typeparam>
    public class BaseMatRadioGroupInternal<TValue> : BaseMatInputComponent<TValue>
    {
        [Parameter]
        public RenderFragment<TValue> ItemTemplate { get; set; }

        [Parameter]
        public IEnumerable<TValue> Items { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public void SetCurrentValue(TValue value)
        {
            this.CurrentValue = value;
        }
    }
}