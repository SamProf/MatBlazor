using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatBlazor.Services.Toast
{
    public class Defaults
    {
        public class Classes
        {
            public const string Toast = "mdc-toast";
            public const string CloseIcon = "cancel";
            public const string ProgressBarClass = "mdc-toast-progress";

            public class Position
            {
                public const string TopCenter = "mdc-toast-top-center";
                public const string BottomCenter = "mdc-toast-bottom-center";
                public const string TopFullWidth = "mdc-toast-top-full-width";
                public const string BottomFullWidth = "mdc-toast-bottom-full-width";
                public const string TopLeft = "mdc-toast-top-left";
                public const string TopRight = "mdc-toast-top-right";
                public const string BottomRight = "mdc-toast-bottom-right";
                public const string BottomLeft = "mdc-toast-bottom-left";
            }

            public class Icons
            {
                public const string Info = "info";
                public const string Success = "check_circle";
                public const string Warning = "warning";
                public const string Danger = "error";
            }
        }
    }
}
