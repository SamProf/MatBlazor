using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public partial class MatDataTableContent<TItem>
    {
        [Parameter]
        public IEnumerable<TItem> Items { get; set; }
        
        [Parameter]
        public RenderFragment<TItem> ChildContent { get; set; }
    }
}