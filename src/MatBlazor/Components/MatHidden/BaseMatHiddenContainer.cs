using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatHiddenContainer : BaseMatComponent
    {
        [Parameter]
        public RenderFragment<bool?> ChildContent { get; set; }


        [Parameter]
        public MatBreakpoint Breakpoint { get; set; }

        [Parameter]
        public MatHiddenDirection Direction { get; set; }

        public bool? Hidden { get; set; } = null;

        [Parameter]
        public EventCallback<bool?> HiddenChanged { get; set; }

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

        public BaseMatHiddenContainer()
        {
            CallAfterRender(async () => { await UpdateVisible(); });
        }
    }
}