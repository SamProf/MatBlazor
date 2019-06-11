using System;
using MatBlazor.Services.Toast;

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

        /// <summary>
        ///  A <see cref="IconClasses"/> instance containing the css classes for all the <see cref="ToastState"/> states.
        /// </summary>
        public IconClasses IconClasses = new IconClasses();

        public Configuration()
        {
            PositionClass = Defaults.Classes.Position.BottomRight;
            NewestOnTop = true;
            PreventDuplicates = true;
            MaxDisplayedToasts = 5;
        }

        internal string ToastTypeClass(ToastType type)
        {
            switch (type)
            {
                case ToastType.Info: return IconClasses.Info;
                case ToastType.Danger: return IconClasses.Danger;
                case ToastType.Success: return IconClasses.Success;
                case ToastType.Warning: return IconClasses.Warning;
                default: return IconClasses.Info;
            }
        }
    }
}
