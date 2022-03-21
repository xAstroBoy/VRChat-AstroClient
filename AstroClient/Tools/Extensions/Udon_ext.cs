namespace AstroClient.Tools.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using CustomClasses;
    using UdonEditor;
    using UdonSearcher;
    using UnityEngine;
    using VRC.Udon;
    using VRC.Udon.Common.Interfaces;
    using xAstroBoy.Extensions;
    using static Constants.CustomLists;

    internal static class Udon_ext
    {
        internal static void UnboxUdonEventToConsole(this UdonBehaviour obj)
        {
            if (obj != null)
            {
                UdonUnboxer.UnboxUdonToConsole(obj);
                UdonUnboxer.DumpUdonUnsupportedTypes();
            }
        }

        internal static void GenerateGettersForThisUdonBehaviour(this UdonBehaviour obj)
        {
            if (obj != null)
            {
                UdonUnboxer.GenerateGettersReaders(obj);

            }
        }

        internal static string UnboxUdonHeap(this Il2CppSystem.Object obj)
        {
            return UdonHeapUnboxerUtils.UnboxUdonHeap(obj);
        }

        internal static UdonBehaviour_Cached FindUdonEvent(this GameObject obj, string subaction)
        {
            return UdonSearch.FindUdonEvent(obj, subaction);
        }

        internal static Il2CppSystem.Object FindUdonVariable(this GameObject obj, string SymbolName)
        {
            return UdonSearch.FindUdonVariable(obj, SymbolName);
        }

        internal static UdonBehaviour_Cached FindUdonEvent(this UdonBehaviour obj, string subaction)
        {
            return UdonSearch.FindUdonEvent(obj, subaction);
        }
        internal static bool HasUdonEvent(this UdonBehaviour obj, string subaction)
        {
            return UdonSearch.HasUdonEvent(obj, subaction);
        }

        internal static void InvokeBehaviour(this List<UdonBehaviour_Cached> udonlist)
        {
            if (udonlist == null || udonlist.Count() == 0)
            {
                return;
            }
            foreach (var udonvar in udonlist)
            {
                udonvar.InvokeBehaviour();
            }
        }
    }
}