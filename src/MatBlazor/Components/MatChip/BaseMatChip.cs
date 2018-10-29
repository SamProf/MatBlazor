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


        public override void UpdateComponent()
        {
            ClassNames = ClassBuilder.GetClasses(this);
        }


        public static ClassBuilder<BaseMatChip> ClassBuilder = ClassBuilder<BaseMatChip>.Create()
            .Get(b => b.Class)
            .Class("mdc-chip")
            .If("mdc-chip--activated", b => b.Active);
    }
}