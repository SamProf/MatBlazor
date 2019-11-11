using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTUInt : MatBlazorSwitchT<uint>
    {
        public override uint Increase(uint v, uint step, uint max)
        {
            var v2 = (uint) (v + step);
            return v2 <= max ? v2 : max;
        }

        public override uint Decrease(uint v, uint step, uint min)
        {
            var v2 = (uint) (v - step);
            return v2 >= min ? v2 : min;
        }

        public override uint Round(uint v, int dp)
        {
            return v;
        }

        public override uint Minimum => uint.MinValue;
        public override uint Maximum => uint.MaxValue;

        public override uint Step => 1;

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
    }
}