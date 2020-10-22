using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// MatDivider is a component that allows for Material styling of a line separator with various orientation options. 
    /// </summary>
    partial class MatDivider
    {
        [Parameter]
        public bool Inset { get; set; }

        [Parameter]
        public bool Padded { get; set; }

        public MatDivider()
        {
            ClassMapper
                .Add("mdc-list-divider")
                .If("mdc-list-divider--inset", () => Inset)
                .If("mdc-list-divider--padded", () => Padded);
        }
    }
}