using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MatBlazor.Components.MatRipple
{
    /// <summary>
    /// Ripples are visual representations used to communicate the status of a component or interactive element. 
    /// </summary>
    public class BaseMatRipple : BaseMatComponent
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