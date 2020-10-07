using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace MatBlazor
{
    /// <summary>
    /// Lists present multiple line items vertically as a single continuous element.
    /// </summary>
    public class BaseMatListItem : BaseMatDomComponent
    {
        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseDown { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// The URL of the List Item
        /// </summary>
        [Parameter]
        public string Href { get; set; }

        /// <summary>
        /// List Item is disabled.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; }

        public BaseMatListItem()
        {
            ClassMapper
                .Add("mdc-list-item")
                .If("mdc-list-item--disabled", () => Disabled);
        }
    }
}
