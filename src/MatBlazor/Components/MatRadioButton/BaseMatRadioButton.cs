using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;

namespace MatBlazor.Components.MatRadioButton
{
    public class BaseMatRadioButton : BaseMatComponent
    {
        protected ElementRef FormFieldRef;

        private bool _checked;
        private bool _disabled;

        [Parameter]
        public bool Checked
        {
            get => _checked;
            set
            {
                if (value != _checked)
                {
                    _checked = value;
                    CheckedChanged?.Invoke(value);
                }
            }
        }


        [Parameter]
        public Action<bool> CheckedChanged { get; set; }

        [Parameter]
        public bool Disabled
        {
            get => _disabled;
            set
            {
                _disabled = value;
                ClassMapper.MakeDirty();
            }
        }

        [Parameter]
        public string Value { get; set; }

        [Parameter]
        public string Name { get; set; }

        [Parameter]
        public string Label { get; set; }

        protected void OnChangeHandler(UIChangeEventArgs e)
        {
            Checked = (bool) e.Value;
        }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await Js.InvokeAsync<object>("matBlazor.matRadioButton.init", Ref, FormFieldRef);
        }

        public BaseMatRadioButton()
        {
            ClassMapper
                .Add("mdc-radio")
                .If("mdc-radio--disabled", () => Disabled);
        }
    }
}