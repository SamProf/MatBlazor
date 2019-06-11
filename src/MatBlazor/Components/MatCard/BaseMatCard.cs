using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// Cards contain content and actions about a single subject.
    /// </summary>
    public class BaseMatCard : BaseMatDomComponent
    {
        public BaseMatCard()
        {
            ClassMapper
                .Add("mdc-card")
                .If("mdc-card--stroked", () => this.Stroke);
        }

        [Parameter]
        protected bool Stroke
        {
            get => _stroke;
            set
            {
                _stroke = value;
                
            }
        }

        [Parameter]
        protected RenderFragment ChildContent { get; set; }


        private bool _stroke;
    }
}