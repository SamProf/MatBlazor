using System;
using System.Collections.Generic;
using System.Linq;

namespace MatBlazor
{
    public class MatToaster : IMatToaster
    {
        public MatToastConfiguration Configuration { get; }
        public event Action OnToastsUpdated;
        public IList<MatToast> Toasts { get; private set; } = new List<MatToast>();

        public MatToaster(MatToastConfiguration configuration)
        {
            Configuration = configuration;
            Configuration.OnUpdate += ConfigurationUpdated;
        }

        public MatToast Add(string message, MatToastType type, string title, string icon, Action<MatToastOptions> configure)
        {
            if (string.IsNullOrEmpty(message))
            {
                return null;
            }

            message = message.Trim();
            title = string.IsNullOrEmpty(title) ? "" : title.Trim();

            if (Configuration.PreventDuplicates && ToastAlreadyPresent(message, title, type))
            {
                return null;
            }

            var options = new MatToastOptions(type, Configuration);
            configure?.Invoke(options);

            var toast = new MatToast(message, title, icon, options);
            toast.OnClose += Remove;
            Toasts.Add(toast);

            OnToastsUpdated?.Invoke();

            return toast;
        }

        public void Clear()
        {
            var toasts = Toasts;
            Toasts = new List<MatToast>();
            OnToastsUpdated?.Invoke();
            DisposeToasts(toasts);
        }

        public void Remove(MatToast toast)
        {
            toast.OnClose -= Remove;
            Toasts.Remove(toast);

            OnToastsUpdated?.Invoke();
//            toast.Dispose();
        }

        private bool ToastAlreadyPresent(string message, string title, MatToastType type)
        {
            return Toasts.Any(t =>
                message.Equals(t.Message) &&
                title.Equals(t.Title) &&
                type.Equals(t.Options.Type)
            );
        }

        private void ConfigurationUpdated()
        {
            OnToastsUpdated?.Invoke();
        }

        public void Dispose()
        {
            Configuration.OnUpdate -= ConfigurationUpdated;
            DisposeToasts(Toasts);
        }

        private void DisposeToasts(IEnumerable<MatToast> toasts)
        {
            foreach (var toast in toasts)
            {
                toast.OnClose -= Remove;
//                toast.Dispose();
            }
        }
    }
}
