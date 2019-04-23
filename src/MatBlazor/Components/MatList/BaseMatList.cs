using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// Lists present multiple line items vertically as a single continuous element. 
    /// </summary>
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