using System;

namespace MatBlazor
{
    /// <inheritdoc />
    /// <summary>
    /// Represents an instance of a Toast
    /// It handles the user interactions and orchestrates the the state transitions
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
                switch (options.Type)
                {
                    case MatToastType.Danger:
                        Icon = "error";
                        break;
                    case MatToastType.Dark:
                        Icon = "error";
                        break;
                    case MatToastType.Info:
                        Icon = "info";
                        break;
                    case MatToastType.Light:
                        Icon = "notification_important";
                        break;
                    case MatToastType.Link:
                        Icon = "link";
                        break;
                    case MatToastType.Primary:
                        Icon = "announcement";
                        break;
                    case MatToastType.Secondary:
                        Icon = "notification_important";
                        break;
                    case MatToastType.Success:
                        Icon = "check_circle";
                        break;
                    case MatToastType.Warning:
                        Icon = "warning";
                        break;
                    default:
                        Icon = "notification_important";
                        break;
                };
            }

            Options = options;
        }
    }
}