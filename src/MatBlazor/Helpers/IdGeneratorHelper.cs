using System;

namespace ITMS.External.MatBlazor
{
    public static class IdGeneratorHelper
    {
        public static string Generate(string prefix)
        {
            return prefix + Guid.NewGuid();
        }
    }
}