using System;

namespace MatBlazor
{
    public class MatBlazorSwitchTBool : MatBlazorSwitchT<bool>
    {
        public override bool FromBool(bool v)
        {
            return v;
        }

        public override bool ToBool(bool v)
        {
            return v;
        }

        public override bool Increase(bool v, bool step, bool max)
        {
            return !v;
        }

        public override bool Decrease(bool v, bool step, bool min)
        {
            return !v;
        }

        public override bool Round(bool v, int dp)
        {
            return v;
        }

        public override bool GetMinimum() => false;

        public override bool GetMaximum() => true;

        public override bool GetStep() => true;

        public override string FormatValueAsString(bool v, string format)
        {
            return v.ToString();
        }

        public override bool ParseFromString(string v, string format)
        {
            return bool.Parse(v);
        }

        public override bool FromDateTimeNull(DateTime? v)
        {
            throw new NotImplementedException();
        }

        public override DateTime? ToDateTimeNull(bool v)
        {
            throw new NotImplementedException();
        }

        public override bool FromBoolNull(bool? v, bool indeterminate)
        {
            return v ?? false;
        }

        public override bool FromDecimal(decimal v)
        {
            return v > 0;
        }
    }
}