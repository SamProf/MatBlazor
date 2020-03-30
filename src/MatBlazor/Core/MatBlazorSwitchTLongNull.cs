using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTLongNull : MatBlazorSwitchT<long?>
    {
        public override long? Increase(long? v, long? step, long? max)
        {
            checked
            {
                try
                {
                    var v2 = (v.HasValue || step.HasValue) ? ((v ?? 0) + (step ?? 0)) : (long?) null;
                    return (max.HasValue && v2.HasValue) ? (v2.Value <= max.Value ? v2.Value : max.Value) : v2;
                }
                catch (OverflowException e)
                {
                    return max;
                }
            }
        }

        public override long? Decrease(long? v, long? step, long? min)
        {
            checked
            {
                try
                {
                    var v2 = (v.HasValue || step.HasValue) ? ((v ?? 0) - (step ?? 0)) : (long?) null;
                    return (min.HasValue && v2.HasValue) ? (v2.Value >= min.Value ? v2.Value : min.Value) : v2;
                }
                catch (OverflowException e)
                {
                    return min;
                }
            }
        }

        public override long? Round(long? v, int dp)
        {
            return v;
        }

        public override long? GetMinimum() => long.MinValue;
        public override long? GetMaximum() => long.MaxValue;

        public override long? GetStep() => 1;

        public override string FormatValueAsString(long? v, string format)
        {
            return v?.ToString(format);
        }

        public override long? ParseFromString(string v, string format)
        {
            if (string.IsNullOrEmpty(v))
            {
                return null;
            }

            return long.Parse(v, NumberStyles.Any);
        }

        public override long? FromDateTimeNull(DateTime? v)
        {
            throw new NotImplementedException();
        }

        public override DateTime? ToDateTimeNull(long? v)
        {
            throw new NotImplementedException();
        }

        public override long? FromBoolNull(bool? v, bool indeterminate)
        {
            throw new NotImplementedException();
        }

        public override long? FromDecimal(decimal v)
        {
            return (long) v;
        }
    }
}