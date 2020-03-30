using System;

namespace MatBlazor
{
    public class MatBlazorSwitchTCharNull : MatBlazorSwitchT<char?>
    {
        public override char? Increase(char? v, char? step, char? max)
        {
            checked
            {
                try
                {
                    var v2 = (v.HasValue || step.HasValue) ? (char?) ((v ?? 0) + (step ?? 0)) : null;
                    return (max.HasValue && v2.HasValue) ? (v2.Value <= max.Value ? v2.Value : max.Value) : v2;
                }
                catch (OverflowException e)
                {
                    return max;
                }
            }
        }

        public override char? Decrease(char? v, char? step, char? min)
        {
            checked
            {
                try
                {
                    var v2 = (v.HasValue || step.HasValue) ? (char?) ((v ?? 0) - (step ?? 0)) : null;
                    return (min.HasValue && v2.HasValue) ? (v2.Value >= min.Value ? v2.Value : min.Value) : v2;
                }
                catch (OverflowException e)
                {
                    return min;
                }
            }
        }

        public override char? Round(char? v, int dp)
        {
            return v;
        }

        public override char? GetMinimum() => char.MinValue;
        public override char? GetMaximum() => char.MaxValue;

        public override char? GetStep() => (char?)1;

        public override string FormatValueAsString(char? v, string format)
        {
            return v?.ToString();
        }

        public override char? ParseFromString(string v, string format)
        {
            if (string.IsNullOrEmpty(v))
            {
                return null;
            }

            return char.Parse(v);
        }

        public override char? FromDateTimeNull(DateTime? v)
        {
            throw new NotImplementedException();
        }

        public override DateTime? ToDateTimeNull(char? v)
        {
            throw new NotImplementedException();
        }

        public override char? FromBoolNull(bool? v, bool indeterminate)
        {
            throw new NotImplementedException();
        }

        public override char? FromDecimal(decimal v)
        {
            return (char)v;
        }
    }
}