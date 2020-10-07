using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace MatBlazor
{
    public class BaseMatSortHeaderRow : BaseMatDomComponent
    {
        [Parameter]
        public string SortId { get; set; }

        [Parameter]
        public EventCallback<string> SortIdChanged { get; set; }

        [Parameter]
        public MatSortDirection Direction { get; set; }

        [Parameter]
        public EventCallback<MatSortDirection> DirectionChanged { get; set; }

        [Parameter]
        public EventCallback<MatSortChangedEvent> SortChanged { get; set; }

        public BaseMatSortHeaderRow()
        {
            ClassMapper.Add("mat-sort-header-row");
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public async Task SetNewSortAsync(string sortId, MatSortDirection direction)
        {
            SortId = sortId;
            Direction = direction;
            await SortIdChanged.InvokeAsync(sortId);
            await DirectionChanged.InvokeAsync(direction);
            await SortChanged.InvokeAsync(new MatSortChangedEvent()
            {
                SortId = sortId,
                Direction = direction
            });
            this.StateHasChanged();
        }
    }
}