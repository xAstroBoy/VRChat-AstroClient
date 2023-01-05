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
            //new AstroPatch(typeof(UdonHeap).GetMethod(nameof(UdonHeap.GetHeapVariableInternal)).MakeGenericMethod(typeof(System.Object)), null, GetPatch(nameof(PlayerStartPatch)));
            //new AstroPatch(typeof(UdonHeap).GetMethod(nameof(UdonHeap)), null, GetPatch(nameof(PlayerStartPatch)));
        }




    }
}
