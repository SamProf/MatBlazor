using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTByte : MatBlazorSwitchT<byte>
    {
        public override byte Increase(byte v, byte step, byte max)
        {
            var result = (v <= max - step) ? (byte)(v + step) : max;
            return result;
        }

        public override byte Decrease(byte v, byte step, byte min)
        {
            var result = (v >= min + step) ? (byte)(v - step) : min;
            return result;
        }

        public override byte Round(byte v, int dp)
        {
            return v;
        }

        public override byte GetMinimum() => byte.MinValue;
        public override byte GetMaximum() => byte.MaxValue;

        public override byte GetStep() => 1;

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

        public override byte FromBoolNull(bool? v, bool indeterminate)
        {
            throw new NotImplementedException();
        }

        public override byte FromDecimal(decimal v)
        {
            return (byte)v;
        }
    }
}