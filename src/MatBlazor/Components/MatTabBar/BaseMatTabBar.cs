using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// WARNING: In Development progress
    /// </summary>
    public class BaseMatTabBar : BaseMatComponent
    {
        private BaseMatTabLabel _active;

        [Parameter]
        protected RenderFragment ChildContent { get; set; }

        internal List<BaseMatTabLabel> Labels { get; }

        internal BaseMatTabLabel Active
        {
            get => _active;
            set
            {
                _active = value;
                this.StateHasChanged();
            }
        }

        public BaseMatTabBar()
        {
            ClassMapper.Add("mdc-tab-bar");
            Labels = new List<BaseMatTabLabel>();
        }
    }
}
