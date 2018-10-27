using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;
using MatBlazor.Helpers;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;

namespace MatBlazor.Components.MatCard
{
    public class BaseMatCard : BaseMatComponent
    {
        [Parameter]
        protected bool Stroke
        {
            get => _stroke;
            set
            {
                _stroke = value;
                UpdateComponent();
            }
        }

        [Parameter]
        protected RenderFragment ChildContent { get; set; }

        public static ClassBuilder<BaseMatCard> ClassBuilder = ClassBuilder<BaseMatCard>.Create()
            .Get(b => b.Class)
            .Class("mdc-card")
            .If("mdc-card--stroked", b => b.Stroke);

        private bool _stroke;

        public override void UpdateComponent()
        {
            ClassNames = ClassBuilder.GetClasses(this);
        }
    }
}
