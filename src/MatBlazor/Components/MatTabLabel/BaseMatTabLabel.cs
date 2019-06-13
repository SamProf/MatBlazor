using System;
using System.Linq;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatTabLabel : BaseMatDomComponent, IDisposable
    {
        [Parameter]
        protected RenderFragment ChildContent { get; set; }


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

        protected override void OnInit()
        {
            Parent.Tabs.Add(this);
            if (Parent.Active == null)
            {
                Parent.Active = this;
            }
        }

        private bool disposed = false;

        public void Dispose()
        {
            disposed = true;
            Parent.Tabs.Remove(this);
            if (Parent.Active == this)
            {
                Parent.Active = Parent.Tabs.FirstOrDefault();
            }
            else
            {
                Parent.ActiveChanged.InvokeAsync(Parent.Active);
            }
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