using Microsoft.AspNetCore.Components;
using System;

namespace MatBlazor
{
    public class BaseMatTabLabel : BaseMatDomComponent, IDisposable
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }


        [CascadingParameter]
        protected BaseMatTabBar Parent { get; set; }

        [CascadingParameter]
        public BaseMatTab Tab { get; set; }

        public BaseMatTabLabel()
        {
            ClassMapper
                .Add("mat-tab-label")
                .Add("mdc-tab")
                .If("mdc-tab--active", () => IsActive);
        }

        protected override void OnInitialized()
        {
            Parent.Tabs.Add(this);
            if (Parent.Active == null)
            {
                Parent.Active = this;
            }
        }

        private bool disposed = false;

        public override void Dispose()
        {
            disposed = true;
            Parent.TabDisposed(this);
        }

        public bool IsActive
        {
            get { return Parent.Active == this; }
        }

        public void Activate()
        {
            if (!disposed)
            {
                Parent.Active = this;
            }
        }
    }
}