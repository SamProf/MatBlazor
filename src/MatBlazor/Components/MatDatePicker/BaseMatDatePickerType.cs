using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MatBlazor
{
    /// <summary>
    /// Datetime picker based on flatpickr.js
    /// </summary>
    public abstract class BaseMatDatePickerType<T> : MatInputTextComponent<T>
    {
        [Parameter]
        public bool EnableTime { get; set; } = false;

        [Parameter]
        public bool EnableSeconds { get; set; } = false;

        [Parameter]
        public bool DisableCalendar { get; set; }

        [Parameter]
        public bool Enable24hours { get; set; }

        [Parameter]
        public bool EnableWeekNumbers { get; set; }

        [Parameter]
        public bool AllowInput { get; set; } = true;

        [Parameter]
        public bool DisableMobile { get; set; }
       
//        [Parameter]
        public string Position { get; set; } = "auto";

//        [Parameter]
        public string Mode { get; set; } = "single";

        private DotNetObjectReference<MatDatePickerTypeJsHelper> dotNetObjectRef;
        private MatDatePickerTypeJsHelper dotNetObject;
        protected ElementReference flatpickrInputRef;

        protected override bool InputTextReadOnly()
        {
            return base.InputTextReadOnly() || !AllowInput;
        }

        public BaseMatDatePickerType()
        {

            ClassMapper.Add("mat-date-picker");
            ClassMapper.Add("mat-text-field-with-actions-container");

            dotNetObject = new MatDatePickerTypeJsHelper()
            {
                OnChangeAction = (value) =>
                {
                    var v = value.FirstOrDefault();
                    CurrentValue = SwitchT.FromDateTimeNull(v);
                    InvokeStateHasChanged();
                },
            };
        }

        public override void Dispose()
        {
            base.Dispose();
            DisposeDotNetObjectRef(dotNetObjectRef);
        }


        

        protected async Task OnClickIconHandler()
        {
            this.InvokeStateHasChanged();

            if (!DisableCalendar && !Disabled && !ReadOnly)
            {

                CallAfterRender(async () =>
                {
                    dotNetObjectRef ??= CreateDotNetObjectRef(dotNetObject);

                    await JsInvokeAsync<object>("matBlazor.matDatePicker.open", Ref, flatpickrInputRef, dotNetObjectRef,
                        new FlatpickrOptions
                        {
                            EnableTime = this.EnableTime,
                            Enable24hours = this.Enable24hours,
                            EnableSeconds = this.EnableSeconds,
                            EnableWeekNumbers = this.EnableWeekNumbers,
                            DisableMobile = this.DisableMobile,
                            Mode = this.Mode,
                            Position = Position,
                            DefaultDate = SwitchT.ToDateTimeNull(Value),
                        });
                });
            }
        }

        public async override Task SetParametersAsync(ParameterView parameters)
        {
//            var valueIsChanged = this.ParameterIsChanged(parameters, nameof(Value), Value);
            await base.SetParametersAsync(parameters);
//            if (valueIsChanged)
//            {
//                CallAfterRender(async () =>
//                {
//                    await JsInvokeAsync<object>("matBlazor.matDatePicker.setDate", Ref, Value);
//                });
//            }
        }

       
    }
}