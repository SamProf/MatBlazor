using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// Checkboxes allow the user to select multiple options from a set.
    /// </summary>
    public class BaseMatCheckbox : BaseMatComponent
    {
        protected ElementRef FormFieldRef;

        public BaseMatCheckbox()
        {
            ClassMapper.Add("mdc-checkbox");
        }

        [Parameter]
        protected RenderFragment ChildContent { get; set; }

        [Parameter]
        protected bool Checked { get; set; }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        protected Action<bool> CheckedChanged { get; set; }
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
            await Js.InvokeAsync<object>("matBlazor.matCheckbox.init", Ref, FormFieldRef);
        }
    }
}