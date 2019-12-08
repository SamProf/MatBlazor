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
                .If("mdc-slider--discrete", () => Discrete);

            CallAfterRender(async () =>
            {
                await JsInvokeAsync<object>("matBlazor.matSlider.init", Ref, jsHelper.Reference);
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
        public string Label { get; set; }

        [Parameter]
        public bool Discrete { get; set; }

        [Parameter]
        public TValue Step { get; set; }

        [Parameter]
        public bool EnableStep { get; set; }

        [Parameter]
        public bool Disabled { get; set; }
    }
}