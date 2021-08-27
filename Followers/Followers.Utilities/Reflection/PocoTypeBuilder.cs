using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace Utilities.Reflection
{
    // public class PocoTypeBuilder
    // {
    //     public Type CreateType(string typeName, Type baseType, IEnumerable<(string FieldName, Type FieldType)> fields)
    //     {
    //         if (fields == null) { throw new ArgumentNullException(nameof(fields)); }
    //
    //         var tb = GetTypeBuilder(typeName, baseType);
    //
    //         tb.DefineDefaultConstructor(MethodAttributes.Public
    //                                     | MethodAttributes.SpecialName
    //                                     | MethodAttributes.RTSpecialName);
    //
    //         foreach (var field in fields)
    //             CreateProperty(tb, field.FieldName, field.FieldType);
    //
    //         return tb.CreateTypeInfo();
    //
    //     }
    //     
    //     private void CreateProperty(TypeBuilder tb, string propertyName, Type propertyType)
    //     {
    //         var fieldBuilder = tb.DefineField("_" + propertyName, propertyType, FieldAttributes.Private);
    //
    //         var propertyBuilder = tb.DefineProperty(propertyName, PropertyAttributes.HasDefault, propertyType, null);
    //         var getProperyMethodBuilder = tb.DefineMethod("get_" + propertyName, MethodAttributes.Public
    //                                                                               | MethodAttributes.SpecialName
    //                                                                               | MethodAttributes.HideBySig, propertyType, Type.EmptyTypes);
    //         var getIl = getProperyMethodBuilder.GetILGenerator();
    //
    //         getIl.Emit(OpCodes.Ldarg_0);
    //         getIl.Emit(OpCodes.Ldfld, fieldBuilder);
    //         getIl.Emit(OpCodes.Ret);
    //
    //         var setPropertyMethodBuilder = tb.DefineMethod("set_" + propertyName, MethodAttributes.Public
    //                                                                               | MethodAttributes.SpecialName
    //                                                                               | MethodAttributes.HideBySig, null, new[] { propertyType });
    //
    //         var setIl = setPropertyMethodBuilder.GetILGenerator();
    //         var modifyProperty = setIl.DefineLabel();
    //         var exitSet = setIl.DefineLabel();
    //
    //         setIl.MarkLabel(modifyProperty);
    //         setIl.Emit(OpCodes.Ldarg_0);
    //         setIl.Emit(OpCodes.Ldarg_1);
    //         setIl.Emit(OpCodes.Stfld, fieldBuilder);
    //
    //         setIl.Emit(OpCodes.Nop);
    //         setIl.MarkLabel(exitSet);
    //         setIl.Emit(OpCodes.Ret);
    //
    //         propertyBuilder.SetGetMethod(getProperyMethodBuilder);
    //         propertyBuilder.SetSetMethod(setPropertyMethodBuilder);
    //     }
    //     
    //     private TypeBuilder GetTypeBuilder(string typeName, Type baseType)
    //     {
    //         var assemblyName = new AssemblyName(Guid.NewGuid().ToString());
    //         var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
    //         var moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
    //
    //         return moduleBuilder.DefineType(typeName, TypeAttributes.Public
    //                                                     | TypeAttributes.Class
    //                                                     | TypeAttributes.AutoClass
    //                                                     | TypeAttributes.AnsiClass
    //                                                     | TypeAttributes.BeforeFieldInit
    //                                                     | TypeAttributes.AutoLayout, baseType);
    //     }
    // }
}
