using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// Ripples are visual representations used to communicate the status of a component or interactive element. 
    /// </summary>
    public class BaseMatRipple : BaseMatDomComponent
    {
        [Parameter]
        protected RenderFragment ChildContent { get; set; }

        [Parameter]
        protected MatRippleColor Color { get; set; }

        public BaseMatRipple()
        {
            ClassMapper
                .Add("mdc-ripple-surface")
                .If("mdc-ripple-surface--primary", () => Color == MatRippleColor.Primary)
                .If("mdc-ripple-surface--accent", () => Color == MatRippleColor.Secondary);
            CallAfterRender(async () => { await Js.InvokeAsync<object>("matBlazor.matRipple.init", Ref); });
        }
    }
}