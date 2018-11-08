using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;
using Microsoft.AspNetCore.Blazor;

namespace MatBlazor.Components.MatIconButton
{
    public class BaseMatIconButton : BaseMatComponent
    {
        public ElementRef Ref { get; set; }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await Js.InvokeAsync<object>("matBlazor.matIconButton.init", Ref);
        }
    }
}
