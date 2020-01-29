using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTUShort : MatBlazorSwitchT<ushort>
    {
        public override ushort Increase(ushort v, ushort step, ushort max)
        {
            checked
            {
                try
                {
                    var v2 = (ushort) (v + step);
                    return v2 <= max ? v2 : max;
                }
                catch (OverflowException e)
                {
                    return max;
                }
            }
        }

        public override ushort Decrease(ushort v, ushort step, ushort min)
        {
            checked
            {
                try
                {
                    var v2 = (ushort) (v - step);
                    return v2 >= min ? v2 : min;
                }
                catch (OverflowException e)
                {
                    return min;
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