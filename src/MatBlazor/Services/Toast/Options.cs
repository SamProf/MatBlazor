using System;
using System.Threading.Tasks;
using MatBlazor.Components.MatToast;

namespace MatBlazor.Services.Toast
{
    public class Options : CommonOptions
    {
        /// <summary>
        /// The async <see cref="Func{MatToast,Task}"/> to be called on user click
        /// </summary>
        public Func<IBaseMatToast, Task> Onclick { get; set; }

        /// <summary>
        /// The <see cref="Type"/>
        /// </summary>
        public ToastType Type { get; }

        /// <summary>
        /// The css class representing the toast state
        /// </summary>
        public string ToastTypeClass { get; set; }

        public Options(ToastType type, Configuration configuration)
        {
            Type = type;
            ToastTypeClass = configuration.ToastTypeClass(type);

            ToastClass = configuration.ToastClass;
            MaximumOpacity = configuration.MaximumOpacity;

            ShowTransitionDuration = configuration.ShowTransitionDuration;

            VisibleStateDuration = configuration.VisibleStateDuration;

            HideTransitionDuration = configuration.HideTransitionDuration;

            ShowProgressBar = configuration.ShowProgressBar;
            ProgressBarClass = configuration.ProgressBarClass;

            ShowCloseButton = configuration.ShowCloseButton;
            CloseIcon = configuration.CloseIcon;

            RequireInteraction = configuration.RequireInteraction;
        }
    }
}
