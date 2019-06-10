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

        [Parameter]
        protected RenderFragment ChildContent { get; set; }

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
                        await Js.InvokeAsync<object>("matBlazor.matDialog.setIsOpen", Ref, value);
                    });
                }
            }
        }

        [Parameter]
        public EventCallback<bool> IsOpenChanged { get; set; }

        public BaseMatDialog()
        {
            ClassMapper.Add("mdc-dialog");
            CallAfterRender(async () => { await Js.InvokeAsync<object>("matBlazor.matDialog.init", Ref, new DotNetObjectRef(this)); });
        }

        [JSInvokable]
        public async Task MatDialogClosedHandler()
        {
            _isOpen = false;
            await IsOpenChanged.InvokeAsync(false);
            this.StateHasChanged();
        }
    }
}