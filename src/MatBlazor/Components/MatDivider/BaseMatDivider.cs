using MatBlazor.Components.Base;
using Microsoft.AspNetCore.Components;

namespace MatBlazor.Components.MatDivider
{
    public class BaseMatDivider : BaseMatComponent
    {
        [Parameter]
        public bool Inset { get; set; }

        [Parameter]
        public bool Padded { get; set; }


        public BaseMatDivider()
        {
            ClassMapper
                .Add("mdc-list-divider")
                .If("mdc-list-divider--inset", () => Inset)
                .If("mdc-list-divider--padded", () => Padded);
        }
    }
}