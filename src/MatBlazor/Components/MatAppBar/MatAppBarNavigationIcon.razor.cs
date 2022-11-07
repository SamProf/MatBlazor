using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace ITMS.External.MatBlazor
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
