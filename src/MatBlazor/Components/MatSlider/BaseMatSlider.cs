using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MatBlazor
{
    /// <summary>
    /// Material Design Slider for Blazor. Sliders let users select from a range of values by moving the slider thumb.
    /// </summary>
    /// <typeparam name="TValue">sbyte, byte, short, ushort, int, uint, long, ulong, char, float, double, decimal, decimal?</typeparam>
    public class BaseMatSlider<TValue> : BaseMatInputComponent<TValue>
    {
        private TValue valueMin;
        private TValue valueMax;
        private TValue step;

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

        protected override void OnValueChanged(bool changed)
        {
            if (changed && Rendered)
            {
                InvokeAsync(async () =>
                {
                    try
                    {
                        await Js.InvokeVoidAsync("matBlazor.matSlider.updateValue", Ref, Value);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                });
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            jsHelper.Dispose();
        }


        [Parameter]
        public TValue ValueMin
        {
            get => valueMin;
            set
            {
                if (!EqualityComparer<TValue>.Default.Equals(valueMin, value) && Rendered)
                {
                    InvokeAsync(async () =>
                    {
                        try
                        {
                            await Js.InvokeVoidAsync("matBlazor.matSlider.updateValueMin", Ref, value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    });
                }
                valueMin = value;
            }
        }

        [Parameter]
        public TValue ValueMax
        {
            get => valueMax;
            set
            {
                if (!EqualityComparer<TValue>.Default.Equals(valueMax, value) && Rendered)
                {
                    InvokeAsync(async () =>
                    {
                        try
                        {
                            await Js.InvokeVoidAsync("matBlazor.matSlider.updateValueMax", Ref, value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    });
                }
                valueMax = value;
            }
        }

        [Parameter]
        public bool Discrete { get; set; }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public bool Markers { get; set; }

        [Parameter]
        public bool Pin { get; set; }

        [Parameter]
        public TValue Step
        {
            get => step;
            set
            {
                if (!EqualityComparer<TValue>.Default.Equals(step, value) && Rendered)
                {
                    InvokeAsync(async () =>
                    {
                        try
                        {
                            await Js.InvokeVoidAsync("matBlazor.matSlider.updateStep", Ref, value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    });
                }
                step = value;
            }
        }

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
