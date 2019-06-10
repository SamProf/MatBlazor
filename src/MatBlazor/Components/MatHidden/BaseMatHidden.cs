using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// Quickly and responsively toggle the visibility value of components and more with our hidden utilities.
    /// </summary>
    public class BaseMatHidden : BaseMatComponent
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public RenderFragment ElseContent { get; set; }

        [Parameter]
        public RenderFragment InitContent { get; set; }

        [Parameter]
        public MatBreakpoint Breakpoint { get; set; }

        [Parameter]
        public MatHiddenDirection Direction { get; set; }

        public bool? Hidden { get; set; } = null;

        [Parameter]
        public EventCallback<bool> HiddenChanged { get; set; }

        protected async Task UpdateVisible()
        {
            var innerWidth = await Js.InvokeAsync<decimal>("matBlazor.utils.windowInnerWidth");
            var val = MatHiddenUtils.IsHidden(innerWidth, Breakpoint, Direction);
            if (!Hidden.HasValue || val != Hidden.Value)
            {
                Hidden = val;
                await HiddenChanged.InvokeAsync(val);
                this.StateHasChanged();
            }
        }

        public BaseMatHidden()
        {
            CallAfterRender(async () => { await UpdateVisible(); });
        }
    }
}