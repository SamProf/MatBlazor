using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatTabLabel : BaseMatComponent
    {
        [Parameter]
        protected RenderFragment ChildContent { get; set; }

        [CascadingParameter]
        protected BaseMatTabBar Parent { get; set; }

        public BaseMatTabLabel()
        {
            ClassMapper.Add("mdc-tab");
        }
    }
}
