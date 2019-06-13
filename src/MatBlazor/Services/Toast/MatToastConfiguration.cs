using System;

namespace MatBlazor
{
    /// <summary>
    /// Represents the global <see cref="MatToastConfiguration"/> instance
    /// </summary>
    public class MatToastConfiguration : MatToastCommonOptions
    {
        private bool _newestOnTop;
        private bool _preventDuplicates;
        private int _maxDisplayedToasts;
        private MatToastPosition _position;

        internal event Action OnUpdate;

        /// <summary>
        /// Drives the toast display sequence: when true the newest displayable toast will be on top. Otherwise it will be on the bottom. Defaults to true.
        /// </summary>
        public bool NewestOnTop
        {
            get => _newestOnTop;
            set
            {
                _newestOnTop = value;
                OnUpdate?.Invoke();
            }
        }

        /// <summary>
        /// When true, a new toast with the same type, title and message of an already present toast will be ignored. Defaults to true.
        /// </summary>
        public bool PreventDuplicates
        {
            get => _preventDuplicates;
            set
            {
                _preventDuplicates = value;
                OnUpdate?.Invoke();
            }
        }

        /// <summary>
        /// The maximum number of toasts to be displayed at the same time. Defaults to 5
        /// </summary>
        public int MaxDisplayedToasts
        {
            get => _maxDisplayedToasts;
            set
            {
                _maxDisplayedToasts = value;
                OnUpdate?.Invoke();
            }
        }

        /// <summary>
        /// The css class driving the toast position in the screen. The predefined positions are contained in <see cref="MatToastPosition"/>. Defaults to <see cref="MatToastPosition.TopRight"/>
        /// </summary>
        public MatToastPosition Position
        {
            get => _position;
            set
            {
                _position = value;
                OnUpdate?.Invoke();
            }
        }

        public MatToastConfiguration()
        {
            NewestOnTop = true;
            PreventDuplicates = true;
            MaxDisplayedToasts = 5;
        }

        internal static string ToastTypeClass(MatToastType type)
        {
            switch (type)
            {
                case MatToastType.Danger: return "mat-toast-danger";
                case MatToastType.Dark: return "mat-toast-dark";
                case MatToastType.Info: return "mat-toast-info";
                case MatToastType.Light: return "mat-toast-light";
                case MatToastType.Link: return "mat-toast-light";
                case MatToastType.Primary: return "mat-toast-primary";
                case MatToastType.Secondary: return "mat-toast-secondary";
                case MatToastType.Success: return "mat-toast-success";
                case MatToastType.Warning: return "mat-toast-warning";
                default: return "mat-toast-info";
            }
        }
    }
}