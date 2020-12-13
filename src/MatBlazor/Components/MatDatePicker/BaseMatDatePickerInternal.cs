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
            InvokeStateHasChanged();

            if (!DisableCalendar && !Disabled && !ReadOnly)
            {
                CallAfterRender(async () =>
                {
                    dotNetObjectRef ??= CreateDotNetObjectRef(dotNetObject);

                    await JsInvokeAsync<object>("matBlazor.matDatePicker.open", Ref, flatpickrInputRef, dotNetObjectRef,
                        new FlatpickrOptions
                        {
                            EnableTime = EnableTime,
                            Enable24hours = Enable24hours,
                            EnableSeconds = EnableSeconds,
                            EnableWeekNumbers = EnableWeekNumbers,
                            DisableMobile = DisableMobile,
                            Mode = Mode,
                            Position = Position.ToString().ToLower(),
                            DefaultDate = SwitchT.ToDateTimeNull(Value),
                            Minimum = EnableTime ? Minimum : Minimum?.Date,
                            Maximum = EnableTime ? Maximum : Maximum?.Date,
                            Value = SwitchT.ToDateTimeNull(CurrentValue),
                            Locale = Locale
                        }) ;
                });
            }
        }

        public async override Task SetParametersAsync(ParameterView parameters)
        {
            await base.SetParametersAsync(parameters);
        }
    }
}