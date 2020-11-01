using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MatBlazor
{
    /// <summary>
    /// Material Design Datetime picker for Blazor
    /// </summary>
    /// <typeparam name="TValue">DateTime, DateTime?</typeparam>
    public abstract class BaseMatDatePickerInternal<TValue> : MatInputTextComponent<TValue>
    {
        [Parameter]
        public bool EnableTime { get; set; } = false;

        [Parameter]
        public bool EnableSeconds { get; set; } = false;


        [Parameter]
        public DateTime? Maximum { get; set; }

        [Parameter]
        public DateTime? Minimum { get; set; }

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

        [Parameter]
        public MatDatePickerPosition Position { get; set; } = MatDatePickerPosition.Auto;

//        [Parameter]
        public string Mode { get; set; } = "single";

        [Parameter]
        public string Locale { get; set; } = "en";

        private DotNetObjectReference<MatDatePickerJsHelper> dotNetObjectRef;
        private readonly MatDatePickerJsHelper dotNetObject;
        protected ElementReference flatpickrInputRef;

        protected override bool InputTextReadOnly()
        {
            return base.InputTextReadOnly() || !AllowInput;
        }

        public BaseMatDatePickerInternal()
        {
            ClassMapper.Add("mat-date-picker");
            ClassMapper.Add("mat-text-field-with-actions-container");

            dotNetObject = new MatDatePickerJsHelper()
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

        protected override string FormatValueAsString(TValue value)
        {
            if (Format == null && EnableTime == false)
            {
                return SwitchT.FormatValueAsString(value, System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            }
            return SwitchT.FormatValueAsString(value, Format);
        }

        protected override bool ValidateCurrentValue(TValue value)
        {
            if (!base.ValidateCurrentValue(value))
            {
                return false;
            }


            var dateValue = SwitchT.ToDateTimeNull(value);
            if (dateValue.HasValue)
            {
                if (Minimum.HasValue && (EnableTime == true ? (Minimum.Value > dateValue.Value) : (Minimum.Value.Date > dateValue.Value.Date)))
                {
                    return false;
                }

                if (Maximum.HasValue && (EnableTime == true ? (Maximum.Value < dateValue.Value) : (Maximum.Value.Date < dateValue.Value.Date)))
                {
                    return false;
                }
            }

            return true;
        }

        protected void OnClickIconHandler()
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
                            Position = Position.ToString().ToLower(),
                            DefaultDate = SwitchT.ToDateTimeNull(Value),
                            Minimum = this.EnableTime ? Minimum : Minimum?.Date,
                            Maximum = this.EnableTime ? Maximum : Maximum?.Date,
                            Value = SwitchT.ToDateTimeNull(CurrentValue),
                            Locale = this.Locale
                        }) ;
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