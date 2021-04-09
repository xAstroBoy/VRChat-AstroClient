namespace AstroClient
{
    using AstroClient.ConsoleUtils;
    using DayClientML2.Utility.Extensions;
    using Harmony;
    using System;
    using System.Reflection;
    using VRC;
    using VRC.SDKBase;

    public class RPCEventHook : GameEvents
    {

        // TODO : MAKE A UDONRPC OVERRIDABLE.

        public static event EventHandler<UdonSyncRPCEventArgs> Event_OnUdonSyncRPC;

        //public static 
        private HarmonyInstance harmony;

        public override void ExecutePriorityPatches()
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
            try
            {
                var array = Networking.DecodeParameters(__1.ParameterBytes);
                string textSelf = LocalPlayerUtils.GetSelfPlayer().DisplayName();
                string text = string.Empty;
                string actiontext = string.Empty;

                foreach (var item in array)
                {
                    text += $"[{item.ToString()}]";
                    actiontext += item.ToString();
                    //ModConsole.DebugLog(item.ToString());
                }

                // USpeak

                var name = __1.ParameterObject.name;
                var parameter = __1.ParameterString;

                bool log = ConfigManager.General.LogRPCEvents;

                if (name.Equals("USpeak"))
                {
                    log = false;
                }

                if (parameter == "UdonSyncRunProgramAsRPC")
                {


                    if (ConfigManager.General.LogUdonEvents)
                    {
                        string sender = string.Empty;
                        string GameObjName = string.Empty;

                        if(__0 != null)
                        {
                            sender = __0.DisplayName();
                        }
                        else
                        {
                            sender = "null";
                        }

                        if(__1.ParameterObject != null)
                        {
                            GameObjName = __1.ParameterObject.name;
                        }
                        else
                        {
                            GameObjName = "null";
                        }

                        ModConsole.DebugLog($"Udon RPC: Sender : {sender} , GameObject : {GameObjName}, Action : {actiontext}");
                    }
                    Event_OnUdonSyncRPC?.Invoke(null, new UdonSyncRPCEventArgs(__0, __1.ParameterObject, actiontext));
                }


                if (log)
                {

                    if (parameter != "UdonSyncRunProgramAsRPC")
                    {
                        if (__0 != null)
                        {
                            ModConsole.DebugLog($"RPC: {__0.DisplayName()}, {name}, {parameter}, {text}, {__1.EventType}, {__2.ToString()}, {__3}, {__4}");
                        }
                        else
                        {
                            ModConsole.DebugLog($"RPC: Null , {name}, {parameter}, {text}, {__1.EventType}, {__2.ToString()}, {__3}, {__4}");
                        }
                    }
                }



            }

            catch { } // Suppress errors as who tf needs em.
        }
    }
}
