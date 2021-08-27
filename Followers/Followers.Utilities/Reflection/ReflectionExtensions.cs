using System;
using System.Collections.Generic;
using System.Linq;

namespace Utilities.Reflection
{
    public static class ReflectionExtensions
    {
        // public static bool IsClosedInterfaceOf(this Type type, Type openGeneric)
        //     => type.GetInterfaces().Any(q => q.IsGenericType && q.GetGenericTypeDefinition() == openGeneric);
        //
        // public static IEnumerable<Type> GetGenericInterfaces(this Type type, Type openGeneric)
        //     => type.GetInterfaces().Where(q => q.IsGenericType && q.GetGenericTypeDefinition() == openGeneric);
        //
        // public static Type GetGenericInterface(this Type type, Type openGeneric)
        //     => type.GetInterfaces().SingleOrDefault(q => q.IsGenericType && q.GetGenericTypeDefinition() == openGeneric);
        //
        // public static IEnumerable<Type> GetClosedGenericInterfaceAttributes(this Type type, Type openGeneric, byte position)
        //     => type.GetGenericInterfaces(openGeneric).Select(q => q.GetGenericArguments()[position]);
        //
        // public static Type GetClosedGenericInterfaceAttribute(this Type type, Type openGeneric, byte position)
        //     => type.GetGenericInterface(openGeneric)?.GetGenericArguments()[position];
    }
}
