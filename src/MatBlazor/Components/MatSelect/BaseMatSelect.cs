using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace MatBlazor
{
    /// <summary>
    /// Selects allow users to select from a single-option menu. It functions as a wrapper around the browser's native select element.
    /// </summary>
    public class BaseMatSelect : BaseMatDomComponent
    {
        private string _value;

        public BaseMatSelect()
        {
            ClassMapper
                .Add("mat-select")
                .Add("mdc-select")
                .If("mdc-select--outlined", () => Outlined)
                .If("mdc-select--disabled", () => Disabled)
                .If("mdc-select--with-leading-icon", () => Icon != null);

            HelperTextClassMapper
                .Add("mdc-text-field-helper-text")
                .If("mdc-text-field-helper-text--persistent", () => HelperTextPersistent)
                .If("mdc-text-field-helper-text--validation-msg", () => HelperTextValidation);
        }

        protected ClassMapper HelperTextClassMapper { get; } = new ClassMapper();

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public bool Enhanced { get; set; } = false;

        [Parameter]
        public bool Outlined { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public string Icon { get; set; }

        [Parameter]
        public string HelperText { get; set; }

        [Parameter]
        public bool HelperTextPersistent { get; set; }

        [Parameter]
        public bool HelperTextValidation { get; set; }

        [Parameter]
        public bool HideDropDownIcon { get; set; }

        [Parameter]
        public string Value
        {
            get => _value;
            set
            {
                if (value != _value)
                {
                    _value = value;
                    ValueChanged.InvokeAsync(value);
                }
            }
        }

        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }

        [Parameter]
        public EventCallback<UIMouseEventArgs> IconOnClick { get; set; }

        [Parameter]
        public EventCallback<UIFocusEventArgs> OnFocus { get; set; }

        [Parameter]
        public EventCallback<UIFocusEventArgs> OnFocusOut { get; set; }

        [Parameter]
        public EventCallback<UIKeyboardEventArgs> OnKeyPress { get; set; }

        [Parameter]
        public EventCallback<UIKeyboardEventArgs> OnKeyDown { get; set; }

        [Parameter]
        public EventCallback<UIKeyboardEventArgs> OnKeyUp { get; set; }

        [Parameter]
        public EventCallback<UIChangeEventArgs> OnInput { get; set; }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await Js.InvokeAsync<object>("matBlazor.matSelect.init", Ref);
        }
    }
}