using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    partial class MatExpansionPanelDetails
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [CascadingParameter]
        public MatExpansionPanel ExpansionPanel { get; set; }
    }
}
