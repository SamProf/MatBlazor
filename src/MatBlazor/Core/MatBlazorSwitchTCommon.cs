using System;

namespace MatBlazor
{
    public class MatBlazorSwitchTCommon<T> : MatBlazorSwitchT<T>
    {
        public override T Increase(T v, T step, T max)
        {
            throw new NotImplementedException();
        }

        public override T Decrease(T v, T step, T min)
        {
            throw new NotImplementedException();
        }

        public override T Round(T v, int dp)
        {
            throw new NotImplementedException();
        }

        public override T GetMinimum()
        {
            throw new NotImplementedException();
        }

        public override T GetMaximum()
        {
            throw new NotImplementedException();
        }

        public override T GetStep()
        {
            throw new NotImplementedException();
        }

        public override string FormatValueAsString(T v, string format)
        {
            throw new NotImplementedException();
        }

        public override T ParseFromString(string v, string format)
        {
            throw new NotImplementedException();
        }

        public override T FromDateTimeNull(DateTime? v)
        {
            throw new NotImplementedException();
        }

        public override DateTime? ToDateTimeNull(T v)
        {
            throw new NotImplementedException();
        }

        public override T FromBoolNull(bool? v, bool indeterminate)
        {
            throw new NotImplementedException();
        }

        public override T FromDecimal(decimal v)
        {
            throw new NotImplementedException();
        }
    }
}