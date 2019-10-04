using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace MatBlazor.Components.MatTextFieldView
{
    public interface IMatInputElementViewModel<T> : IMatInputViewModel<T>
    {
        ElementReference InputRef { get; set; }
        string Type { get; set; }
        string InputClass { get; set; }
        string InputStyle { get; set; }

        string InputId { get; set; }
        Dictionary<string, object> InputAttributes { get; set; }
        string Name { get; set; }
    }
}