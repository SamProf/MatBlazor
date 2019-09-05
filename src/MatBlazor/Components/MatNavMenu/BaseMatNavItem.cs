using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace MatBlazor
{
    /// <summary>
    /// Nav Item is a menu item in the Nav Menu. Inherits from Mat List Item.
    /// </summary>
    public class BaseMatNavItem : BaseMatListItem
    {
        [Inject]
        public NavigationManager UriHelper { get; set; }

        [CascadingParameter]
        public BaseMatNavMenu MatNavMenu { get; set; }

        [CascadingParameter]
        public BaseMatNavSubMenu MatNavSubMenu { get; set; }

        [Parameter]
        public bool Selected { get; set; }

        [Parameter]
        public bool AllowSelection { get; set; } = true;

        [Parameter]
        public EventCallback<bool> SelectedChanged { get; set; }

        public async Task ToggleSelectedAsync()
        {
            this.Selected = !this.Selected;
            
            await SelectedChanged.InvokeAsync(this.Selected);

            if (MatNavMenu != null)
            {
                await this.MatNavMenu.ToggleSelectedAsync(this, MatNavSubMenu);
            }

            this.StateHasChanged();
        }

        public BaseMatNavItem()
        {
            ClassMapper
                .Add("mdc-nav-item")
                .If("mdc-list-item--selected", () => Selected);
        }

        protected async void OnClickHandler(MouseEventArgs e)
        {
            if (AllowSelection)
            {
                await this.ToggleSelectedAsync();
            }

            if (Href != null && !Disabled)
            {
                UriHelper.NavigateTo(Href);
            }
        }
    }
}