using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTLong : MatBlazorSwitchT<long>
    {
        public override long Increase(long v, long step, long max)
        {
            checked
            {
                try
                {
                    var v2 = (long) (v + step);
                    return v2 <= max ? v2 : max;
                }
                catch (OverflowException e)
                {
                    return max;
                }
            }
        }

        public override long Decrease(long v, long step, long min)
        {
            checked
            {
                try
                {
                    var v2 = (long) (v - step);
                    return v2 >= min ? v2 : min;
                }
                catch (OverflowException e)
                {
                    return min;
                }
            }
        }

        public override long Round(long v, int dp)
        {
            return v;
        }

        public override long GetMinimum() => long.MinValue;
        public override long GetMaximum() => long.MaxValue;

        public override long GetStep() => 1;

        public override string FormatValueAsString(long v, string format)
        {
            return v.ToString(format);
        }

        public override long ParseFromString(string v, string format)
        {
            return long.Parse(v, NumberStyles.Any);
        }

        public override long FromDateTimeNull(DateTime? v)
        {
            throw new NotImplementedException();
        }

        public override DateTime? ToDateTimeNull(long v)
        {
            throw new NotImplementedException();
        }

        public override long FromBoolNull(bool? v, bool indeterminate)
        {
            throw new NotImplementedException();
        }

        public override long FromDecimal(decimal v)
        {
            return (long) v;
        }
    }
}