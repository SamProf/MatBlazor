using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Components;

namespace MatBlazor.Components.MatDrawer
{
    public class BaseMatDrawer : BaseMatComponent
    {

        [Parameter]
        protected RenderFragment ChildContent { get; set; }

        public BaseMatDrawer()
        {
            ClassMapper
                .Add("mdc-drawer");
        }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await Js.InvokeAsync<object>("matBlazor.matDrawer.init", Ref, new { });
        }
    }
}