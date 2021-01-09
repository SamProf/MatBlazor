using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.CompilerServices;
using Microsoft.AspNetCore.Components.Rendering;
using System.Collections.Generic;

namespace MatBlazor
{
    public abstract class BaseMatContainerComponent : BaseMatDomComponent
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Tag { get; set; } = "div";

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, Tag);
            builder.AddAttribute(1, "class", ClassMapper.AsString());
            builder.AddAttribute(2, "style", StyleMapper.AsString());
            builder.AddMultipleAttributes(3,
                RuntimeHelpers.TypeCheck<IEnumerable<KeyValuePair<string, object>>>(Attributes));
            builder.AddAttribute(4, "Id", Id);
            builder.AddElementReferenceCapture(5, (__value) => { Ref = __value; });
            builder.AddContent(7, ChildContent);
            builder.CloseElement();
        }
    }
}