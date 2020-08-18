using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTUShort : MatBlazorSwitchT<ushort>
    {
        public override ushort Clamp(ushort v, ushort min, ushort max)
        {
            return v < min ? min : v > max ? max : v;
        }

        public override ushort Increase(ushort v, ushort step)
        {
            checked
            {
                try
                {
                    return (ushort) (v + step);
                }
                catch (OverflowException)
                {
                    return ushort.MaxValue;
                }
            }
        }

        public override ushort Decrease(ushort v, ushort step)
        {
            checked
            {
                try
                {
                    return (ushort) (v - step);
                }
                catch (OverflowException)
                {
                    return ushort.MinValue;
                }
            }
        }

        public override ushort Round(ushort v, int dp)
        {
            return v;
        }

        public override ushort GetMinimum() => ushort.MinValue;
        public override ushort GetMaximum() => ushort.MaxValue;

        public override ushort GetStep() => 1;

        public override string FormatValueAsString(ushort v, string format)
        {
            return v.ToString(format);
        }

        public override ushort ParseFromString(string v, string format)
        {
            return ushort.Parse(v, NumberStyles.Any);
        }

        public override ushort FromDateTimeNull(DateTime? v)
        {
            throw new NotImplementedException();
        }

        public override DateTime? ToDateTimeNull(ushort v)
        {
            throw new NotImplementedException();
        }

        public override ushort FromBoolNull(bool? v, bool indeterminate)
        {
            throw new NotImplementedException();
        }

        public override ushort FromDecimal(decimal v)
        {
            return (ushort) v;
        }
    }
}