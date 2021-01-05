using Microsoft.AspNetCore.Components;

namespace MatBlazor
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