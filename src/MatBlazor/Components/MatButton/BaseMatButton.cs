using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace MatBlazor
{
    /// <summary>
    /// Buttons communicate an action a user can take.
    /// They are typically placed throughout your UI, in places like dialogs, forms, cards, and toolbars.
    /// </summary>
    public class BaseMatButton : BaseMatDomComponent
    {
        [Inject]
        public Microsoft.AspNetCore.Components.NavigationManager UriHelper { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await JsInvokeAsync<object>("matBlazor.matButton.init", Ref);
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
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        /// <summary>
        /// Stop propagation of the OnClick event
        /// </summary>
        [Parameter]
        public bool OnClickStopPropagation { get; set; }

        /// <summary>
        ///  Command executed when the user clicks on an element.
        /// </summary>
        [Parameter]
        public ICommand Command { get; set; }


        [Parameter]
        public string Type { get; set; } = null;

        [Parameter]
        public string Name { get; set; } = null;

        [Parameter]
        public string Value { get; set; } = null;


        /// <summary>
        ///  Command parameter.
        /// </summary>
        [Parameter]
        public object CommandParameter { get; set; }

        /// <summary>
        /// Link to a url when clicked.
        /// </summary>
        [Parameter]
        public string Link { get; set; }

        /// <summary>
        /// Target of Link when clicked.
        /// </summary>
        [Parameter]
        public string Target { get; set; } = null;

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

            }
        }


        /// <summary>
        /// Inline label of Button.
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        protected void OnClickHandler(MouseEventArgs ev)
        {
            if (Link != null)
            {
                if (!string.IsNullOrEmpty(Target))
                {
                    JSRuntime.InvokeAsync<object>("open", Link, Target);
                }
                else
                {
                    UriHelper.NavigateTo(Link);
                }
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
