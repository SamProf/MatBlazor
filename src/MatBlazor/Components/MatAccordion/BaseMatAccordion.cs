using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatAccordion : BaseMatComponent
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public bool Multi { get; set; }

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