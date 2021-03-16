using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace MatBlazor
{
    public abstract class BaseMatInputElementComponent<T> : BaseMatInputComponent<T>
    {
        public ElementReference InputRef { get; protected set; }

        [Parameter] public string InputId { get; set; } = MatId.NewId("mat-input-id-");

        [Parameter] public IDictionary<string, object> InputAttributes { get; set; }

        protected IDictionary<string, object> GetInputAttributes()
        {
            return InputAttributes;
        }
    }
}