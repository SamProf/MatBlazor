using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public abstract class BaseMatInputElementComponent<T> : BaseMatInputComponent<T>
    {
        public ElementReference InputRef { get; protected set; }
    }
}