using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace MatBlazor
{
    /// <summary>
    /// MatNavMenu provides a navigation container
    /// </summary>
    public class BaseMatNavMenu : BaseMatDomComponent, IMatNavSubMenuToggler
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public BaseMatNavItem CurrentNavItem { get; private set; }
        public BaseMatNavSubMenu CurrentSelectedNavSubMenu { get; private set; }
        public BaseMatNavSubMenu CurrentNavSubMenu { get; private set; }

        [Parameter]
        public bool Multi { get; set; }

        public event EventHandler<bool> AllSubMenusToggled;

        public async Task ToggleSubMenuAsync(BaseMatNavSubMenu subMenu)
        {
            if (!Multi)
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

        public void ToggleAllSubMenus(bool expanded)
        {
            AllSubMenusToggled?.Invoke(this, expanded);
        }

        public async Task ToggleSelectedAsync(BaseMatNavItem navItem, BaseMatNavSubMenu navSubMenu)
        {
            if (navItem.Selected)
            {
                var currentNavItem = CurrentNavItem;
                CurrentNavItem = navItem;

                if (currentNavItem != null && currentNavItem != navItem && currentNavItem.Selected)
                {
                    await currentNavItem.ToggleSelectedAsync();
                }
            }

            if (navSubMenu != null)
            {
                await navSubMenu.ToggleSelectedAsync();
                CurrentSelectedNavSubMenu = navSubMenu;
            }
            else
            {
                CurrentSelectedNavSubMenu = null;
            }
        }

        public BaseMatNavMenu()
        {
            ClassMapper.Add("mat-accordion");
        }
    }
}
