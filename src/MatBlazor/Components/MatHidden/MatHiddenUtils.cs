using System;

namespace MatBlazor
{
    public static class MatHiddenUtils
    {
        public static bool IsHidden(decimal width, MatBreakpoint breakpoint, MatHiddenDirection direction)
        {
            switch (direction)
            {
                case MatHiddenDirection.Down:
                    switch (breakpoint)
                    {
                        case MatBreakpoint.XS:
                            return width < (decimal) MatBreakpoint.SM;
                        case MatBreakpoint.SM:
                            return width < (decimal) MatBreakpoint.MD;
                        case MatBreakpoint.MD:
                            return width < (decimal) MatBreakpoint.LG;
                        case MatBreakpoint.LG:
                            return width < (decimal) MatBreakpoint.XL;
                        case MatBreakpoint.XL:
                            return true;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(breakpoint), breakpoint, null);
                    }

                    break;
                case MatHiddenDirection.Up:
                    return width >= (decimal) breakpoint;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
    }
}