using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;

namespace MatBlazor.Components.MatIconButton
{
    public class BaseMatIconButton : BaseMatComponent
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public Action<UIMouseEventArgs> OnClick { get; set; }

        [Parameter]
        public string Icon { get; set; }

        [Parameter]
        public string HRef { get; set; }

        [Parameter]
        public string Target { get; set; }

        [Parameter]
        public string Title { get; set; }

        public ElementRef Ref { get; set; }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await Js.InvokeAsync<object>("matBlazor.matIconButton.init", Ref);
        }

        protected void OnClickHandler(UIMouseEventArgs e)
        {
            OnClick?.Invoke(e);
        }
    }
}