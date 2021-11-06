﻿namespace AstroLibrary.Extensions
{
    using AstroClient;
    using AstroClient.Udon;
    using System.Collections.Generic;
    using System.Linq;
    using UnhollowerBaseLib.Runtime;
    using UnityEngine;
    using VRC.Udon;
    using VRC.Udon.Common.Interfaces;
    using static AstroClient.Variables.CustomLists;

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

        internal static void ExecuteUdonEvent(this UdonBehaviour_Cached udonvar)
        {
            if (udonvar != null)
            {
                InvokeEvent(udonvar.UdonBehaviour, udonvar.EventKey);
            }
        }

        private static void InvokeEvent(UdonBehaviour behaviour, string EventKey)
        {
            if (behaviour != null)
            {
                if (EventKey.IsNotNullOrEmptyOrWhiteSpace())
                {
                    if (EventKey.StartsWith("_"))
                    {
                        behaviour.SendCustomEvent(EventKey);
                    }
                    else
                    {
                        behaviour.SendCustomNetworkEvent(NetworkEventTarget.All, EventKey);
                    }
                }
            }
        }

        internal static void ExecuteUdonEvent(this List<UdonBehaviour_Cached> udonlist)
        {
            if (udonlist == null || udonlist.Count() == 0)
            {
                return;
            }
            foreach (var udonvar in udonlist)
            {
                udonvar.ExecuteUdonEvent();
            }
        }
    }
}