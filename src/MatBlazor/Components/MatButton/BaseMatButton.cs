using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// Buttons communicate an action a user can take.
    /// They are typically placed throughout your UI, in places like dialogs, forms, cards, and toolbars.
    /// </summary>
    public class BaseMatButton : BaseMatComponent
    {
        [Inject]
        public Microsoft.AspNetCore.Components.IUriHelper UriHelper { get; set; }


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

        /// <summary>
        ///  Event occurs when the user clicks on an element.
        /// </summary>
        [Parameter]
        protected EventCallback<UIMouseEventArgs> OnClick { get; set; }

        /// <summary>
        ///  Command executed when the user clicks on an element.
        /// </summary>
        [Parameter]
        protected ICommand Command { get; set; }


        [Parameter]
        protected string Type { get; set; } = null;

        [Parameter]
        protected string Name { get; set; } = null;

        [Parameter]
        protected string Value { get; set; } = null;


        /// <summary>
        ///  Command parameter.
        /// </summary>
        [Parameter]
        protected object CommandParameter { get; set; }

        /// <summary>
        /// Link to a url when clicked.
        /// </summary>
        [Parameter]
        public string Link { get; set; }

        /// <summary>
        /// Button has raised style.
        /// </summary>
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

        /// <summary>
        /// Button has unelevated style.
        /// </summary>
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

        /// <summary>
        /// Button has outlined style.
        /// </summary>
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

        /// <summary>
        /// Button has dense style.
        /// </summary>

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

        /// <summary>
        /// Button is disabled.
        /// </summary>
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

        /// <summary>
        /// Specifies an button's icon.
        /// </summary>
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

        /// <summary>
        /// Specifies if icon has trailing position.
        /// </summary>
        [Parameter]
        public string TrailingIcon { get; set; }

        /// <summary>
        /// Text label of Button.
        /// </summary>
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


        /// <summary>
        /// Inline label of Button.
        /// </summary>
        [Parameter]
        protected RenderFragment ChildContent { get; set; }

        protected void OnClickHandler(UIMouseEventArgs ev)
        {
            if (Link != null)
            {
                UriHelper.NavigateTo(Link);
            }
            else
            {
                OnClick.InvokeAsync(ev);
                if (Command?.CanExecute(CommandParameter) ?? false)
                {
                    Command.Execute(CommandParameter);
                }
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