using System;

namespace MatBlazor
{
    public enum MatToastPosition
    {
        TopRight,
        TopCenter,
        BottomCenter,
        TopFullWidth,
        BottomFullWidth,
        TopLeft,
        BottomRight,
        BottomLeft,
    }


    public class MatToatsPositionConvertor
    {
        public static string Convert(MatToastPosition position)
        {
            return position switch
            {
                MatToastPosition.TopCenter => "mat-toast-top-center",
                MatToastPosition.BottomCenter => "mat-toast-bottom-center",
                MatToastPosition.TopFullWidth => "mat-toast-top-full-width",
                MatToastPosition.BottomFullWidth => "mat-toast-bottom-full-width",
                MatToastPosition.TopLeft => "mat-toast-top-left",
                MatToastPosition.TopRight => "mat-toast-top-right",
                MatToastPosition.BottomRight => "mat-toast-bottom-right",
                MatToastPosition.BottomLeft => "mat-toast-bottom-left",
                _ => throw new ArgumentOutOfRangeException(nameof(position), position, null),
            };
        }
    }
}