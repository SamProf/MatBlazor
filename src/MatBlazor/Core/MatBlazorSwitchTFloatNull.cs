using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTFloatNull : MatBlazorSwitchT<float?>
    {
        public override float? Increase(float? v, float? step, float? max)
        {
            checked
            {
                try
                {
                    var v2 = (v.HasValue || step.HasValue) ? ((v ?? 0) + (step ?? 0)) : (float?) null;
                    return (max.HasValue && v2.HasValue) ? (v2.Value <= max.Value ? v2.Value : max.Value) : v2;
                }
                catch (OverflowException e)
                {
                    return max;
                }
            }
        }

        public override float? Decrease(float? v, float? step, float? min)
        {
            checked
            {
                try
                {
                    var v2 = (v.HasValue || step.HasValue) ? ((v ?? 0) - (step ?? 0)) : (float?) null;
                    return (min.HasValue && v2.HasValue) ? (v2.Value >= min.Value ? v2.Value : min.Value) : v2;
                }
                catch (OverflowException e)
                {
                    return min;
                }
            }
        }

        public override float? Round(float? v, int dp)
        {
            if (v.HasValue)
            {
                return (float?)Math.Round(v.Value, dp);
            }

            return v;
        }

        public override float? GetMinimum() => float.MinValue;
        public override float? GetMaximum() => float.MaxValue;

        public override float? GetStep() => 1;

        public override string FormatValueAsString(float? v, string format)
        {
            return v?.ToString(format);
        }
        public override float? ParseFromString(string v, string format)
        {
            if (string.IsNullOrEmpty(v))
            {
                return null;
            }

            return float.Parse(v, NumberStyles.Any);
        }

        public override float? FromDateTimeNull(DateTime? v)
        {
            throw new NotImplementedException();
        }

        public override DateTime? ToDateTimeNull(float? v)
        {
            throw new NotImplementedException();
        }

        public override float? FromBoolNull(bool? v, bool indeterminate)
        {
            throw new NotImplementedException();
        }

        public override float? FromDecimal(decimal v)
        {
            return (float) v;
        }
    }
}