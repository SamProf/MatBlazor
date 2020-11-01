using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace MatBlazor
{
    /// <summary>
    /// Acts as a container for items such as application title, navigation icon, and action items.
    /// </summary>
    partial class MatAppBar : BaseMatDomComponent
    {
        [Parameter]
        public bool Short { get; set; }
        [Parameter]
        public bool Fixed { get; set; }
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public MatAppBar()
        {
            ClassMapper
                .Add("mdc-top-app-bar")
                .If("mdc-top-app-bar--short", () => Short)
                .If("mdc-top-app-bar--fixed", () => Fixed);
        }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await JsInvokeAsync<object>("matBlazor.matAppBar.init", Ref);
        }

    }
}