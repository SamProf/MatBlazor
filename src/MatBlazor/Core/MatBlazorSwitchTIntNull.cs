using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTIntNull : MatBlazorSwitchT<int?>
    {
        public override int? Clamp(int? v, int? min, int? max)
        {
            return v < min ? min : v > max ? max : v;
        }

        public override int? Increase(int? v, int? step)
        {
            checked
            {
                try
                {
                    return (v.HasValue || step.HasValue) ? ((v ?? 0) + (step ?? 0)) : (int?) null;
                }
                catch (OverflowException)
                {
                    return int.MaxValue;
                }
            }
        }

        public override int? Decrease(int? v, int? step)
        {
            checked
            {
                try
                {
                    return (v.HasValue || step.HasValue) ? ((v ?? 0) - (step ?? 0)) : (int?) null;
                }
                catch (OverflowException)
                {
                    return int.MinValue;
                }
            }
        }

        public override int? Round(int? v, int dp)
        {
            return v;
        }

        public override int? GetMinimum() => int.MinValue;
        public override int? GetMaximum() => int.MaxValue;

        public override int? GetStep() => 1;

        public override string FormatValueAsString(int? v, string format)
        {
            return v?.ToString(format);
        }

        public override int? ParseFromString(string v, string format)
        {
            if (string.IsNullOrEmpty(v))
            {
                return null;
            }

            return int.Parse(v, NumberStyles.Any);
        }

        public override int? FromDateTimeNull(DateTime? v)
        {
            throw new NotImplementedException();
        }

        public override DateTime? ToDateTimeNull(int? v)
        {
            throw new NotImplementedException();
        }

        public override int? FromBoolNull(bool? v, bool indeterminate)
        {
            throw new NotImplementedException();
        }

        public override int? FromDecimal(decimal v)
        {
            return (int) v;
        }
    }
}