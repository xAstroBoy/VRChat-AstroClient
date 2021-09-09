namespace AstroLibrary.Extensions
{
    using AstroClient;
    using AstroClient.Udon;
    using AstroLibrary.Console;
    using MelonLoader;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UnityEngine;
    using VRC.Udon;
    using static AstroClient.Variables.CustomLists;

    public static class Udon_ext
    {
        public static void UnboxUdonEventToConsole(this UdonBehaviour obj)
        {
            if (obj != null)
            {
                UdonUnboxer.UnboxUdonToConsole(obj);
            }
        }
        public static UdonBehaviour_Cached FindUdonEvent(this GameObject obj, string subaction)
        {
            return UdonSearch.FindUdonEvent(obj, subaction);
        }

        public static UdonBehaviour_Cached FindUdonEvent(this UdonBehaviour obj, string subaction)
        {
            return UdonSearch.FindUdonEvent(obj, subaction);
        }

        public static void ExecuteUdonEvent(this UdonBehaviour_Cached udonvar)
        {
            if (udonvar != null)
            {
                Task.Run(() => { InvokeEvent(udonvar.UdonBehaviour, udonvar.EventKey); });
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
                        behaviour.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, EventKey);
                    }
                }
            }
        }

        public static void ExecuteUdonEvent(this List<UdonBehaviour_Cached> udonlist)
        {
            if (udonlist == null || udonlist.Count() == 0)
            {
                return;
            }
            foreach (var udonvar in udonlist)
            {
                Task.Run(() => { InvokeEvent(udonvar.UdonBehaviour, udonvar.EventKey); });
            }
        }
    }
}