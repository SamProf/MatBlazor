using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;

namespace MatBlazor
{
    public class MatComponentHost : ComponentBase
    {
        [Parameter]
        public Type Type { get; set; }

        [Parameter]
        public Dictionary<string, object> Attributes { get; set; }


        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenComponent(7, Type);
            builder.AddMultipleAttributes(8,
                Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers
                    .TypeCheck<System.Collections.Generic.IEnumerable<
                        System.Collections.Generic.KeyValuePair<string, object>>>(
                        Attributes
                    ));
            builder.CloseComponent();
        }
    }
}