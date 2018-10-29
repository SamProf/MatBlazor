using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;
using MatBlazor.Helpers;
using Microsoft.AspNetCore.Blazor.Components;

namespace MatBlazor.Components.MatTextField
{
    public class BaseMatTextField : BaseMatComponent
    {
        [Parameter]
        public string Value { get; set; }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public string Icon { get; set; }

        [Parameter]
        public bool IconTrailing { get; set; }

        [Parameter]
        public bool Box { get; set; }

        [Parameter]
        public bool Outlined { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public bool FullWidth { get; set; }

        [Parameter]
        public bool Required { get; set; }

        [Parameter]
        public string HelperText { get; set; }

        [Parameter]
        public string PlaceHolder { get; set; }

        [Parameter]
        public string Type { get; set; }

        public override void UpdateComponent()
        {
            ClassNames = ClassBuilder.GetClasses(this);
        }


        public static ClassBuilder<BaseMatTextField> ClassBuilder = ClassBuilder<BaseMatTextField>.Create()
            .Get(b => b.Class)
            .Class("mdc-text-field")
            .Class("mdc-text-field--upgraded")
            .If("mdc-text-field--with-leading-icon", b => b.Icon != null && !b.IconTrailing)
            .If("mdc-text-field--with-trailing-icon", b => b.Icon != null && b.IconTrailing)
            .If("mdc-text-field--box", b => !b.FullWidth && b.Box)
            .If("mdc-text-field--outlined", b => !b.FullWidth && b.Outlined)
            .If("mdc-text-field--disabled", b => b.Disabled)
            .If("mdc-text-field--fullwidth", b => b.FullWidth);
    }
}