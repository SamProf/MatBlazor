using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;

namespace MatBlazor
{
    /// <summary>
    /// Selects allow users to select from a single-option menu. It functions as a wrapper around the browser's native select element.
    /// </summary>
    public class BaseCoreMatSelect<TValue, TKey> : BaseMatInputComponent<TValue>, IBaseCoreMatSelect<TKey>
    {
        private MatSelectJsHelper jsHelper;
        private DotNetObjectReference<MatSelectJsHelper> jsHelperReference;

        internal MatBlazorSwitchT<TKey> switchTK = MatBlazorSwitchT<TKey>.Get();
        
        public BaseCoreMatSelect()
        {
            jsHelper = new MatSelectJsHelper();
            jsHelper.SetValueEvent += JsHelper_SetValueEvent;

            ClassMapper
                .Add("mat-select")
                .Add("mdc-select")
                .If("mdc-select--filled", () => !Outlined)
                .If("mdc-select--outlined", () => Outlined)
                .If("mdc-select--disabled", () => Disabled)
                .If("mdc-select--with-leading-icon", () => Icon != null);

            StyleMapper
                .If("width: 100%", () => FullWidth);

            HelperTextClassMapper
                .Add("mdc-text-field-helper-text")
                .If("mdc-text-field-helper-text--persistent", () => HelperTextPersistent)
                .If("mdc-text-field-helper-text--validation-msg", () => HelperTextValidation);


            CallAfterRender(async () =>
            {
                jsHelperReference ??= DotNetObjectReference.Create(jsHelper);
                await JsInvokeAsync<object>("matBlazor.matSelect.init", Ref, jsHelperReference,
                    switchTK.FormatValueAsString(GetKeyFromValue(CurrentValue), null), new MatSelectInitOptions()
                    {
                        FullWidth = FullWidth,
                    });
            });
        }

        private void JsHelper_SetValueEvent(object sender, string value)
        {
            SetValueEvent(value);
        }


        protected void OnChangeEventHandler(ChangeEventArgs e)
        {
            SetValueEvent((string) e.Value);
        }


        protected void SetValueEvent(string value)
        {
            CurrentValue = GetValueFromKey(switchTK.ParseFromString(value, null));
        }

        protected override void OnValueChanged(bool changed)
        {
            base.OnValueChanged(changed);
            if (changed && Rendered)
            {
                CallAfterRender(async () =>
                {
                    await JsInvokeAsync<object>("matBlazor.matSelect.setValue", Ref, switchTK.FormatValueAsString(GetKeyFromValue(CurrentValue), null));
                });
            }
        }

        protected virtual TValue GetValueFromKey(TKey key)
        {
            throw new NotImplementedException();
        }

        protected virtual TKey GetKeyFromValue(TValue value)
        {
            throw new NotImplementedException();
        }

        protected ClassMapper HelperTextClassMapper { get; } = new ClassMapper();

//        [Parameter]
//        public RenderFragment ChildContent { get; set; }


        protected virtual RenderFragment GetChildContent()
        {
            throw new NotImplementedException();
        }

        [Parameter]
        public bool Enhanced
        {
            get => true;
            set
            {
                //_enhanced = value; Important - nothing, because MDC now support only Enhanced select's
            }
        }


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
        public bool FullWidth { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> IconOnClick { get; set; }

      

        public MatBlazorSwitchT<TKey> SwitchTypeKey => switchTK;
    }
}