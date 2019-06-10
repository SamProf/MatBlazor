using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatTab : BaseMatDomComponent
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public RenderFragment LabelContent { get; set; }

        [Parameter]
        public string Label { get; set; }


        public BaseMatTab()
        {
            LabelContent = builder => { builder.AddContent(0, Label); };
        }
    }
}