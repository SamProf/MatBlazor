namespace MatBlazor
{
    public class MatPageSize
    {
        public long Value { get; set; }
        public string Text { get; set; }

        public MatPageSize(long value, string text)
        {
            Value = value;
            Text = text;
        }

        public MatPageSize(long value) : this(value, value.ToString())
        {
        }
    }
}