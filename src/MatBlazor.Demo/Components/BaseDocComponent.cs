using Microsoft.AspNetCore.Components;

namespace MatBlazor.Demo.Components
{
    public class BaseDocComponent : ComponentBase
    {
        [Parameter]
        public bool Secondary { get; set; }
    }
}