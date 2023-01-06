using System.Reflection;
using AstroClient.Cheetos;
using AstroClient.ClientActions;
using HarmonyLib;
using VRC.Udon.Common;
using VRC.Udon.Common.Interfaces;

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

        private static MethodInfo _GetHeapVariableInternal { get; set; } = null;
        
        private static MethodInfo GetHeapVariableInternal
        {
            get
            {
                if(_GetHeapVariableInternal == null)
                {
                    return _GetHeapVariableInternal = (from m in typeof(IUdonHeap).GetMethods()
                     where m.Name.Equals("GetHeapVariable") && m.IsGenericMethod
                     select m).First();
                }
                return _GetHeapVariableInternal;
            }
        }
        
        internal override void ExecutePriorityPatches()
        {
            var GenericTypes = GetHeapVariableInternal.GetGenericArguments();
            new AstroPatch(GetHeapVariableInternal.MakeGenericMethod(GenericTypes),  GetPatch(nameof(GetHeapVariableInternalRedirect)));

            //new AstroPatch(typeof(UdonHeap).GetMethod(nameof(UdonHeap)), null, GetPatch(nameof(PlayerStartPatch)));
        }

        private static void GetHeapVariableInternalRedirect<T>(ref IUdonHeap __instance, ref T __result, ref uint __0)
        {
            Log.Write($"GetHeapVariable called!");
        }



    }
}
