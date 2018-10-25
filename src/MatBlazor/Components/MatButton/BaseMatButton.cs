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
        public string ClassNames { get; private set; }

        [Parameter]
        protected Action<UIMouseEventArgs> OnClick { get; set; }


        [Parameter]
        public string Class
        {
            get => _class;
            set
            {
                _class = value;
                UpdateClass();
            }
        }

        [Parameter]
        public MatButtonType ButtonType
        {
            get => _buttonType;
            set
            {
                _buttonType = value;
                UpdateClass();
            }
        }

        [Parameter]
        public bool Disabled
        {
            get => _disabled;
            set
            {
                _disabled = value;
                UpdateClass();
            }
        }

        [Parameter]
        public bool IsIconButton
        {
            get => _isIconButton;
            set
            {
                _isIconButton = value;
                UpdateClass();
            }
        }

        [Parameter]
        public bool IsRoundButton
        {
            get => _isRoundButton;
            set
            {
                _isRoundButton = value;
                UpdateClass();
            }
        }

        [Parameter]
        protected RenderFragment ChildContent { get; set; }

        protected override void OnInit()
        {
            base.OnInit();
            UpdateClass();
        }

        private void UpdateClass()
        {
            ClassNames = classBuilder.GetClasses(this);
        }

        private bool _disabled;
        private bool _isIconButton;
        private bool _isRoundButton;
        private MatButtonType _buttonType;
        private string _class;


        private static ClassBuilder<BaseMatButton> classBuilder = ClassBuilder<BaseMatButton>.Create()
            .Get(b => b.Class)
            .Class("mdc-button")
            .Dictionary(b => b.ButtonType, new Dictionary<MatButtonType, string>()
            {
                {MatButtonType.Raised, "mdc-button--raised"},
                {MatButtonType.Unelevated, "mdc-button--unelevated"},
                {MatButtonType.Outlined, "mdc-button--outlined"},
            });
    }

    public enum MatButtonType
    {
        Text = 0,
        Raised = 1,
        Unelevated = 2,
        Outlined = 3
    }
}