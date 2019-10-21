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
        public bool EnableTime { get; set; }

        [Parameter]
        public bool EnableSeconds { get; set; }

        [Parameter]
        public bool DisableCalendar { get; set; }

        [Parameter]
        public bool Enable24hours { get; set; }

        [Parameter]
        public bool EnableWeekNumbers { get; set; }

        [Parameter]
        public bool AllowInput { get; set; }

        [Parameter]
        public bool DisableMobile { get; set; }

        [Parameter]
        public bool Inline { get; set; }

        [Parameter]
        public string Position { get; set; } = "auto";

        [Parameter]
        public string Mode { get; set; } = "single";

        private DotNetObjectReference<MatDatePickerTypeJsHelper> dotNetObjectRef;
        private MatDatePickerTypeJsHelper dotNetObject;
        protected ElementReference flatpickrInputRef;


        private MatTypeConverter<DateTime?, T> typeConverterChange;
        public BaseMatDatePickerType()
        {

            ClassMapper.Add("mat-date-picker");
            typeConverterChange = MatTypeConverterManager.Get<DateTime?, T>();

            dotNetObject = new MatDatePickerTypeJsHelper()
            {
                OnChangeAction = (value) =>
                {
                    var v = value.FirstOrDefault();
                    CurrentValue = typeConverterChange(v, Format);
                    InvokeStateHasChanged();
                },
            };

            CallAfterRender(async () =>
            {
                dotNetObjectRef ??= CreateDotNetObjectRef(dotNetObject);

                await JsInvokeAsync<object>("matBlazor.matDatePicker.init", Ref, flatpickrInputRef, dotNetObjectRef,
                    Value, new FlatpickrOptions
                    {
                        EnableTime = this.EnableTime,
                        NoCalendar = this.DisableCalendar,
                        Enable24hours = this.Enable24hours,
                        EnableSeconds = this.EnableSeconds,
                        EnableWeekNumbers = this.EnableWeekNumbers,

                        AllowInput = this.AllowInput,
//                    AltFormat = this.AltFormat,
//                    AltInputClass = this.AltInputClass,
//                        DateFormat = this.DateFormat,
                        DisableMobile = this.DisableMobile,
                        Inline = this.Inline,
                        Mode = this.Mode,
                        Position = this.Position
                    });
            });
        }

        public override void Dispose()
        {
            base.Dispose();
            DisposeDotNetObjectRef(dotNetObjectRef);
        }


        

        protected async Task OnClickIconHandler()
        {
            this.InvokeStateHasChanged();

            CallAfterRender(async () => { await JsInvokeAsync<object>("matBlazor.matDatePicker.open", Ref, Value); });
        }

        public async override Task SetParametersAsync(ParameterView parameters)
        {
            var valueIsChanged = this.ParameterIsChanged(parameters, nameof(Value), Value);
            await base.SetParametersAsync(parameters);
            if (valueIsChanged)
            {
                CallAfterRender(async () =>
                {
                    await JsInvokeAsync<object>("matBlazor.matDatePicker.setDate", Ref, Value);
                });
            }
        }

        /// <summary>
        /// The options from https://flatpickr.js.org/options/
        /// </summary>
        public class FlatpickrOptions
        {
            public bool EnableTime { get; set; } = false;

            public bool EnableSeconds { get; set; } = false;

            public bool NoCalendar { get; set; } = false;

            public bool Enable24hours { get; set; } = false;

            public bool EnableWeekNumbers { get; set; } = false;

            public string DateFormat { get; set; } = "Y-m-d";

            public bool AllowInput { get; set; } = false;

            public bool DisableMobile { get; set; } = false;

            public bool Inline { get; set; } = false;

            public string Position { get; set; } = "auto";

            public string Mode { get; set; } = "single";

            public string AltInputClass { get; set; } = "";

            public string AltFormat { get; set; } = "F j, Y";
        }
    }
    
}