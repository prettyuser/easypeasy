using System;
using System.Collections.Generic;
using System.Linq;

namespace Utilities.Reflection
{
    public static class ReflectionExtensions
    {
        public static IEnumerable<Type> GetGenericInterfaces(this Type type, Type openGeneric)
            => type.GetInterfaces().Where(q => q.IsGenericType && q.GetGenericTypeDefinition() == openGeneric);
        
        public static IEnumerable<Type> GetClosedGenericInterfaceAttributes(this Type type, Type openGeneric, byte position)
            => type.GetGenericInterfaces(openGeneric).Select(q => q.GetGenericArguments()[position]);
    }
}