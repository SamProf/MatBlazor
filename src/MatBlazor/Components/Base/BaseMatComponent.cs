using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.MatButton;
using MatBlazor.Helpers;
using Microsoft.AspNetCore.Blazor.Components;

namespace MatBlazor.Components.Base
{
    public abstract class BaseMatComponent : BlazorComponent
    {
        public string ClassNames { get; internal set; }


        public static ClassBuilder<BaseMatComponent> ClassBuilder = ClassBuilder<BaseMatComponent>.Create()
            .Get(b => b.Class);


        [Parameter]
        public string Class
        {
            get => _class;
            set
            {
                _class = value;
                UpdateComponent();
            }
        }

        private string _class;


        public abstract void UpdateComponent();

        protected override void OnInit()
        {
            base.OnInit();
            UpdateComponent();
        }
    }
}