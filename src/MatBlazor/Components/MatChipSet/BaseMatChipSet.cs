using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;

namespace MatBlazor.Components.MatChipSet
{
    public class BaseMatChipSet : BaseMatComponent
    {
        protected ElementRef MdcChipSetRef;

        [Parameter]
        protected RenderFragment ChildContent { get; set; }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await Js.InvokeAsync<object>("mdc.chips.MDCChipSet.attachTo", MdcChipSetRef);
        }
    }
}
