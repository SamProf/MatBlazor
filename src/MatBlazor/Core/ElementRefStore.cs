using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class ElementRefStore
    {
        private ElementRef _ref;

        public ElementRef Ref
        {
            get => _ref;
            set => _ref = value;
        }
    }
}