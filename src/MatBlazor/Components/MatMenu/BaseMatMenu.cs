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
            await JsInvokeVoidAsync("matBlazor.matMenu.setAnchorElement", Ref, anchorElement);
        }

        public async Task OpenAsync(ElementReference anchorElement)
        {
            await JsInvokeVoidAsync("matBlazor.matMenu.setAnchorElement", Ref, anchorElement);
            await JsInvokeVoidAsync("matBlazor.matMenu.open", Ref);
        }

        public async Task CloseAsync()
        {
            await JsInvokeVoidAsync("matBlazor.matMenu.close", Ref);
        }

        public async Task OpenAsync()
        {
            
            await JsInvokeVoidAsync("matBlazor.matMenu.setAnchorElement", Ref, TargetForwardRef.Current);
            await JsInvokeVoidAsync("matBlazor.matMenu.open", Ref);
        }
        public async Task SetState(bool open)
        {
            await JsInvokeVoidAsync("matBlazor.matMenu.setAnchorElement", Ref, TargetForwardRef.Current);
            await JsInvokeVoidAsync("matBlazor.matMenu.setState", Ref, open);
        }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await JsInvokeVoidAsync("matBlazor.matMenu.init", Ref);
        }
    }
}