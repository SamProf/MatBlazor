using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTDoubleNull : MatBlazorSwitchT<double?>
    {
        public override double? Clamp(double? v, double? min, double? max)
        {
            return v < min ? min : v > max ? max : v;
        }

        public override double? Increase(double? v, double? step)
        {
            checked
            {
                try
                {
                    return (v.HasValue || step.HasValue) ? ((v ?? 0) + (step ?? 0)) : (double?) null;
                }
                catch (OverflowException)
                {
                    return double.MaxValue;
                }
            }
        }

        public override double? Decrease(double? v, double? step)
        {
            checked
            {
                try
                {
                    return (v.HasValue || step.HasValue) ? ((v ?? 0) - (step ?? 0)) : (double?) null;
                }
                catch (OverflowException)
                {
                    return double.MinValue;
                }
            }
        }

        public override double? Round(double? v, int dp)
        {
            if (v.HasValue)
            {
                return Math.Round(v.Value, dp);
            }

            return v;
        }

        public override double? GetMinimum() => double.MinValue;
        public override double? GetMaximum() => double.MaxValue;

        public override double? GetStep() => 1;

        public override string FormatValueAsString(double? v, string format)
        {
            return v?.ToString(format);
        }

        public override double? ParseFromString(string v, string format)
        {
            if (string.IsNullOrEmpty(v))
            {
                return null;
            }

            return double.Parse(v, NumberStyles.Any);
        }

        public override double? FromDateTimeNull(DateTime? v)
        {
            throw new NotImplementedException();
        }

        public override DateTime? ToDateTimeNull(double? v)
        {
            throw new NotImplementedException();
        }

        public override double? FromBoolNull(bool? v, bool indeterminate)
        {
            throw new NotImplementedException();
        }

        public override double? FromDecimal(decimal v)
        {
            return (double) v;
        }
    }
}