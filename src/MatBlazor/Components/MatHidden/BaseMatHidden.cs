using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatHidden : BaseMatComponent
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public MatBreakpoint Breakpoint { get; set; }

        [Parameter]
        public MatHiddenDirection Direction { get; set; }

        public bool Hidden { get; set; } = true;


        protected async Task UpdateVisible()
        {
            var innerWidth = await Js.InvokeAsync<decimal>("matBlazor.utils.windowInnerWidth");
            var val = MatHiddenUtils.IsHidden(innerWidth, Breakpoint, Direction);
            if (val != Hidden)
            {
                Hidden = val;
                this.StateHasChanged();
            }
        }

        public BaseMatHidden()
        {
            CallAfterRender(async () => { await UpdateVisible(); });
        }
    }
}