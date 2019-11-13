using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace MatBlazor
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