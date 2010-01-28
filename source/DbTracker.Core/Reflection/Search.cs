using System;
using System.Collections.Generic;
using System.Reflection;

namespace DbTracker.Core.Reflection
{
    public class Search
    {
        public static IDictionary<PropertyInfo, T> GetPropertiesWithAttribute<T>(Type type)
            where T : Attribute
        {
            var properties = type.GetProperties();

            var result = new Dictionary<PropertyInfo, T>();
            foreach (var property in properties)
            {
                var attr = GetAttribute<T>(property);
                if (attr != null) result.Add(property, attr);
            }
            return result;
        }

        private static T GetAttribute<T>(ICustomAttributeProvider property)
            where T : Attribute
        {
            foreach (Attribute attr in property.GetCustomAttributes(true))
            {
                if (attr.GetType() != typeof(T)) continue;
                return (T)attr;
            }
            return null;
        }
    }
}