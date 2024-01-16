﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Threading.Tasks;

namespace MatBlazor
{
    /// <summary>
    /// Mat Table Row display a table row   
    /// </summary>
    public class BaseTableRow<TItem> : BaseMatDomComponent
    {
        [CascadingParameter]
        public BaseMatTable<TItem> Table { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public bool Selected { get; set; }

        [Parameter]
        public bool AllowSelection { get; set; }

        [Parameter]
        public TItem RowItem { get; set; }

        [Parameter]
        public EventCallback<bool> SelectedChanged { get; set; }

        public async Task ToggleSelectedAsync()
        {
            Selected = !Selected;
            await SelectedChanged.InvokeAsync(Selected);
            await Table.ToggleSelectedAsync(this);
            StateHasChanged();            
        }

        public BaseTableRow()
        {
            ClassMapper
                .Add("mdc-table-row")
                .If("mdc-table-row-hover", () => AllowSelection)
                .If("mdc-table-row-selected", () => Selected);
        }

        protected async Task OnClickHandler(MouseEventArgs _)
        {
            if (AllowSelection && !Selected)
            {
                await ToggleSelectedAsync();
            }
        }
    }
}
