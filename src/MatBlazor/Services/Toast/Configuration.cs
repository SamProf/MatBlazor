using System;
using MatBlazor.MatToaster.Helpers;

namespace MatBlazor.Services.Toast
{
    /// <summary>
    /// Represents the global <see cref="Configuration"/> instance
    /// </summary>
    public class Configuration : CommonOptions
    {
        private bool _newestOnTop;
        private bool _preventDuplicates;
        private int _maxDisplayedToasts;
        private string _positionClass;

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
        /// The css class driving the toast position in the screen. The predefined positions are contained in <see cref="Defaults.Classes.Position"/>. Defaults to <see cref="Defaults.Classes.Position.TopRight"/>
        /// </summary>
        public string PositionClass
        {
            get => _positionClass;
            set
            {
                _positionClass = value;
                OnUpdate?.Invoke();
            }
        }

        public Configuration()
        {
            PositionClass = Position.BottomRight;
            NewestOnTop = true;
            PreventDuplicates = true;
            MaxDisplayedToasts = 5;
        }

        internal string ToastTypeClass(ToastType type)
        {
            switch (type)
            {
                case ToastType.Danger: return "mdc-toast-danger";
                case ToastType.Dark: return "mdc-toast-dark";
                case ToastType.Info: return "mdc-toast-info";
                case ToastType.Light: return "mdc-toast-light";
                case ToastType.Link: return "mdc-toast-light";
                case ToastType.Primary: return "mdc-toast-primary";
                case ToastType.Secondary: return "mdc-toast-secondary";
                case ToastType.Success: return "mdc-toast-success";
                case ToastType.Warning: return "mdc-toast-warning";
                default: return "mdc-toast-info";
            }
        }
    }
}
