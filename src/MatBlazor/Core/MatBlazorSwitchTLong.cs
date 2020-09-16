using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTLong : MatBlazorSwitchT<long>
    {
        public override long Clamp(long v, long min, long max)
        {
            return v < min ? min : v > max ? max : v;
        }

        public override long Increase(long v, long step)
        {
            checked
            {
                try
                {
                    return (long) (v + step);
                }
                catch (OverflowException)
                {
                    return long.MaxValue;
                }
            }
        }

        public override long Decrease(long v, long step)
        {
            checked
            {
                try
                {
                    return (long) (v - step);
                }
                catch (OverflowException)
                {
                    return long.MinValue;
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