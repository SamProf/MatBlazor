using System.Collections.Generic;

namespace MatBlazor.Components.MatAutocomplete
{
    public class AutocompleteSearchResult<TItem>
    {
        public List<MatAutocompleteItem<TItem>> ListResult { get; set; }

        public string SearchText { get; set; }
    }
}
