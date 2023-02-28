using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using AstroClient.xAstroBoy.Patching;
using HarmonyLib;
using Mono.Cecil;
using Mono.Cecil.Cil;
using UnityEngine;
using MethodAttributes = System.Reflection.MethodAttributes;
using OpCodes = System.Reflection.Emit.OpCodes;
using ParameterAttributes = System.Reflection.ParameterAttributes;
using TypeAttributes = System.Reflection.TypeAttributes;

public static class MethodGenerator
{

    internal static int BlockAllMethods(this Type type)
    {
        int patched = 0;
        bool isMonoBehaviour = typeof(MonoBehaviour).IsAssignableFrom(type);

        foreach (var methodInfo in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly))
        {
            if (!methodInfo.IsSpecialName && methodInfo.DeclaringType == type)
            {
                var parameters = methodInfo.GetParameters();
                var returnType = methodInfo.ReturnType;

                if (isMonoBehaviour && parameters.Length > 0 && parameters[0].ParameterType == typeof(MonoBehaviour))
                {
                    var patchedMethod = GenerateReturnFalseMethodWithInstanceDestroy(methodInfo, type);
                    var patch = new AstroPatch(methodInfo, new HarmonyMethod(patchedMethod));
                    if (patch.isActivePatch)
                    {
                        patched++;
                    }
                }
                else if (returnType == typeof(void))
                {
                    var patchedMethod = GenerateReturnFalseMethodVoid(methodInfo, type);
                    var patch = new AstroPatch(methodInfo, new HarmonyMethod(patchedMethod));
                    if (patch.isActivePatch)
                    {
                        patched++;
                    }
                }
                else
                {
                    var patchedMethod = GenerateReturnFalseMethodWithReturn(methodInfo, type);
                    var patch = new AstroPatch(methodInfo, new HarmonyMethod(patchedMethod));
                    if (patch.isActivePatch)
                    {
                        patched++;
                    }
                }
            }
        }

        return patched;
    }


    private static MethodBase GenerateReturnFalseMethodVoid(MethodDefinition methodDef)
    {
        var parameters = methodDef.Parameters;
        var parameterTypes = parameters.Select(p => p.ParameterType.GetType()).ToArray();
        var parameterNames = Enumerable.Range(0, parameters.Count).Select(i => $"__{i}").ToArray();

        var assemblyName = new AssemblyName(Guid.NewGuid().ToString());
        var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
        var moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName.Name);
        var typeBuilder = moduleBuilder.DefineType($"{methodDef.Name}_PatchType", TypeAttributes.Public);

        var methodBuilder = typeBuilder.DefineMethod($"{methodDef.Name}_Patch", MethodAttributes.Public | MethodAttributes.Static);
        methodBuilder.SetReturnType(typeof(bool));
        methodBuilder.SetParameters(parameterTypes);

        var ilGenerator = methodBuilder.GetILGenerator();
        for (int i = 0; i < parameterTypes.Length; i++)
        {
            ilGenerator.Emit(OpCodes.Ldarg, i);
        }
        ilGenerator.Emit(OpCodes.Pop);
        ilGenerator.Emit(OpCodes.Ldc_I4_0);
        ilGenerator.Emit(OpCodes.Ret);

        for (int i = 0; i < parameterNames.Length; i++)
        {
            methodBuilder.DefineParameter(i + 1, ParameterAttributes.In, parameterNames[i]);
        }

        var type = typeBuilder.CreateType();
        var methodInfo = type.GetMethod(methodBuilder.Name, parameterTypes);

        return methodInfo;
    }
    private static MethodBase GenerateReturnFalseMethodWithReturn(MethodDefinition methodDef)
    {
        var parameters = methodDef.Parameters;
        var parameterTypes = parameters.Select(p => p.ParameterType).ToArray();
        var parameterNames = Enumerable.Range(0, parameters.Count).Select(i => $"__{i}").ToArray();

        var assemblyName = new AssemblyName(Guid.NewGuid().ToString());
        var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
        var moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName.Name);
        var typeBuilder = moduleBuilder.DefineType($"{methodDef.Name}_PatchType", TypeAttributes.Public);

        var methodBuilder = typeBuilder.DefineMethod($"{methodDef.Name}_Patch", MethodAttributes.Public | MethodAttributes.Static);
        methodBuilder.SetReturnType(typeof(bool));
        methodBuilder.SetParameters(parameterTypes);

        var ilGenerator = methodBuilder.GetILGenerator();
        for (int i = 0; i < parameterTypes.Length; i++)
        {
            ilGenerator.Emit(OpCodes.Ldarg, i);
        }
        ilGenerator.Emit(OpCodes.Pop);
        ilGenerator.Emit(OpCodes.Ldc_I4_0);
        if (methodDef.ReturnType.IsValueType)
        {
            ilGenerator.Emit(OpCodes.Box, methodBuilder.Module.ImportReference(methodDef.ReturnType));
        }
        ilGenerator.Emit(OpCodes.Ret);

        for (int i = 0; i < parameterNames.Length; i++)
        {
            methodBuilder.DefineParameter(i + 1, ParameterAttributes.In, parameterNames[i]);
        }

        var type = typeBuilder.CreateType();
        var methodInfo = type.GetMethod(methodBuilder.Name, parameterTypes);

        return methodInfo;
    }


    public static MethodDefinition GenerateReturnFalseMethodWithInstanceDestroy(MethodDefinition method)
    {
        var module = method.Module;
        var returnType = module.TypeSystem.Boolean;
        var parameters = method.Parameters;

        var patchedMethod = new MethodDefinition($"{method.Name}_Patch", MethodAttributes.Private | MethodAttributes.Static,
            returnType);

        for (int i = 0; i < parameters.Count; i++)
        {
            patchedMethod.Parameters.Add(new ParameterDefinition($"{parameters[i].Name}", ParameterAttributes.None, parameters[i].ParameterType));
        }

        var ilProcessor = patchedMethod.Body.GetILProcessor();
        var jumpTarget = Instruction.Create(OpCodes.Nop);

        ilProcessor.Emit(OpCodes.Ldarg_0);
        ilProcessor.Emit(OpCodes.Brtrue_S, jumpTarget);

        ilProcessor.Emit(OpCodes.Ldc_I4_0);
        ilProcessor.Emit(OpCodes.Ret);

        ilProcessor.Append(jumpTarget);

        ilProcessor.Emit(OpCodes.Ldarg_0);
        ilProcessor.Emit(OpCodes.Ldc_I4_0);
        ilProcessor.Emit(OpCodes.Call, module.ImportReference(typeof(UnityEngine.Object).GetMethod("DestroyImmediate", new[] { typeof(UnityEngine.Object), typeof(bool) })));
        ilProcessor.Emit(OpCodes.Ldc_I4_0);
        ilProcessor.Emit(OpCodes.Ret);

        return patchedMethod;
    }
}
