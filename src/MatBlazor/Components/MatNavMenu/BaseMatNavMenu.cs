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

        [Parameter]
        public bool Multi { get; set; }

        public BaseMatNavSubMenu Current { get; private set; }

        public async Task ToggleAsync(BaseMatNavSubMenu subMenu)
        {
            if (!Multi)
            {
                if (subMenu.Expanded)
                {
                    var current = Current;
                    Current = subMenu;

                    if (current != null && current != subMenu && current.Expanded)
                    {
                        await current.ToggleAsync();
                    }
                }
            }
        }

        public async Task ToggleSelectedAsync(BaseMatNavItem navItem)
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
        }

        public BaseMatNavMenu()
        {
            ClassMapper.Add("mat-accordion");
        }
    }
}
