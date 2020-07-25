using System;

namespace MatBlazor
{
    public class MatBlazorSwitchTGuidNull : MatBlazorSwitchT<Guid?>
    {
        public override Guid? Increase(Guid? v, Guid? step, Guid? max)
        {
            throw new NotImplementedException();
        }

        public override Guid? Decrease(Guid? v, Guid? step, Guid? min)
        {
            throw new NotImplementedException();
        }

        public override Guid? Round(Guid? v, int dp)
        {
            throw new NotImplementedException();
        }

        public override Guid? GetMinimum()
        {
            throw new NotImplementedException();
        }

        public override Guid? GetMaximum()
        {
            throw new NotImplementedException();
        }

        public override Guid? GetStep()
        {
            throw new NotImplementedException();
        }

        public override string FormatValueAsString(Guid? v, string format)
        {
            return v?.ToString(format);
        }

        public override Guid? ParseFromString(string v, string format)
        {
            if (Guid.TryParse(v, out var result))
            {
                return result;
            }

            return null;
        }

        public override Guid? FromDateTimeNull(DateTime? v)
        {
            throw new NotImplementedException();
        }

        public override DateTime? ToDateTimeNull(Guid? v)
        {
            throw new NotImplementedException();
        }

        public override Guid? FromBoolNull(bool? v, bool indeterminate)
        {
            throw new NotImplementedException();
        }

        public override Guid? FromDecimal(decimal v)
        {
            throw new NotImplementedException();
        }
    }
}