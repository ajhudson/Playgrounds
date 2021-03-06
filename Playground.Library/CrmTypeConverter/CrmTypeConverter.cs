using Microsoft.Xrm.Sdk;
using System;
using System.Linq;

namespace Playground.Library.CrmTypeConverter
{
    public class CrmTypeConverter<TInput, TOutput> : IConvertible   where TInput : class, new() 
                                                                    where TOutput : IConvertible
    {
        private static Type[] ValidTypes = new[] { typeof(Money), typeof(OptionSetValue), typeof(EntityReference) };

        private static string[] ValidTypeNames = ValidTypes.Select(t => t.Name).ToArray();

        private readonly TInput _object;

        public CrmTypeConverter(TInput obj)
        {
            bool isCrmType = ValidTypes.Any(t => t == obj.GetType());

            if (!isCrmType)
            {
                throw new InvalidCastException($"{nameof(obj)} must be one of the followin types: {string.Join(", ", ValidTypeNames)}");
            }

            this._object = obj;
        }

        public TypeCode GetTypeCode()
        {
            throw new NotImplementedException();
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public byte ToByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public char ToChar(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public double ToDouble(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public short ToInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public int ToInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public long ToInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public float ToSingle(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public string ToString(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
    }
}
