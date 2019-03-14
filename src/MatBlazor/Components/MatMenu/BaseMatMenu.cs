using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Components;

namespace MatBlazor.Components.MatMenu
{
    public class BaseMatMenu : BaseMatComponent
    {
        protected ElementRef MdcMenu;
        private bool _opened;


        public async Task OpenAsync(ElementRef anchorElement)
        {
            await Js.InvokeAsync<object>("matBlazor.matMenu.open", MdcMenu, anchorElement);
        }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await Js.InvokeAsync<object>("matBlazor.matMenu.init", MdcMenu);
        }
    }
}