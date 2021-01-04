using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace MatBlazor
{
    partial class MatCardContent
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public bool Unbounded { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            ClassMapper.Add("mdc-card__primary-action");
        }
    }
}
