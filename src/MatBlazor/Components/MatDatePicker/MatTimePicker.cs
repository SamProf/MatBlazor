using System.Globalization;

namespace MatBlazor
{
    public class MatTimePicker<TValue> : MatDatePickerInternal<TValue>
    {
        public MatTimePicker()
        {
            base.NoCalendar = true;
            base.EnableTime = true;
            base.Format = CultureInfo.CurrentUICulture.DateTimeFormat.ShortTimePattern;
        }
    }
}