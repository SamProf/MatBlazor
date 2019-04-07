using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatBlazor.Components.MatAutocomplete
{
    public class AutocompleteElementWrapper<TItem>
    {
        public TItem Element { get; set; }

        public string StringValue { get; set; }
    }
}
