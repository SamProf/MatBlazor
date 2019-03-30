using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;

namespace MatBlazor.Components.MatTooltip
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