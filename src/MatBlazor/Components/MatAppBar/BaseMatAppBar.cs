using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;
using Microsoft.AspNetCore.Blazor;

namespace MatBlazor.Components.MatAppBar
{
    public class BaseMatAppBar : BaseMatComponent
    {
        public ElementRef Ref { get; set; }


        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await Js.InvokeAsync<object>("matBlazor.matAppBar.init", Ref);
        }
    }
}