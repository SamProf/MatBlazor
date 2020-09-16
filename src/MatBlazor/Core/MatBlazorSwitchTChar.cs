using System;

namespace MatBlazor
{
    public class MatBlazorSwitchTChar : MatBlazorSwitchT<char>
    {
        public override char Clamp(char v, char min, char max)
        {
            return v < min ? min : v > max ? max : v;
        }

        public override char Increase(char v, char step)
        {
            checked
            {
                try
                {
                    return (char) (v + step);
                }
                catch (OverflowException)
                {
                    return char.MaxValue;
                }
            }
        }

        public override char Decrease(char v, char step)
        {
            checked
            {
                try
                {
                    return (char)(v - step);
                }
                catch (OverflowException)
                {
                    return char.MinValue;
                }
            }
        }

        public override char Round(char v, int dp)
        {
            return v;
        }

        public override char GetMinimum() => char.MinValue;
        public override char GetMaximum() => char.MaxValue;

        public override char GetStep() => (char)1;

        public override string FormatValueAsString(char v, string format)
        {
            return v.ToString();
        }

        public override char ParseFromString(string v, string format)
        {
            return char.Parse(v);
        }

        public override char FromDateTimeNull(DateTime? v)
        {
            throw new NotImplementedException();
        }

        public override DateTime? ToDateTimeNull(char v)
        {
            throw new NotImplementedException();
        }

        public override char FromBoolNull(bool? v, bool indeterminate)
        {
            throw new NotImplementedException();
        }

        public override char FromDecimal(decimal v)
        {
            return (char)v;
        }
    }
}