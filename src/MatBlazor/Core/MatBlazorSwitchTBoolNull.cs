using System;
using Microsoft.AspNetCore.Components.RenderTree;

namespace MatBlazor
{
    public class MatBlazorSwitchTBoolNull : MatBlazorSwitchT<bool?>
    {
        public override bool? Increase(bool? v, bool? step, bool? max)
        {
            return !(v ?? false);
        }

        public override bool? Decrease(bool? v, bool? step, bool? min)
        {
            return !(v ?? false);
        }

        public override bool? Round(bool? v, int dp)
        {
            return v;
        }

        public override bool? Minimum => null;

        public override bool? Maximum => null;

        public override bool? Step => true;

        public override string FormatValueAsString(bool? v, string format)
        {
            return v?.ToString();
        }

        public override bool? ParseFromString(string v, string format)
        {
            if (string.IsNullOrEmpty(v))
            {
                return null;
            }

            return bool.Parse(v);
        }

        public override bool? FromDateTimeNull(DateTime? v)
        {
            throw new NotImplementedException();
        }

        public override DateTime? ToDateTimeNull(bool? v)
        {
            throw new NotImplementedException();
        }

        public override bool? FromBoolNull(bool? v, bool indeterminate)
        {
            return v;
        }

        public override bool? FromDecimal(decimal v)
        {
            if (v == 0)
            {
                return null;
            }

            return v > 0;
        }
    }
}