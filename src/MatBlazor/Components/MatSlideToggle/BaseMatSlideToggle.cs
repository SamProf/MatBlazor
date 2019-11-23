using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// Component for on/off control that can be toggled via clicking or dragging.
    /// </summary>
    public class BaseMatSlideToggle<TValue> : BaseMatInputElementComponent<TValue>
    {

        protected bool Checked => SwitchT.ToBool(CurrentValue);

        public BaseMatSlideToggle()
        {
            ClassMapper
                .Add("mat-switch")
                .Add("mdc-switch")
                .If("mdc-switch--disabled", () => Disabled)
                .If("mdc-switch--checked", () => Checked);
            CallAfterRender(async () =>
            {
                await JsInvokeAsync<object>("matBlazor.matSlideToggle.init", Ref);
            });
        }


        protected void OnChangedHandler(ChangeEventArgs e)
        {
            CurrentValue = SwitchT.FromBool((bool)e.Value);
        }
       
        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public bool Disabled { get; set; }
    }
}