using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace MatBlazor
{
    partial class MatAppBarAction
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        [Parameter]
        public string Icon { get; set; }

        [Parameter]
        public string Label { get; set; }

        private void OnClickHandler(MouseEventArgs e)
        {
            OnClick.InvokeAsync(e);
        }
    }
}