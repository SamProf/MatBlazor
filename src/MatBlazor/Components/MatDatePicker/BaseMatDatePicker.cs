using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MatBlazor
{
    /// <summary>
    /// Datetime picker based on flatpickr.js
    /// </summary>
    public class BaseMatDatePicker : BaseMatComponent
    {
        protected BaseMatTextField TextFieldRef;
        private DateTime? _value;

        [Parameter]
        public DateTime? Value
        {
            get => _value;
            set { _value = value; }
        }

        [Parameter]
        public EventCallback<DateTime?> ValueChanged { get; set; }

        public override ElementRef Ref
        {
            get => TextFieldRef.InputRef;
            set => throw new NotSupportedException();
        }

        public BaseMatDatePicker()
        {
            CallAfterRender(async () => { Js.InvokeAsync<object>("matBlazor.matDatePicker.init", Ref, new DotNetObjectRef(this), Value); });
        }



        [JSInvokable]
        public async Task MatDatePickerOnChangeHandler(DateTime?[] value)
        {
            var v = value.First();
            Value = v;
            await ValueChanged.InvokeAsync(Value);
            this.StateHasChanged();
        }



        public async override Task SetParametersAsync(ParameterCollection parameters)
        {
            var valueIsChanged = this.ParameterIsChanged(parameters, nameof(Value), Value);
            await base.SetParametersAsync(parameters);
            if (valueIsChanged)
            {
                CallAfterRender(async () =>
                {
                    Js.InvokeAsync<object>("matBlazor.matDatePicker.setDate", Ref, Value);
                });
            }
        }
    }
}