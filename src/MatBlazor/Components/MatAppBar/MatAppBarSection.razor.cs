using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    partial class MatAppBarSection
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public MatAppBarSectionAlign Align { get; set; } = MatAppBarSectionAlign.Start;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ClassMapper
                .Add("mdc-top-app-bar__section")
                .If("mdc-top-app-bar__section--align-start", () => this.Align == MatAppBarSectionAlign.Start)
                .If("mdc-top-app-bar__section--align-end", () => this.Align == MatAppBarSectionAlign.End);
        }
    }
}
