using System;
using System.Collections.Generic;

namespace MatBlazor
{
    public class ClassBuilderRuleDictionary<T, TK> : ClassBuilderRule<T>
    {
        public IDictionary<TK, string> Dictionary { get; set; }

        public Func<T, TK> Func { get; set; }

        public ClassBuilderRuleDictionary(Func<T, TK> func, IDictionary<TK, string> dictionary)
        {
            Func = func;
            Dictionary = dictionary;
        }

        public override string GetClass(T data)
        {
            var key = Func(data);

            if (Dictionary.TryGetValue(key, out var value))
            {
                return value;
            }

            return null;
        }
    }
}