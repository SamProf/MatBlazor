using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatOption : BaseMatDomComponent
    {
        public BaseMatOption()
        {
            ClassMapper
                .Add("mdc-list-item")
                .If("mdc-list-item--disabled", ()=>Disabled);
        }

        [CascadingParameter()]
        public BaseMatSelect Parent { get; set; }

        [Parameter]
        protected RenderFragment ChildContent { get; set; }

        [Parameter]
        protected bool Disabled { get; set; }

        [Parameter]
        protected string Value { get; set; }
    }
}