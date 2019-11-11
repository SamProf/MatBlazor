using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace MatBlazor
{
    public abstract class MatBlazorSwitchT<T>
    {
        public abstract T Increase(T v, T step, T max);
        public abstract T Decrease(T v, T step, T min);
        public abstract T Round(T v, int dp);

        public abstract T Minimum { get; }
        public abstract T Maximum { get; }
        public abstract T Step { get; }

        public abstract string FormatValueAsString(T v, string format);
        public abstract T ParseFromString(string v, string format);

        public abstract T FromDateTimeNull(DateTime? v);
        public abstract DateTime? ToDateTimeNull(T v);


        private static readonly MatSwitchT Ts = new MatSwitchT()
            .Case<MatBlazorSwitchT<sbyte>>(new MatBlazorSwitchTSByte())
            .Case<MatBlazorSwitchT<byte>>(new MatBlazorSwitchTByte())
            .Case<MatBlazorSwitchT<short>>(new MatBlazorSwitchTShort())
            .Case<MatBlazorSwitchT<ushort>>(new MatBlazorSwitchTUShort())
            .Case<MatBlazorSwitchT<int>>(new MatBlazorSwitchTInt())
            .Case<MatBlazorSwitchT<uint>>(new MatBlazorSwitchTUInt())
            .Case<MatBlazorSwitchT<long>>(new MatBlazorSwitchTLong())
            .Case<MatBlazorSwitchT<ulong>>(new MatBlazorSwitchTULong())
            .Case<MatBlazorSwitchT<char>>(new MatBlazorSwitchTChar())
            .Case<MatBlazorSwitchT<float>>(new MatBlazorSwitchTFloat())
            .Case<MatBlazorSwitchT<double>>(new MatBlazorSwitchTDouble())
            .Case<MatBlazorSwitchT<decimal>>(new MatBlazorSwitchTDecimal())
            .Case<MatBlazorSwitchT<decimal?>>(new MatBlazorSwitchTDecimalNull())
            .Case<MatBlazorSwitchT<string>>(new MatBlazorSwitchTString())
            .Case<MatBlazorSwitchT<DateTime>>(new MatBlazorSwitchTDateTime())
            .Case<MatBlazorSwitchT<DateTime?>>(new MatBlazorSwitchTDateTimeNull())
            ;

        public static MatBlazorSwitchT<T> Get()
        {
            return Ts.Get<MatBlazorSwitchT<T>>();
        }
    }
}