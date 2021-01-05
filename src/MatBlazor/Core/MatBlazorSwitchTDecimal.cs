using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTDecimal : MatBlazorSwitchT<decimal>
    {
        public override decimal Increase(decimal v, decimal step, decimal max)
        {
            checked
            {
                try
                {
                    var v2 = (decimal) (v + step);
                    return v2 <= max ? v2 : max;
                }
                catch (OverflowException e)
                {
                    return max;
                }
            }
        }

        public override decimal Decrease(decimal v, decimal step, decimal min)
        {
            checked
            {
                try
                {
                    var v2 = (decimal) (v - step);
                    return v2 >= min ? v2 : min;
                }
                catch (OverflowException e)
                {
                    return min;
                }
            }
        }

        public override decimal Round(decimal v, int dp)
        {
            return Math.Round(v, dp);
        }

        public override decimal GetMinimum() => decimal.MinValue;
        public override decimal GetMaximum() => decimal.MaxValue;

        public override decimal GetStep() => 1;

        public override string FormatValueAsString(decimal v, string format)
        {
            return v.ToString(format);
        }

        public override decimal ParseFromString(string v, string format)
        {
            return decimal.Parse(v, NumberStyles.Any);
        }

        public override decimal FromDateTimeNull(DateTime? v)
        {
            throw new NotImplementedException();
        }

        public override DateTime? ToDateTimeNull(decimal v)
        {
            throw new NotImplementedException();
        }

        public override decimal FromBoolNull(bool? v, bool indeterminate)
        {
            throw new NotImplementedException();
        }

        public override decimal FromDecimal(decimal v)
        {
            return v;
        }
    }
}