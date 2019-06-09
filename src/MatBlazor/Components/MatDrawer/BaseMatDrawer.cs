using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MatBlazor
{
    /// <summary>
    /// The navigation drawer slides in from the left and contains the navigation destinations for your app.
    /// </summary>
    public class BaseMatDrawer : BaseMatComponent
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
                .If("mdc-drawer--dismissible", () => Mode == MatDrawerMode.Dismissible || Mode == MatDrawerMode.Responsive)
                .If("mdc-drawer--modal", () => Mode == MatDrawerMode.Modal);
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

            var mode = Mode;

            if (mode == MatDrawerMode.Responsive)
            {
                this.CallAfterRender(async () =>
                {
                    var isMobile = await Js.InvokeAsync<bool>("matBlazor.utils.isMobile");
                    if (isMobile)
                    {
                        Mode = MatDrawerMode.Modal;
                    }
                    else
                    {
                        Mode = MatDrawerMode.Dismissible;
                    }

                    this.StateHasChanged();


                    this.CallAfterRender(async () =>
                    {
                        await Js.InvokeAsync<object>("matBlazor.matDrawer.init", Ref, new DotNetObjectRef(this));

                        if (Mode == MatDrawerMode.Dismissible)
                        {
                            Opened = true;
                        }
                    });
                });
            }
            else
            {
                this.CallAfterRender(async () =>
                {
                    await Js.InvokeAsync<object>("matBlazor.matDrawer.init", Ref, new DotNetObjectRef(this));
                });
            }
        }
    }
}