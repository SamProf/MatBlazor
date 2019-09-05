using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// WARNING: In Development progress
    /// </summary>
    public class BaseMatTabBar : BaseMatDomComponent
    {
        private BaseMatTabLabel _active;

        internal List<BaseMatTabLabel> Tabs = new List<BaseMatTabLabel>();

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public BaseMatTabLabel Active
        {
            get => _active;
            set
            {
                if (_active == value)
                {
                    return;
                }

                _active = value;

                this.InvokeStateHasChanged();
                if (!Disposed)
                {
                    ActiveChanged.InvokeAsync(value);
                }
            }
        }

        internal async Task TabDisposed(BaseMatTabLabel tab)
        {
            if (!Disposed)
            {
                await InvokeAsync(() =>
                {
                    Tabs.Remove(tab);
                    if (this.Active == tab)
                    {
                        this.Active = this.Tabs.FirstOrDefault();
                    }
                    else
                    {
                        this.ActiveChanged.InvokeAsync(this.Active);
                    }
                });
            }
        }


        [Parameter]
        public EventCallback<BaseMatTabLabel> ActiveChanged { get; set; }

        public BaseMatTabBar()
        {
            ClassMapper.Add("mdc-tab-bar");
//            this.CallAfterRender(async () => { await this.JsInvokeAsync<object>("matBlazor.matTabBar.init", Ref); });
        }
    }
}