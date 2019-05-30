using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// Menus display a list of choices on a transient sheet of material.
    /// </summary>
    public class BaseMatMenu : BaseMatComponent
    {
        private bool _opened;


        public BaseMatMenu()
        {
            ClassMapper.Add("mdc-menu mdc-menu-surface");
        }

        [Parameter]
        protected RenderFragment ChildContent { get; set; }


        public async Task OpenAsync(ElementRef anchorElement)
        {
            await Js.InvokeAsync<object>("matBlazor.matMenu.open", Ref, anchorElement);
        }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await Js.InvokeAsync<object>("matBlazor.matMenu.init", Ref);
        }
    }
}