namespace MatBlazor
{
    /// <summary>
    /// The common options for MatToaster
    /// </summary>
    public class MatToastCommonOptions
    {
        /// <summary>
        /// The main toast class. Defaults to <see cref="MatToastClasses.MatToastClasses"/>
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// The maximum opacity expressed as an integer percentage for a toast in the Visible state. Defaults to 80% where 0 means completely hidden and 100 means solid color.
        /// </summary>
        public int MaximumOpacity { get; set; } = 100;

        /// <summary>
        /// How long the showing transition takes to bring a toast to the MaximumOpacity and set it to the Visible state. Defaults to 500 ms.
        /// </summary>
        public int ShowTransitionDuration { get; set; } = 500;

        /// <summary>
        /// Interval between component repaint during the showing transition. Defaults to 100 ms.
        /// </summary>
        public int ShowStepDuration { get; set; } = 100;

        /// <summary>
        /// How long the toast remain visible without user interaction. Defaults to 5000 ms.
        /// </summary>
        public int VisibleStateDuration { get; set; } = 5000;

        /// <summary>
        /// How long the hiding transition takes to make a toast disappear. Defaults to 500 ms.
        /// </summary>
        public int HideTransitionDuration { get; set; } = 500;

        /// <summary>
        /// Interval between component repaint during the hiding transition. Defaults to 100 ms.
        /// </summary>
        public int HideStepDuration { get; set; } = 100;

        /// <summary>
        /// States if a progress bar has to be shown during the toast Visible state. Defaults to true.
        /// </summary>
        public bool ShowProgressBar { get; set; } = true;

        /// <summary>
        /// Interval between component repaint during the Visible state: it's used only if ShowProgressBar is true. Defaults to 50 ms.
        /// </summary>
        public int ProgressBarStepDuration { get; set; } = 50;

        /// <summary>
        /// States if the close button has to be used for hiding a toast. The button presence disables the default "hide on click" behavior. Defaults to true.
        /// </summary>
        public bool ShowCloseButton { get; set; } = true;

        /// <summary>
        /// The css class for the close icon. Defaults to <see cref="MatToastClasses.CloseIcon"/>.
        /// </summary>
        public string CloseIcon { get; set; } = MatToastClasses.CloseIcon;

        /// <summary>
        /// When true it disables the auto hiding and forces the user to interact with the toast for closing it. Defaults to false.
        /// </summary>
        public bool RequireInteraction { get; set; } = false;
    }
}