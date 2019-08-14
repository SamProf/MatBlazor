using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// Menus display a list of choices on a transient sheet of material.
    /// </summary>
    public class BaseMatMenu : BaseMatDomComponent
    {
        private bool _opened;
        private bool _menuOpen;


        public BaseMatMenu()
        {
            ClassMapper.Add("mdc-menu mdc-menu-surface");
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }


        [Parameter]
        public ForwardRef TargetForwardRef { get; set; }

        public async Task OpenAsync(ElementReference anchorElement)
        {
            await Js.InvokeAsync<object>("matBlazor.matMenu.open", Ref, anchorElement);
        }

        public async Task OpenAsync()
        {
            await OpenAsync(TargetForwardRef.Current);
        }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await Js.InvokeAsync<object>("matBlazor.matMenu.init", Ref);
        }
    }
}