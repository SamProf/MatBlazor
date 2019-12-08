using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTDouble : MatBlazorSwitchT<double>
    {
        public override double Increase(double v, double step, double max)
        {
            return Math.Min(v + step, max);
        }

        public override double Decrease(double v, double step, double min)
        {
            return Math.Max(v - step, min);
        }

        public override double Round(double v, int dp)
        {
            return Math.Round(v, dp);
        }

        public override double GetMinimum() => double.MinValue;
        public override double GetMaximum() => double.MaxValue;

        public override double GetStep() => 1;

        public override string FormatValueAsString(double v, string format)
        {
            return v.ToString(format);
        }

        public override double ParseFromString(string v, string format)
        {
            return double.Parse(v, NumberStyles.Any);
        }

        public override double FromDateTimeNull(DateTime? v)
        {
            throw new NotImplementedException();
        }

        public override DateTime? ToDateTimeNull(double v)
        {
            throw new NotImplementedException();
        }

        public override double FromBoolNull(bool? v, bool indeterminate)
        {
            throw new NotImplementedException();
        }

        public override double FromDecimal(decimal v)
        {
            return (double) v;
        }
    }
}