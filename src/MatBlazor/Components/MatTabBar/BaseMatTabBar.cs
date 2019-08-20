using System.Collections.Generic;
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
                this.StateHasChanged();
                ActiveChanged.InvokeAsync(value);
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