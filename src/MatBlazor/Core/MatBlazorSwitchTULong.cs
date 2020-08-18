using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTULong : MatBlazorSwitchT<ulong>
    {
        public override ulong Clamp(ulong v, ulong min, ulong max)
        {
            return v < min ? min : v > max ? max : v;
        }

        public override ulong Increase(ulong v, ulong step)
        {
            checked
            {
                try
                {
                    return (ulong) (v + step);
                }
                catch (OverflowException)
                {
                    return ulong.MaxValue;
                }
            }
        }

        public override ulong Decrease(ulong v, ulong step)
        {
            checked
            {
                try
                {
                    return (ulong) (v - step);
                }
                catch (OverflowException)
                {
                    return ulong.MinValue;
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