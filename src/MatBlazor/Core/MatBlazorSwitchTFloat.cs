using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTFloat : MatBlazorSwitchT<float>
    {
        public override float Increase(float v, float step, float max)
        {
            checked
            {
                try
                {
                    var v2 = (float) (v + step);
                    return v2 <= max ? v2 : max;
                }
                catch (OverflowException e)
                {
                    return max;
                }
            }
        }

        public override float Decrease(float v, float step, float min)
        {
            checked
            {
                try
                {
                    var v2 = (float)(v - step);
                    return v2 >= min ? v2 : min;
                }
                catch (OverflowException e)
                {
                    return min;
                }
            }
        }

        public override float Round(float v, int dp)
        {
            return (float)Math.Round(v, dp);
        }

        public override float GetMinimum() => float.MinValue;
        public override float GetMaximum() => float.MaxValue;

        public override float GetStep() => 1;

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

        public override float FromDecimal(decimal v)
        {
            return (float) v;
        }
    }
}