namespace AstroLibrary.Extensions
{
    using AstroClient;
    using AstroClient.Udon;
    using System.Collections.Generic;
    using System.Linq;
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
        public static CachedUdonEvent FindUdonEvent(this GameObject obj, string subaction)
        {
            return UdonSearch.FindUdonEvent(obj, subaction);
        }

        public static CachedUdonEvent FindUdonEvent(this UdonBehaviour obj, string subaction)
        {
            return UdonSearch.FindUdonEvent(obj, subaction);
        }

        public static void ExecuteUdonEvent(this CachedUdonEvent udonvar)
        {
            if (udonvar.Action != null && udonvar.EventKey != null && udonvar != null)
            {
                if (!string.IsNullOrEmpty(udonvar.EventKey) && !string.IsNullOrWhiteSpace(udonvar.EventKey))
                {
                    if (udonvar.EventKey.StartsWith("_"))
                    {
                        udonvar.Action.SendCustomEvent(udonvar.EventKey);
                    }
                    else
                    {
                        udonvar.Action.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, udonvar.EventKey);
                    }
                }
            }
        }

        public static void ExecuteUdonEvent(this List<CachedUdonEvent> udonlist)
        {
            if (udonlist == null || udonlist.Count() == 0)
            {
                return;
            }
            foreach (var udonvar in udonlist)
            {
                if (udonvar.Action != null && udonvar.EventKey != null && udonvar != null)
                {
                    if (!string.IsNullOrEmpty(udonvar.EventKey) && !string.IsNullOrWhiteSpace(udonvar.EventKey))
                    {
                        if (udonvar.EventKey.StartsWith("_"))
                        {
                            udonvar.Action.SendCustomEvent(udonvar.EventKey);
                        }
                        else
                        {
                            udonvar.Action.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, udonvar.EventKey);
                        }
                    }
                }
            }
        }
    }
}