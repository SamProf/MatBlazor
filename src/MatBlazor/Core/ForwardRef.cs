using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class ForwardRef : ForwardRef<ElementReference>
    {
    }


    public class ForwardRef<T>
    {
        private T _current;

        public T Current
        {
            get => _current;
            set => Set(value);
        }


        public void Set(T value)
        {
            _current = value;
        }
    }
}