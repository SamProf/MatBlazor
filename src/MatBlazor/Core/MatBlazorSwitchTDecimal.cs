using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MatBlazor
{
    public class MatBlazorSwitchTDecimal : MatBlazorSwitchT<decimal>
    {
        public override decimal Increase(decimal v, decimal step, decimal max)
        {
            return Math.Min(v + step, max);
        }

        public override decimal Decrease(decimal v, decimal step, decimal min)
        {
            return Math.Max(v - step, min);
        }

        public override decimal Round(decimal v, int dp)
        {
            return Math.Round(v, dp);
        }

        public override decimal Minimum => decimal.MinValue;
        public override decimal Maximum => decimal.MaxValue;

        public override decimal Step => 1;

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
    }
}