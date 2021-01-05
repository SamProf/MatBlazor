using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace MatBlazor
{
    public class MatViewChildren<TSelect> : ComponentBase where TSelect : IComponent
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }


        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (ChildContent != null)
            {
                builder.AddContent(0, this.ChildContent);
            }
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }


        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
        }


        // public void Attach(RenderHandle renderHandle)
        // {
        //     renderHandle.Render(builder =>
        //     {
        //         ChildContent?.Invoke(builder);
        //         
        //     });
        // }
        //
        // public async Task SetParametersAsync(ParameterView parameters)
        // {
        //     ChildContent = parameters.GetValueOrDefault(nameof(ChildContent), ChildContent);
        // }
    }
}