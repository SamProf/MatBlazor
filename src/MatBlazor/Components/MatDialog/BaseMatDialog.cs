using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MatBlazor
{
    /// <summary>
    /// Dialogs inform users about a specific task and may contain critical information, require decisions, or involve multiple tasks.
    /// </summary>
    public class BaseMatDialog : BaseMatDomComponent
    {
        private bool _isOpen;

        // true is the mdc default
        private bool _canBeClosed = true;

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public bool IsOpen
        {
            get => _isOpen;
            set
            {
                if (IsOpen != value)
                {
                    _isOpen = value;
                    CallAfterRender(async () =>
                    {
                        await JsInvokeAsync<object>("matBlazor.matDialog.setIsOpen", Ref, value);
                    });
                }
            }
        }

        /// <summary>
        /// Event occurs when the dialog is opened or closed.
        /// </summary>
        [Parameter]
        public EventCallback<bool> IsOpenChanged { get; set; }

        /// <summary>
        /// Indicates if the user is able to close the dialog via Escape or click on the Scrim.
        /// </summary>
        [Parameter]
        public bool CanBeClosed
        {
            get => _canBeClosed;
            set
            {
                if (CanBeClosed != value)
                {
                    _canBeClosed = value;
                    CallAfterRender(async () =>
                    {
                        await JsInvokeAsync<object>("matBlazor.matDialog.setCanBeClosed", Ref, value);
                    });
                }
            }
        }

        private DotNetObjectReference<BaseMatDialog> dotNetObjectRef;

        public BaseMatDialog()
        {

            ClassMapper.Add("mdc-dialog");
            CallAfterRender(async () =>
            {
                dotNetObjectRef ??= CreateDotNetObjectRef(this);
                await JsInvokeAsync<object>("matBlazor.matDialog.init", Ref, dotNetObjectRef);
            });
        }

        public override void Dispose()
        {
            base.Dispose();
            DisposeDotNetObjectRef(dotNetObjectRef);
        }

        [JSInvokable]
        public async Task MatDialogClosedHandler()
        {
            _isOpen = false;
            await IsOpenChanged.InvokeAsync(false);
            this.StateHasChanged();
        }

        [JSInvokable]
        public async Task MatDialogOpenedHandler()
        {
            _isOpen = true;
            await IsOpenChanged.InvokeAsync(true);
            this.StateHasChanged();
        }
    }
}