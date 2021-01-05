using System;

namespace MatBlazor
{
    /// <inheritdoc />
    /// <summary>
    /// Represents an instance of a Toast
    /// It handles the user interactions and orchestrates the state transitions
    /// </summary>
    public class MatToast
    {
        public MatToastOptions Options { get; }

        public string Title { get; }

        public string Message { get; }

        public string Icon { get; set; }

        public event Action<MatToast> OnClose;
        public event Action OnUpdate;


        public void InvokeOnUpdate()
        {
            OnUpdate?.Invoke();
        }

        public void InvokeOnClose()
        {
            OnClose?.Invoke(this);
        }

        public MatToast(string message, string title, string icon, MatToastOptions options)
        {
            Message = message;
            Title = title;
            Icon = icon;

            if (string.IsNullOrEmpty(icon))
            {
                Icon = options.Type switch
                {
                    MatToastType.Danger => "error",
                    MatToastType.Dark => "error",
                    MatToastType.Info => "info",
                    MatToastType.Light => "notification_important",
                    MatToastType.Link => "link",
                    MatToastType.Primary => "announcement",
                    MatToastType.Secondary => "notification_important",
                    MatToastType.Success => "check_circle",
                    MatToastType.Warning => "warning",
                    _ => "notification_important",
                };
            }

            Options = options;
        }
    }
}