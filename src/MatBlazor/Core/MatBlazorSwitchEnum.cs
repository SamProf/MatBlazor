using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatBlazor.Core
{
    internal class MatBlazorSwitchEnum<T> : MatBlazorSwitchT<T>
    {
        public override T Decrease(T v, T step, T min)
        {
            throw new NotImplementedException();
        }

        public override string FormatValueAsString(T v, string format)
        {
            if (v == null) return null;
            return v.ToString();
        }

        public override T FromBoolNull(bool? v, bool indeterminate)
        {
            throw new NotImplementedException();
        }

        public override T FromDateTimeNull(DateTime? v)
        {
            throw new NotImplementedException();
        }

        public override T FromDecimal(decimal v)
        {
            throw new NotImplementedException();
        }

        public override T GetMaximum()
        {
            throw new NotImplementedException();
        }

        public override T GetMinimum()
        {
            throw new NotImplementedException();
        }

        public override T GetStep()
        {
            throw new NotImplementedException();
        }

        public override T Increase(T v, T step, T max)
        {
            throw new NotImplementedException();
        }

        public override T ParseFromString(string v, string format)
        {
            if (string.IsNullOrWhiteSpace(v))
                return default;
            var type = Nullable.GetUnderlyingType(typeof(T));
            type ??= typeof(T);
            return (T)Enum.Parse(type, v);
        }

        public override T Round(T v, int dp)
        {
            throw new NotImplementedException();
        }

        public override DateTime? ToDateTimeNull(T v)
        {
            throw new NotImplementedException();
        }
    }
}
