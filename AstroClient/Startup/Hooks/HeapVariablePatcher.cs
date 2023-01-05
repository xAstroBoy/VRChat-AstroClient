using System.Reflection;
using AstroClient.Cheetos;
using AstroClient.ClientActions;
using HarmonyLib;
using VRC.Udon.Common;

namespace AstroClient.Tools.UdonEditor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CustomClasses;
    using VRC.Udon;


    /// <summary>
    /// Special class to handle Heap Get/Set and doesn't conflict with ther generated Readers
    /// </summary>
    internal class HeapVariablePatcher : AstroEvents
    {
        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(HeapVariablePatcher).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        internal override void ExecutePriorityPatches()
        {
            var GetHeapVariableInternal = (from m in typeof(UdonHeap).GetMethods()
                                    where m.Name.Equals("GetHeapVariableInternal") && m.IsGenericMethod
                                    select m).First();
            //foreach (var item in GetHeapVariableInternal.GetGenericArguments())
            //{
            //    Log.Write($"GetHeapVariable supports : {item.FullName}");
            //}

            new AstroPatch(GetHeapVariableInternal.MakeGenericMethod(new[] {typeof(System.Object)}), null, GetPatch(nameof(GetHeapVariableInternal_System_Object_Postfix)));
            new AstroPatch(GetHeapVariableInternal.MakeGenericMethod(new[] {typeof(Il2CppSystem.Object)}), null, GetPatch(nameof(GetHeapVariableInternal_Il2CppSystem_Object_Postfix)));
            new AstroPatch(GetHeapVariableInternal.MakeGenericMethod(new[] {typeof(UnityEngine.Object)}), null, GetPatch(nameof(GetHeapVariableInternal_UnityEngine_Object_Postfix)));

            //new AstroPatch(typeof(UdonHeap).GetMethod(nameof(UdonHeap)), null, GetPatch(nameof(PlayerStartPatch)));
        }

        private static void GetHeapVariableInternal_System_Object_Postfix(ref VRC.Udon.Common.UdonHeap __instance, ref System.Object __result, ref uint __0)
        {
        }
        private static void GetHeapVariableInternal_Il2CppSystem_Object_Postfix(ref VRC.Udon.Common.UdonHeap __instance, ref Il2CppSystem.Object __result, ref uint __0)
        {
        }

        private static void GetHeapVariableInternal_UnityEngine_Object_Postfix(ref VRC.Udon.Common.UdonHeap __instance, ref UnityEngine.Object __result, ref uint __0)
        {
        }



    }
}
