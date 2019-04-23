using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatTab : BaseMatComponent
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public BaseMatTab()
        {
        }
    }
}
