using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace YnabRestApi.Utils {
    internal static class EnumExtensions {

        internal static string GetEnumDescription(this Enum value) {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any()) {
                return attributes.First().Description;
            }

            return value.ToString();
        }

        internal static IDictionary<string, T> GetValues<T>() where T : System.Enum {
            return Enum.GetValues(typeof(T))
            .Cast<T>()
            .ToDictionary(k => k.GetEnumDescription(), v => v);
        }

    }
}
