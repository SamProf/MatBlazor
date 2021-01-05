using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace MatBlazor
{
    /// <summary>
    /// Menus display a list of choices on a transient sheet of material.
    /// </summary>
    public class BaseMatMenu : BaseMatDomComponent
    {
        public BaseMatMenu()
        {
            ClassMapper.Add("mdc-menu mdc-menu-surface");
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }


        [Parameter]
        public ForwardRef TargetForwardRef { get; set; }
        public async Task SetAnchorElementAsync(ElementReference anchorElement)
        {
            await JsInvokeAsync<object>("matBlazor.matMenu.setAnchorElement", Ref, anchorElement);
        }

        public async Task OpenAsync(ElementReference anchorElement)
        {
            await JsInvokeAsync<object>("matBlazor.matMenu.setAnchorElement", Ref, anchorElement);
            await JsInvokeAsync<object>("matBlazor.matMenu.open", Ref);
        }

        public async Task CloseAsync()
        {
            await JsInvokeAsync<object>("matBlazor.matMenu.close", Ref);
        }

        public async Task OpenAsync()
        {
            
            await JsInvokeAsync<object>("matBlazor.matMenu.setAnchorElement", Ref, TargetForwardRef.Current);
            await JsInvokeAsync<object>("matBlazor.matMenu.open", Ref);
        }
        public async Task SetState(bool open)
        {
            await JsInvokeAsync<object>("matBlazor.matMenu.setAnchorElement", Ref, TargetForwardRef.Current);
            await JsInvokeAsync<object>("matBlazor.matMenu.setState", Ref, open);
        }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await JsInvokeAsync<object>("matBlazor.matMenu.init", Ref);
        }
    }
}