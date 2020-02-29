namespace MatBlazor
{
    public class MatVirtualScrollView
    {
        public int ClientHeight { get; set; }

        public int ScrollTop { get; set; }
    }

    public class MatVirtualScrollViewResult
    {
        public int Height { get; set; }
        public int SkipItems { get; set; }
        public int TakeItems { get; set; }
    }
}