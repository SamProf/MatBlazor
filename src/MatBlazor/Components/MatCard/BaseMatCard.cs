using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// Card component for Blazor contain content and actions about a single subject. 
    /// </summary>
    public class BaseMatCard : BaseMatDomComponent
    {
        public BaseMatCard()
        {
            ClassMapper
                .Add("mat-card")
                .Add("mdc-card")
                .If("mdc-card--outlined", () => this.Outlined);
        }


        /// <summary>
        /// Unelevated outlined card.
        /// </summary>
        [Parameter]
        public bool Outlined
        {
            get => _outlined;
            set { _outlined = value; }
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        private bool _outlined;
    }
}