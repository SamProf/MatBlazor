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

        private DotNetObjectRef<BaseMatDialog> dotNetObjectRef;

        public BaseMatDialog()
        {
            
            ClassMapper.Add("mdc-dialog");
            CallAfterRender(async () =>
            {
                dotNetObjectRef = dotNetObjectRef ?? CreateDotNetObjectRef(this);
                await Js.InvokeAsync<object>("matBlazor.matDialog.init", Ref, dotNetObjectRef);
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
    }
}