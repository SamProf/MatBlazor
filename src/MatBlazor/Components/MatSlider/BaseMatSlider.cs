using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MatBlazor
{
    /// <summary>
    /// Sliders let users select from a range of values by moving the slider thumb. 
    /// </summary>
    public class BaseMatSlider : BaseMatDomComponent
    {
        protected JsHelper jsHelper;

        private decimal _value;

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await Js.InvokeAsync<object>("matBlazor.matSlider.init", Ref, DotNetObjectRef.Create(jsHelper));
        }

        public BaseMatSlider()
        {
            jsHelper = new JsHelper(this);
            ClassMapper
                .Add("mdc-slider")
                .If("mdc-slider--discrete", () => Discrete)
                ;
        }


        [Parameter]
        public decimal ValueMin { get; set; } = 0;

        [Parameter]
        public decimal ValueMax { get; set; } = 100;

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public bool Discrete { get; set; }

        [Parameter]
        [Obsolete("Freezed while bug in Blazor")]
        public decimal Step { get; set; }

        [Parameter]
        public bool Disabled { get; set; }


        [Parameter]
        public decimal Value
        {
            get => _value;
            set
            {
                if (value != _value)
                {
                    _value = value;
                    ValueChanged.InvokeAsync(value);
                }
            }
        }

        [Parameter]
        public EventCallback<decimal> ValueChanged { get; set; }

        public class JsHelper
        {
            private BaseMatSlider _source;

            public JsHelper(BaseMatSlider source)
            {
                _source = source;
            }

            [JSInvokable]
            public decimal OnChangeHandler(decimal value)
            {
                _source.Value = value;
                return value;
            }
        }
    }
}