using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatSelect<TValue> : CoreMatSelect<TValue, TValue>
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        protected override RenderFragment GetChildContent()
        {
            return ChildContent;
        }

        protected override TValue GetKeyFromValue(TValue value)
        {
            return value;
        }

        protected override TValue GetValueFromKey(TValue key)
        {
            return key;
        }
    }
}