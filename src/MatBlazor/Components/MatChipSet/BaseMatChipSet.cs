using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatChipSet : BaseMatDomComponent
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await Js.InvokeAsync<object>("matBlazor.matChipSet.init", Ref);
        }
    }
}