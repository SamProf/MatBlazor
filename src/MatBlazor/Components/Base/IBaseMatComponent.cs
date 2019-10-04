using System;

namespace MatBlazor
{
    public interface IBaseMatComponent : IDisposable
    {
        ForwardRef RefBack { get; set; }
    }
}