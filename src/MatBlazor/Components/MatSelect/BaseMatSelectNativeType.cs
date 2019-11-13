using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatSelectNativeType<T> : MatSelectTypeKey<T, T>
    {
        
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        protected override T GetKeyFromValue(T value)
        {
            return value;
        }

        protected override T GetValueFromKey(T key)
        {
            return key;
        }
    }
}
