using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// Component for on/off control that can be toggled via clicking or dragging.
    /// </summary>
    public class BaseMatSlideToggle : BaseMatDomComponent
    {
        public BaseMatSlideToggle()
        {
            ClassMapper
                .Add("mdc-switch")
                .If("mdc-switch--disabled", () => Disabled)
                .If("mdc-switch--checked", () => Checked);
        }

        private bool _checked;


        protected void OnChangedHandler(ChangeEventArgs e)
        {
            Checked = (bool) e.Value;
        }

        [Parameter]
        public EventCallback<bool> CheckedChanged { get; set; }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public bool Checked
        {
            get => _checked;
            set
            {
                if (_checked != value)
                {
                    _checked = value;
                    CheckedChanged.InvokeAsync(value);
                }
            }
        }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await JsInvokeAsync<object>("matBlazor.matSlideToggle.init", Ref);
        }
    }
}