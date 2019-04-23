using System;

namespace MatBlazor
{
    public class ClassBuilderRuleGet<T> : ClassBuilderRule<T>
    {
        public Func<T, string> Func { get; set; }

        public ClassBuilderRuleGet(Func<T, string> func)
        {
            Func = func;
        }

        public override string GetClass(T data)
        {
            return Func(data);
        }
    }
}