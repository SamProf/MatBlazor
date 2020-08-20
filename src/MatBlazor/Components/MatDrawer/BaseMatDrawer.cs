using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MatBlazor
{
    /// <summary>
    /// The navigation drawer slides in from the left and contains the navigation destinations for your app.
    /// </summary>
    public class BaseMatDrawer : BaseMatDomComponent
    {
        private bool _opened;

        [Parameter]
        public RenderFragment ChildContent { get; set; }


        [Parameter]
        public MatDrawerMode Mode { get; set; }

        [Parameter]
        public int ContentTabIndex { get; set; } = 0;


        [Parameter]
        public bool Opened
        {
            get => _opened;
            set
            {
                if (this._opened != value)
                {
                    _opened = value;

                    this.CallAfterRender(async () =>
                    {
                        await this.JsInvokeAsync<object>("matBlazor.matDrawer.setOpened", Ref, _opened);
                    });

                    OpenedChanged.InvokeAsync(value);
                }
            }
        }


        [Parameter]
        public EventCallback<bool> OpenedChanged { get; set; }

        private DotNetObjectReference<BaseMatDrawer> dotNetObjectRef;
        public BaseMatDrawer()
        {
            ClassMapper
                .Add("mdc-drawer")
                .Add("mat-drawer")
                .If("mdc-drawer--dismissible", () => Mode == MatDrawerMode.Dismissible)
                .If("mdc-drawer--modal", () => Mode == MatDrawerMode.Modal);

            this.CallAfterRender(async () =>
            {
                dotNetObjectRef ??= CreateDotNetObjectRef(this);
                await JsInvokeAsync<object>("matBlazor.matDrawer.init", Ref, dotNetObjectRef);
            });
        }

        public override void Dispose()
        {
            base.Dispose();
            DisposeDotNetObjectRef(dotNetObjectRef);
        }


        [JSInvokable]
        public void ClosedHandler()
        {
            this.StateHasChanged();
            this._opened = false;
            OpenedChanged.InvokeAsync(false);
        }

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }
    }
}