using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Library.CrmTypeConverter
{
    public static class CrmTypeConverterUtils
    {
        public static object ConvertCrmType(object value)
        {
            string typeName = value.GetType().Name;

            switch (typeName)
            {
                case nameof(Int16):
                case nameof(Int32):
                    return Convert.ToInt32(value);

                case nameof(Decimal):
                    return Convert.ToDecimal(value);

                case nameof(DateTime):
                    return Convert.ToDateTime(value);

                case nameof(Boolean):
                    return Convert.ToBoolean(value);

                case nameof(Byte) + "[]":
                    return (byte[])value;


            }

            return null;
            
        }
    }
}
