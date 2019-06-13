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
        protected RenderFragment ChildContent { get; set; }


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
                        await this.Js.InvokeAsync<object>("matBlazor.matDrawer.setOpened", Ref, _opened);
                    });

                    OpenedChanged.InvokeAsync(value);
                }
            }
        }


        [Parameter]
        public EventCallback<bool> OpenedChanged { get; set; }

        public BaseMatDrawer()
        {
            ClassMapper
                .Add("mdc-drawer")
                .Add("mat-drawer")
                .If("mdc-drawer--dismissible", () => Mode == MatDrawerMode.Dismissible)
                .If("mdc-drawer--modal", () => Mode == MatDrawerMode.Modal);


            this.CallAfterRender(async () =>
            {
                await Js.InvokeAsync<object>("matBlazor.matDrawer.init", Ref, DotNetObjectRef.Create(this));
            });
        }


        [JSInvokable]
        public void ClosedHandler()
        {
            this.StateHasChanged();
            this._opened = false;
            OpenedChanged.InvokeAsync(false);
        }

        protected async override Task OnInitAsync()
        {
            await base.OnInitAsync();
        }
    }
}