using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTByte : MatBlazorSwitchT<byte>
    {
        public override byte Increase(byte v, byte step, byte max)
        {
            var v2 = (byte) (v + step);
            return v2 <= max ? v2 : max;
        }

        public override byte Decrease(byte v, byte step, byte min)
        {
            var v2 = (byte) (v - step);
            return v2 >= min ? v2 : min;
        }

        public override byte Round(byte v, int dp)
        {
            return v;
        }

        public override byte Minimum => byte.MinValue;
        public override byte Maximum => byte.MaxValue;

        public override byte Step => 1;
        public override string FormatValueAsString(byte v, string format)
        {
            return v.ToString(format);
        }

        public override byte ParseFromString(string v, string format)
        {
            return byte.Parse(v, NumberStyles.Any);
        }

        public override byte FromDateTimeNull(DateTime? v)
        {
            throw new NotImplementedException();
        }

        public override DateTime? ToDateTimeNull(byte v)
        {
            throw new NotImplementedException();
        }
    }
}