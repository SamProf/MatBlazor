using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Components;

namespace MatBlazor.Components.MatIconButton
{
    /// <summary>
    /// Icons are appropriate for buttons that allow a user to take actions or make a selection, such as adding or removing a star to an item.
    /// </summary>
    public class BaseMatIconButton : BaseMatComponent
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventCallback<UIMouseEventArgs> OnClick { get; set; }

        [Parameter]
        public Action<UIMouseEventArgs> OnMouseDown { get; set; }

        [Parameter]
        public string Icon { get; set; }

        [Parameter]
        public string Link { get; set; }

        [Parameter]
        public string Target { get; set; }

        [Parameter]
        public string Title { get; set; }

        public BaseMatIconButton()
        {
            ClassMapper
                .Add("mdc-icon-button")
                .Add("mat-icon-button");
        }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await Js.InvokeAsync<object>("matBlazor.matIconButton.init", Ref);
        }

        protected void OnClickHandler(UIMouseEventArgs e)
        {
            OnClick.InvokeAsync(e);
        }
    }
}