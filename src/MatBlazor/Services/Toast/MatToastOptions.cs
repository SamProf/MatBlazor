using System;
using System.Threading.Tasks;

namespace MatBlazor
{
    public class MatToastOptions : MatToastCommonOptions
    {
        /// <summary>
        /// The async <see cref="Func{MatToast,Task}"/> to be called on user click
        /// </summary>
        public Func<MatToast, Task> Onclick { get; set; }

        /// <summary>
        /// The <see cref="Type"/>
        /// </summary>
        public MatToastType Type { get; }

        public MatToastOptions(MatToastType type, MatToastConfiguration configuration)
        {
            Type = type;
        
            Class = configuration.Class;
            MaximumOpacity = configuration.MaximumOpacity;

            ShowTransitionDuration = configuration.ShowTransitionDuration;

            VisibleStateDuration = configuration.VisibleStateDuration;

            HideTransitionDuration = configuration.HideTransitionDuration;

            ShowProgressBar = configuration.ShowProgressBar;

            ShowCloseButton = configuration.ShowCloseButton;
            CloseIcon = configuration.CloseIcon;

            RequireInteraction = configuration.RequireInteraction;
        }
    }
}