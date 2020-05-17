using System.Collections.Generic;
using System.Threading.Tasks;

namespace MatBlazor
{
    public interface IAutocompleteItemsSource<TItem>
    {
        /// <summary>
        /// Returns the items to be populated in the dropdown list based on a search after the search text.
        /// </summary>
        /// <param name="searchText">The search text which is provided by the user in the input component.</param>
        /// <returns></returns>
        Task<IEnumerable<TItem>> GetFilteredItemsAsync(string searchText);
    }
}
