using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// Ripples are visual representations used to communicate the status of a component or interactive element. 
    /// </summary>
    public class BaseMatRipple : BaseMatDomComponent
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public MatRippleColor Color { get; set; }

        public BaseMatRipple()
        {
            ClassMapper
                .Add("mdc-ripple-surface")
                .If("mdc-ripple-surface--primary", () => Color == MatRippleColor.Primary)
                .If("mdc-ripple-surface--accent", () => Color == MatRippleColor.Secondary);
            CallAfterRender(async () => { await JsInvokeAsync<object>("matBlazor.matRipple.init", Ref); });
        }
    }
}