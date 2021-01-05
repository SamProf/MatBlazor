using System;

namespace MatBlazor
{
    /// <summary>
    /// The options from https://flatpickr.js.org/options/
    /// </summary>
    internal class FlatpickrOptions
    {
        public bool EnableTime { get; set; } = false;

        public bool EnableSeconds { get; set; } = false;

        public bool Enable24hours { get; set; } = false;

        public bool EnableWeekNumbers { get; set; } = false;

        public bool DisableMobile { get; set; } = false;

        public string Position { get; set; } = "auto";

        public string Mode { get; set; } = "single";

        public DateTime? DefaultDate { get; set; }

        public DateTime? Minimum { get; set; }

        public DateTime? Maximum { get; set; }

        public DateTime? Value { get; set; }

        public string Locale { get; set; } = "en";
    }
}