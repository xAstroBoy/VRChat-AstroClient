﻿namespace AstroClient
{
    using AstroClient.ConsoleUtils;
    using DayClientML2.Utility.Extensions;
    using Harmony;
    using MelonLoader;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using UnhollowerBaseLib;
    using VRC;
    using VRC.SDKBase;
    using static DayClientML2.Utility.MiscUtility;

    public class RPCEventHook : Overridables
    {
        private HarmonyInstance harmony;

        public override void OnWorldReveal()
        {
            HookRPCEvents();
        }

        public void HookRPCEvents()
        {
            if (harmony == null)
            {
                harmony = HarmonyInstance.Create(BuildInfo.Name + " RPCEventHook");
            }

            harmony.Patch(AccessTools.Method(typeof(VRC_EventDispatcherRFC), nameof(VRC_EventDispatcherRFC.Method_Public_Void_Player_VrcEvent_VrcBroadcastType_Int32_Single_0)), new HarmonyMethod(typeof(RPCEventHook).GetMethod(nameof(OnRPCEvent), BindingFlags.Static | BindingFlags.NonPublic)), null);
            ModConsole.Log("Hooked VRC_EventDispatcherRFC");
        }

        private static void OnRPCEvent(ref Player __0, ref VRC_EventHandler.VrcEvent __1, ref VRC_EventHandler.VrcBroadcastType __2, ref int __3, ref float __4)
        {
            var array = Networking.DecodeParameters(__1.ParameterBytes);
            string text = string.Empty;

            foreach (var item in array)
            {
                text += $"[{item.ToString()}] ";
                //ModConsole.DebugLog(item.ToString());
            }

            ModConsole.DebugLog($"RPC: {__0.DisplayName()}, {__1.ParameterObject.name}, {__1.ParameterString}, {text}, {__1.EventType}, {__2.ToString()}, {__3}, {__4}");
        }
    }
}
