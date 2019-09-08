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
    public class BaseMatDatePicker : BaseMatInputComponent<DateTime?>
    {
        protected BaseMatTextFieldView TextFieldRef;

        protected ElementReference flatpickrInput;

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
        public bool AllowInput { get; set; }

        [Parameter]
        public bool DisableMobile { get; set; }

        [Parameter]
        public bool Inline { get; set; }

        [Parameter]
        public string Position { get; set; } = "auto";

        [Parameter]
        public string Mode { get; set; } = "single";

        [Parameter]
        public string DateFormat { get; set; } = "Y-m-d";

        [Parameter]
        public string AltInputClass { get; set; } = "";

        [Parameter]
        public string AltFormat { get; set; } = "F j, Y";


        public virtual ElementReference Ref
        {
            get => TextFieldRef.InputRef;
        }


        private DotNetObjectReference<BaseMatDatePicker> dotNetObjectRef;


        protected async Task OnClickIconHandler()
        {
            this.InvokeStateHasChanged();

            CallAfterRender(async () =>
            {
                await JsInvokeAsync<object>("matBlazor.matDatePicker.open", TextViewForwardRef.Current);
            });
        }


        public override void AfterValueChanged()
        {
            base.AfterValueChanged();
            CallAfterRender(async () =>
            {
                await JsInvokeAsync<object>("matBlazor.matDatePicker.setDate", TextViewForwardRef.Current, Value);
                InvokeStateHasChanged();
            });
        }

        protected async Task InputValueChangedHandler(string v)
        {
            this.InvokeStateHasChanged();

            ValueAsString = v;
        }

        public BaseMatDatePicker()
        {
            CallAfterRender(async () =>
            {
                dotNetObjectRef = dotNetObjectRef ?? CreateDotNetObjectRef(this);

                await JsInvokeAsync<object>("matBlazor.matDatePicker.init2", TextViewForwardRef.Current, flatpickrInput,
                    dotNetObjectRef, Value, new FlatpickrOptions
                    {
                        EnableTime = this.EnableTime,
                        NoCalendar = this.NoCalendar,
                        Enable24hours = this.Enable24hours,
                        EnableSeconds = this.EnableSeconds,
                        EnableWeekNumbers = this.EnableWeekNumbers,

                        AllowInput = this.AllowInput,
                        AltFormat = this.AltFormat,
                        AltInputClass = this.AltInputClass,
                        DateFormat = this.DateFormat,
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


        [JSInvokable]
        public async Task MatDatePickerOnChangeHandler(DateTime?[] value)
        {
            var v = value.First();
//            Console.WriteLine(v.Value);
//            Console.WriteLine(DateTime.Parse("2019-08-19T15:09:04.143Z").ToLocalTime());
            Value = v;
//            await ValueChanged.InvokeAsync(Value);
            this.StateHasChanged();
        }


        public override string ValueAsString
        {
            get { return Value?.ToString(); }
            set { Value = DateTime.Parse(value); }
        }

        public async override Task SetParametersAsync(ParameterView parameters)
        {
//            var valueIsChanged = this.ParameterIsChanged(parameters, nameof(Value), Value);
            await base.SetParametersAsync(parameters);
//            if (valueIsChanged)
//            {
//                CallAfterRender(async () =>
//                {
//                    await JsInvokeAsync<object>("matBlazor.matDatePicker.setDate", TextViewForwardRef., Value);
//                    InvokeStateHasChanged();
//                });
//            }
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