using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTUShortNull : MatBlazorSwitchT<ushort?>
    {
        public override ushort? Clamp(ushort? v, ushort? min, ushort? max)
        {
            return v < min ? min : v > max ? max : v;
        }

        public override ushort? Increase(ushort? v, ushort? step)
        {
            checked
            {
                try
                {
                    return (v.HasValue || step.HasValue) ? (ushort?) ((v ?? 0) + (step ?? 0)) : null;
                }
                catch (OverflowException)
                {
                    return ushort.MaxValue;
                }
            }
        }

        public override ushort? Decrease(ushort? v, ushort? step)
        {
            checked
            {
                try
                {
                    return (v.HasValue || step.HasValue) ? (ushort?) ((v ?? 0) - (step ?? 0)) : null;
                }
                catch (OverflowException)
                {
                    return ushort.MinValue;
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