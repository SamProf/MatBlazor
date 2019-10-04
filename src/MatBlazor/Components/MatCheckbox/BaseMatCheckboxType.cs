using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MatBlazor
{
    /// <summary>
    /// Checkboxes allow the user to select multiple options from a set.
    /// </summary>
    public class BaseMatCheckboxType<T> : BaseMatInputElementComponent<T>
    {
        protected ElementReference ComponentRef;

        public BaseMatCheckboxType()
        {
            ClassMapper
                .Add("mdc-form-field");
            inputClassMapper
                .Add("mdc-checkbox__native-control");
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
        
        [Parameter]
        public string Label { get; set; }

        protected bool Indeterminate => typeof(bool?) == typeof(T);

        [Parameter]
        public bool Disabled { get; set; }

        protected async Task ChangeHandlerAsync(ChangeEventArgs e)
        {
            CurrentValue = (T) (object) (bool) e.Value;
        }

        protected override async Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await JsInvokeAsync<object>("matBlazor.matCheckbox.init",
                Ref,
                ComponentRef,
                CurrentValue);
        }


        public override async Task SetParametersAsync(ParameterView parameters)
        {
            await base.SetParametersAsync(parameters);
            T v;
            if (parameters.TryGetValue(nameof(Value), out v))
            {
                if (Indeterminate && !(v as bool?).HasValue)
                {
                    CallAfterRender(async () =>
                    {
                        await JsInvokeAsync<object>("matBlazor.matCheckbox.setIndeterminate", Ref);
                    });
                }
            }
        }
    }
}