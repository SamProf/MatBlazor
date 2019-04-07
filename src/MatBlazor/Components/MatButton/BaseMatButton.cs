using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MatBlazor.Components.Base;
using MatBlazor.Helpers;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Components;

namespace MatBlazor.Components.MatButton
{
    public class BaseMatButton : BaseMatComponent
    {
        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await Js.InvokeAsync<object>("matBlazor.matButton.init", Ref);
        }

        public BaseMatButton()
        {
            ClassMapper
                .Add("mdc-button")
                .If("mdc-button--raised", () => this.Raised)
                .If("mdc-button--unelevated", () => this.Unelevated)
                .If("mdc-button--outlined", () => this.Outlined)
                .If("mdc-button--dense", () => this.Dense);
        }

        [Parameter]
        protected EventCallback<UIMouseEventArgs> OnClick { get; set; }

        [Parameter]
        protected ICommand Command { get; set; }

               
        [Parameter]
        protected object CommandParameter { get; set; }

        [Parameter]
        public bool Raised
        {
            get => _raised;
            set
            {
                _raised = value;
                ClassMapper.MakeDirty();
            }
        }

        [Parameter]
        public bool Unelevated
        {
            get => _unelevated;
            set
            {
                _unelevated = value;
                ClassMapper.MakeDirty();
            }
        }

        [Parameter]
        public bool Outlined
        {
            get => _outlined;
            set
            {
                _outlined = value;
                ClassMapper.MakeDirty();
            }
        }

        [Parameter]
        public bool Dense
        {
            get => _dense;
            set
            {
                _dense = value;
                ClassMapper.MakeDirty();
            }
        }

        [Parameter]
        public bool Disabled
        {
            get => _disabled;
            set
            {
                _disabled = value;
                ClassMapper.MakeDirty();
            }
        }


        [Parameter]
        public string Icon
        {
            get => _icon;
            set
            {
                _icon = value;
                ClassMapper.MakeDirty();
            }
        }

        [Parameter]
        public string TrailingIcon { get; set; }

        [Parameter]
        public string Label
        {
            get => _label;
            set
            {
                _label = value;
                ClassMapper.MakeDirty();
            }
        }


        [Parameter]
        protected RenderFragment ChildContent { get; set; }

        protected void OnClickHandler(UIMouseEventArgs ev)
        {
            OnClick.InvokeAsync(ev);
            if(Command?.CanExecute(CommandParameter) ?? false)
            {
                Command.Execute(CommandParameter);
            }
        }

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