using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// The Material tooltip provides a text label that is displayed when the user hovers an element.
    /// </summary>
    public class BaseMatTooltip : BaseMatDomComponent
    {
        [Parameter]
        public RenderFragment<ForwardRef> ChildContent { get; set; }

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
        public ForwardRef TargetForwardRef { get; set; } = new ForwardRef();

        public BaseMatTooltip()
        {
            ClassMapper.Add("mat-tooltip");
            CallAfterRender(async () =>
            {
                await JsInvokeAsync<object>("matBlazor.matTooltip.init", Ref, TargetForwardRef?.Current, TargetId,
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