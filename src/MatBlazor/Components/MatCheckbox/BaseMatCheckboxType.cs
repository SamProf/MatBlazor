using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// Checkboxes allow the user to select multiple options from a set.
    /// </summary>
    public class BaseMatCheckboxType<T> : BaseMatInputElementComponent<T>
    {

        protected ElementReference ComponentRef { get; set; }

        public BaseMatCheckboxType()
        {
            ClassMapper
                .Add("mat-checkbox")
                .Add("mdc-form-field");

            CallAfterRender(async () =>
            {
                await JsInvokeAsync<object>("matBlazor.matCheckbox.init", Ref, ComponentRef);
            });
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
       
        [Parameter]
        public string Label { get; set; }

        
        [Parameter]
        public bool Indeterminate { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public string InputValue { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
            if (CurrentValue == null && Indeterminate)
            {
                CallAfterRender(async () =>
                {
                    await JsInvokeAsync<object>("matBlazor.matCheckbox.setIndeterminate", Ref, CurrentValue, Indeterminate);
                });
            }
        }

        protected void ChangeHandler(ChangeEventArgs e)
        {
            CurrentValue = SwitchT.FromBoolNull((bool) e.Value, Indeterminate);
        }

        
    }
}