using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTShortNull : MatBlazorSwitchT<short?>
    {
        public override short? Clamp(short? v, short? min, short? max)
        {
            return v < min ? min : v > max ? max : v;
        }

        public override short? Increase(short? v, short? step)
        {
            checked
            {
                try
                {
                    return (v.HasValue || step.HasValue) ? (short?) ((v ?? 0) + (step ?? 0)) : null;
                }
                catch (OverflowException)
                {
                    return short.MaxValue;
                }
            }
        }

        public override short? Decrease(short? v, short? step)
        {
            checked
            {
                try
                {
                    return (v.HasValue || step.HasValue) ? (short?) ((v ?? 0) - (step ?? 0)) : null;
                }
                catch (OverflowException)
                {
                    return short.MinValue;
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