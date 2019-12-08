using System;

namespace MatBlazor
{
    public class MatBlazorSwitchTString : MatBlazorSwitchT<string>
    {
        public override string Increase(string v, string step, string max)
        {
            throw new System.NotImplementedException();
        }

        public override string Decrease(string v, string step, string min)
        {
            throw new System.NotImplementedException();
        }

        public override string Round(string v, int dp)
        {
            throw new System.NotImplementedException();
        }

        public override string GetMinimum() => throw new System.NotImplementedException();
        public override string GetMaximum() => throw new System.NotImplementedException();
        public override string GetStep() => throw new System.NotImplementedException();

        public override string FormatValueAsString(string v, string format)
        {
            return v;
        }

        public override string ParseFromString(string v, string format)
        {
            return v;
        }

        public override string FromDateTimeNull(DateTime? v)
        {
            throw new NotImplementedException();
        }

        public override DateTime? ToDateTimeNull(string v)
        {
            throw new NotImplementedException();
        }

        public override string FromBoolNull(bool? v, bool indeterminate)
        {
            throw new NotImplementedException();
        }

        public override string FromDecimal(decimal v)
        {
            return v.ToString();
        }
    }
}