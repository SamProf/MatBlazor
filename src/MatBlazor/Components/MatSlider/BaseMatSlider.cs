using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.JSInterop;

namespace MatBlazor.Components.MatSlider
{
    public class BaseMatSlider : BaseMatComponent
    {
        protected ElementRef MdcSliderRef;

        protected JsHelper jsHelper;

//        protected DotNetObjectRef jsHelperRef;
        private decimal _value;

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await Js.InvokeAsync<object>("matBlazor.matSlider.init", MdcSliderRef, new DotNetObjectRef(jsHelper));
        }

        public BaseMatSlider()
        {
            jsHelper = new JsHelper(this);
//            jsHelperRef = new DotNetObjectRef(jsHelper);
        }


        [Parameter]
        public decimal ValueMin { get; set; } = 0;

        [Parameter]
        public decimal ValueMax { get; set; } = 100;

        [Parameter]
        public string Label { get; set; };


        [Parameter]
        public decimal Value
        {
            get => _value;
            set
            {
                if (value != _value)
                {
                    _value = value;
                    ValueChanged?.Invoke(value);
                }
            }
        }

        [Parameter]
        public Action<decimal> ValueChanged { get; set; }

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