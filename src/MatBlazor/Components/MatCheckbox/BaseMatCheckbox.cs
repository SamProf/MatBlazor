using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// Checkboxes allow the user to select multiple options from a set.
    /// </summary>
    public class BaseMatCheckbox : BaseMatDomComponent
    {
        protected ElementReference ComponentRef;

        public BaseMatCheckbox()
        {
            ClassMapper.Add("mdc-checkbox");
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public bool Checked { get; set; }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public Action<bool> CheckedChanged { get; set; }
//
//        [Parameter]
//        public bool Indeterminate { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public string Value { get; set; }

        protected void ChangeHandler(UIChangeEventArgs e)
        {
            Checked = (bool) e.Value;
            CheckedChanged?.Invoke(this.Checked);
        }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await JsInvokeAsync<object>("matBlazor.matCheckbox.init", ComponentRef, Ref);
        }
    }
}