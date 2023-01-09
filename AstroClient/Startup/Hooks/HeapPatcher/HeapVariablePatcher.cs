using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using AstroClient.Cheetos;
using AstroClient.ClientActions;
using HarmonyLib;
using VRC.Udon.Common;
using VRC.Udon.Common.Exceptions;
using VRC.Udon.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroClient.Tools.Extensions;
using Mono.CSharp.Linq;
using VRC.Udon;
using IStrongBox = Il2CppSystem.Runtime.CompilerServices.IStrongBox;

namespace AstroClient.Tools.UdonEditor
{


    /// <summary>
    /// Special class to handle Heap Get/Set and doesn't conflict with ther generated Readers
    /// </summary>
    internal class HeapVariablePatcher : AstroEvents
    {
        private static void PatchGeneratedMethod(Type masterType, Func<MethodInfo, bool> check, HarmonyMethod prefix = null, HarmonyMethod postfix = null, HarmonyMethod transpiler = null)
        {
            var SearchBindings = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance;
            //Find the compiler-created method nested in masterType that passes the check, Patch it
            List<Type> nestedTypes = new List<Type>();
            nestedTypes.Add(masterType);
            if (nestedTypes.Count != 0)
            {
                Log.Debug($"Found {nestedTypes.Count} types in MasterType {masterType.FullName}");

                while (nestedTypes.Any())
                {
                    Log.Debug($"Checking Types {nestedTypes.Count}");
                    Type type = nestedTypes.Pop();
                    Log.Debug($"Scanning Type {type.FullDescription()}, Left : {nestedTypes.Count}");
                    var FoundTypes = type.GetNestedTypes(SearchBindings);
                    nestedTypes.AddRange(FoundTypes);
                    Log.Debug($"Added Found Nested Types {FoundTypes.Length} in Search list , Remaining Types to check.. {nestedTypes.Count}");
                    var ContainedMethods = AccessTools.GetDeclaredMethods(type);
                    Log.Debug($"Found {ContainedMethods.Count} Methods..");
                    foreach (var method in ContainedMethods)
                    {
                        Log.Debug($"Found Method : {method.FullDescription()} in Type {masterType.FullDescription()}");
                    }
                    var TargetedMethods = AccessTools.GetDeclaredMethods(type).Where(check).ToList();
                    Log.Debug($"Found {TargetedMethods.Count} Targeted Methods..");

                    foreach (var method in TargetedMethods)
                    {
                        new AstroPatch(method, prefix, postfix, transpiler);
                    }

                }
            }
            else
            {
                Log.Warn($"Couldn't find Types in MasterType {masterType.FullName}");
            }
        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(HeapVariablePatcher).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        private static MethodInfo _GetHeapVariableInternal { get; set; } = null;
        
        private static MethodInfo GetHeapVariableInternal
        {
            get
            {
                if(_GetHeapVariableInternal == null)
                {
                    return _GetHeapVariableInternal = (from m in typeof(UdonHeap).GetMethods()
                     where m.Name.Equals("GetHeapVariableInternal") && m.IsGenericMethod
                     select m).First();
                }
                return _GetHeapVariableInternal;
            }
        }
        
        internal override void ExecutePriorityPatches()
        {
            //Patch();
        }

        internal static void Patch()
        {
           // var Name1 = "GetHeapVariableInternal".ToLower();
           // //new AstroPatch(GetHeapVariableInternal,  Transpiler: GetPatch(nameof(GetHeapVariableInternal_Transpiler)));
           // PatchGeneratedMethod(typeof(UdonHeap), m => m.Name.ToLower().Equals(Name1) || m.Name.ToLower().Contains(Name1), transpiler: GetPatch(nameof(GetHeapVariableInternal_Transpiler)));

           ..
        }
        private static IEnumerable<CodeInstruction> GetHeapVariableInternal_Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            Log.Debug("GetHeapVariableInternal Called!");
            foreach (CodeInstruction i in instructions)
            {
                yield return i;
            }
        }

        // TODO: Edit to make sure it returns patched values, else redirect to original method.
        //private bool GetHeapVariableInternalRedirect<T>(ref VRC.Udon.Common.UdonHeap __instance, ref T __result, ref uint __0)
        //{
        //    IStrongBox strongBox = __instance._heap[(int)__0];
        //    if (strongBox == null)
        //    {
        //        return true;
        //    }
        //    StrongBox<T> strongBox2 = strongBox as StrongBox<T>;
        //    if (strongBox2 == null)
        //    {
        //        object value = strongBox.Value;
        //        T t2;
        //        if (value != null)
        //        {
        //            if (!(value is T))
        //            {
        //                Log.Warn(string.Concat(new string[] { "Cannot retrieve heap variable of type '", value.GetType().Name, "' as type '", typeof(T).FullName, "'" }));
        //                return true;
        //            }
        //            T t = (T)((object)value);
        //            t2 = t;
        //        }
        //        else
        //        {
        //            t2 = default(T);
        //        }
        //        __result = t2;
        //    }
        //    __result = strongBox2.Value;
        //    return true;
        //}


    }
}
