using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;
using Microsoft.AspNetCore.Components;

namespace MatBlazor.Demo.BlazorFiddle
{
    public class BaseBlazorFiddle : BaseMatComponent
    {
        [Parameter]
        protected string Code { get; set; }

        [Parameter]
        protected string Template { get; set; } = null;

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await Js.InvokeAsync<object>("blazorFiddle.create", Ref, new
            {
                Text = this.Code,
                Template = this.Template,
            });
        }
    }
}