using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace MatBlazor
{
    public static class InteropHelper
    {
        public static async Task StartAsync()
        {
            await JSRuntime.Current.InvokeAsync<object>(
                "matBlazor.start"
            );
        }
    }
}