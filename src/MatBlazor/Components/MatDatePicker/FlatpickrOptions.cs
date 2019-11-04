namespace MatBlazor
{
    /// <summary>
    /// The options from https://flatpickr.js.org/options/
    /// </summary>
    internal class FlatpickrOptions
    {
        public bool EnableTime { get; set; } = false;

        public bool EnableSeconds { get; set; } = false;

        public bool NoCalendar { get; set; } = false;

        public bool Enable24hours { get; set; } = false;

        public bool EnableWeekNumbers { get; set; } = false;

        public string DateFormat { get; set; } = "Y-m-d";

        public bool AllowInput { get; set; } = false;

        public bool DisableMobile { get; set; } = false;

        public bool Inline { get; set; } = false;

        public string Position { get; set; } = "auto";

        public string Mode { get; set; } = "single";

        public string AltInputClass { get; set; } = "";

        public string AltFormat { get; set; } = "F j, Y";
    }
}