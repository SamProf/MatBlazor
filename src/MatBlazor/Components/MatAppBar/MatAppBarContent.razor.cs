using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    partial class MatAppBarContent
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
