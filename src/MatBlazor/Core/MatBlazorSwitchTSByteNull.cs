using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTSByteNull : MatBlazorSwitchT<sbyte?>
    {
        public override sbyte? Increase(sbyte? v, sbyte? step, sbyte? max)
        {
            checked
            {
                try
                {
                    var v2 = (v.HasValue || step.HasValue) ? (sbyte?) ((v ?? 0) + (step ?? 0)) : null;
                    return (max.HasValue && v2.HasValue) ? (v2.Value <= max.Value ? v2.Value : max.Value) : v2;
                }
                catch (OverflowException e)
                {
                    return max;
                }
            }
        }

        public override sbyte? Decrease(sbyte? v, sbyte? step, sbyte? min)
        {
            checked
            {
                try
                {
                    var v2 = (v.HasValue || step.HasValue) ? (sbyte?) ((v ?? 0) - (step ?? 0)) : null;
                    return (min.HasValue && v2.HasValue) ? (v2.Value >= min.Value ? v2.Value : min.Value) : v2;
                }
                catch (OverflowException e)
                {
                    return min;
                }
            }
        }

        public override sbyte? Round(sbyte? v, int dp)
        {
            return v;
        }

        public override sbyte? GetMinimum() => sbyte.MinValue;
        public override sbyte? GetMaximum() => sbyte.MaxValue;

        public override sbyte? GetStep() => 1;

        public override string FormatValueAsString(sbyte? v, string format)
        {
            return v?.ToString(format);
        }

        public override sbyte? ParseFromString(string v, string format)
        {
            if (string.IsNullOrEmpty(v))
            {
                return null;
            }

            return sbyte.Parse(v, NumberStyles.Any);
        }

        public override sbyte? FromDateTimeNull(DateTime? v)
        {
            throw new NotImplementedException();
        }

        public override DateTime? ToDateTimeNull(sbyte? v)
        {
            throw new NotImplementedException();
        }

        public override sbyte? FromBoolNull(bool? v, bool indeterminate)
        {
            throw new NotImplementedException();
        }

        public override sbyte? FromDecimal(decimal v)
        {
            return (sbyte) v;
        }
    }
}