using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTULong : MatBlazorSwitchT<ulong>
    {
        public override ulong Increase(ulong v, ulong step, ulong max)
        {
            checked
            {
                try
                {
                    var v2 = (ulong) (v + step);
                    return v2 <= max ? v2 : max;
                }
                catch (OverflowException e)
                {
                    return max;
                }
            }
        }

        public override ulong Decrease(ulong v, ulong step, ulong min)
        {
            checked
            {
                try
                {
                    var v2 = (ulong) (v - step);
                    return v2 >= min ? v2 : min;
                }
                catch (OverflowException e)
                {
                    return min;
                }
            }
        }

        public override ulong Round(ulong v, int dp)
        {
            return v;
        }

        public override ulong GetMinimum() => ulong.MinValue;
        public override ulong GetMaximum() => ulong.MaxValue;

        public override ulong GetStep() => 1;

        public override string FormatValueAsString(ulong v, string format)
        {
            return v.ToString(format);
        }

        public override ulong ParseFromString(string v, string format)
        {
            return ulong.Parse(v, NumberStyles.Any);
        }

        public override ulong FromDateTimeNull(DateTime? v)
        {
            throw new NotImplementedException();
        }

        public override DateTime? ToDateTimeNull(ulong v)
        {
            throw new NotImplementedException();
        }

        public override ulong FromBoolNull(bool? v, bool indeterminate)
        {
            throw new NotImplementedException();
        }

        public override ulong FromDecimal(decimal v)
        {
            return (ulong) v;
        }
    }
}