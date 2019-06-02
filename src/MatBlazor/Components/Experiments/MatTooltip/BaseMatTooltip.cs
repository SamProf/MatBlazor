using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// The Material tooltip provides a text label that is displayed when the user hovers an element.
    /// </summary>
    public class BaseMatTooltip : BaseMatComponent
    {
        [Parameter]
        protected RenderFragment<ElementRefStore> ChildContent { get; set; }

        [Parameter]
        public RenderFragment TooltipContent { get; set; }

        [Parameter]
        public string Tooltip { get; set; }

        [Parameter]
        public string TargetId { get; set; }

        [Parameter]
        public bool Wrap { get; set; }

        [Parameter]
        public MatTooltipPosition Position { get; set; }

        [Parameter]
        public ElementRefStore ContentRefStore { get; set; } = new ElementRefStore();

        public BaseMatTooltip()
        {
            ClassMapper.Add("mat-tooltip");
            CallAfterRender(async () =>
            {
                await Js.InvokeAsync<object>("matBlazor.matTooltip.init", RefStore.Ref, ContentRefStore?.Ref, TargetId,
                    CreateJSOptions());
            });
        }


        private MatTooltipJSOptions CreateJSOptions()
        {
            return new MatTooltipJSOptions()
            {
                Position = Position.ToString()
            };
        }
    }


    public enum MatTooltipPosition
    {
        Bottom,
        Right,
        Left,
        Top,
    }


    public class MatTooltipJSOptions
    {
        public string Position { get; set; }
    }
}