using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTUInt : MatBlazorSwitchT<uint>
    {
        public override uint Increase(uint v, uint step, uint max)
        {
            checked
            {
                try
                {
                    var v2 = (uint) (v + step);
                    return v2 <= max ? v2 : max;
                }
                catch (OverflowException e)
                {
                    return max;
                }
            }
        }

        public override uint Decrease(uint v, uint step, uint min)
        {
            checked
            {
                try
                {
                    var v2 = (uint) (v - step);
                    return v2 >= min ? v2 : min;
                }
                catch (OverflowException e)
                {
                    return min;
                }
            }
        }

        public override uint Round(uint v, int dp)
        {
            return v;
        }

        public override uint GetMinimum() => uint.MinValue;
        public override uint GetMaximum() => uint.MaxValue;

        public override uint GetStep() => 1;

        public override string FormatValueAsString(uint v, string format)
        {
            return v.ToString(format);
        }

        public override uint ParseFromString(string v, string format)
        {
            return uint.Parse(v, NumberStyles.Any);
        }

        public override uint FromDateTimeNull(DateTime? v)
        {
            throw new NotImplementedException();
        }

        public override DateTime? ToDateTimeNull(uint v)
        {
            throw new NotImplementedException();
        }

        public override uint FromBoolNull(bool? v, bool indeterminate)
        {
            throw new NotImplementedException();
        }

        public override uint FromDecimal(decimal v)
        {
            return (uint) v;
        }
    }
}