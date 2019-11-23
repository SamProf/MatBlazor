using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTSByte : MatBlazorSwitchT<sbyte>
    {
        public override sbyte Increase(sbyte v, sbyte step, sbyte max)
        {
            var v2 = (sbyte) (v + step);
            return v2 <= max ? v2 : max;
        }

        public override sbyte Decrease(sbyte v, sbyte step, sbyte min)
        {
            var v2 = (sbyte) (v - step);
            return v2 >= min ? v2 : min;
        }

        public override sbyte Round(sbyte v, int dp)
        {
            return v;
        }

        public override sbyte Minimum => sbyte.MinValue;
        public override sbyte Maximum => sbyte.MaxValue;

        public override sbyte Step => 1;

        public override string FormatValueAsString(sbyte v, string format)
        {
            return v.ToString(format);
        }

        public override sbyte ParseFromString(string v, string format)
        {
            return sbyte.Parse(v, NumberStyles.Any);
        }

        public override sbyte FromDateTimeNull(DateTime? v)
        {
            throw new NotImplementedException();
        }

        public override DateTime? ToDateTimeNull(sbyte v)
        {
            throw new NotImplementedException();
        }

        public override sbyte FromBoolNull(bool? v, bool indeterminate)
        {
            throw new NotImplementedException();
        }

        public override sbyte FromDecimal(decimal v)
        {
            return (sbyte) v;
        }
    }
}