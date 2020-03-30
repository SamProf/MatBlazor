using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTUShortNull : MatBlazorSwitchT<ushort?>
    {
        public override ushort? Increase(ushort? v, ushort? step, ushort? max)
        {
            checked
            {
                try
                {
                    var v2 = (v.HasValue || step.HasValue) ? (ushort?) ((v ?? 0) + (step ?? 0)) : null;
                    return (max.HasValue && v2.HasValue) ? (v2.Value <= max.Value ? v2.Value : max.Value) : v2;
                }
                catch (OverflowException e)
                {
                    return max;
                }
            }
        }

        public override ushort? Decrease(ushort? v, ushort? step, ushort? min)
        {
            checked
            {
                try
                {
                    var v2 = (v.HasValue || step.HasValue) ? (ushort?) ((v ?? 0) - (step ?? 0)) : null;
                    return (min.HasValue && v2.HasValue) ? (v2.Value >= min.Value ? v2.Value : min.Value) : v2;
                }
                catch (OverflowException e)
                {
                    return min;
                }
            }
        }

        public override ushort? Round(ushort? v, int dp)
        {
            return v;
        }

        public override ushort? GetMinimum() => ushort.MinValue;
        public override ushort? GetMaximum() => ushort.MaxValue;

        public override ushort? GetStep() => 1;

        public override string FormatValueAsString(ushort? v, string format)
        {
            return v?.ToString(format);
        }

        public override ushort? ParseFromString(string v, string format)
        {
            if (string.IsNullOrEmpty(v))
            {
                return null;
            }

            return ushort.Parse(v, NumberStyles.Any);
        }

        public override ushort? FromDateTimeNull(DateTime? v)
        {
            throw new NotImplementedException();
        }

        public override DateTime? ToDateTimeNull(ushort? v)
        {
            throw new NotImplementedException();
        }

        public override ushort? FromBoolNull(bool? v, bool indeterminate)
        {
            throw new NotImplementedException();
        }

        public override ushort? FromDecimal(decimal v)
        {
            return (ushort) v;
        }
    }
}