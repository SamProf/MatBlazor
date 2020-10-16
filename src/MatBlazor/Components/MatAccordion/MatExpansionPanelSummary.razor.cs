using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace MatBlazor
{
    partial class MatExpansionPanelSummary
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [CascadingParameter]
        public MatExpansionPanel ExpansionPanel { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ClassMapper.Add("mat-expansion-panel__summary").Add("mdc-ripple-surface");
            CallAfterRender(async () => { await JsInvokeAsync<object>("matBlazor.matAccordion.initSummary", Ref); });
        }

        protected void OnClickHandler(MouseEventArgs e)
        {
            this.ExpansionPanel.ToggleAsync();
        }
    }
}
