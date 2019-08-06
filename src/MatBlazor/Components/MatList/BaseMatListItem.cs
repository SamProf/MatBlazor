using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// Lists present multiple line items vertically as a single continuous element.
    /// </summary>
    public class BaseMatListItem : BaseMatDomComponent
    {
        [Parameter]
        protected EventCallback<UIMouseEventArgs> OnMouseDown { get; set; }

        [Parameter]
        protected EventCallback<UIMouseEventArgs> OnClick { get; set; }

        [Parameter]
        protected RenderFragment ChildContent { get; set; }

        /// <summary>
        /// The URL of the List Item
        /// </summary>
        [Parameter]
        protected string Href { get; set; }

        /// <summary>
        /// List Item is disabled.
        /// </summary>
        [Parameter]
        public bool Disabled
        {
            get => _disabled;
            set
            {
                _disabled = value;
                
            }
        }

        private bool _disabled;

        public BaseMatListItem()
        {
            ClassMapper
                .Add("mdc-list-item")
                .If("mdc-list-item--disabled", () => _disabled);
        }
    }
}
