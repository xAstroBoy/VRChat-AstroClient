using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.SDKBase;
using AstroClient.components;
using Color = System.Drawing.Color;

#region AstroClient Imports

using AstroClient.Cloner;
using AstroClient.ConsoleUtils;
using AstroClient.Finder;
using System.Reflection;
using RubyButtonAPI;
using UnityEngine.UI;
using DayClientML2.Utility.Extensions;
using AstroClient.AstroUtils.ItemTweaker;
using static AstroClient.Forces;
using VRC.SDK3.Components;
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
