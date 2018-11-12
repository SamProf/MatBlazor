using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;

namespace MatBlazor.Components.MatAppBar
{
    public class BaseMatAppBar : BaseMatComponent
    {
        public ElementRef Ref { get; set; }

        [Parameter]
        public bool Short { get; set; }

        [Parameter]
        public bool Fixed { get; set; }

        public BaseMatAppBar()
        {
            ClassMapper
                .Add("mdc-top-app-bar")
                .If("mdc-top-app-bar--short", () => Short)
                .If("mdc-top-app-bar--fixed", () => Fixed);
        }


        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await Js.InvokeAsync<object>("matBlazor.matAppBar.init", Ref);
        }
    }
}