using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatOptionTypeKey<T, TK> : BaseMatDomComponent
    {
        internal string StringValue()
        {
            return this.Parent?.switchTK.FormatValueAsString(Value, null);
        }

        public BaseMatOptionTypeKey()
        {
            ClassMapper
                .Add("mat-option")
                .If("mdc-list-item", () => Parent?.Enhanced ?? false)
                .If("mdc-list-item--disabled", () => Disabled && (Parent?.Enhanced ?? false));
        }

        [CascadingParameter()]
        public BaseMatSelectTypeKey<T, TK> Parent { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public TK Value { get; set; }
    }
}