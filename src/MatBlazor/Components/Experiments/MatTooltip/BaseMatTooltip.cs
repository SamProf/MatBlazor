using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatTooltip : BaseMatComponent
    {
        protected MarkupString commentNode;

        [Parameter]
        protected RenderFragment ChildContent { get; set; }

        public BaseMatTooltip()
        {
            this.commentNode = new MarkupString($"<!-- id=bugaga123 -->");
        }
    }
}