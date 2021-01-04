using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace MatBlazor
{
    /// <summary>
    /// MatNavSubMenu provides an expandable panel for child navigation lists.
    /// </summary>
    public class BaseMatNavSubMenu : BaseMatDomComponent, IMatNavSubMenuToggler
    {
        [CascadingParameter]
        public BaseMatNavMenu MatNavMenu { get; set; }

        [CascadingParameter]
        public BaseMatNavSubMenu ParentSubMenu { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public bool Expanded { get; set; }

        [Parameter]
        public bool Selected { get; set; }

        [Parameter]
        public EventCallback<bool> SelectedChanged { get; set; }

        [Parameter]
        public EventCallback<bool> ExpandedChanged { get; set; }

        public BaseMatNavSubMenu CurrentNavSubMenu { get; private set; }

        public event EventHandler<bool> AllSubMenusToggled;

        protected override Task OnInitializedAsync()
        {
            var parent = (IMatNavSubMenuToggler)ParentSubMenu ?? MatNavMenu;
            parent.AllSubMenusToggled += OnAllSubMenusToggled;
            return base.OnInitializedAsync();
        }

        public override void Dispose()
        {
            var parent = (IMatNavSubMenuToggler)ParentSubMenu ?? MatNavMenu;
            parent.AllSubMenusToggled -= OnAllSubMenusToggled;
            base.Dispose();
        }

        private void OnAllSubMenusToggled(object source, bool expanded)
        {
            if (this.Expanded != expanded)
            {
                this.Expanded = expanded;
                this.StateHasChanged();
            }
            ToggleAllSubMenus(expanded);
        }

        public async Task ToggleAsync()
        {
            this.Expanded = !this.Expanded;
            await ExpandedChanged.InvokeAsync(this.Expanded);
            await ((IMatNavSubMenuToggler)this.ParentSubMenu ?? this.MatNavMenu).ToggleSubMenuAsync(this);
            this.StateHasChanged();
        }

        public void ToggleAllSubMenus(bool expanded)
        {
            AllSubMenusToggled?.Invoke(this, expanded);
        }

        public async Task ToggleSubMenuAsync(BaseMatNavSubMenu subMenu)
        {
            if (!MatNavMenu.Multi)
            {
                if (subMenu.Expanded)
                {
                    var current = CurrentNavSubMenu;
                    CurrentNavSubMenu = subMenu;

                    if (current != null && current != subMenu && current.Expanded)
                    {
                        await current.ToggleAsync();
                    }
                }
            }
        }
        public async Task ToggleSelectedAsync()
        {
            this.Selected = !this.Selected;
            await SelectedChanged.InvokeAsync(this.Selected);
            this.StateHasChanged();
        }

        public BaseMatNavSubMenu()
        {
            ClassMapper
                .Add("mat-expansion-panel")
                .If("mat-expansion-panel--expanded", () => Expanded)
                .If("mdc-expansion-panel--selected", () => Selected);
        }
    }
}
