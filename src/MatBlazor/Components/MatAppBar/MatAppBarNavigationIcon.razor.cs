using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace MatBlazor
{
    partial class MatAppBarNavigationIcon
    {
        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        void OnClickHandler(MouseEventArgs e)
        {
            OnClick.InvokeAsync(e);
        }
    }
}
