using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;
using MatBlazor.Helpers;
using Microsoft.AspNetCore.Blazor.Components;

namespace MatBlazor.Components.MatChip
{
    public class BaseMatChip : BaseMatComponent
    {
        [Parameter]
        public string LeadingIcon { get; set; }

        [Parameter]
        public string TrailingIcon { get; set; }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public bool Active { get; set; } = false;


        public BaseMatChip()
        {
            ClassMapper
                .Add("mdc-chip")
                .If("mdc-chip--activated", () => this.Active);
        }
    }
}