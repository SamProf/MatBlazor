using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatDrawerContainer : BaseMatDomComponent
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public BaseMatDrawerContainer()
        {
            ClassMapper
                .Add("mdc-drawer-app-content");
        }
    }
}