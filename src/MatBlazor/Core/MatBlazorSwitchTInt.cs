using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTInt : MatBlazorSwitchT<int>
    {
        public override int Increase(int v, int step, int max)
        {
            var result = (v <= max - step) ? v + step : max;
            return result;
        }

        public override int Decrease(int v, int step, int min)
        {
            var result = (v >= min + step) ? v - step : min;
            return result;
        }

        public override int Round(int v, int dp)
        {
            return v;
        }

        public override int GetMinimum() => int.MinValue;
        public override int GetMaximum() => int.MaxValue;

        public override int GetStep() => 1;

        public override string FormatValueAsString(int v, string format)
        {
            return v.ToString(format);
        }

        public override int ParseFromString(string v, string format)
        {
            return int.Parse(v, NumberStyles.Any);
        }

        public override int FromDateTimeNull(DateTime? v)
        {
            throw new NotImplementedException();
        }

        public override DateTime? ToDateTimeNull(int v)
        {
            throw new NotImplementedException();
        }

        public override int FromBoolNull(bool? v, bool indeterminate)
        {
            throw new NotImplementedException();
        }

        public override int FromDecimal(decimal v)
        {
            return (int)v;
        }
    }
}