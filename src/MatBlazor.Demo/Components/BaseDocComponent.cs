using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor.Demo.Components
{
    public class BaseDocComponent : ComponentBase
    {
        [Parameter]
        public bool Secondary { get; set; }
    }
}