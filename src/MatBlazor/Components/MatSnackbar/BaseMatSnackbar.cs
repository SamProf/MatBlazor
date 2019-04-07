using System.Threading.Tasks;
using MatBlazor.Components.Base;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MatBlazor.Components.MatSnackbar
{
    public class BaseMatSnackbar : BaseMatComponent
    {
        private bool _isOpen;

        [Parameter]
        protected RenderFragment ChildContent { get; set; }

        [Parameter]
        protected bool Stacked { get; set; }

        [Parameter]
        protected bool Leading { get; set; }

        [Parameter]
        protected bool IsOpen
        {
            get => _isOpen;
            set
            {
                if (IsOpen != value)
                {
                    _isOpen = value;
                    CallAfterRender(async () =>
                    {
                        await Js.InvokeAsync<object>("matBlazor.matSnackbar.setIsOpen", Ref, value);
                    });
                }
            }
        }

        [Parameter]
        public EventCallback<bool> IsOpenChanged { get; set; }

        public BaseMatSnackbar()
        {
            ClassMapper
                .Add("mdc-snackbar")
                .If("mdc-snackbar--stacked", () => Stacked)
                .If("mdc-snackbar--leading", () => Leading);
            CallAfterRender(async () =>
            {
                await Js.InvokeAsync<object>("matBlazor.matSnackbar.init", Ref, new DotNetObjectRef(this));
            });
        }

        [JSInvokable]
        public async Task MatSnackbarClosedHandler()
        {
            _isOpen = false;
            await IsOpenChanged.InvokeAsync(false);
            this.StateHasChanged();
        }
    }
}