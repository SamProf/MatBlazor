using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace MatBlazor
{
    /// <summary>
    /// Mat Table Row display a table row   
    /// </summary>
    public class BaseTableRow : BaseMatDomComponent
    {
        [CascadingParameter]
        public BaseMatTable Table { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public bool Selected { get; set; }

        [Parameter]
        public bool AllowSelection { get; set; }

        [Parameter]
        public object RowItem { get; set; }

        [Parameter]
        public EventCallback<bool> SelectedChanged { get; set; }

        public async Task ToggleSelectedAsync()
        {
            this.Selected = !this.Selected;
            await SelectedChanged.InvokeAsync(this.Selected);
            await this.Table.ToggleSelectedAsync(this);
            this.StateHasChanged();            
        }

        public BaseTableRow()
        {
            ClassMapper
                .Add("mdc-table-row")
                .If("mdc-table-row-hover", () => AllowSelection)
                .If("mdc-table-row-selected", () => Selected);
        }

        protected void OnClickHandler(MouseEventArgs _)
        {
            if (AllowSelection)
            {
                ToggleSelectedAsync();
            }
        }
    }
}
