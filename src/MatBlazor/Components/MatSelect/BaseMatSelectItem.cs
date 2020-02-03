using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatSelectItem<TValue> : CoreMatSelectValue<TValue, TValue>
    {
        protected override int GetKeyFromValue(TValue value)
        {
            return Items.IndexOf(value);
        }

        protected override TValue GetValueFromKey(int key)
        {
            return Items[key];
        }
    }
}