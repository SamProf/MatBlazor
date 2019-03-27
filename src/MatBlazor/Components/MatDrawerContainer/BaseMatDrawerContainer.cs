using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;
using Microsoft.AspNetCore.Components;

namespace MatBlazor.Components.MatDrawerContainer
{
    public class BaseMatDrawerContainer  : BaseMatComponent
    {
        [Parameter]
        protected RenderFragment ChildContent { get; set; }

        public BaseMatDrawerContainer()
        {
            ClassMapper
                .Add("mdc-drawer-app-content");
        }
    }
}
