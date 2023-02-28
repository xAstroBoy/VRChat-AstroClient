using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;

namespace AstroClient.xAstroBoy.Patching;

internal class DynamicTools
{
    internal static DynamicMethod CreateDynamicMethod(MethodInfo original, Type returnType, Type[] parameterTypes, Func<ILGenerator, MethodInfo, bool> dynamicMethodBody)
    {
        var dynamicMethod = new DynamicMethod(
            $"Dynamic_{Guid.NewGuid():N}",
            returnType,
            parameterTypes,
            original.DeclaringType.Module,
            true
        );
        dynamicMethodBody(dynamicMethod.GetILGenerator(), original);
        return dynamicMethod;
    }
}