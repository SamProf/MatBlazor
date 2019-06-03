using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class ForwardRef
    {
        private ElementRef _current;

        public ElementRef Current
        {
            get => _current;
            set => Set(value);
        }


        public void Set(ElementRef value)
        {
            _current = value;
        }
    }
}