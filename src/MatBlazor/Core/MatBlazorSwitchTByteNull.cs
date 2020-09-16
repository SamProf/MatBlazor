using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTByteNull : MatBlazorSwitchT<byte?>
    {
        public override byte? Clamp(byte? v, byte? min, byte? max)
        {
            return v < min ? min : v > max ? max : v;
        }

        public override byte? Increase(byte? v, byte? step)
        {
            checked
            {
                try
                {
                    return (v.HasValue || step.HasValue) ? (byte?) ((v ?? 0) + (step ?? 0)) : null;
                }
                catch (OverflowException)
                {
                    return byte.MaxValue;
                }
            }
        }

        public override byte? Decrease(byte? v, byte? step)
        {
            checked
            {
                try
                {
                    return (v.HasValue || step.HasValue) ? (byte?) ((v ?? 0) - (step ?? 0)) : null;
                }
                catch (OverflowException)
                {
                    return byte.MinValue;
                }
            }
        }

        public override byte? Round(byte? v, int dp)
        {
            return v;
        }

        public override byte? GetMinimum() => byte.MinValue;
        public override byte? GetMaximum() => byte.MaxValue;

        public override byte? GetStep() => 1;

        public override string FormatValueAsString(byte? v, string format)
        {
            return v?.ToString(format);
        }

        public override byte? ParseFromString(string v, string format)
        {
            if (string.IsNullOrEmpty(v))
            {
                return null;
            }

            return byte.Parse(v, NumberStyles.Any);
        }

        public override byte? FromDateTimeNull(DateTime? v)
        {
            throw new NotImplementedException();
        }

        public override DateTime? ToDateTimeNull(byte? v)
        {
            throw new NotImplementedException();
        }

        public override byte? FromBoolNull(bool? v, bool indeterminate)
        {
            throw new NotImplementedException();
        }

        public override byte? FromDecimal(decimal v)
        {
            return (byte)v;
        }
    }
}