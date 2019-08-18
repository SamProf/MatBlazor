using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// Lists present multiple line items vertically as a single continuous element. 
    /// </summary>
    public class BaseMatList : BaseMatDomComponent
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public bool SingleSelection { get; set; }

        [Parameter]
        public bool TwoLine { get; set; }

        public BaseMatList()
        {
            ClassMapper
                .Add("mdc-list")
                .If("mdc-list--two-line", () => TwoLine);
        }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await JsInvokeAsync<object>("matBlazor.matList.init", this.Ref, new MatListJsOptions()
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