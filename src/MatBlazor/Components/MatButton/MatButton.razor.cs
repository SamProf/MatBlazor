using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MatBlazor
{
    /// <summary>
    /// Buttons communicate an action a user can take.
    /// They are typically placed throughout your UI, in places like dialogs, forms, cards, and toolbars.
    /// </summary>
    partial class MatButton : BaseMatDomComponent
    {
        [Inject]
        public Microsoft.AspNetCore.Components.NavigationManager UriHelper { get; set; }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await JsInvokeAsync<object>("matBlazor.matButton.init", Ref);
        }

        public MatButton()
        {
            ClassMapper
                .Add("mdc-button")
                .If("mdc-button--raised", () => this.Raised)
                .If("mdc-button--unelevated", () => this.Unelevated)
                .If("mdc-button--outlined", () => this.Outlined)
                .If("mdc-button--dense", () => this.Dense);
        }

        /// <summary>
        /// Event occurs when the user clicks on an element.
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        /// <summary>
        /// Stop propagation of the OnClick event
        /// </summary>
        [Parameter]
        public bool OnClickStopPropagation { get; set; }

        /// <summary>
        /// Command executed when the user clicks on an element.
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
        /// Command parameter.
        /// </summary>
        [Parameter]
        public object CommandParameter { get; set; }

        /// <summary>
        /// Link to a url when clicked.
        /// </summary>
        [Parameter]
        public string Link { get; set; }

        /// <summary>
        /// Force browser to redirect outside component router-space.
        /// </summary>
        [Parameter]
        public bool ForceLoad { get; set; }

        /// <summary>
        /// Target of Link when clicked.
        /// </summary>
        [Parameter]
        public string Target { get; set; } = null;


        /// <summary>
        /// Button has raised style.
        /// </summary>
        [Parameter]
        public bool Raised { get; set; }

        /// <summary>
        /// Button has unelevated style.
        /// </summary>
        [Parameter]
        public bool Unelevated { get; set; }

        /// <summary>
        /// Button has outlined style.
        /// </summary>
        [Parameter]
        public bool Outlined { get; set; }

        /// <summary>
        /// Button has dense style.
        /// </summary>
        [Parameter]
        public bool Dense { get; set; }

        /// <summary>
        /// Button is disabled.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; }

        /// <summary>
        /// Specifies an button's icon.
        /// </summary>
        [Parameter]
        public string Icon { get; set; }

        /// <summary>
        /// Specifies if icon has trailing position.
        /// </summary>
        [Parameter]
        public string TrailingIcon { get; set; }

        /// <summary>
        /// Text label of Button.
        /// </summary>
        [Parameter]
        public string Label { get; set; }


        /// <summary>
        /// Inline label of Button.
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        protected async void OnClickHandler(MouseEventArgs ev)
        {
            if (Link != null)
            {
                if (!string.IsNullOrEmpty(Target))
                {
                    try
                    {
                        await JsInvokeAsync<object>("open", Link, Target);
                    }
                    catch (TaskCanceledException ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
                else
                {
                    UriHelper.NavigateTo(Link, ForceLoad);
                }
            }
            else
            {
                await OnClick.InvokeAsync(ev);
                if (Command?.CanExecute(CommandParameter) ?? false)
                {
                    Command.Execute(CommandParameter);
                }
            }
        }
    }
}
