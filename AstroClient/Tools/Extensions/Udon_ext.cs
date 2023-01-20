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
                UdonDumper.UnboxUdonToConsole(obj);
                UdonDumper.DumpUdonUnsupportedTypes();
            }
        }

        internal static void GenerateGettersForThisUdonBehaviour(this UdonBehaviour obj)
        {
            if (obj != null)
            {
                UdonDumper.GenerateGettersReaders(obj);

            }
        }

        internal static string Real_UnboxAsString(this RawUdonBehaviour obj, string SymbolName)
        {
            return UdonHeapUnboxerUtils.Real_UnboxAsString(obj, SymbolName);
        }
        internal static string FakeUdon_UnboxAsString(this RawUdonBehaviour obj, string SymbolName)
        {
            return UdonHeapUnboxerUtils.FakeUdon_UnboxAsString(obj, SymbolName);
        }

        internal static UdonBehaviour_Cached FindUdonEvent(this GameObject obj, string subaction)
        {
            return UdonSearch.FindUdonEvent(obj, subaction);
        }
        internal static UdonBehaviour_Cached FindUdonEvent(this GameObject obj, string action, string subaction, bool ShowError = true)
        {
            return UdonSearch.FindUdonEvent(obj, action, subaction, ShowError);
        }

        internal static RawUdonBehaviour FindUdonVariable(this GameObject obj, string SymbolName)
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
        internal static bool HasUdonEvent(this GameObject obj, string subaction)
        {
            return UdonSearch.HasUdonEvent(obj, subaction);
        }

        internal static void InvokeBehaviour(this List<UdonBehaviour_Cached> udonlist)
        {
            if (udonlist == null || udonlist.Count() == 0)
            {
                return;
            }
            for (int i = 0; i < udonlist.Count; i++)
            {
                udonlist[i].InvokeBehaviour();
            }
        }

        internal static bool isEventKeyValid(this UdonBehaviour UdonBehaviour, string EventKey)
        {
            if (UdonBehaviour != null)
            {
                var eventKeys = UdonBehaviour.Get_EventKeys();
                if (eventKeys == null) return false;
                for (int UdonKeys = 0; UdonKeys < eventKeys.Length; UdonKeys++)
                {
                    var key = eventKeys[UdonKeys];
                    if (key == EventKey)
                        return true;
                }
            }
            return false;
        }


    }
}