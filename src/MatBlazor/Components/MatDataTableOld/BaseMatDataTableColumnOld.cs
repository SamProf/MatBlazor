using System;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatDataTableColumnOld<TItem> : ComponentBase
    {
        [CascadingParameter()]
        public BaseMatDataTableOld<TItem> DataTable { get; set; }

        [Parameter]
        public RenderFragment<TItem> Template { get; set; }

        [Parameter]
        public string Header { get; set; }

        [Parameter]
        public RenderFragment HeaderTemplate { get; set; }

        [Parameter]
        public Func<TItem, object> Value { get; set; }

        [Parameter]
        public bool Sort { get; set; } = false;


        protected override void OnInitialized()
        {
            base.OnInitialized();
            DataTable?.AddColumn(this);
        }
    }
}