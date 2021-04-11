namespace AstroClient
{
    using AstroClient.ConsoleUtils;
    using DayClientML2.Utility.Extensions;
    using Harmony;
    using System;
    using System.Linq;
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
                //var array = Networking.DecodeParameters(__1.ParameterBytes); // KIRAI SUGGESTS TO USE utf8 decode and discard the first 6 characters.
                string actionstring = string.Empty;
                string actiontext = string.Empty;
                if (__1.ParameterBytes != null && __1.ParameterBytes.Count() != 0)
                {
                    actionstring = System.Text.Encoding.UTF8.GetString(__1.ParameterBytes);

                    actiontext = actionstring.Substring(6);

                }
                else
                {
                    actiontext = null;
                }




                string sender = string.Empty;
                string GameObjName = string.Empty;


                var name = __1.ParameterObject.name;
                var parameter = __1.ParameterString;

                bool log = ConfigManager.General.LogRPCEvents;

                if (name.Equals("USpeak") || name.Equals("SceneEventHandlerAndInstantiator"))
                {
                    log = false;
                }

                if (__0 != null)
                {
                    sender = __0.DisplayName();
                }
                else
                {
                    sender = "null";
                }

                if (__1.ParameterObject != null)
                {
                    GameObjName = __1.ParameterObject.name;
                }
                else
                {
                    GameObjName = "null";
                }



                if (parameter.Equals("UdonSyncRunProgramAsRPC"))
                {
                    if (ConfigManager.General.LogUdonEvents)
                    {

                        ModConsole.DebugLog($"Udon RPC: Sender : {sender} , GameObject : {GameObjName}, Action : {actiontext}");
                    }
                    Event_OnUdonSyncRPC?.Invoke(null, new UdonSyncRPCEventArgs(__0, __1.ParameterObject, actiontext));
                }


                if (log)
                {

                    if (parameter != "UdonSyncRunProgramAsRPC")
                    {
                        ModConsole.DebugLog($"RPC: {sender}, {name}, {parameter}, [{actiontext}], {__1.EventType}, {__2.ToString()}, {__3}, {__4}");

                    }
                }



            }

            catch (Exception e)
            {
                ModConsole.Error("Error Intercepting RPC Event!");
                ModConsole.ErrorExc(e);
            }
        }
    }
}
