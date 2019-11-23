using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace MatBlazor
{
    public class MatDotNetObjectReference<T> : IDisposable where T:class
    {
        private DotNetObjectReference<T> _reference;
        public T Value { get; }


        public MatDotNetObjectReference(T value)
        {
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
            (Value as IDisposable)?.Dispose();
        }
    }
}
