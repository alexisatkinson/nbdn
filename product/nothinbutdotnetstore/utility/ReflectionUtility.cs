using System;
using System.Linq.Expressions;

namespace nothinbutdotnetstore.utility
{
    public static class ReflectionUtility
    {
        public static string get_name_of_property<T>(Expression<Func<T, object>> accessor)
        {
            return ((MemberExpression) accessor.Body).Member.Name;
        }
    }
}