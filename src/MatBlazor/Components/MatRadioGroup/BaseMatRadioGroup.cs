using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;
using Microsoft.AspNetCore.Components;

namespace MatBlazor.Components.MatRadioGroup
{
    public class BaseMatRadioGroup : BaseMatComponent
    {
        private string _value;

        [Parameter]
        protected RenderFragment ChildContent { get; set; }


        [Parameter]
        public string Value
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
        public EventCallback<string> ValueChanged { get; set; }
    }
}