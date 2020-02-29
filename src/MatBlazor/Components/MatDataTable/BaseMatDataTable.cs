using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatDataTable : BaseMatDomComponent
    {
        internal IMatDataTableItems ItemsComponent { get; set; }

        internal BaseMatPaginator PaginatorComponent { get; set; }

        public BaseMatDataTable()
        {
            ClassMapper
                .Add("mat-data-table")
                .Add("mdc-data-table");
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public void Update()
        {
            this.ItemsComponent?.MarkStateHasChanged();
        }
    }
}