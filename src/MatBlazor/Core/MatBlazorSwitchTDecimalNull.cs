using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTDecimalNull : MatBlazorSwitchT<decimal?>
    {
        public override decimal? Increase(decimal? v, decimal? step, decimal? max)
        {
            checked
            {
                try
                {
                    var v2 = (v.HasValue || step.HasValue) ? ((v ?? 0) + (step ?? 0)) : (decimal?) null;
                    return (max.HasValue && v2.HasValue) ? (v2.Value <= max.Value ? v2.Value : max.Value) : v2;
                }
                catch (OverflowException e)
                {
                    return max;
                }
            }
        }

        public override decimal? Decrease(decimal? v, decimal? step, decimal? min)
        {
            checked
            {
                try
                {
                    var v2 = (v.HasValue || step.HasValue) ? ((v ?? 0) - (step ?? 0)) : (decimal?) null;
                    return (min.HasValue && v2.HasValue) ? (v2.Value >= min.Value ? v2.Value : min.Value) : v2;
                }
                catch (OverflowException e)
                {
                    return min;
                }
            }
        }

        public override decimal? Round(decimal? v, int dp)
        {
            if (v.HasValue)
            {
                return Math.Round(v.Value, dp);
            }

            return v;
        }

        public override decimal? GetMinimum() => null;
        public override decimal? GetMaximum() => null;
        public override decimal? GetStep() => 1;

        public override string FormatValueAsString(decimal? v, string format)
        {
            return v?.ToString(format);
        }

        public override decimal? ParseFromString(string v, string format)
        {
            if (string.IsNullOrEmpty(v))
            {
                return null;
            }

            return decimal.Parse(v, NumberStyles.Any);
        }

        public override decimal? FromDateTimeNull(DateTime? v)
        {
            throw new NotImplementedException();
        }

        public override DateTime? ToDateTimeNull(decimal? v)
        {
            throw new NotImplementedException();
        }

        public override decimal? FromBoolNull(bool? v, bool indeterminate)
        {
            throw new NotImplementedException();
        }

        public override decimal? FromDecimal(decimal v)
        {
            return v;
        }
    }
}