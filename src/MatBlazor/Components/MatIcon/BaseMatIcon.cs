using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;
using Microsoft.AspNetCore.Components;

namespace MatBlazor.Components.MatIcon
{
    public class BaseMatIcon : BaseMatComponent
    {

        [Parameter]
        public string Icon { get; set; }


        [Parameter]
        protected RenderFragment ChildContent { get; set; }

        public BaseMatIcon()
        {
            ClassMapper.Add("material-icons");
        }
    }
}
