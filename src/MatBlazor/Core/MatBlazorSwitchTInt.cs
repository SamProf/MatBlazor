using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTInt : MatBlazorSwitchT<int>
    {
        public override int Increase(int v, int step, int max)
        {
            checked
            {
                try
                {
                    var v2 = (int) (v + step);
                    return v2 <= max ? v2 : max;
                }
                catch (OverflowException)
                {
                    return max;
                }
            }
        }

        public override int Decrease(int v, int step, int min)
        {
            checked
            {
                try
                {
                    var v2 = (int) (v - step);
                    return v2 >= min ? v2 : min;
                }
                catch (OverflowException)
                {
                    return min;
                }
            }
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
            if (int.TryParse(v, NumberStyles.Any, CultureInfo.InvariantCulture, out var num)) return num;
            return 0;
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
            return (int) v;
        }
    }
}