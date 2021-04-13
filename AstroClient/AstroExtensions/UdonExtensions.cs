using System.Collections.Generic;
using System.Linq;
using VRC.SDKBase;

#region AstroClient Imports

using static AstroClient.variables.CustomLists;

#endregion AstroClient Imports

namespace AstroClient.extensions
{
    public static class UdonExtensions
    {
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
            if (udonlist == null)
            {
                return;
            }
            if (udonlist.Count() == 0)
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