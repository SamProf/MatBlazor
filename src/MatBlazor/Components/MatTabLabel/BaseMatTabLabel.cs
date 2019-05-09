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
            if (Parent.Active == null)
            {
                Parent.Active = this;
            }
        }

        public void Dispose()
        {
            Parent.ActiveChanged.InvokeAsync(Parent.Active);
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