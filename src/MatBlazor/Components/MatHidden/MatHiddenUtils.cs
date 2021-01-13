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
                    return breakpoint switch
                    {
                        MatBreakpoint.XS => width < (decimal)MatBreakpoint.SM,
                        MatBreakpoint.SM => width < (decimal)MatBreakpoint.MD,
                        MatBreakpoint.MD => width < (decimal)MatBreakpoint.LG,
                        MatBreakpoint.LG => width < (decimal)MatBreakpoint.XL,
                        MatBreakpoint.XL => true,
                        _ => throw new ArgumentOutOfRangeException(nameof(breakpoint), breakpoint, null),
                    };
                case MatHiddenDirection.Up:
                    return width >= (decimal) breakpoint;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
    }
}