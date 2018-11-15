using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;

namespace MatBlazor.Components.MatList
{
    public class BaseMatList : BaseMatComponent
    {
        [Parameter]
        protected RenderFragment ChildContent { get; set; }

        [Parameter]
        protected bool SingleSelection { get; set; }

        [Parameter]
        protected bool TwoLine { get; set; }

        public BaseMatList()
        {
            ClassMapper
                .Add("mdc-list")
                .If("mdc-list--two-line", () => TwoLine);
        }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await Js.InvokeAsync<object>("matBlazor.matList.init", this.Ref, new MatListJsOptions()
            {
                SingleSelection = SingleSelection
            });
        }
    }


    public class MatListJsOptions
    {
        public bool SingleSelection { get; set; }
    }
}