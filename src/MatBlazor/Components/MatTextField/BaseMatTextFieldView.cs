using System.Threading.Tasks;
using MatBlazor.Components.MatTextFieldView;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace MatBlazor
{
    /// <summary>
    /// Text fields allow users to input, edit, and select text.
    /// </summary>
    public class BaseMatTextFieldView : BaseMatDomComponent
    {
        [Parameter]
        public IMatTextFieldViewModel Model { get; set; }


        protected ClassMapper LabelClassMapper = new ClassMapper();
        protected ClassMapper InputClassMapper = new ClassMapper();
        protected ClassMapper HelperTextClassMapper = new ClassMapper();

        public BaseMatTextFieldView()
        {
            ClassMapper
                .Add("mdc-text-field")
                .Add("_mdc-text-field--upgraded")
                .If("mdc-text-field--with-leading-icon", () => Model.Icon != null && !Model.IconTrailing)
                .If("mdc-text-field--with-trailing-icon", () => Model.Icon != null && Model.IconTrailing)
                .If("mdc-text-field--box", () => !Model.FullWidth && Model.Box)
                .If("mdc-text-field--dense", () => Model.Dense)
                .If("mdc-text-field--outlined", () => !Model.FullWidth && Model.Outlined)
                .If("mdc-text-field--disabled", () => Model.Disabled)
                .If("mdc-text-field--fullwidth", () => Model.FullWidth)
                .If("mdc-text-field--fullwidth-with-leading-icon",
                    () => Model.FullWidth && Model.Icon != null && !Model.IconTrailing)
                .If("mdc-text-field--fullwidth-with-trailing-icon",
                    () => Model.FullWidth && Model.Icon != null && Model.IconTrailing)
                .If("mdc-text-field--textarea", () => Model.TextArea);

            LabelClassMapper
                .Add("mdc-floating-label")
                .If("mat-floating-label--float-above-outlined",
                    () => Model.Outlined && !string.IsNullOrEmpty(Model.CurrentValueAsString))
                .If("mdc-floating-label--float-above", () => !string.IsNullOrEmpty(Model.CurrentValueAsString));

            InputClassMapper
                .Get(() => Model.InputClass)
                .Add("mdc-text-field__input")
                .If("_mdc-text-field--upgraded", () => !string.IsNullOrEmpty(Model.CurrentValueAsString))
                .If("mat-hide-clearbutton", () => Model.HideClearButton);

            HelperTextClassMapper
                .Add("mdc-text-field-helper-text")
                .If("mdc-text-field-helper-text--persistent", () => Model.HelperTextPersistent)
                .If("mdc-text-field-helper-text--validation-msg", () => Model.HelperTextValidation);
        }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await JsInvokeAsync<object>("matBlazor.matTextField.init", Ref);
        }
    }
}