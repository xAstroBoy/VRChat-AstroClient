using System.Collections.Generic;

#region AstroClient Imports

using static AstroClient.variables.CustomLists;

#endregion AstroClient Imports

namespace AstroClient.extensions
{
    public static class UdonExtensions
    {
        public static void ExecuteUdonEvent(this CachedUdonEvent udonvar)
        {
            if (udonvar.Action != null)
            {
                udonvar.Action.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, udonvar.EventKey);
            }
        }

        public static void ExecuteUdonEvent(this List<CachedUdonEvent> udonlist)
        {
            foreach (var cachedudon in udonlist)
            {
                if (cachedudon.Action != null)
                {
                    cachedudon.Action.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, cachedudon.EventKey);
                }
            }
        }
    }
}