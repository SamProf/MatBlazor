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

        public abstract T GetMinimum();
        public abstract T GetMaximum();
        public abstract T GetStep();

        public abstract string FormatValueAsString(T v, string format);
        public abstract T ParseFromString(string v, string format);

        public abstract T FromDateTimeNull(DateTime? v);
        public abstract DateTime? ToDateTimeNull(T v);

        public abstract T FromBoolNull(bool? v, bool indeterminate);

        public abstract T FromDecimal(decimal v);

        public virtual bool ToBool(T v)
        {
            throw new NotImplementedException();
        }

        public virtual T FromBool(bool v)
        {
            throw new NotImplementedException();
        }

        private static readonly MatSwitchT Ts = new MatSwitchT()
            .Case<MatBlazorSwitchT<sbyte>>(new MatBlazorSwitchTSByte())
            .Case<MatBlazorSwitchT<sbyte?>>(new MatBlazorSwitchTSByteNull())
            .Case<MatBlazorSwitchT<byte>>(new MatBlazorSwitchTByte())
            .Case<MatBlazorSwitchT<byte?>>(new MatBlazorSwitchTByteNull())
            .Case<MatBlazorSwitchT<short>>(new MatBlazorSwitchTShort())
            .Case<MatBlazorSwitchT<short?>>(new MatBlazorSwitchTShortNull())
            .Case<MatBlazorSwitchT<ushort>>(new MatBlazorSwitchTUShort())
            .Case<MatBlazorSwitchT<ushort?>>(new MatBlazorSwitchTUShortNull())
            .Case<MatBlazorSwitchT<int>>(new MatBlazorSwitchTInt())
            .Case<MatBlazorSwitchT<int?>>(new MatBlazorSwitchTIntNull())
            .Case<MatBlazorSwitchT<uint>>(new MatBlazorSwitchTUInt())
            .Case<MatBlazorSwitchT<uint?>>(new MatBlazorSwitchTUIntNull())
            .Case<MatBlazorSwitchT<long>>(new MatBlazorSwitchTLong())
            .Case<MatBlazorSwitchT<long?>>(new MatBlazorSwitchTLongNull())
            .Case<MatBlazorSwitchT<ulong>>(new MatBlazorSwitchTULong())
            .Case<MatBlazorSwitchT<ulong?>>(new MatBlazorSwitchTULongNull())
            .Case<MatBlazorSwitchT<char>>(new MatBlazorSwitchTChar())
            .Case<MatBlazorSwitchT<char?>>(new MatBlazorSwitchTCharNull())
            .Case<MatBlazorSwitchT<float>>(new MatBlazorSwitchTFloat())
            .Case<MatBlazorSwitchT<float?>>(new MatBlazorSwitchTFloatNull())
            .Case<MatBlazorSwitchT<double>>(new MatBlazorSwitchTDouble())
            .Case<MatBlazorSwitchT<double?>>(new MatBlazorSwitchTDoubleNull())
            .Case<MatBlazorSwitchT<decimal>>(new MatBlazorSwitchTDecimal())
            .Case<MatBlazorSwitchT<decimal?>>(new MatBlazorSwitchTDecimalNull())
            .Case<MatBlazorSwitchT<string>>(new MatBlazorSwitchTString())
            .Case<MatBlazorSwitchT<DateTime>>(new MatBlazorSwitchTDateTime())
            .Case<MatBlazorSwitchT<DateTime?>>(new MatBlazorSwitchTDateTimeNull())
            .Case<MatBlazorSwitchT<bool>>(new MatBlazorSwitchTBool())
            .Case<MatBlazorSwitchT<bool?>>(new MatBlazorSwitchTBoolNull())
            .Case<MatBlazorSwitchT<Guid>>(new MatBlazorSwitchTGuid())
            .Case<MatBlazorSwitchT<Guid?>>(new MatBlazorSwitchTGuidNull());

        public static MatBlazorSwitchT<T> Get()
        {
            return Ts.Get<MatBlazorSwitchT<T>>();
        }
    }
}