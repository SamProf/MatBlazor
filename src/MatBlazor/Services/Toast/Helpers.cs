namespace MatBlazor
{
    public enum ToastType
    {
        Danger,
        Dark,
        Info,
        Light,
        Link,
        Primary,
        Secondary,
        Success,
        Warning
    }
    public enum ToastState
    {
        Init,
        Showing,
        Hiding,
        Visible,
        MouseOver
    }

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

    public class Classes
    {
        public const string Toast = "mdc-toast";
        public const string CloseIcon = "cancel";
    }
}
