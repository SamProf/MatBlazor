using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// Chips are compact elements that allow users to enter information, select a choice, filter content, or trigger an action.
    /// </summary>
    public class BaseMatChip : BaseMatComponent
    {
        [Parameter]
        public string LeadingIcon { get; set; }

        [Parameter]
        public string TrailingIcon { get; set; }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public bool Active { get; set; } = false;


        public BaseMatChip()
        {
            ClassMapper
                .Add("mdc-chip")
                .If("mdc-chip--activated", () => this.Active);
        }
    }
}