using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTShortNull : MatBlazorSwitchT<short?>
    {
        public override short? Increase(short? v, short? step, short? max)
        {
            checked
            {
                try
                {
                    var v2 = (v.HasValue || step.HasValue) ? (short?) ((v ?? 0) + (step ?? 0)) : null;
                    return (max.HasValue && v2.HasValue) ? (v2.Value <= max.Value ? v2.Value : max.Value) : v2;
                }
                catch (OverflowException e)
                {
                    return max;
                }
            }
        }

        public override short? Decrease(short? v, short? step, short? min)
        {
            checked
            {
                try
                {
                    var v2 = (v.HasValue || step.HasValue) ? (short?) ((v ?? 0) - (step ?? 0)) : null;
                    return (min.HasValue && v2.HasValue) ? (v2.Value >= min.Value ? v2.Value : min.Value) : v2;
                }
                catch (OverflowException e)
                {
                    return min;
                }
            }
        }

        public override short? Round(short? v, int dp)
        {
            return v;
        }

        public override short? GetMinimum() => short.MinValue;
        public override short? GetMaximum() => short.MaxValue;

        public override short? GetStep() => 1;

        public override string FormatValueAsString(short? v, string format)
        {
            return v?.ToString(format);
        }

        public override short? ParseFromString(string v, string format)
        {
            if (string.IsNullOrEmpty(v))
            {
                return null;
            }

            return short.Parse(v, NumberStyles.Any);
        }

        public override short? FromDateTimeNull(DateTime? v)
        {
            throw new NotImplementedException();
        }

        public override DateTime? ToDateTimeNull(short? v)
        {
            throw new NotImplementedException();
        }

        public override short? FromBoolNull(bool? v, bool indeterminate)
        {
            throw new NotImplementedException();
        }

        public override short? FromDecimal(decimal v)
        {
            return (short) v;
        }
    }
}