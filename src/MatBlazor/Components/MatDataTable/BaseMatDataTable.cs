using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatDataTable<TItem> : BaseMatDomComponent
    {
        [Parameter]
        public IReadOnlyList<TItem> Items { get; set; }
    }
}