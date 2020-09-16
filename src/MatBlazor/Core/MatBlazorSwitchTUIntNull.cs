using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTUIntNull : MatBlazorSwitchT<uint?>
    {
        public override uint? Clamp(uint? v, uint? min, uint? max)
        {
            return v < min ? min : v > max ? max : v;
        }

        public override uint? Increase(uint? v, uint? step)
        {
            checked
            {
                try
                {
                    return (v.HasValue || step.HasValue) ? ((v ?? 0) + (step ?? 0)) : (uint?) null;
                }
                catch (OverflowException)
                {
                    return uint.MaxValue;
                }
            }
        }

        public override uint? Decrease(uint? v, uint? step)
        {
            checked
            {
                try
                {
                    return (v.HasValue || step.HasValue) ? ((v ?? 0) - (step ?? 0)) : (uint?) null;
                }
                catch (OverflowException)
                {
                    return uint.MinValue;
                }
            }
        }

        public override uint? Round(uint? v, int dp)
        {
            return v;
        }

        public override uint? GetMinimum() => uint.MinValue;
        public override uint? GetMaximum() => uint.MaxValue;

        public override uint? GetStep() => 1;

        public override string FormatValueAsString(uint? v, string format)
        {
            return v?.ToString(format);
        }

        public override uint? ParseFromString(string v, string format)
        {
            if (string.IsNullOrEmpty(v))
            {
                return null;
            }

            return uint.Parse(v, NumberStyles.Any);
        }

        public override uint? FromDateTimeNull(DateTime? v)
        {
            throw new NotImplementedException();
        }

        public override DateTime? ToDateTimeNull(uint? v)
        {
            throw new NotImplementedException();
        }

        public override uint? FromBoolNull(bool? v, bool indeterminate)
        {
            throw new NotImplementedException();
        }

        public override uint? FromDecimal(decimal v)
        {
            return (uint) v;
        }
    }
}