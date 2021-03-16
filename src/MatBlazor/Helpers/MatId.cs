using System;
using System.Threading;

namespace MatBlazor
{
    public static class MatId
    {
        private static long _lastId = 0;

        public static string NewId(string prefix = "")
        {
            return prefix + Interlocked.Increment(ref _lastId);
        }
    }
}