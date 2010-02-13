using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.utility
{
    public static class UsefulExtensions
    {
        public static bool has_attribute<AttributeType>(this Type type)
        {
            throw new NotImplementedException();
        }
        public static AttributeType get_attribute<AttributeType>(this Type type)
        {
            throw new NotImplementedException();
        }
        public static void each<T>(this IEnumerable<T> items, Action<T> visitor)
        {
            foreach (var item in items)
            {
                visitor(item);
            }
        }
    }
}