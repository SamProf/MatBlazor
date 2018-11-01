using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;

namespace MatBlazor.Components.MatSelect
{
    public class BaseMatSelect : BaseMatComponent
    {

        protected ElementRef MdcSelectRef;

        public BaseMatSelect()
        {
            ClassMapper.Add("mdc-select");
        }

        [Parameter]
        protected RenderFragment ChildContent { get; set; }

        [Parameter]
        protected string Label { get; set; }


        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await Js.InvokeAsync<object>("mdc.select.MDCSelect.attachTo", MdcSelectRef);
        }
    }
}
