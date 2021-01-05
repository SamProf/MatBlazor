using System;

namespace MatBlazor
{
    public class MatProgressCircleSvgSize
    {
        private static Lazy<MatProgressCircleSvgSize> _Large = new Lazy<MatProgressCircleSvgSize>(() => new MatProgressCircleSvgSize
        {
            ViewBox = "0 0 48 48",
            CoordinatesX = 24,
            CoordinatesY = 24,
            Radius = 18,
            StokeDasharray = 113.097,
            StokeDashoffset = 56.549
        });
        private static Lazy<MatProgressCircleSvgSize> _Medium = new Lazy<MatProgressCircleSvgSize>(() => new MatProgressCircleSvgSize
        {
            ViewBox = "0 0 32 32",
            CoordinatesX = 16,
            CoordinatesY = 16,
            Radius = 12.5,
            StokeDasharray = 78.54,
            StokeDashoffset = 39.27
        });
        private static Lazy<MatProgressCircleSvgSize> _Small = new Lazy<MatProgressCircleSvgSize>(() => new MatProgressCircleSvgSize
        {
            ViewBox = "0 0 24 24",
            CoordinatesX = 12,
            CoordinatesY = 12,
            Radius = 8.75,
            StokeDasharray = 54.978,
            StokeDashoffset = 27.489
        });

        public static MatProgressCircleSvgSize Small => _Small.Value;

        public static MatProgressCircleSvgSize Medium => _Medium.Value;

        public static MatProgressCircleSvgSize Large => _Large.Value;

        private MatProgressCircleSvgSize() { }

        public string ViewBox { get; private set; }

        public int CoordinatesX { get; private set; }

        public int CoordinatesY { get; private set; }

        public double Radius { get; private set; }

        public double StokeDasharray { get; private set; }

        public double StokeDashoffset { get; private set; }
    }
}
