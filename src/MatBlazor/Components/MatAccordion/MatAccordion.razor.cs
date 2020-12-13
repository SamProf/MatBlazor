using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace MatBlazor
{
    partial class MatAccordion
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

        public MatExpansionPanel Current { get; private set; }

        public async Task ToggleAsync(MatExpansionPanel panel)
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

        public MatAccordion()
        {
            ClassMapper.Add("mat-accordion");
        }
    }
}