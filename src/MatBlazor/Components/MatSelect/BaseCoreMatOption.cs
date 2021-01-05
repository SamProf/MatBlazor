using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseCoreMatOption<TValue> : BaseMatDomComponent
    {
        internal string StringValue()
        {
            return this.Parent.SwitchTypeKey.FormatValueAsString(Value, null);
        }


        protected string RenderAttributeAriaDisabled()
        {
            return Disabled ? "disabled" : null;
        }

        public BaseCoreMatOption()
        {
            ClassMapper
                .Add("mat-option")
                .Add("mdc-list-item")
                .If("mdc-list-item--disabled", () => Disabled);
        }

        [CascadingParameter()]
        public IBaseCoreMatSelect<TValue> Parent { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public TValue Value { get; set; }
    }
}