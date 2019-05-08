using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatTabBar : BaseMatComponent
    {
        [Parameter]
        protected RenderFragment ChildContent { get; set; }

        public BaseMatTabBar()
        {
            ClassMapper.Add("mdc-tab-bar");
        }
    }
}
