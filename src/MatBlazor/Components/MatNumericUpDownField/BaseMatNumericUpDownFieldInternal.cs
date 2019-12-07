using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

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

        protected async Task Increase()
        {
            CurrentValue = SwitchT.Increase(CurrentValue, Step, Maximum);
        }

        protected async Task Decrease()
        {
            CurrentValue = SwitchT.Decrease(CurrentValue, Step, Minimum);
        }

        protected override TValue CurrentValue
        {
            get => base.CurrentValue;
            set => base.CurrentValue = SwitchT.Round(value, DecimalPlaces);
        }

        [Parameter]
        public bool AllowInput { get; set; } = true;


        [Parameter]
        public TValue Maximum { get; set; }

        [Parameter]
        public TValue Minimum { get; set; }

        [Parameter]
        public int DecimalPlaces { get; set; } = 0;

        [Parameter]
        public TValue Step { get; set; }

        public string PlusIcon { get; set; } = MatIconNames.Keyboard_arrow_down;

        public string MinusIcon { get; set; } = MatIconNames.Keyboard_arrow_up;

        protected override bool InputTextReadOnly()
        {
            return base.InputTextReadOnly() || !AllowInput;
        }

        private EventCallback<KeyboardEventArgs> OnKeyDownEvent2;
        public BaseMatNumericUpDownFieldInternal()
        {
            OnKeyDownEvent2 = EventCallback.Factory.Create<KeyboardEventArgs>(this, async (e) =>
                {
                    await OnKeyDown.InvokeAsync(e);
                    if (e.Key == "ArrowUp")
                    {
                        await Increase();
                    }
                    else if (e.Key == "ArrowDown")
                    {
                        await Decrease();
                    }
                });
            Step = SwitchT.Step;
            Maximum = SwitchT.Maximum;
            Minimum = SwitchT.Minimum;

            ClassMapper.Add("mat-numeric-up-down-field");
            ClassMapper.Add("mat-text-field-with-actions-container");
        }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
        }
    }
}