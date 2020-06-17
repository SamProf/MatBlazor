using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// MatExpansionPanel provides an expandable details-summary view.
    /// </summary>
    public class BaseMatExpansionPanel : BaseMatDomComponent
    {
        [CascadingParameter]
        public BaseMatAccordion Accordion { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public bool Expanded { get; set; }

        /// <summary>
        /// Hides the toggle icon in the expansion panel summary
        /// </summary>
        [Parameter]
        public bool HideToggle { get; set; }

        /// <summary>
        /// Enables lazy rendering of the expansion panel details.
        /// </summary>
        [Parameter]
        public bool LazyRendering { get; set; }

        [Parameter]
        public EventCallback<bool> ExpandedChanged { get; set; }

        public async Task ToggleAsync()
        {
            this.Expanded = !this.Expanded;
            await ExpandedChanged.InvokeAsync(this.Expanded);
            await this.Accordion.ToggleAsync(this);
            this.StateHasChanged();
        }

        public BaseMatExpansionPanel()
        {
            ClassMapper
                .Add("mat-expansion-panel")
                .Add("mdc-elevation--z3")
                .If("mat-expansion-panel--expanded", () => Expanded);           
        }

        protected override void OnInitialized()
        {
            HideToggle = HideToggle || (Accordion?.HideToggle ?? false);
            LazyRendering = LazyRendering || (Accordion?.LazyRendering ?? false);
        }
    }
}
