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
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public string Value { get; set; }
    }
}