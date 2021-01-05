using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    partial class MatAppBarContainer
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
