using System.Collections.Generic;

namespace MatBlazor
{
    public static partial class MatThemeColors
    {
        public static MatThemeColorRed Red { get; } = new MatThemeColorRed();
        public static MatThemeColorPink Pink { get; } = new MatThemeColorPink();
        public static MatThemeColorPurple Purple { get; } = new MatThemeColorPurple();
        public static MatThemeColorDeepPurple DeepPurple { get; } = new MatThemeColorDeepPurple();
        public static MatThemeColorIndigo Indigo { get; } = new MatThemeColorIndigo();
        public static MatThemeColorBlue Blue { get; } = new MatThemeColorBlue();
        public static MatThemeColorLightBlue LightBlue { get; } = new MatThemeColorLightBlue();
        public static MatThemeColorCyan Cyan { get; } = new MatThemeColorCyan();
        public static MatThemeColorTeal Teal { get; } = new MatThemeColorTeal();
        public static MatThemeColorGreen Green { get; } = new MatThemeColorGreen();
        public static MatThemeColorLightGreen LightGreen { get; } = new MatThemeColorLightGreen();
        public static MatThemeColorLime Lime { get; } = new MatThemeColorLime();
        public static MatThemeColorYellow Yellow { get; } = new MatThemeColorYellow();
        public static MatThemeColorAmber Amber { get; } = new MatThemeColorAmber();
        public static MatThemeColorOrange Orange { get; } = new MatThemeColorOrange();
        public static MatThemeColorDeepOrange DeepOrange { get; } = new MatThemeColorDeepOrange();
        public static MatThemeColorBrown Brown { get; } = new MatThemeColorBrown();
        public static MatThemeColorGrey Grey { get; } = new MatThemeColorGrey();
        public static MatThemeColorBlueGrey BlueGrey { get; } = new MatThemeColorBlueGrey();

        static MatThemeColors()
        {
            Items = new Dictionary<string, MatThemeColor>()
            {
                {Red.Key, Red},
                {Pink.Key, Pink},
                {Purple.Key, Purple},
                {DeepPurple.Key, DeepPurple},
                {Indigo.Key, Indigo},
                {Blue.Key, Blue},
                {LightBlue.Key, LightBlue},
                {Cyan.Key, Cyan},
                {Teal.Key, Teal},
                {Green.Key, Green},
                {LightGreen.Key, LightGreen},
                {Lime.Key, Lime},
                {Yellow.Key, Yellow},
                {Amber.Key, Amber},
                {Orange.Key, Orange},
                {DeepOrange.Key, DeepOrange},
                {Brown.Key, Brown},
                {Grey.Key, Grey},
                {BlueGrey.Key, BlueGrey},
            };
        }
    }

    public class MatThemeColorRed : MatThemeColor
    {
        public MatThemeColorShadow _50 { get; } = new MatThemeColorShadow("50", "_50", "#ffebee");
        public MatThemeColorShadow _100 { get; } = new MatThemeColorShadow("100", "_100", "#ffcdd2");
        public MatThemeColorShadow _200 { get; } = new MatThemeColorShadow("200", "_200", "#ef9a9a");
        public MatThemeColorShadow _300 { get; } = new MatThemeColorShadow("300", "_300", "#e57373");
        public MatThemeColorShadow _400 { get; } = new MatThemeColorShadow("400", "_400", "#ef5350");
        public MatThemeColorShadow _500 { get; } = new MatThemeColorShadow("500", "_500", "#f44336");
        public MatThemeColorShadow _600 { get; } = new MatThemeColorShadow("600", "_600", "#e53935");
        public MatThemeColorShadow _700 { get; } = new MatThemeColorShadow("700", "_700", "#d32f2f");
        public MatThemeColorShadow _800 { get; } = new MatThemeColorShadow("800", "_800", "#c62828");
        public MatThemeColorShadow _900 { get; } = new MatThemeColorShadow("900", "_900", "#b71c1c");
        public MatThemeColorShadow A100 { get; } = new MatThemeColorShadow("a100", "A100", "#ff8a80");
        public MatThemeColorShadow A200 { get; } = new MatThemeColorShadow("a200", "A200", "#ff5252");
        public MatThemeColorShadow A400 { get; } = new MatThemeColorShadow("a400", "A400", "#ff1744");
        public MatThemeColorShadow A700 { get; } = new MatThemeColorShadow("a700", "A700", "#d50000");

        public MatThemeColorRed() : base("red", "Red")
        {
            Shadows = new Dictionary<string, MatThemeColorShadow>()
            {
                {_50.Key, _50},
                {_100.Key, _100},
                {_200.Key, _200},
                {_300.Key, _300},
                {_400.Key, _400},
                {_500.Key, _500},
                {_600.Key, _600},
                {_700.Key, _700},
                {_800.Key, _800},
                {_900.Key, _900},
                {A100.Key, A100},
                {A200.Key, A200},
                {A400.Key, A400},
                {A700.Key, A700},
            };
        }
    }

    public class MatThemeColorPink : MatThemeColor
    {
        public MatThemeColorShadow _50 { get; } = new MatThemeColorShadow("50", "_50", "#fce4ec");
        public MatThemeColorShadow _100 { get; } = new MatThemeColorShadow("100", "_100", "#f8bbd0");
        public MatThemeColorShadow _200 { get; } = new MatThemeColorShadow("200", "_200", "#f48fb1");
        public MatThemeColorShadow _300 { get; } = new MatThemeColorShadow("300", "_300", "#f06292");
        public MatThemeColorShadow _400 { get; } = new MatThemeColorShadow("400", "_400", "#ec407a");
        public MatThemeColorShadow _500 { get; } = new MatThemeColorShadow("500", "_500", "#e91e63");
        public MatThemeColorShadow _600 { get; } = new MatThemeColorShadow("600", "_600", "#d81b60");
        public MatThemeColorShadow _700 { get; } = new MatThemeColorShadow("700", "_700", "#c2185b");
        public MatThemeColorShadow _800 { get; } = new MatThemeColorShadow("800", "_800", "#ad1457");
        public MatThemeColorShadow _900 { get; } = new MatThemeColorShadow("900", "_900", "#880e4f");
        public MatThemeColorShadow A100 { get; } = new MatThemeColorShadow("a100", "A100", "#ff80ab");
        public MatThemeColorShadow A200 { get; } = new MatThemeColorShadow("a200", "A200", "#ff4081");
        public MatThemeColorShadow A400 { get; } = new MatThemeColorShadow("a400", "A400", "#f50057");
        public MatThemeColorShadow A700 { get; } = new MatThemeColorShadow("a700", "A700", "#c51162");

        public MatThemeColorPink() : base("pink", "Pink")
        {
            Shadows = new Dictionary<string, MatThemeColorShadow>()
            {
                {_50.Key, _50},
                {_100.Key, _100},
                {_200.Key, _200},
                {_300.Key, _300},
                {_400.Key, _400},
                {_500.Key, _500},
                {_600.Key, _600},
                {_700.Key, _700},
                {_800.Key, _800},
                {_900.Key, _900},
                {A100.Key, A100},
                {A200.Key, A200},
                {A400.Key, A400},
                {A700.Key, A700},
            };
        }
    }

    public class MatThemeColorPurple : MatThemeColor
    {
        public MatThemeColorShadow _50 { get; } = new MatThemeColorShadow("50", "_50", "#f3e5f5");
        public MatThemeColorShadow _100 { get; } = new MatThemeColorShadow("100", "_100", "#e1bee7");
        public MatThemeColorShadow _200 { get; } = new MatThemeColorShadow("200", "_200", "#ce93d8");
        public MatThemeColorShadow _300 { get; } = new MatThemeColorShadow("300", "_300", "#ba68c8");
        public MatThemeColorShadow _400 { get; } = new MatThemeColorShadow("400", "_400", "#ab47bc");
        public MatThemeColorShadow _500 { get; } = new MatThemeColorShadow("500", "_500", "#9c27b0");
        public MatThemeColorShadow _600 { get; } = new MatThemeColorShadow("600", "_600", "#8e24aa");
        public MatThemeColorShadow _700 { get; } = new MatThemeColorShadow("700", "_700", "#7b1fa2");
        public MatThemeColorShadow _800 { get; } = new MatThemeColorShadow("800", "_800", "#6a1b9a");
        public MatThemeColorShadow _900 { get; } = new MatThemeColorShadow("900", "_900", "#4a148c");
        public MatThemeColorShadow A100 { get; } = new MatThemeColorShadow("a100", "A100", "#ea80fc");
        public MatThemeColorShadow A200 { get; } = new MatThemeColorShadow("a200", "A200", "#e040fb");
        public MatThemeColorShadow A400 { get; } = new MatThemeColorShadow("a400", "A400", "#d500f9");
        public MatThemeColorShadow A700 { get; } = new MatThemeColorShadow("a700", "A700", "#a0f");

        public MatThemeColorPurple() : base("purple", "Purple")
        {
            Shadows = new Dictionary<string, MatThemeColorShadow>()
            {
                {_50.Key, _50},
                {_100.Key, _100},
                {_200.Key, _200},
                {_300.Key, _300},
                {_400.Key, _400},
                {_500.Key, _500},
                {_600.Key, _600},
                {_700.Key, _700},
                {_800.Key, _800},
                {_900.Key, _900},
                {A100.Key, A100},
                {A200.Key, A200},
                {A400.Key, A400},
                {A700.Key, A700},
            };
        }
    }

    public class MatThemeColorDeepPurple : MatThemeColor
    {
        public MatThemeColorShadow _50 { get; } = new MatThemeColorShadow("50", "_50", "#ede7f6");
        public MatThemeColorShadow _100 { get; } = new MatThemeColorShadow("100", "_100", "#d1c4e9");
        public MatThemeColorShadow _200 { get; } = new MatThemeColorShadow("200", "_200", "#b39ddb");
        public MatThemeColorShadow _300 { get; } = new MatThemeColorShadow("300", "_300", "#9575cd");
        public MatThemeColorShadow _400 { get; } = new MatThemeColorShadow("400", "_400", "#7e57c2");
        public MatThemeColorShadow _500 { get; } = new MatThemeColorShadow("500", "_500", "#673ab7");
        public MatThemeColorShadow _600 { get; } = new MatThemeColorShadow("600", "_600", "#5e35b1");
        public MatThemeColorShadow _700 { get; } = new MatThemeColorShadow("700", "_700", "#512da8");
        public MatThemeColorShadow _800 { get; } = new MatThemeColorShadow("800", "_800", "#4527a0");
        public MatThemeColorShadow _900 { get; } = new MatThemeColorShadow("900", "_900", "#311b92");
        public MatThemeColorShadow A100 { get; } = new MatThemeColorShadow("a100", "A100", "#b388ff");
        public MatThemeColorShadow A200 { get; } = new MatThemeColorShadow("a200", "A200", "#7c4dff");
        public MatThemeColorShadow A400 { get; } = new MatThemeColorShadow("a400", "A400", "#651fff");
        public MatThemeColorShadow A700 { get; } = new MatThemeColorShadow("a700", "A700", "#6200ea");

        public MatThemeColorDeepPurple() : base("deep-purple", "DeepPurple")
        {
            Shadows = new Dictionary<string, MatThemeColorShadow>()
            {
                {_50.Key, _50},
                {_100.Key, _100},
                {_200.Key, _200},
                {_300.Key, _300},
                {_400.Key, _400},
                {_500.Key, _500},
                {_600.Key, _600},
                {_700.Key, _700},
                {_800.Key, _800},
                {_900.Key, _900},
                {A100.Key, A100},
                {A200.Key, A200},
                {A400.Key, A400},
                {A700.Key, A700},
            };
        }
    }

    public class MatThemeColorIndigo : MatThemeColor
    {
        public MatThemeColorShadow _50 { get; } = new MatThemeColorShadow("50", "_50", "#e8eaf6");
        public MatThemeColorShadow _100 { get; } = new MatThemeColorShadow("100", "_100", "#c5cae9");
        public MatThemeColorShadow _200 { get; } = new MatThemeColorShadow("200", "_200", "#9fa8da");
        public MatThemeColorShadow _300 { get; } = new MatThemeColorShadow("300", "_300", "#7986cb");
        public MatThemeColorShadow _400 { get; } = new MatThemeColorShadow("400", "_400", "#5c6bc0");
        public MatThemeColorShadow _500 { get; } = new MatThemeColorShadow("500", "_500", "#3f51b5");
        public MatThemeColorShadow _600 { get; } = new MatThemeColorShadow("600", "_600", "#3949ab");
        public MatThemeColorShadow _700 { get; } = new MatThemeColorShadow("700", "_700", "#303f9f");
        public MatThemeColorShadow _800 { get; } = new MatThemeColorShadow("800", "_800", "#283593");
        public MatThemeColorShadow _900 { get; } = new MatThemeColorShadow("900", "_900", "#1a237e");
        public MatThemeColorShadow A100 { get; } = new MatThemeColorShadow("a100", "A100", "#8c9eff");
        public MatThemeColorShadow A200 { get; } = new MatThemeColorShadow("a200", "A200", "#536dfe");
        public MatThemeColorShadow A400 { get; } = new MatThemeColorShadow("a400", "A400", "#3d5afe");
        public MatThemeColorShadow A700 { get; } = new MatThemeColorShadow("a700", "A700", "#304ffe");

        public MatThemeColorIndigo() : base("indigo", "Indigo")
        {
            Shadows = new Dictionary<string, MatThemeColorShadow>()
            {
                {_50.Key, _50},
                {_100.Key, _100},
                {_200.Key, _200},
                {_300.Key, _300},
                {_400.Key, _400},
                {_500.Key, _500},
                {_600.Key, _600},
                {_700.Key, _700},
                {_800.Key, _800},
                {_900.Key, _900},
                {A100.Key, A100},
                {A200.Key, A200},
                {A400.Key, A400},
                {A700.Key, A700},
            };
        }
    }

    public class MatThemeColorBlue : MatThemeColor
    {
        public MatThemeColorShadow _50 { get; } = new MatThemeColorShadow("50", "_50", "#e3f2fd");
        public MatThemeColorShadow _100 { get; } = new MatThemeColorShadow("100", "_100", "#bbdefb");
        public MatThemeColorShadow _200 { get; } = new MatThemeColorShadow("200", "_200", "#90caf9");
        public MatThemeColorShadow _300 { get; } = new MatThemeColorShadow("300", "_300", "#64b5f6");
        public MatThemeColorShadow _400 { get; } = new MatThemeColorShadow("400", "_400", "#42a5f5");
        public MatThemeColorShadow _500 { get; } = new MatThemeColorShadow("500", "_500", "#2196f3");
        public MatThemeColorShadow _600 { get; } = new MatThemeColorShadow("600", "_600", "#1e88e5");
        public MatThemeColorShadow _700 { get; } = new MatThemeColorShadow("700", "_700", "#1976d2");
        public MatThemeColorShadow _800 { get; } = new MatThemeColorShadow("800", "_800", "#1565c0");
        public MatThemeColorShadow _900 { get; } = new MatThemeColorShadow("900", "_900", "#0d47a1");
        public MatThemeColorShadow A100 { get; } = new MatThemeColorShadow("a100", "A100", "#82b1ff");
        public MatThemeColorShadow A200 { get; } = new MatThemeColorShadow("a200", "A200", "#448aff");
        public MatThemeColorShadow A400 { get; } = new MatThemeColorShadow("a400", "A400", "#2979ff");
        public MatThemeColorShadow A700 { get; } = new MatThemeColorShadow("a700", "A700", "#2962ff");

        public MatThemeColorBlue() : base("blue", "Blue")
        {
            Shadows = new Dictionary<string, MatThemeColorShadow>()
            {
                {_50.Key, _50},
                {_100.Key, _100},
                {_200.Key, _200},
                {_300.Key, _300},
                {_400.Key, _400},
                {_500.Key, _500},
                {_600.Key, _600},
                {_700.Key, _700},
                {_800.Key, _800},
                {_900.Key, _900},
                {A100.Key, A100},
                {A200.Key, A200},
                {A400.Key, A400},
                {A700.Key, A700},
            };
        }
    }

    public class MatThemeColorLightBlue : MatThemeColor
    {
        public MatThemeColorShadow _50 { get; } = new MatThemeColorShadow("50", "_50", "#e1f5fe");
        public MatThemeColorShadow _100 { get; } = new MatThemeColorShadow("100", "_100", "#b3e5fc");
        public MatThemeColorShadow _200 { get; } = new MatThemeColorShadow("200", "_200", "#81d4fa");
        public MatThemeColorShadow _300 { get; } = new MatThemeColorShadow("300", "_300", "#4fc3f7");
        public MatThemeColorShadow _400 { get; } = new MatThemeColorShadow("400", "_400", "#29b6f6");
        public MatThemeColorShadow _500 { get; } = new MatThemeColorShadow("500", "_500", "#03a9f4");
        public MatThemeColorShadow _600 { get; } = new MatThemeColorShadow("600", "_600", "#039be5");
        public MatThemeColorShadow _700 { get; } = new MatThemeColorShadow("700", "_700", "#0288d1");
        public MatThemeColorShadow _800 { get; } = new MatThemeColorShadow("800", "_800", "#0277bd");
        public MatThemeColorShadow _900 { get; } = new MatThemeColorShadow("900", "_900", "#01579b");
        public MatThemeColorShadow A100 { get; } = new MatThemeColorShadow("a100", "A100", "#80d8ff");
        public MatThemeColorShadow A200 { get; } = new MatThemeColorShadow("a200", "A200", "#40c4ff");
        public MatThemeColorShadow A400 { get; } = new MatThemeColorShadow("a400", "A400", "#00b0ff");
        public MatThemeColorShadow A700 { get; } = new MatThemeColorShadow("a700", "A700", "#0091ea");

        public MatThemeColorLightBlue() : base("light-blue", "LightBlue")
        {
            Shadows = new Dictionary<string, MatThemeColorShadow>()
            {
                {_50.Key, _50},
                {_100.Key, _100},
                {_200.Key, _200},
                {_300.Key, _300},
                {_400.Key, _400},
                {_500.Key, _500},
                {_600.Key, _600},
                {_700.Key, _700},
                {_800.Key, _800},
                {_900.Key, _900},
                {A100.Key, A100},
                {A200.Key, A200},
                {A400.Key, A400},
                {A700.Key, A700},
            };
        }
    }

    public class MatThemeColorCyan : MatThemeColor
    {
        public MatThemeColorShadow _50 { get; } = new MatThemeColorShadow("50", "_50", "#e0f7fa");
        public MatThemeColorShadow _100 { get; } = new MatThemeColorShadow("100", "_100", "#b2ebf2");
        public MatThemeColorShadow _200 { get; } = new MatThemeColorShadow("200", "_200", "#80deea");
        public MatThemeColorShadow _300 { get; } = new MatThemeColorShadow("300", "_300", "#4dd0e1");
        public MatThemeColorShadow _400 { get; } = new MatThemeColorShadow("400", "_400", "#26c6da");
        public MatThemeColorShadow _500 { get; } = new MatThemeColorShadow("500", "_500", "#00bcd4");
        public MatThemeColorShadow _600 { get; } = new MatThemeColorShadow("600", "_600", "#00acc1");
        public MatThemeColorShadow _700 { get; } = new MatThemeColorShadow("700", "_700", "#0097a7");
        public MatThemeColorShadow _800 { get; } = new MatThemeColorShadow("800", "_800", "#00838f");
        public MatThemeColorShadow _900 { get; } = new MatThemeColorShadow("900", "_900", "#006064");
        public MatThemeColorShadow A100 { get; } = new MatThemeColorShadow("a100", "A100", "#84ffff");
        public MatThemeColorShadow A200 { get; } = new MatThemeColorShadow("a200", "A200", "#18ffff");
        public MatThemeColorShadow A400 { get; } = new MatThemeColorShadow("a400", "A400", "#00e5ff");
        public MatThemeColorShadow A700 { get; } = new MatThemeColorShadow("a700", "A700", "#00b8d4");

        public MatThemeColorCyan() : base("cyan", "Cyan")
        {
            Shadows = new Dictionary<string, MatThemeColorShadow>()
            {
                {_50.Key, _50},
                {_100.Key, _100},
                {_200.Key, _200},
                {_300.Key, _300},
                {_400.Key, _400},
                {_500.Key, _500},
                {_600.Key, _600},
                {_700.Key, _700},
                {_800.Key, _800},
                {_900.Key, _900},
                {A100.Key, A100},
                {A200.Key, A200},
                {A400.Key, A400},
                {A700.Key, A700},
            };
        }
    }

    public class MatThemeColorTeal : MatThemeColor
    {
        public MatThemeColorShadow _50 { get; } = new MatThemeColorShadow("50", "_50", "#e0f2f1");
        public MatThemeColorShadow _100 { get; } = new MatThemeColorShadow("100", "_100", "#b2dfdb");
        public MatThemeColorShadow _200 { get; } = new MatThemeColorShadow("200", "_200", "#80cbc4");
        public MatThemeColorShadow _300 { get; } = new MatThemeColorShadow("300", "_300", "#4db6ac");
        public MatThemeColorShadow _400 { get; } = new MatThemeColorShadow("400", "_400", "#26a69a");
        public MatThemeColorShadow _500 { get; } = new MatThemeColorShadow("500", "_500", "#009688");
        public MatThemeColorShadow _600 { get; } = new MatThemeColorShadow("600", "_600", "#00897b");
        public MatThemeColorShadow _700 { get; } = new MatThemeColorShadow("700", "_700", "#00796b");
        public MatThemeColorShadow _800 { get; } = new MatThemeColorShadow("800", "_800", "#00695c");
        public MatThemeColorShadow _900 { get; } = new MatThemeColorShadow("900", "_900", "#004d40");
        public MatThemeColorShadow A100 { get; } = new MatThemeColorShadow("a100", "A100", "#a7ffeb");
        public MatThemeColorShadow A200 { get; } = new MatThemeColorShadow("a200", "A200", "#64ffda");
        public MatThemeColorShadow A400 { get; } = new MatThemeColorShadow("a400", "A400", "#1de9b6");
        public MatThemeColorShadow A700 { get; } = new MatThemeColorShadow("a700", "A700", "#00bfa5");

        public MatThemeColorTeal() : base("teal", "Teal")
        {
            Shadows = new Dictionary<string, MatThemeColorShadow>()
            {
                {_50.Key, _50},
                {_100.Key, _100},
                {_200.Key, _200},
                {_300.Key, _300},
                {_400.Key, _400},
                {_500.Key, _500},
                {_600.Key, _600},
                {_700.Key, _700},
                {_800.Key, _800},
                {_900.Key, _900},
                {A100.Key, A100},
                {A200.Key, A200},
                {A400.Key, A400},
                {A700.Key, A700},
            };
        }
    }

    public class MatThemeColorGreen : MatThemeColor
    {
        public MatThemeColorShadow _50 { get; } = new MatThemeColorShadow("50", "_50", "#e8f5e9");
        public MatThemeColorShadow _100 { get; } = new MatThemeColorShadow("100", "_100", "#c8e6c9");
        public MatThemeColorShadow _200 { get; } = new MatThemeColorShadow("200", "_200", "#a5d6a7");
        public MatThemeColorShadow _300 { get; } = new MatThemeColorShadow("300", "_300", "#81c784");
        public MatThemeColorShadow _400 { get; } = new MatThemeColorShadow("400", "_400", "#66bb6a");
        public MatThemeColorShadow _500 { get; } = new MatThemeColorShadow("500", "_500", "#4caf50");
        public MatThemeColorShadow _600 { get; } = new MatThemeColorShadow("600", "_600", "#43a047");
        public MatThemeColorShadow _700 { get; } = new MatThemeColorShadow("700", "_700", "#388e3c");
        public MatThemeColorShadow _800 { get; } = new MatThemeColorShadow("800", "_800", "#2e7d32");
        public MatThemeColorShadow _900 { get; } = new MatThemeColorShadow("900", "_900", "#1b5e20");
        public MatThemeColorShadow A100 { get; } = new MatThemeColorShadow("a100", "A100", "#b9f6ca");
        public MatThemeColorShadow A200 { get; } = new MatThemeColorShadow("a200", "A200", "#69f0ae");
        public MatThemeColorShadow A400 { get; } = new MatThemeColorShadow("a400", "A400", "#00e676");
        public MatThemeColorShadow A700 { get; } = new MatThemeColorShadow("a700", "A700", "#00c853");

        public MatThemeColorGreen() : base("green", "Green")
        {
            Shadows = new Dictionary<string, MatThemeColorShadow>()
            {
                {_50.Key, _50},
                {_100.Key, _100},
                {_200.Key, _200},
                {_300.Key, _300},
                {_400.Key, _400},
                {_500.Key, _500},
                {_600.Key, _600},
                {_700.Key, _700},
                {_800.Key, _800},
                {_900.Key, _900},
                {A100.Key, A100},
                {A200.Key, A200},
                {A400.Key, A400},
                {A700.Key, A700},
            };
        }
    }

    public class MatThemeColorLightGreen : MatThemeColor
    {
        public MatThemeColorShadow _50 { get; } = new MatThemeColorShadow("50", "_50", "#f1f8e9");
        public MatThemeColorShadow _100 { get; } = new MatThemeColorShadow("100", "_100", "#dcedc8");
        public MatThemeColorShadow _200 { get; } = new MatThemeColorShadow("200", "_200", "#c5e1a5");
        public MatThemeColorShadow _300 { get; } = new MatThemeColorShadow("300", "_300", "#aed581");
        public MatThemeColorShadow _400 { get; } = new MatThemeColorShadow("400", "_400", "#9ccc65");
        public MatThemeColorShadow _500 { get; } = new MatThemeColorShadow("500", "_500", "#8bc34a");
        public MatThemeColorShadow _600 { get; } = new MatThemeColorShadow("600", "_600", "#7cb342");
        public MatThemeColorShadow _700 { get; } = new MatThemeColorShadow("700", "_700", "#689f38");
        public MatThemeColorShadow _800 { get; } = new MatThemeColorShadow("800", "_800", "#558b2f");
        public MatThemeColorShadow _900 { get; } = new MatThemeColorShadow("900", "_900", "#33691e");
        public MatThemeColorShadow A100 { get; } = new MatThemeColorShadow("a100", "A100", "#ccff90");
        public MatThemeColorShadow A200 { get; } = new MatThemeColorShadow("a200", "A200", "#b2ff59");
        public MatThemeColorShadow A400 { get; } = new MatThemeColorShadow("a400", "A400", "#76ff03");
        public MatThemeColorShadow A700 { get; } = new MatThemeColorShadow("a700", "A700", "#64dd17");

        public MatThemeColorLightGreen() : base("light-green", "LightGreen")
        {
            Shadows = new Dictionary<string, MatThemeColorShadow>()
            {
                {_50.Key, _50},
                {_100.Key, _100},
                {_200.Key, _200},
                {_300.Key, _300},
                {_400.Key, _400},
                {_500.Key, _500},
                {_600.Key, _600},
                {_700.Key, _700},
                {_800.Key, _800},
                {_900.Key, _900},
                {A100.Key, A100},
                {A200.Key, A200},
                {A400.Key, A400},
                {A700.Key, A700},
            };
        }
    }

    public class MatThemeColorLime : MatThemeColor
    {
        public MatThemeColorShadow _50 { get; } = new MatThemeColorShadow("50", "_50", "#f9fbe7");
        public MatThemeColorShadow _100 { get; } = new MatThemeColorShadow("100", "_100", "#f0f4c3");
        public MatThemeColorShadow _200 { get; } = new MatThemeColorShadow("200", "_200", "#e6ee9c");
        public MatThemeColorShadow _300 { get; } = new MatThemeColorShadow("300", "_300", "#dce775");
        public MatThemeColorShadow _400 { get; } = new MatThemeColorShadow("400", "_400", "#d4e157");
        public MatThemeColorShadow _500 { get; } = new MatThemeColorShadow("500", "_500", "#cddc39");
        public MatThemeColorShadow _600 { get; } = new MatThemeColorShadow("600", "_600", "#c0ca33");
        public MatThemeColorShadow _700 { get; } = new MatThemeColorShadow("700", "_700", "#afb42b");
        public MatThemeColorShadow _800 { get; } = new MatThemeColorShadow("800", "_800", "#9e9d24");
        public MatThemeColorShadow _900 { get; } = new MatThemeColorShadow("900", "_900", "#827717");
        public MatThemeColorShadow A100 { get; } = new MatThemeColorShadow("a100", "A100", "#f4ff81");
        public MatThemeColorShadow A200 { get; } = new MatThemeColorShadow("a200", "A200", "#eeff41");
        public MatThemeColorShadow A400 { get; } = new MatThemeColorShadow("a400", "A400", "#c6ff00");
        public MatThemeColorShadow A700 { get; } = new MatThemeColorShadow("a700", "A700", "#aeea00");

        public MatThemeColorLime() : base("lime", "Lime")
        {
            Shadows = new Dictionary<string, MatThemeColorShadow>()
            {
                {_50.Key, _50},
                {_100.Key, _100},
                {_200.Key, _200},
                {_300.Key, _300},
                {_400.Key, _400},
                {_500.Key, _500},
                {_600.Key, _600},
                {_700.Key, _700},
                {_800.Key, _800},
                {_900.Key, _900},
                {A100.Key, A100},
                {A200.Key, A200},
                {A400.Key, A400},
                {A700.Key, A700},
            };
        }
    }

    public class MatThemeColorYellow : MatThemeColor
    {
        public MatThemeColorShadow _50 { get; } = new MatThemeColorShadow("50", "_50", "#fffde7");
        public MatThemeColorShadow _100 { get; } = new MatThemeColorShadow("100", "_100", "#fff9c4");
        public MatThemeColorShadow _200 { get; } = new MatThemeColorShadow("200", "_200", "#fff59d");
        public MatThemeColorShadow _300 { get; } = new MatThemeColorShadow("300", "_300", "#fff176");
        public MatThemeColorShadow _400 { get; } = new MatThemeColorShadow("400", "_400", "#ffee58");
        public MatThemeColorShadow _500 { get; } = new MatThemeColorShadow("500", "_500", "#ffeb3b");
        public MatThemeColorShadow _600 { get; } = new MatThemeColorShadow("600", "_600", "#fdd835");
        public MatThemeColorShadow _700 { get; } = new MatThemeColorShadow("700", "_700", "#fbc02d");
        public MatThemeColorShadow _800 { get; } = new MatThemeColorShadow("800", "_800", "#f9a825");
        public MatThemeColorShadow _900 { get; } = new MatThemeColorShadow("900", "_900", "#f57f17");
        public MatThemeColorShadow A100 { get; } = new MatThemeColorShadow("a100", "A100", "#ffff8d");
        public MatThemeColorShadow A200 { get; } = new MatThemeColorShadow("a200", "A200", "#ff0");
        public MatThemeColorShadow A400 { get; } = new MatThemeColorShadow("a400", "A400", "#ffea00");
        public MatThemeColorShadow A700 { get; } = new MatThemeColorShadow("a700", "A700", "#ffd600");

        public MatThemeColorYellow() : base("yellow", "Yellow")
        {
            Shadows = new Dictionary<string, MatThemeColorShadow>()
            {
                {_50.Key, _50},
                {_100.Key, _100},
                {_200.Key, _200},
                {_300.Key, _300},
                {_400.Key, _400},
                {_500.Key, _500},
                {_600.Key, _600},
                {_700.Key, _700},
                {_800.Key, _800},
                {_900.Key, _900},
                {A100.Key, A100},
                {A200.Key, A200},
                {A400.Key, A400},
                {A700.Key, A700},
            };
        }
    }

    public class MatThemeColorAmber : MatThemeColor
    {
        public MatThemeColorShadow _50 { get; } = new MatThemeColorShadow("50", "_50", "#fff8e1");
        public MatThemeColorShadow _100 { get; } = new MatThemeColorShadow("100", "_100", "#ffecb3");
        public MatThemeColorShadow _200 { get; } = new MatThemeColorShadow("200", "_200", "#ffe082");
        public MatThemeColorShadow _300 { get; } = new MatThemeColorShadow("300", "_300", "#ffd54f");
        public MatThemeColorShadow _400 { get; } = new MatThemeColorShadow("400", "_400", "#ffca28");
        public MatThemeColorShadow _500 { get; } = new MatThemeColorShadow("500", "_500", "#ffc107");
        public MatThemeColorShadow _600 { get; } = new MatThemeColorShadow("600", "_600", "#ffb300");
        public MatThemeColorShadow _700 { get; } = new MatThemeColorShadow("700", "_700", "#ffa000");
        public MatThemeColorShadow _800 { get; } = new MatThemeColorShadow("800", "_800", "#ff8f00");
        public MatThemeColorShadow _900 { get; } = new MatThemeColorShadow("900", "_900", "#ff6f00");
        public MatThemeColorShadow A100 { get; } = new MatThemeColorShadow("a100", "A100", "#ffe57f");
        public MatThemeColorShadow A200 { get; } = new MatThemeColorShadow("a200", "A200", "#ffd740");
        public MatThemeColorShadow A400 { get; } = new MatThemeColorShadow("a400", "A400", "#ffc400");
        public MatThemeColorShadow A700 { get; } = new MatThemeColorShadow("a700", "A700", "#ffab00");

        public MatThemeColorAmber() : base("amber", "Amber")
        {
            Shadows = new Dictionary<string, MatThemeColorShadow>()
            {
                {_50.Key, _50},
                {_100.Key, _100},
                {_200.Key, _200},
                {_300.Key, _300},
                {_400.Key, _400},
                {_500.Key, _500},
                {_600.Key, _600},
                {_700.Key, _700},
                {_800.Key, _800},
                {_900.Key, _900},
                {A100.Key, A100},
                {A200.Key, A200},
                {A400.Key, A400},
                {A700.Key, A700},
            };
        }
    }

    public class MatThemeColorOrange : MatThemeColor
    {
        public MatThemeColorShadow _50 { get; } = new MatThemeColorShadow("50", "_50", "#fff3e0");
        public MatThemeColorShadow _100 { get; } = new MatThemeColorShadow("100", "_100", "#ffe0b2");
        public MatThemeColorShadow _200 { get; } = new MatThemeColorShadow("200", "_200", "#ffcc80");
        public MatThemeColorShadow _300 { get; } = new MatThemeColorShadow("300", "_300", "#ffb74d");
        public MatThemeColorShadow _400 { get; } = new MatThemeColorShadow("400", "_400", "#ffa726");
        public MatThemeColorShadow _500 { get; } = new MatThemeColorShadow("500", "_500", "#ff9800");
        public MatThemeColorShadow _600 { get; } = new MatThemeColorShadow("600", "_600", "#fb8c00");
        public MatThemeColorShadow _700 { get; } = new MatThemeColorShadow("700", "_700", "#f57c00");
        public MatThemeColorShadow _800 { get; } = new MatThemeColorShadow("800", "_800", "#ef6c00");
        public MatThemeColorShadow _900 { get; } = new MatThemeColorShadow("900", "_900", "#e65100");
        public MatThemeColorShadow A100 { get; } = new MatThemeColorShadow("a100", "A100", "#ffd180");
        public MatThemeColorShadow A200 { get; } = new MatThemeColorShadow("a200", "A200", "#ffab40");
        public MatThemeColorShadow A400 { get; } = new MatThemeColorShadow("a400", "A400", "#ff9100");
        public MatThemeColorShadow A700 { get; } = new MatThemeColorShadow("a700", "A700", "#ff6d00");

        public MatThemeColorOrange() : base("orange", "Orange")
        {
            Shadows = new Dictionary<string, MatThemeColorShadow>()
            {
                {_50.Key, _50},
                {_100.Key, _100},
                {_200.Key, _200},
                {_300.Key, _300},
                {_400.Key, _400},
                {_500.Key, _500},
                {_600.Key, _600},
                {_700.Key, _700},
                {_800.Key, _800},
                {_900.Key, _900},
                {A100.Key, A100},
                {A200.Key, A200},
                {A400.Key, A400},
                {A700.Key, A700},
            };
        }
    }

    public class MatThemeColorDeepOrange : MatThemeColor
    {
        public MatThemeColorShadow _50 { get; } = new MatThemeColorShadow("50", "_50", "#fbe9e7");
        public MatThemeColorShadow _100 { get; } = new MatThemeColorShadow("100", "_100", "#ffccbc");
        public MatThemeColorShadow _200 { get; } = new MatThemeColorShadow("200", "_200", "#ffab91");
        public MatThemeColorShadow _300 { get; } = new MatThemeColorShadow("300", "_300", "#ff8a65");
        public MatThemeColorShadow _400 { get; } = new MatThemeColorShadow("400", "_400", "#ff7043");
        public MatThemeColorShadow _500 { get; } = new MatThemeColorShadow("500", "_500", "#ff5722");
        public MatThemeColorShadow _600 { get; } = new MatThemeColorShadow("600", "_600", "#f4511e");
        public MatThemeColorShadow _700 { get; } = new MatThemeColorShadow("700", "_700", "#e64a19");
        public MatThemeColorShadow _800 { get; } = new MatThemeColorShadow("800", "_800", "#d84315");
        public MatThemeColorShadow _900 { get; } = new MatThemeColorShadow("900", "_900", "#bf360c");
        public MatThemeColorShadow A100 { get; } = new MatThemeColorShadow("a100", "A100", "#ff9e80");
        public MatThemeColorShadow A200 { get; } = new MatThemeColorShadow("a200", "A200", "#ff6e40");
        public MatThemeColorShadow A400 { get; } = new MatThemeColorShadow("a400", "A400", "#ff3d00");
        public MatThemeColorShadow A700 { get; } = new MatThemeColorShadow("a700", "A700", "#dd2c00");

        public MatThemeColorDeepOrange() : base("deep-orange", "DeepOrange")
        {
            Shadows = new Dictionary<string, MatThemeColorShadow>()
            {
                {_50.Key, _50},
                {_100.Key, _100},
                {_200.Key, _200},
                {_300.Key, _300},
                {_400.Key, _400},
                {_500.Key, _500},
                {_600.Key, _600},
                {_700.Key, _700},
                {_800.Key, _800},
                {_900.Key, _900},
                {A100.Key, A100},
                {A200.Key, A200},
                {A400.Key, A400},
                {A700.Key, A700},
            };
        }
    }

    public class MatThemeColorBrown : MatThemeColor
    {
        public MatThemeColorShadow _50 { get; } = new MatThemeColorShadow("50", "_50", "#efebe9");
        public MatThemeColorShadow _100 { get; } = new MatThemeColorShadow("100", "_100", "#d7ccc8");
        public MatThemeColorShadow _200 { get; } = new MatThemeColorShadow("200", "_200", "#bcaaa4");
        public MatThemeColorShadow _300 { get; } = new MatThemeColorShadow("300", "_300", "#a1887f");
        public MatThemeColorShadow _400 { get; } = new MatThemeColorShadow("400", "_400", "#8d6e63");
        public MatThemeColorShadow _500 { get; } = new MatThemeColorShadow("500", "_500", "#795548");
        public MatThemeColorShadow _600 { get; } = new MatThemeColorShadow("600", "_600", "#6d4c41");
        public MatThemeColorShadow _700 { get; } = new MatThemeColorShadow("700", "_700", "#5d4037");
        public MatThemeColorShadow _800 { get; } = new MatThemeColorShadow("800", "_800", "#4e342e");
        public MatThemeColorShadow _900 { get; } = new MatThemeColorShadow("900", "_900", "#3e2723");

        public MatThemeColorBrown() : base("brown", "Brown")
        {
            Shadows = new Dictionary<string, MatThemeColorShadow>()
            {
                {_50.Key, _50},
                {_100.Key, _100},
                {_200.Key, _200},
                {_300.Key, _300},
                {_400.Key, _400},
                {_500.Key, _500},
                {_600.Key, _600},
                {_700.Key, _700},
                {_800.Key, _800},
                {_900.Key, _900},
            };
        }
    }

    public class MatThemeColorGrey : MatThemeColor
    {
        public MatThemeColorShadow _50 { get; } = new MatThemeColorShadow("50", "_50", "#fafafa");
        public MatThemeColorShadow _100 { get; } = new MatThemeColorShadow("100", "_100", "#f5f5f5");
        public MatThemeColorShadow _200 { get; } = new MatThemeColorShadow("200", "_200", "#eee");
        public MatThemeColorShadow _300 { get; } = new MatThemeColorShadow("300", "_300", "#e0e0e0");
        public MatThemeColorShadow _400 { get; } = new MatThemeColorShadow("400", "_400", "#bdbdbd");
        public MatThemeColorShadow _500 { get; } = new MatThemeColorShadow("500", "_500", "#9e9e9e");
        public MatThemeColorShadow _600 { get; } = new MatThemeColorShadow("600", "_600", "#757575");
        public MatThemeColorShadow _700 { get; } = new MatThemeColorShadow("700", "_700", "#616161");
        public MatThemeColorShadow _800 { get; } = new MatThemeColorShadow("800", "_800", "#424242");
        public MatThemeColorShadow _900 { get; } = new MatThemeColorShadow("900", "_900", "#212121");

        public MatThemeColorGrey() : base("grey", "Grey")
        {
            Shadows = new Dictionary<string, MatThemeColorShadow>()
            {
                {_50.Key, _50},
                {_100.Key, _100},
                {_200.Key, _200},
                {_300.Key, _300},
                {_400.Key, _400},
                {_500.Key, _500},
                {_600.Key, _600},
                {_700.Key, _700},
                {_800.Key, _800},
                {_900.Key, _900},
            };
        }
    }

    public class MatThemeColorBlueGrey : MatThemeColor
    {
        public MatThemeColorShadow _50 { get; } = new MatThemeColorShadow("50", "_50", "#eceff1");
        public MatThemeColorShadow _100 { get; } = new MatThemeColorShadow("100", "_100", "#cfd8dc");
        public MatThemeColorShadow _200 { get; } = new MatThemeColorShadow("200", "_200", "#b0bec5");
        public MatThemeColorShadow _300 { get; } = new MatThemeColorShadow("300", "_300", "#90a4ae");
        public MatThemeColorShadow _400 { get; } = new MatThemeColorShadow("400", "_400", "#78909c");
        public MatThemeColorShadow _500 { get; } = new MatThemeColorShadow("500", "_500", "#607d8b");
        public MatThemeColorShadow _600 { get; } = new MatThemeColorShadow("600", "_600", "#546e7a");
        public MatThemeColorShadow _700 { get; } = new MatThemeColorShadow("700", "_700", "#455a64");
        public MatThemeColorShadow _800 { get; } = new MatThemeColorShadow("800", "_800", "#37474f");
        public MatThemeColorShadow _900 { get; } = new MatThemeColorShadow("900", "_900", "#263238");

        public MatThemeColorBlueGrey() : base("blue-grey", "BlueGrey")
        {
            Shadows = new Dictionary<string, MatThemeColorShadow>()
            {
                {_50.Key, _50},
                {_100.Key, _100},
                {_200.Key, _200},
                {_300.Key, _300},
                {_400.Key, _400},
                {_500.Key, _500},
                {_600.Key, _600},
                {_700.Key, _700},
                {_800.Key, _800},
                {_900.Key, _900},
            };
        }
    }
}