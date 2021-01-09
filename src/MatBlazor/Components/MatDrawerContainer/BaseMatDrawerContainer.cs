using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatDrawerContainer : BaseMatDomComponent
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [Parameter]
        public string DrawerWidth { get; set; } = null;

        public BaseMatDrawerContainer()
        {
            ClassMapper
                .Add("mdc-drawer-app-content");
            StyleMapper
                .GetIf(() => $"--mat-drawer-custom-width: {DrawerWidth}", () => !string.IsNullOrWhiteSpace(DrawerWidth));
        }
    }
}