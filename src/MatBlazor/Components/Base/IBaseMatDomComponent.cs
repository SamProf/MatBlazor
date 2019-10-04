using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public interface IBaseMatDomComponent : IBaseMatComponent
    {
        string Id { get; set; }
        Dictionary<string, object> Attributes { get; set; }
        ElementReference Ref { get; }
        string Class { get; set; }
        string Style { get; set; }
    }
}