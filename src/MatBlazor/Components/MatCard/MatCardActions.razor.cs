using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace MatBlazor
{
    partial class MatCardActions
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            ClassMapper.Add("mdc-card__actions");
        }
    }
}
