using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Components;

namespace MatBlazor.Components.MatTab
{
    public class BaseMatTab : BaseMatComponent
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public BaseMatTab()
        {
        }
    }
}
