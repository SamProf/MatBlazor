using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatAutocompleteKey<TValue, TItem> : MatInputTextComponent<TValue>
    {
        [Parameter]
        public IEnumerable<TItem> Items { get; set; }
    }
}
