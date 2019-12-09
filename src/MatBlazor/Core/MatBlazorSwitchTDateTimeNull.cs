using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTDateTimeNull : MatBlazorSwitchT<DateTime?>
    {
        public override DateTime? Increase(DateTime? v, DateTime? step, DateTime? max)
        {
            throw new NotImplementedException();
        }

        public override DateTime? Decrease(DateTime? v, DateTime? step, DateTime? min)
        {
            throw new NotImplementedException();
        }

        public override DateTime? Round(DateTime? v, int dp)
        {
            throw new NotImplementedException();
        }

        public override DateTime? GetMinimum() => null;

        public override DateTime? GetMaximum() => null;

        public override DateTime? GetStep() => throw new NotImplementedException();

        public override string FormatValueAsString(DateTime? v, string format)
        {
            if (!v.HasValue)
            {
                return null;
            }

            if (v.Value == DateTime.MinValue)
            {
                return string.Empty;
            }

            return v.Value.ToLocalTime().ToString(format);
        }

        public override DateTime? ParseFromString(string v, string format)
        {
            if (string.IsNullOrEmpty(v))
            {
                return null;
            }

            if (DateTime.TryParseExact(v, format, CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal,
                out var result))
            {
                return result;
            }

            return DateTime.Parse(v, CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal);
        }

        public override DateTime? FromDateTimeNull(DateTime? v)
        {
            return v;
        }

        public override DateTime? ToDateTimeNull(DateTime? v)
        {
            return v;
        }

        public override DateTime? FromBoolNull(bool? v, bool indeterminate)
        {
            throw new NotImplementedException();
        }

        public override DateTime? FromDecimal(decimal v)
        {
            throw new NotImplementedException();
        }
    }
}