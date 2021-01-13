using System;
using System.Collections.Generic;

namespace MatBlazor
{
    public class MatSwitchT
    {
        private readonly Dictionary<Type, object> dictionary = new Dictionary<Type, object>();


        public MatSwitchT Case<T>(T action)
        {
            dictionary[typeof(T)] = action;
            return this;
        }

        public T Get<T>()
        {
            if (dictionary.TryGetValue(typeof(T), out var result))
            {
                return (T) result;
            }

            return (T)(object)null;
        }
    }
}