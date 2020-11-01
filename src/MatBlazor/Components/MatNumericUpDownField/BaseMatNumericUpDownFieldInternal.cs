using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MatBlazor
{
    /// <summary>
    /// Material Design NumericUpDown for Blazor, text fields allow users to input, edit, and select text.
    /// </summary>
    /// <typeparam name="TValue">sbyte, byte, short, ushort, int, uint, long, ulong, char, float, double, decimal, decimal?</typeparam>
    public class BaseMatNumericUpDownFieldInternal<TValue> : MatInputTextComponent<TValue>
    {
        protected override EventCallback<KeyboardEventArgs> OnKeyDownEvent()
        {
            return OnKeyDownEvent2;
        }

        protected void Increase()
        {
            CurrentValue = SwitchT.Increase(CurrentValue, Step, Maximum);
        }

        protected void Decrease()
        {
            CurrentValue = SwitchT.Decrease(CurrentValue, Step, Minimum);
        }

        protected override TValue CurrentValue
        {
            get => base.CurrentValue;
            set => base.CurrentValue = SwitchT.Round(value, RoundingDecimalPlaces);
        }

        [Parameter]
        public bool AllowInput { get; set; } = true;


        [Parameter]
        public TValue Maximum { get; set; }

        [Parameter]
        public TValue Minimum { get; set; }

        [Parameter]
        public int DecimalPlaces { get; set; } = 0;

        private int RoundingDecimalPlaces => FieldType == MatNumericUpDownFieldType.Percent ? DecimalPlaces + 2 : DecimalPlaces;

        [Parameter]
        public TValue Step { get; set; }

        [Parameter]
        public MatNumericUpDownFieldType FieldType { get; set; }

        public string PlusIcon { get; set; } = MatIconNames.Keyboard_arrow_down;

        public string MinusIcon { get; set; } = MatIconNames.Keyboard_arrow_up;

        protected override bool InputTextReadOnly()
        {
            return base.InputTextReadOnly() || !AllowInput;
        }

        private readonly EventCallback<KeyboardEventArgs> OnKeyDownEvent2;
        public BaseMatNumericUpDownFieldInternal()
        {
            OnKeyDownEvent2 = EventCallback.Factory.Create<KeyboardEventArgs>(this, async (e) =>
                {
                    await OnKeyDown.InvokeAsync(e);
                    if (e.Key == "ArrowUp")
                    {
                        Increase();
                    }
                    else if (e.Key == "ArrowDown")
                    {
                        Decrease();
                    }
                });
            Maximum = SwitchT.GetMaximum();
            Minimum = SwitchT.GetMinimum();

            ClassMapper.Add("mat-numeric-up-down-field");
            ClassMapper.Add("mat-text-field-with-actions-container");
        }

        private readonly TValue ZeroValue = MatTypeConverter.ChangeType<TValue>(0);

        protected override void OnParametersSet()
        {
            if (FieldType == MatNumericUpDownFieldType.Currency)
            {
                if (Step == null || Step.Equals(ZeroValue))
                {
                    Step = SwitchT.GetStep();
                }
                Format = $"c{DecimalPlaces}";
            }
            else if (FieldType == MatNumericUpDownFieldType.Percent)
            {
                if (Step == null || Step.Equals(ZeroValue))
                {
                    Step = MatTypeConverter.ChangeType<TValue>(0.01m);
                }
                Format = $"p{DecimalPlaces}";
            }
            else if (Step == null || Step.Equals(ZeroValue))
            {
                Step = SwitchT.GetStep();
            }
        }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
        }

        protected override bool TryParseValueFromString(string value, out TValue result, out string validationErrorMessage)
        {
            if (string.IsNullOrEmpty(value) == false)
            {
                if (value[^1] == '%')
                {
                    value = value[0..^1];
                }
            }
            var success = base.TryParseValueFromString(value, out result, out validationErrorMessage);
            
            if (success == true && FieldType == MatNumericUpDownFieldType.Percent)
            {
                // The standard percent formatter assumes 1.0 is 100%, so we divide the input by 100 to make the input match the output
                if (result != null)
                {
                    if (result is decimal decimalResult)
                    {
                        result = MatTypeConverter.ChangeType<TValue>(decimalResult * 0.01m);
                    }
                    else if (result is float floatResult)
                    {
                        result = MatTypeConverter.ChangeType<TValue>(floatResult * 0.01f);
                    }
                    else if (result is double doubleResult)
                    {
                        result = MatTypeConverter.ChangeType<TValue>(doubleResult * 0.01d);
                    }
                }
            }
            if (result != null) // Snap to Min/Max
            {
                var comparer = Comparer<TValue>.Default;
                if (Maximum != null && comparer.Compare(result, Maximum) > 0) result = Maximum;
                if (Minimum != null && comparer.Compare(result, Minimum) < 0) result = Minimum;
            }

            return success;
        }
    }
}