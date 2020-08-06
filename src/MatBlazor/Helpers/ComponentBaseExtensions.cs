using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public static class ComponentBaseExtensions
    {
        public static bool ParameterIsChanged<T>(this ComponentBase cmp, ParameterView parameters,
            string parameterName, T value)
        {
            if (parameters.TryGetValue(parameterName, out T newValue))
            {
                if (!EqualityComparer<T>.Default.Equals(value, newValue))
                {
                    return true;
                }
            }

            return false;
        }
    }
}