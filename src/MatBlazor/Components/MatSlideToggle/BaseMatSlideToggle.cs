using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;

namespace MatBlazor.Components.MatSlideToggle
{
    public class BaseMatSlideToggle : BaseMatComponent
    {
        protected ElementRef MdcSwitch;

        public BaseMatSlideToggle()
        {
            ClassMapper
                .Add("mdc-switch")
                .If("mdc-switch--disabled", () => Disabled)
                .If("mdc-switch--checked", () => Checked);
        }

        private bool _checked;


        protected void OnChangedHandler(UIChangeEventArgs e)
        {
            Checked = (bool) e.Value;
        }

        [Parameter]
        public Action<bool> CheckedChanged { get; set; }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public bool Checked
        {
            get => _checked;
            set
            {
                if (_checked != value)
                {
                    _checked = value;
                    CheckedChanged?.Invoke(value);
                }
            }
        }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await Js.InvokeAsync<object>("mdc.switchControl.MDCSwitch.attachTo", MdcSwitch);
        }
    }
}