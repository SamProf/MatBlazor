using Microsoft.AspNetCore.Components;

namespace ITMS.External.MatBlazor
{
    partial class MatExpansionPanelDetails
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [CascadingParameter]
        public MatExpansionPanel ExpansionPanel { get; set; }
    }
}
