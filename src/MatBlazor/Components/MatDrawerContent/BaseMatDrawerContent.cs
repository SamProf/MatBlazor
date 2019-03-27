using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;
using Microsoft.AspNetCore.Components;

namespace MatBlazor.Components.MatDrawerContent
{
    public class BaseMatDrawerContent : BaseMatComponent
    {
        [Parameter]
        protected RenderFragment ChildContent { get; set; }

        public BaseMatDrawerContent()
        {
            ClassMapper.Add("mdc-drawer-app-content");
        }
    }
}