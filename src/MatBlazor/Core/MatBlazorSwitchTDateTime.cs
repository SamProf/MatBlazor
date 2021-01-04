using System;
using System.Globalization;

namespace MatBlazor
{
    public class MatBlazorSwitchTDateTime : MatBlazorSwitchT<DateTime>
    {
        public override DateTime Increase(DateTime v, DateTime step, DateTime max)
        {
            throw new NotImplementedException();
        }

        public override DateTime Decrease(DateTime v, DateTime step, DateTime min)
        {
            throw new NotImplementedException();
        }

        public override DateTime Round(DateTime v, int dp)
        {
            throw new NotImplementedException();
        }

        public override DateTime GetMinimum() => DateTime.MinValue;

        public override DateTime GetMaximum() => DateTime.MaxValue;

        public override DateTime GetStep() => throw new NotImplementedException();

        public override string FormatValueAsString(DateTime v, string format)
        {
            if (v == DateTime.MinValue)
            {
                return string.Empty;
            }

            return v.ToLocalTime().ToString(format);
        }

        public override DateTime ParseFromString(string v, string format)
        {
            if (string.IsNullOrEmpty(v))
            {
                return DateTime.MinValue;
            }

            if (DateTime.TryParseExact(v, format, CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal,
                out var result))
            {
                return result;
            }

            return DateTime.Parse(v, CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal);
        }

        public override DateTime FromDateTimeNull(DateTime? v)
        {
            return v ?? DateTime.MinValue;
        }

        public override DateTime? ToDateTimeNull(DateTime v)
        {
            return v != DateTime.MinValue ? v : (DateTime?)null;
        }

        public override DateTime FromBoolNull(bool? v, bool indeterminate)
        {
            throw new NotImplementedException();
        }

        public override DateTime FromDecimal(decimal v)
        {
            throw new NotImplementedException();
        }
    }
}