using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MatBlazor
{
    public class BaseMatLink: BaseMatDomComponent
    {
        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await JsInvokeAsync<object>("matBlazor.matButton.init", Ref);
        }

        public BaseMatLink()
        {
            ClassMapper
                .Add("mdc-button")
                .Add("mdc-link")
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

        [Parameter]
        public ICommand Command { get; set; }

        /// <summary>
        ///  Command parameter.
        /// </summary>
        [Parameter]
        public object CommandParameter { get; set; }

        /// <summary>
        /// Link to a url when clicked.
        /// </summary>
        [Parameter]
        public string Href { get; set; }

        /// <summary>
        /// Target of Link when clicked.
        /// </summary>
        [Parameter]
        public string Target { get; set; } = null;

        /// <summary>
        /// Link has raised style.
        /// </summary>
        [Parameter]
        public bool Raised { get; set; }

        /// <summary>
        /// Link has unelevated style.
        /// </summary>
        [Parameter]
        public bool Unelevated { get; set; }

        /// <summary>
        /// Link has outlined style.
        /// </summary>
        [Parameter]
        public bool Outlined { get; set; }

        /// <summary>
        /// Link has dense style.
        /// </summary>

        [Parameter]
        public bool Dense { get; set; }

        /// <summary>
        /// Link is disabled.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; }

        /// <summary>
        /// Specifies the link's icon.
        /// </summary>
        [Parameter]
        public string Icon { get; set; }

        /// <summary>
        /// Specifies if icon has trailing position.
        /// </summary>
        [Parameter]
        public string TrailingIcon { get; set; }

        /// <summary>
        /// Inline label of Button.
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        protected async void OnClickHandler(MouseEventArgs ev)
        {
            await OnClick.InvokeAsync(ev);
            if (Command?.CanExecute(CommandParameter) ?? false)
            {
                Command.Execute(CommandParameter);
            }
        }
    }
}
