using Microsoft.JSInterop;
using System;

namespace ITMS.External.MatBlazor
{
    public class MatSelectJsHelper
    {
        public event EventHandler<string> SetValueEvent;

        [JSInvokable]
        public void SetValue(string value)
        {
            SetValueEvent?.Invoke(this, value);
        }
    }
}