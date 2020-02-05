using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatDataTable : BaseMatDomComponent
    {
        internal IMatDataTableItems Items { get; set; }

        public BaseMatDataTable()
        {
            ClassMapper
                .Add("mat-data-table")
                .Add("mdc-data-table");
        }


        [Parameter]
        public RenderFragment ChildContent { get; set; }

        // [Parameter]
        // public IReadOnlyList<TItem> Items { get; set; }
    }
}