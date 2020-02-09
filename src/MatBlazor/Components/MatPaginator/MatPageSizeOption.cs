namespace MatBlazor
{
    public class MatPageSizeOption
    {
        public int Value { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }

        public MatPageSizeOption(int value, string text)
        {
            Value = value;
            Text = text;
        }

        public MatPageSizeOption(int value) : this(value, value.ToString())
        {
        }
    }
}