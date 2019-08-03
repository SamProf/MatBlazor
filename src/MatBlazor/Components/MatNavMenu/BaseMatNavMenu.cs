using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// MatNavMenu provides a navigation container
    /// </summary>
    public class BaseMatNavMenu : BaseMatDomComponent
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public BaseMatNavItem CurrentNavItem { get; private set; }
        public BaseMatNavSubMenu CurrentSelectedNavSubMenu { get; private set; }
        public BaseMatNavSubMenu CurrentNavSubMenu { get; private set; }

        [Parameter]
        public bool Multi { get; set; }



        public async Task ToggleAsync(BaseMatNavSubMenu subMenu)
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

                if (CurrentSelectedNavSubMenu == null)
                {
                    CurrentSelectedNavSubMenu = navSubMenu;                    
                }
                else
                {
                    await CurrentSelectedNavSubMenu.ToggleSelectedAsync();
                    CurrentSelectedNavSubMenu = navSubMenu;                    
                }
            }
        }

        public BaseMatNavMenu()
        {
            ClassMapper.Add("mat-accordion");
        }
    }
}
