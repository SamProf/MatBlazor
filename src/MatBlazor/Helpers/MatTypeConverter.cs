using System;

namespace MatBlazor
{
    public static class MatTypeConverter
    {
        public static T ChangeType<T>(object value)
        {
            var t = typeof(T);

            if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                {
                    return default;
                }

                t = Nullable.GetUnderlyingType(t);
            }

            return (T)Convert.ChangeType(value, t);
        }
    }

    //    public static class MatTypeConverterManager
    //    {
    //        private static Dictionary<Type, Dictionary<Type, MatTypeConverter>> Converters;
    //
    //
    //        static MatTypeConverterManager()
    //        {
    //            Converters = new Dictionary<Type, Dictionary<Type, MatTypeConverter>>();
    //            Register<string, string>((value, format) => value);
    //
    //            Register<DateTime, string>((value, format) =>
    //            {
    //                if (value == DateTime.MinValue)
    //                {
    //                    return string.Empty;
    //                }
    //
    //                return value.ToLocalTime().ToString(format);
    //            });
    //
    //            Register<DateTime?, string>((value, format) =>
    //            {
    //                if (!value.HasValue)
    //                {
    //                    return null;
    //                }
    //
    //                return value.Value.ToLocalTime().ToString(format);
    //            });
    //
    //            Register<string, DateTime?>((value, format) =>
    //            {
    //                if (string.IsNullOrEmpty(value))
    //                {
    //                    return null;
    //                }
    //
    //                if (DateTime.TryParseExact(value, format, CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal,
    //                    out var result))
    //                {
    //                    return result;
    //                }
    //
    //                return DateTime.Parse(value, CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal);
    //            });
    //
    //            Register<string, DateTime>((value, format) =>
    //            {
    //                if (string.IsNullOrEmpty(value))
    //                {
    //                    return DateTime.MinValue;
    //                }
    //
    //                if (DateTime.TryParseExact(value, format, CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal,
    //                    out var result))
    //                {
    //                    return result;
    //                }
    //
    //                return DateTime.Parse(value, CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal);
    //            });
    //
    //            Register<DateTime, DateTime>((value, format) => { return value; });
    //            Register<DateTime?, DateTime?>((value, format) => value);
    //            Register<DateTime?, DateTime>((value, format) =>
    //            {
    //                if (value.HasValue)
    //                {
    //                    return value.Value;
    //                }
    //
    //                return DateTime.MinValue;
    //            });
    //            Register<DateTime, DateTime?>((value, format) =>
    //            {
    //                if (value == DateTime.MinValue)
    //                {
    //                    return null;
    //                }
    //
    //                return value;
    //            });
    //
    //            Register<decimal, decimal>((value, format) => value);
    //            Register<decimal, string>((value, format) => value.ToString(format));
    //            Register<string, decimal>((value, format) => decimal.Parse(value, NumberStyles.Any));
    //            Register<decimal, decimal?>((value, format) => value == default(Decimal) ? (decimal?)null : value);
    //            Register<decimal?, decimal>((value, format) => value ?? default);
    //            Register<decimal?, string>((value, format) =>
    //            {
    //                if (value.HasValue)
    //                {
    //                    return value.Value.ToString(format);
    //                }
    //
    //                return null;
    //            });
    //            
    //            Register<string, decimal?>((value, format) =>
    //            {
    //                if (string.IsNullOrEmpty(value))
    //                {
    //                    return null;
    //                }
    //
    //                return decimal.Parse(value);
    //            });
    //        }
    //
    ////        public static MatTypeConverter GetConverter(Type typeFrom, Type typeTo)
    ////        {
    ////        }
    //
    //        private static void Register<TFROM, TTO>(Func<TFROM, string, TTO> func)
    //        {
    //            var typeFrom = typeof(TFROM);
    //            var typeTo = typeof(TTO);
    //
    //            Dictionary<Type, MatTypeConverter> d2;
    //            if (!Converters.TryGetValue(typeFrom, out d2))
    //            {
    //                d2 = new Dictionary<Type, MatTypeConverter>();
    //                Converters.Add(typeFrom, d2);
    //            }
    //
    //            MatTypeConverter converter;
    //            if (d2.TryGetValue(typeTo, out converter))
    //            {
    //                throw new Exception($"MatConverter from {typeFrom.Name} to {typeTo.Name} already registered.");
    //            }
    //
    //            d2.Add(typeTo, (value, format) => func((TFROM) value, format) as object);
    //        }
    //
    //
    //        public static MatTypeConverter<TFROM, TTO> Get<TFROM, TTO>()
    //        {
    //            var converter = Get(typeof(TFROM), typeof(TTO));
    //            return (value, format) => (TTO) converter(value, format);
    //        }
    //
    //        public static MatTypeConverter Get(Type typeFrom, Type typeTo)
    //        {
    //            Dictionary<Type, MatTypeConverter> d2;
    //            if (!Converters.TryGetValue(typeFrom, out d2))
    //            {
    //                throw new Exception($"MatConverter from {typeFrom.Name} to {typeTo.Name} not registered.");
    //            }
    //
    //            MatTypeConverter converter;
    //            if (!d2.TryGetValue(typeTo, out converter))
    //            {
    //                throw new Exception($"MatConverter from {typeFrom.Name} to {typeTo.Name} not registered.");
    //            }
    //
    //            return converter;
    //        }
    //    }
    //
    //
    //    public delegate object MatTypeConverter(object value, string format);
    //
    //    public delegate TTO MatTypeConverter<TFROM, TTO>(TFROM value, string format);
}