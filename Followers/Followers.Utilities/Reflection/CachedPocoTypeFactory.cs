using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Utilities.Reflection
{
    // public class CachedPocoTypeFactor<T> where T : IEquatable<T>
    // {
    //     private ConcurrentDictionary<T, Type> _cachedTypes = new ConcurrentDictionary<T, Type>();        
    //     
    //     public Type GetType(T typeId, string typeName, Type baseType, Func<IEnumerable<(string FieldName, Type FieldType)>> fieldsGetterFunc)
    //     {
    //         var rowType = _cachedTypes.GetOrAdd(typeId, tn =>
    //         {
    //             var fields = fieldsGetterFunc();
    //
    //             var pocoTypeBuilder = new PocoTypeBuilder();
    //
    //             return pocoTypeBuilder.CreateType(typeName, baseType, fields);
    //         });
    //
    //         return rowType;
    //     }
    // }
}
