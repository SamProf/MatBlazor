using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTShort : MatBlazorSwitchT<short>
    {
        public override short Increase(short v, short step, short max)
        {
            var v2 = (short) (v + step);
            return v2 <= max ? v2 : max;
        }

        public override short Decrease(short v, short step, short min)
        {
            var v2 = (short) (v - step);
            return v2 >= min ? v2 : min;
        }

        public override short Round(short v, int dp)
        {
            return v;
        }

        public override short Minimum => short.MinValue;
        public override short Maximum => short.MaxValue;

        public override short Step => 1;

        public override string FormatValueAsString(short v, string format)
        {
            return v.ToString(format);
        }
        public override short ParseFromString(string v, string format)
        {
            return short.Parse(v, NumberStyles.Any);
        }

        public override short FromDateTimeNull(DateTime? v)
        {
            throw new NotImplementedException();
        }

        public override DateTime? ToDateTimeNull(short v)
        {
            throw new NotImplementedException();
        }

        public override short FromBoolNull(bool? v, bool indeterminate)
        {
            throw new NotImplementedException();
        }
    }
}