using System;

namespace MatBlazor
{
    public static class IdGeneratorHelper
    {
        public static string Generate(string prefix)
        {
            return prefix + Guid.NewGuid();
        }
    }
}