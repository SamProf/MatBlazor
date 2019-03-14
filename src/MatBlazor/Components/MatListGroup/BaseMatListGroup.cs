using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Components;

namespace MatBlazor.Components.MatListGroup
{
    public class BaseMatListGroup : BaseMatComponent
    {
        [Parameter]
        protected RenderFragment ChildContent { get; set; }

        public BaseMatListGroup()
        {
            ClassMapper
                .Add("mdc-list-group");
        }
    }
}