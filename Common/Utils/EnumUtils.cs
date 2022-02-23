using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Common.Utils {
	public static class EnumUtils {

        public static string GetDescription(this Enum value) {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null) {
                FieldInfo field = type.GetField(name);
                if (field != null) {
                    DescriptionAttribute attr =
                           Attribute.GetCustomAttribute(field,
                             typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null) {
                        return attr.Description;
                    }
                }
            }
            return null;
        }

        public static T ParseEnumOrDefault<T>(string parse, T defaultValue = default(T)) where T : struct {
            T result;
            if (!Enum.TryParse<T>(parse, out result)) {
                result = defaultValue;
            }
            return result;
        }

    }
}
