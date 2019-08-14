using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatDrawerContent : BaseMatDomComponent
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public BaseMatDrawerContent()
        {
            ClassMapper
                .Add("mdc-drawer-app-content")
                .Add("mat-drawer-app-content");
        }
    }
}