using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTFloat : MatBlazorSwitchT<float>
    {
        public override float Increase(float v, float step, float max)
        {
            return Math.Min(v + step, max);
        }

        public override float Decrease(float v, float step, float min)
        {
            return Math.Max(v - step, min);
        }

        public override float Round(float v, int dp)
        {
            return (float)Math.Round(v, dp);
        }

        public override float Minimum => float.MinValue;
        public override float Maximum => float.MaxValue;

        public override float Step => 1;

        public override string FormatValueAsString(float v, string format)
        {
            return v.ToString(format);
        }
        public override float ParseFromString(string v, string format)
        {
            return float.Parse(v, NumberStyles.Any);
        }

        public override float FromDateTimeNull(DateTime? v)
        {
            throw new NotImplementedException();
        }

        public override DateTime? ToDateTimeNull(float v)
        {
            throw new NotImplementedException();
        }

        public override float FromBoolNull(bool? v, bool indeterminate)
        {
            throw new NotImplementedException();
        }
    }
}