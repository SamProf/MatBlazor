using System;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatTabLabel : BaseMatComponent, IDisposable
    {
        [Parameter]
        protected RenderFragment ChildContent { get; set; }

        [CascadingParameter]
        protected BaseMatTabBar Parent { get; set; }

        public BaseMatTabLabel()
        {
            ClassMapper.Add("mdc-tab")
                .If("mdc-tab--active", () => IsActive);
        }

        protected override void OnInit()
        {
            Parent.Labels.Add(this);
        }

        public void Dispose()
        {
            Parent.Labels.Remove(this);
        }

        public bool IsActive
        {
            get { return Parent.Active == this; }
        }

        public void Activate()
        {
            Parent.Active = this;
        }
    }
}
