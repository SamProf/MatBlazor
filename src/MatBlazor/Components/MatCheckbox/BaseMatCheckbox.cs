using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Components;

namespace MatBlazor.Components.MatCheckbox
{
    public class BaseMatCheckbox : BaseMatComponent
    {
        protected ElementRef FormFieldRef;

        public BaseMatCheckbox()
        {
            ClassMapper.Add("mdc-checkbox");
        }

        [Parameter]
        public bool Checked { get; set; }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public EventCallback<bool> CheckedChanged { get; set; }
//
//        [Parameter]
//        public bool Indeterminate { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public string Value { get; set; }

        protected void ChangeHandler(UIChangeEventArgs e)
        {
            Checked = (bool) e.Value;
            CheckedChanged.InvokeAsync(this.Checked);
        }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await Js.InvokeAsync<object>("matBlazor.matCheckbox.init", Ref, FormFieldRef);

        }
    }
}