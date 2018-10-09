using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatBlazor.Helpers
{
    public class ClassBuilder<T>
    {
        public static ClassBuilder<T> Create()
        {
            return new ClassBuilder<T>();
        }

        public ClassBuilder<T> If(string className, Func<T, bool> func)
        {
            Rules.Add(new ClassBuilderRuleIf<T>(className, func));
            return this;
        }

        public ClassBuilder<T> Class(string className)
        {
            Rules.Add(new ClassBuilderRuleClass<T>(className));
            return this;
        }


        private List<ClassBuilderRule<T>> Rules = new List<ClassBuilderRule<T>>();

        public string GetClasses(T data)
        {
            return string.Join(" ", Rules.Select(i => i.GetClass(data)).Where(i => i != null));
        }
    }


    public abstract class ClassBuilderRule<T>
    {
        public abstract string GetClass(T data);
    }

    public class ClassBuilderRuleClass<T> : ClassBuilderRule<T>
    {
        public string ClassName { get; set; }


        public ClassBuilderRuleClass(string className)
        {
            ClassName = className;
        }

        public override string GetClass(T data)
        {
            return ClassName;
        }
    }

    public class ClassBuilderRuleIf<T> : ClassBuilderRule<T>
    {
        public string ClassName { get; set; }
        public Func<T, bool> Func { get; set; }

        public ClassBuilderRuleIf(string className, Func<T, bool> func)
        {
            ClassName = className;
            Func = func;
        }

        public override string GetClass(T data)
        {
            if (Func(data))
            {
                return ClassName;
            }

            return null;
        }
    }
}