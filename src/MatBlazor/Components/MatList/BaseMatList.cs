using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace MatBlazor
{
    /// <summary>
    /// Lists present multiple line items vertically as a single continuous element. 
    /// </summary>
    public class BaseMatList : BaseMatDomComponent
    {
        private int _selectedIndex = -1;

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public bool SingleSelection { get; set; }

        [Parameter]
        public bool TwoLine { get; set; }

        public BaseMatList()
        {
            ClassMapper
                .Add("mdc-list")
                .If("mdc-list--two-line", () => TwoLine);
        }

        /// <summary>
        /// Gets the index of the selected item in the list.
        /// </summary>
        /// <returns>The index.</returns>
        public async Task<int> GetSelectedIndex()
        {
            _selectedIndex = await JsInvokeAsync<int>("matBlazor.matList.getSelectedIndex", this.Ref);
            return _selectedIndex;
        }

        /// <summary>
        /// Sets the selected item in the list by index.
        /// </summary>
        /// <param name="index">The index of the item to select.</param>
        public async Task SetSelectedIndex(int index)
        {
            if (_selectedIndex != index)
            {
                await JsInvokeAsync<object>("matBlazor.matList.setSelectedIndex", this.Ref, index);
                _selectedIndex = index;
            }
        }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await JsInvokeAsync<object>("matBlazor.matList.init", this.Ref, new MatListJsOptions()
            {
                SingleSelection = SingleSelection
            });
        }
    }


    public class MatListJsOptions
    {
        public bool SingleSelection { get; set; }
    }
}