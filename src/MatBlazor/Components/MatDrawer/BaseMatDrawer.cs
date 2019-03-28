using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MatBlazor.Components.MatDrawer
{
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

                    OpenedChanged?.Invoke(value);
                }
            }
        }


        [Parameter]
        public Action<bool> OpenedChanged { get; set; }

        public BaseMatDrawer()
        {
            

            ClassMapper
                .Add("mdc-drawer")
                .If("mdc-drawer--dismissible", () => Mode == MatDrawerMode.Dismissible)
                .If("mdc-drawer--modal", () => Mode == MatDrawerMode.Modal);

            this.CallAfterRender(async () =>
            {
                await Js.InvokeAsync<object>("matBlazor.matDrawer.init", Ref, new DotNetObjectRef(this));
            });
        }



        [JSInvokable]
        public void ClosedHandler()
        {
            this.StateHasChanged();
            this._opened = false;
            OpenedChanged?.Invoke(false);
        }

    }
}