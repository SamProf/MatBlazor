using System;
using System.Threading.Tasks;

namespace MatBlazor
{
    /// <summary>
    /// Defines interface for a container component that
    /// can toggle the expansion state of its sub menus.
    /// </summary>
    public interface IMatNavSubMenuToggler
    {
        event EventHandler<bool> AllSubMenusToggled;

        Task ToggleSubMenuAsync(BaseMatNavSubMenu subMenu);

        void ToggleAllSubMenus(bool expanded);
    }
}