using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace MatBlazor
{
    /// <summary>
    /// Selects allow users to select from a single-option menu. It functions as a wrapper around the browser's native select element.
    /// </summary>
    public class BaseMatSelectTypeKey<T, TK> : BaseMatInputComponent<T>
    {
        private MatSelectJsHelper jsHelper;
        private DotNetObjectReference<MatSelectJsHelper> jsHelperReference;

        internal MatBlazorSwitchT<TK> switchTK = MatBlazorSwitchT<TK>.Get();

        public BaseMatSelectTypeKey()
        {
            jsHelper = new MatSelectJsHelper();
            jsHelper.SetValueEvent += JsHelper_SetValueEvent;

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


            CallAfterRender(async () =>
            {
                jsHelperReference??= DotNetObjectReference.Create(jsHelper);
                await JsInvokeAsync<object>("matBlazor.matSelect.init", Ref, jsHelperReference);
            });
        }

        private void JsHelper_SetValueEvent(object sender, string value)
        {
            SetValueEvent(value);
        }
        
        
        protected void OnChangeEventHandler(ChangeEventArgs  e)
        {
            SetValueEvent((string)e.Value);
        }
        
        
        protected void SetValueEvent(string value)
        {
            CurrentValue = GetValueFromKey(switchTK.ParseFromString(value, null));
        }

        protected virtual T GetValueFromKey(TK key)
        {
            throw new NotImplementedException();
        }

        protected virtual TK GetKeyFromValue(T value)
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

//        [Parameter]
//        public string Value
//        {
//            get => _value;
//            set
//            {
//                if (value != _value)
//                {
//                    _value = value;
//                    CallAfterRender(async () => await JsInvokeAsync<object>("matBlazor.matSelect.setValue", Ref, value));
//                    ValueChanged.InvokeAsync(value);
//                }
//            }
//        }
//
//        [Parameter]
//        public EventCallback<string> ValueChanged { get; set; }


        public override async Task SetParametersAsync(ParameterView parameters)
        {
            await base.SetParametersAsync(parameters);
            object valueKey;
            if (parameters.TryGetValue(nameof(Value), out valueKey))
            {
                CallAfterRender(async () =>
                {
                    await JsInvokeAsync<object>("matBlazor.matSelect.setValue", Ref, GetKeyFromValue(CurrentValue));
                });
            }
        }

        [Parameter]
        public EventCallback<MouseEventArgs> IconOnClick { get; set; }

        [Parameter]
        public EventCallback<FocusEventArgs> OnFocus { get; set; }

        [Parameter]
        public EventCallback<FocusEventArgs> OnFocusOut { get; set; }

        [Parameter]
        public EventCallback<KeyboardEventArgs> OnKeyPress { get; set; }

        [Parameter]
        public EventCallback<KeyboardEventArgs> OnKeyDown { get; set; }

        [Parameter]
        public EventCallback<KeyboardEventArgs> OnKeyUp { get; set; }

        [Parameter]
        public EventCallback<ChangeEventArgs> OnInput { get; set; }
    }
}