using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatDatePicker : BaseMatComponent
    {
        protected BaseMatTextField TextFieldRef;

        public override ElementRef Ref
        {
            get => TextFieldRef.InputRef;
            set => throw new NotSupportedException();
        }

        public BaseMatDatePicker()
        {
            CallAfterRender(async () =>
            {
                Js.InvokeAsync<object>("matBlazor.matDatePicker.init", Ref);
            });
        }
    }
}