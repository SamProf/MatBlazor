using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MatBlazor
{
    /// <summary>
    /// Snackbars provide brief messages about app processes at the bottom of the screen.
    /// </summary>
    public class BaseMatSnackbar : BaseMatDomComponent
    {
        private bool _isOpen;
        private CancellationTokenSource _timeoutCts;

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Positions the action buttons below the label instead of alongside it.
        /// </summary>
        [Parameter]
        public bool Stacked { get; set; }

        /// <summary>
        /// Displays the snackbar on the "leading edge" of the screen (the left side in LTR, or the right side in RTL). 
        ///
        /// By default, snackbars are centered horizontally within the viewport. On larger screens, they can optionally be displayed on the leading edge by setting this property.
        /// </summary>
        [Parameter]
        public bool Leading { get; set; }

        /// <summary>
        /// Controls whether or not the snackbar is shown.
        /// </summary>
        [Parameter]
        public bool IsOpen
        {
            get => _isOpen;
            set
            {
                if (IsOpen != value)
                {
                    _isOpen = value;
                    CallAfterRender(async () => await SetIsOpen(value));
                    if (!_isOpen)
                    {
                        _timeoutCts?.Cancel(false);
                    }
                    else if (_isOpen && Timeout >= 0)
                    {
                        if (_timeoutCts != null)
                        {
                            _timeoutCts.Cancel(false);
                            _timeoutCts.Dispose();
                        }
                        _timeoutCts = new CancellationTokenSource();
                        Task.Delay(Timeout, _timeoutCts.Token).ContinueWith(task =>
                        {
                            if (_timeoutCts.IsCancellationRequested) // <-- we were closed before the timeout, so don't close
                            {   
                                return;
                            }
                            _isOpen = false;
                            SetIsOpen(false);
                        });
                    }
                }
            }
        }

        private async Task SetIsOpen(bool value)
        {
            await JsInvokeAsync<object>("matBlazor.matSnackbar.setIsOpen", Ref, value);
        }

        /// <summary>
        /// Timeout in ms after which the snackbar closes itself. Default: 10000 ms
        /// To leave the snackbar open indefinitely set the timeout to -1
        /// </summary>
        [Parameter]
        public int Timeout { get; set; } = 10000; // ms

        /// <summary>
        /// This event is raised whenever IsOpen changes.
        /// </summary>
        [Parameter]
        public EventCallback<bool> IsOpenChanged { get; set; }


        private DotNetObjectReference<BaseMatSnackbar> _dotNetObjectRef;

        public BaseMatSnackbar()
        {
            ClassMapper
                .Add("mdc-snackbar")
                .If("mdc-snackbar--stacked", () => Stacked)
                .If("mdc-snackbar--leading", () => Leading);
            CallAfterRender(async () =>
            {
                _dotNetObjectRef ??= CreateDotNetObjectRef(this);
                await JsInvokeAsync<object>("matBlazor.matSnackbar.init", Ref, _dotNetObjectRef);
            });
        }

        public override void Dispose()
        {
            base.Dispose();
            DisposeDotNetObjectRef(_dotNetObjectRef);
            _timeoutCts?.Cancel(false);
            _timeoutCts?.Dispose();
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