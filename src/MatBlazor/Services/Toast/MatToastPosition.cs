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
            switch (position)
            {
                case MatToastPosition.TopCenter:
                    return "mat-toast-top-center";
                case MatToastPosition.BottomCenter:
                    return "mat-toast-bottom-center";
                case MatToastPosition.TopFullWidth:
                    return "mat-toast-top-full-width";
                case MatToastPosition.BottomFullWidth:
                    return "mat-toast-bottom-full-width";
                case MatToastPosition.TopLeft:
                    return "mat-toast-top-left";
                case MatToastPosition.TopRight:
                    return "mat-toast-top-right";
                case MatToastPosition.BottomRight:
                    return "mat-toast-bottom-right";
                case MatToastPosition.BottomLeft:
                    return "mat-toast-bottom-left";
                default:
                    throw new ArgumentOutOfRangeException(nameof(position), position, null);
            }
        }
    }
}