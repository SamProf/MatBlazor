using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace MatBlazor
{
    public class MatDatePickerJsHelper
    {
        [JSInvokable]
        public void MatDatePickerOnChangeHandler(DateTime?[] value)
        {
            OnChangeAction?.Invoke(value);
        }

        public Action<DateTime?[]> OnChangeAction;
    }
}