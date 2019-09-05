using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace MatBlazor
{
    /// <summary>
    /// A floating action button represents the primary action in an application.
    /// </summary>
    public class BaseMatFAB : BaseMatDomComponent
    {
        [Parameter]
        public string Icon { get; set; }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public bool Mini { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        public BaseMatFAB()
        {
            ClassMapper
                .Add("mat-fab")
                .Add("mdc-fab")
                .If("mdc-fab--extended", () => Label != null)
                .If("mdc-fab--mini", () => Mini);
        }
    }
}