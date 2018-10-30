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
        public BaseMatCard()
        {
            ClassMapper
                .Add("mdc-card")
                .If("mdc-card--stroked", () => this.Stroke);
        }

        [Parameter]
        protected bool Stroke
        {
            get => _stroke;
            set
            {
                _stroke = value;
                ClassMapper.MakeDirty();
            }
        }

        [Parameter]
        protected RenderFragment ChildContent { get; set; }


        private bool _stroke;
    }
}