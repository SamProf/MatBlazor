using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatDrawerContainer  : BaseMatComponent
    {
        [Parameter]
        protected RenderFragment ChildContent { get; set; }

        public BaseMatDrawerContainer()
        {
            ClassMapper
                .Add("mdc-drawer-app-content");
        }
    }
}
