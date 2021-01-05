using Microsoft.JSInterop;
using System;

namespace MatBlazor
{
    public class MatDotNetObjectReference<T> : IDisposable where T:class
    {
        private readonly bool _disposeValue;
        private DotNetObjectReference<T> _reference;
        public T Value { get; }


        public MatDotNetObjectReference(T value, bool disposeValue = true)
        {
            _disposeValue = disposeValue;
            Value = value;
        }

        public DotNetObjectReference<T> Reference
        {
            get
            {
                if (_reference == null)
                {
                    _reference = DotNetObjectReference.Create(Value);
                }

                return _reference;
            }
        }

        public void Dispose()
        {
            _reference?.Dispose();
            if (_disposeValue)
            {
                (Value as IDisposable)?.Dispose();
            }
        }
    }
}
