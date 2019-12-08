using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTChar : MatBlazorSwitchT<char>
    {
        public override char Increase(char v, char step, char max)
        {
            var v2 = (char) (v + step);
            return v2 <= max ? v2 : max;
        }

        public override char Decrease(char v, char step, char min)
        {
            var v2 = (char) (v - step);
            return v2 >= min ? v2 : min;
        }

        public override char Round(char v, int dp)
        {
            return v;
        }

        public override char GetMinimum() => char.MinValue;
        public override char GetMaximum() => char.MaxValue;

        public override char GetStep() => (char) 1;

        public override string FormatValueAsString(char v, string format)
        {
            return v.ToString();
        }

        public override char ParseFromString(string v, string format)
        {
            return char.Parse(v);
        }

        public override char FromDateTimeNull(DateTime? v)
        {
            throw new NotImplementedException();
        }

        public override DateTime? ToDateTimeNull(char v)
        {
            throw new NotImplementedException();
        }

        public override char FromBoolNull(bool? v, bool indeterminate)
        {
            throw new NotImplementedException();
        }

        public override char FromDecimal(decimal v)
        {
            return (char) v;
        }
    }
}