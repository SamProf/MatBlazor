using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MatBlazor
{
    /// <summary>
    /// Datetime picker based on flatpickr.js
    /// </summary>
    public class BaseMatDatePicker : BaseMatDomComponent
    {
        protected BaseMatTextField TextFieldRef;
        private DateTime? _value;

        [Parameter]
        public DateTime? Value
        {
            get => _value;
            set { _value = value; }
        }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public bool Dense { get; set; }

        [Parameter]
        public bool Outlined { get; set; }

        //        [Parameter]
        public bool FullWidth { get; set; }

        [Parameter]
        public bool Required { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        //        [Parameter]
        public bool ReadOnly { get; set; }

        //        [Parameter]
        public string PlaceHolder { get; set; }

        //        [Parameter]
        public string HelperText { get; set; }

        [Parameter]
        public bool EnableTime { get; set; }

        [Parameter]
        public bool EnableSeconds { get; set; }

        [Parameter]
        public bool NoCalendar { get; set; }

        [Parameter]
        public bool Enable24hours { get; set; }

        [Parameter]
        public bool EnableWeekNumbers { get; set; }

        [Parameter]
        public EventCallback<DateTime?> ValueChanged { get; set; }

        public virtual ElementRef Ref
        {
            get => TextFieldRef.InputRef;
        }


        private DotNetObjectRef<BaseMatDatePicker> dotNetObjectRef;

        public BaseMatDatePicker()
        {
            CallAfterRender(async () =>
            {
                dotNetObjectRef = dotNetObjectRef ?? CreateDotNetObjectRef(this);

                Js.InvokeAsync<object>("matBlazor.matDatePicker.init", Ref, dotNetObjectRef, Value, new flatpickrOptions
                {
                    EnableTime = this.EnableTime,
                    NoCalendar = this.NoCalendar,
                    Enable24hours = this.Enable24hours,
                    EnableSeconds = this.EnableSeconds,
                    EnableWeekNumbers = this.EnableWeekNumbers
                });
            });
        }

        public override void Dispose()
        {
            base.Dispose();
            DisposeDotNetObjectRef(dotNetObjectRef);
        }


        [JSInvokable]
        public async Task MatDatePickerOnChangeHandler(DateTime?[] value)
        {
            var v = value.First();
            Value = v;
            await ValueChanged.InvokeAsync(Value);
            this.StateHasChanged();
        }


        public async override Task SetParametersAsync(ParameterCollection parameters)
        {
            var valueIsChanged = this.ParameterIsChanged(parameters, nameof(Value), Value);
            await base.SetParametersAsync(parameters);
            if (valueIsChanged)
            {
                CallAfterRender(async () => { Js.InvokeAsync<object>("matBlazor.matDatePicker.setDate", Ref, Value); });
            }
        }

        public class flatpickrOptions
        {
            public bool EnableTime { get; set; } = false;

            public bool EnableSeconds { get; set; } = false;

            public bool NoCalendar { get; set; } = false;

            public bool Enable24hours { get; set; } = false;

            public bool EnableWeekNumbers { get; set; } = false;

            public string DateFormat { get; set; } = "Y-m-d H:i";
        }
    }
}