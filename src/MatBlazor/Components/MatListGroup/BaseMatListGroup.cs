using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatListGroup : BaseMatComponent
    {
        [Parameter]
        protected RenderFragment ChildContent { get; set; }

        public BaseMatListGroup()
        {
            ClassMapper
                .Add("mdc-list-group");
        }
    }
}