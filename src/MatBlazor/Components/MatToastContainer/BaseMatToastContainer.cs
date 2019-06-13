using System;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Collections.Generic;
using MatBlazor.Components.MatToast;

namespace MatBlazor
{
    /// <summary>
    /// Toasts provide brief notifications or messages about app processes
    /// </summary>
    public class BaseMatToastContainer : BaseMatDomComponent, IDisposable
    {
        [Inject]
        protected IBaseMatToastContainer ToastContainer { get; set; }

        public IEnumerable<IBaseMatToast> MatToasts
        {
            get
            {
                var toasts = ToastContainer.Toasts.Take(ToastContainer.Configuration.MaxDisplayedToasts);

                return ToastContainer.Configuration.NewestOnTop
                    ? toasts.Reverse()
                    : toasts;
            }
        }

        public BaseMatToastContainer()
        {
  
        }

        public string Class => ToastContainer.Configuration.PositionClass;

        protected override void OnInit()
        {
            base.OnInit();
            ToastContainer.OnToastsUpdated += () => Invoke(StateHasChanged);
        }

        public void Dispose()
        {
            ToastContainer.OnToastsUpdated -= StateHasChanged;
        }
    }
}
