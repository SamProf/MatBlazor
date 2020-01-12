using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTShort : MatBlazorSwitchT<short>
    {
        public override short Increase(short v, short step, short max)
        {
            var result = (v <= max - step) ? (short)(v + step) : max;
            return result;
        }

        public override short Decrease(short v, short step, short min)
        {
            var result = (v >= min + step) ? (short)(v - step) : min;
            return result;
        }

        public override short Round(short v, int dp)
        {
            return v;
        }

        public override short GetMinimum() => short.MinValue;
        public override short GetMaximum() => short.MaxValue;

        public override short GetStep() => 1;

        public override string FormatValueAsString(short v, string format)
        {
            return v.ToString(format);
        }
        public override short ParseFromString(string v, string format)
        {
            return short.Parse(v, NumberStyles.Any);
        }

        public override short FromDateTimeNull(DateTime? v)
        {
            throw new NotImplementedException();
        }

        public override DateTime? ToDateTimeNull(short v)
        {
            throw new NotImplementedException();
        }

        public override short FromBoolNull(bool? v, bool indeterminate)
        {
            throw new NotImplementedException();
        }

        public override short FromDecimal(decimal v)
        {
            return (short)v;
        }
    }
}