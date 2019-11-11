using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTULong : MatBlazorSwitchT<ulong>
    {
        public override ulong Increase(ulong v, ulong step, ulong max)
        {
            var v2 = (ulong) (v + step);
            return v2 <= max ? v2 : max;
        }

        public override ulong Decrease(ulong v, ulong step, ulong min)
        {
            var v2 = (ulong) (v - step);
            return v2 >= min ? v2 : min;
        }

        public override ulong Round(ulong v, int dp)
        {
            return v;
        }

        public override ulong Minimum => ulong.MinValue;
        public override ulong Maximum => ulong.MaxValue;

        public override ulong Step => 1;

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
    }
}