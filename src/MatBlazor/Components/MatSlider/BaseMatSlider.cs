using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// Material Design Slider for Blazor. Sliders let users select from a range of values by moving the slider thumb.
    /// </summary>
    /// <typeparam name="TValue">sbyte, byte, short, ushort, int, uint, long, ulong, char, float, double, decimal, decimal?</typeparam>
    public class BaseMatSlider<TValue> : BaseMatInputComponent<TValue>
    {
        protected MatDotNetObjectReference<MatSliderJsHelper> jsHelper;

        public BaseMatSlider()
        {
            jsHelper = new MatDotNetObjectReference<MatSliderJsHelper>(new MatSliderJsHelper());
            jsHelper.Value.OnChangeEvent += Value_OnChangeEvent;
            ValueMin = SwitchT.GetMinimum();
            ValueMax = SwitchT.GetMaximum();
            Step = SwitchT.GetStep();

            ClassMapper
                .Add("mat-slider")
                .Add("mdc-slider")
                .If("mdc-slider--discrete", () => Discrete)
                .If("mdc-slider--display-markers", () => Discrete && Markers);
            CallAfterRender(async () =>
            {
                await JsInvokeAsync<object>("matBlazor.matSlider.init", Ref, jsHelper.Reference, Immediate);
            });
        }

        private void Value_OnChangeEvent(object sender, decimal e)
        {
            CurrentValue = SwitchT.FromDecimal(e);
        }

        public override void Dispose()
        {
            base.Dispose();
            jsHelper.Dispose();
        }


        [Parameter]
        public TValue ValueMin { get; set; }

        [Parameter]
        public TValue ValueMax { get; set; }

        [Parameter]
        public bool Discrete { get; set; }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public bool Markers { get; set; }

        [Parameter]
        public bool Pin { get; set; }

        [Parameter]
        public TValue Step { get; set; }

        [Parameter]
        public bool EnableStep { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        /// <summary>
        /// When set to true, any change to the slider immediately changes the value.
        /// </summary>
        [Parameter]
        public bool Immediate { get; set; }

        public string MarkerStyle
        {
            get
            {
                try
                {
                    decimal.TryParse(ValueMin.ToString(), out var min);
                    decimal.TryParse(ValueMax.ToString(), out var max);
                    if (!decimal.TryParse(Step.ToString(), out var step))
                    {
                        step = 1;
                    }
                    return "background: linear-gradient(to right, currentcolor 2px, transparent 0px) 0px center / calc((100% - 2px) / " + ((max - 0) / step).ToString() + ") 100% repeat-x;";
                }
                catch
                {
                    return "";
                }
            }
        }
    }
}
