using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTInt : MatBlazorSwitchT<int>
    {
        public override int Increase(int v, int step, int max)
        {
            var v2 = (int) (v + step);
            return v2 <= max ? v2 : max;
        }

        public override int Decrease(int v, int step, int min)
        {
            var v2 = (ushort) (v - step);
            return v2 >= min ? v2 : min;
        }

        public override int Round(int v, int dp)
        {
            return v;
        }

        public override int Minimum => int.MinValue;
        public override int Maximum => int.MaxValue;

        public override int Step => 1;

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
    }
}