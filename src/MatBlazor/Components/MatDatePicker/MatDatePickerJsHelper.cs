using Microsoft.JSInterop;
using System;

namespace ITMS.External.MatBlazor
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