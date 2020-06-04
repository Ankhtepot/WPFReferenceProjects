using System;
using System.Collections.Generic;
using System.Printing;
using System.Text;

namespace ItemsAsGridLine.Model
{
    public static class EnumUtils
    {
        public static TEnum RandomValueOf<TEnum>() where TEnum : Enum
        {
            var type = typeof(TEnum);

            if (!type.IsEnum) throw new InvalidCastException($"{type} is not an Enum.");

            var enumValues = Enum.GetValues(type);
            return (TEnum)enumValues.GetValue(new Random().Next(0, enumValues.Length));
        }
    }
}
