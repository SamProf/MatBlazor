using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public abstract class BaseMatInputElementComponent<T> : BaseMatInputComponent<T>
    {
        protected MatBlazorSwitchT<T> SwitchT = MatBlazorSwitchT<T>.Get();
        public ElementReference InputRef { get; protected set; }
    }
}