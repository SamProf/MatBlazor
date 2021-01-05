using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatBlazor
{
    /// <summary>
    /// WARNING: In Development progress
    /// </summary>
    public class BaseMatTabBar : BaseMatDomComponent
    {
        private BaseMatTabLabel _active;
        private int _activeIndex;
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
                _activeIndex = this.Tabs.IndexOf(_active);

                this.InvokeStateHasChanged();
                if (!Disposed)
                {
                    ActiveChanged.InvokeAsync(value);
                    ActiveIndexChanged.InvokeAsync(_activeIndex);
                }
            }
        }

        [Parameter]
        public int ActiveIndex 
        {
            get => _activeIndex;
            set
            {
                var tab = this.Tabs?.ElementAtOrDefault(value);
                if (tab == null)
                {
                    return;
                }
                _activeIndex = value;
                Active = tab;
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
                        this.ActiveIndexChanged.InvokeAsync(this.ActiveIndex);
                    }
                });
            }
        }


        [Parameter]
        public EventCallback<BaseMatTabLabel> ActiveChanged { get; set; }

        [Parameter]
        public EventCallback<int> ActiveIndexChanged { get; set; }

        public BaseMatTabBar()
        {
            ClassMapper.Add("mdc-tab-bar");
//            this.CallAfterRender(async () => { await this.JsInvokeAsync<object>("matBlazor.matTabBar.init", Ref); });
        }
    }
}