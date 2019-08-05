using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;

namespace MatBlazor
{
    public abstract class BaseMatTypography : BaseMatDomComponent
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        private string tagName;
        private string className;

        protected BaseMatTypography(string tagName, string className)
        {
            this.tagName = tagName;
            this.className = className;
        }


        protected override async Task OnInitAsync()
        {
            await base.OnInitAsync();
            ClassMapper
                .Add("mdc-typography");
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, tagName);
            builder.AddAttribute(1, "class", ClassMapper.Class);
            builder.AddAttribute(2, "style", GenerateStyle());
            builder.AddMultipleAttributes(3,
                RuntimeHelpers
                    .TypeCheck<global::System.Collections.Generic.IEnumerable<
                        global::System.Collections.Generic.KeyValuePair<string, object>>>(Attributes));
            builder.AddAttribute(4, "Id", Id);
            builder.AddElementReferenceCapture(5, (__value) => { Ref = __value; }
            );
            builder.AddContent(7, ChildContent);
            builder.CloseElement();
        }
    }
}