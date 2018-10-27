using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;
using MatBlazor.Helpers;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;

namespace MatBlazor.Components.MatButton
{
    public class BaseMatButton : BaseMatComponent
    {
        

        [Parameter]
        protected Action<UIMouseEventArgs> OnClick { get; set; }


        [Parameter]
        public bool Raised
        {
            get => _raised;
            set
            {
                _raised = value;
                UpdateComponent();
            }
        }

        [Parameter]
        public bool Unelevated
        {
            get => _unelevated;
            set
            {
                _unelevated = value;
                UpdateComponent();
            }
        }

        [Parameter]
        public bool Outlined
        {
            get => _outlined;
            set
            {
                _outlined = value;
                UpdateComponent();
            }
        }

        [Parameter]
        public bool Dense
        {
            get => _dense;
            set
            {
                _dense = value;
                UpdateComponent();
            }
        }

        [Parameter]
        public bool Disabled
        {
            get => _disabled;
            set
            {
                _disabled = value;
                UpdateComponent();
            }
        }


        [Parameter]
        public string Icon
        {
            get => _icon;
            set
            {
                _icon = value;
                UpdateComponent();
            }
        }

        [Parameter]
        public string Label
        {
            get => _label;
            set
            {
                _label = value;
                UpdateComponent();
            }
        }


        [Parameter]
        protected RenderFragment ChildContent { get; set; }

       
        public override void UpdateComponent()
        {
            ClassNames = ClassBuilder.GetClasses(this);
        }


        public static ClassBuilder<BaseMatButton> ClassBuilder = ClassBuilder<BaseMatButton>.Create()
            .Get(b => b.Class)
            .Class("mdc-button")
            .If("mdc-button--raised", b => b.Raised)
            .If("mdc-button--unelevated", b => b.Unelevated)
            .If("mdc-button--outlined", b => b.Outlined)
            .If("mdc-button--dense", b => b.Dense);


        private bool _raised;
        private bool _unelevated;
        private bool _outlined;
        private bool _dense;
        private bool _disabled;
        private string _icon;
        private string _label;
    }

//    public enum MatButtonType
//    {
//        Text = 0,
//        Raised = 1,
//        Unelevated = 2,
//        Outlined = 3
//    }
}