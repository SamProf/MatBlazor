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

        public BaseMatNavMenu()
        {
            ClassMapper.Add("mat-accordion");
        }
    }
}