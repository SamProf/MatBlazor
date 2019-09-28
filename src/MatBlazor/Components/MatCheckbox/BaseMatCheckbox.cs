using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// Checkboxes allow the user to select multiple options from a set.
    /// </summary>
    public class BaseMatCheckbox : BaseMatInputComponent<bool>
    {
        protected ElementReference ComponentRef;

        public BaseMatCheckbox()
        {
            ClassMapper.Add("mdc-checkbox");
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Label { get; set; }

       
//        [Parameter]
//        public bool Indeterminate { get; set; }

        [Parameter]
        public bool Disabled { get; set; }
        
        protected async Task ChangeHandlerAsync(ChangeEventArgs e)
        {
            CurrentValue = (bool) e.Value;
        }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await JsInvokeAsync<object>("matBlazor.matCheckbox.init", ComponentRef, Ref);
        }
    }
}