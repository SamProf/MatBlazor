using Microsoft.AspNetCore.Components;

namespace ITMS.External.MatBlazor
{
    public partial class MatDataTable
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }


        public MatDataTable()
        {
            ClassMapper.Add("mdc-data-table");
        }
    }
}