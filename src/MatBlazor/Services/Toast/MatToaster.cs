using System;
using System.Collections.Generic;
using System.Linq;

namespace MatBlazor
{
    public class MatToaster : IBaseMatToastContainer
    {
        public Configuration Configuration { get; }
        public event Action OnToastsUpdated;
        public IList<IBaseMatToast> Toasts { get; private set; } = new List<IBaseMatToast>();

        public MatToaster(Configuration configuration)
        {
            Configuration = configuration;
            Configuration.OnUpdate += ConfigurationUpdated;
        }

        public void Add(string message, ToastType type, string title, string icon, Action<Options> configure)
        {
            if (string.IsNullOrEmpty(message)) return;

            message = message.Trim();
            title = string.IsNullOrEmpty(title) ? "" : title.Trim();

            if (Configuration.PreventDuplicates && ToastAlreadyPresent(message, title, type))
            {
                return;
            }

            var options = new Options(type, Configuration);
            configure?.Invoke(options);

            var toast = new IBaseMatToast(message, title, icon, options);
            toast.OnClose += Remove;
            Toasts.Add(toast);

            OnToastsUpdated?.Invoke();
        }

        public void Clear()
        {
            var toasts = Toasts;
            Toasts = new List<IBaseMatToast>();
            OnToastsUpdated?.Invoke();
            DisposeToasts(toasts);
        }

        public void Remove(IBaseMatToast toast)
        {
            toast.OnClose -= Remove;
            Toasts.Remove(toast);

            OnToastsUpdated?.Invoke();
            toast.Dispose();
        }

        private bool ToastAlreadyPresent(string message, string title, ToastType type)
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

        private void DisposeToasts(IEnumerable<IBaseMatToast> toasts)
        {
            foreach (var toast in toasts)
            {
                toast.OnClose -= Remove;
                toast.Dispose();
            }
        }
    }
}