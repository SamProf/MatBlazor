using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatAccordion : BaseMatDomComponent
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public bool Multi { get; set; }

        /// <summary>
        /// Hides toggle icon for all expansion panel summaries in the accordion
        /// </summary>
        [Parameter]
        public bool HideToggle { get; set; }

        /// <summary>
        /// Enables lazy rendering for all expansion panel details in the accordion.
        /// </summary>
        [Parameter]
        public bool LazyRendering { get; set; }

        public BaseMatExpansionPanel Current { get; private set; }

        public async Task ToggleAsync(BaseMatExpansionPanel panel)
        {
            if (!Multi)
            {
                if (panel.Expanded)
                {
                    var current = Current;
                    Current = panel;

                    if (current != null && current != panel && current.Expanded)
                    {
                        await current.ToggleAsync();
                    }
                }
            }
        }

        public BaseMatAccordion()
        {
            ClassMapper.Add("mat-accordion");
        }
    }
}