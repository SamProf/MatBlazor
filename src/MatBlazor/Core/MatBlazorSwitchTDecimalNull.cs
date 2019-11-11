using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTDecimalNull : MatBlazorSwitchT<decimal?>
    {
        public override decimal? Increase(decimal? v, decimal? step, decimal? max)
        {
            var v2 = (v.HasValue || step.HasValue) ? ((v ?? 0) + (step ?? 0)) : (decimal?) null;
            if (max.HasValue && v2.HasValue)
            {
                return Math.Min(v2.Value, max.Value);
            }

            return v2;
        }

        public override decimal? Decrease(decimal? v, decimal? step, decimal? min)
        {
            decimal? v2 = (v.HasValue || step.HasValue) ? ((v ?? 0) - (step ?? 0)) : (decimal?) null;
            if (min.HasValue && v2.HasValue)
            {
                return Math.Max(v2.Value, min.Value);
            }

            return v2;
        }

        public override decimal? Round(decimal? v, int dp)
        {
            if (v.HasValue)
            {
                return Math.Round(v.Value, dp);
            }

            return v;
        }

        public override decimal? Minimum => null;
        public override decimal? Maximum => null;
        public override decimal? Step => 1;

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
    }
}