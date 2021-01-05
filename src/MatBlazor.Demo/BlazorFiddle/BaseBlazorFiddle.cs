using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace MatBlazor.Demo.BlazorFiddle
{
    public class BaseBlazorFiddle : BaseMatDomComponent
    {
        [Parameter]
        public string Code { get; set; }

        [Parameter]
        public string Template { get; set; } = null;

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            try
            {
                await JsInvokeAsync<object>("blazorFiddle.create", Ref, new
                {
                    Text = Code,
                    Template,
                });
            }
            catch (Exception /*e*/)
            {
//                Console.WriteLine(e);
//                throw;
            }
        }
    }
}