using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MatBlazor
{
    /// <summary>
    /// Toasts provide brief notifications or messages about app processes
    /// </summary>
    public class BaseMatToastContainer : BaseMatDomComponent
    {
        [Inject]
        protected IMatToaster Toaster { get; set; }

        public IEnumerable<MatToast> ToastsToShow
        {
            get
            {
                var toasts = Toaster.Toasts.Take(Toaster.Configuration.MaxDisplayedToasts);

                return Toaster.Configuration.NewestOnTop
                    ? toasts.Reverse()
                    : toasts;
            }
        }

        public BaseMatToastContainer()
        {
            ClassMapper
                .Add("mat-toast-container")
                .Get(() => MatToatsPositionConvertor.Convert(Toaster.Configuration.Position));
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Toaster.OnToastsUpdated += InvokeStateHasChanged;
        }

        public override void Dispose()
        {
            base.Dispose();
            Toaster.OnToastsUpdated -= InvokeStateHasChanged;
        }
    }
}