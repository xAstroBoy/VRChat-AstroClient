using AstroClient.ConsoleUtils;
using DayClientML2.Utility;
using DayClientML2.Utility.Extensions;
using Harmony;
using System;
using System.Linq;
using System.Reflection;
using VRC;
using VRC.SDKBase;

namespace AstroClient
{
    public class RPCEventHook : GameEvents
    {

        // TODO : MAKE A UDONRPC OVERRIDABLE.

        public static event EventHandler<UdonSyncRPCEventArgs> Event_OnUdonSyncRPC;

        //public static 
        private HarmonyInstance harmony;

        public override void ExecutePriorityPatches()
        {
            MiscUtility.DelayFunction(1f, new Action(() =>
            {
                HookRPCEvents();
            }));

        }


        public void HookRPCEvents()
        {
            try {
                if (harmony == null)
                {
                    harmony = HarmonyInstance.Create(BuildInfo.Name + " RPCEventHook");
                }

               harmony.Patch(AccessTools.Method(typeof(VRC_EventDispatcherRFC), nameof(VRC_EventDispatcherRFC.Method_Public_Void_Player_VrcEvent_VrcBroadcastType_Int32_Single_0)), new HarmonyMethod(typeof(RPCEventHook).GetMethod(nameof(OnRPCEvent), BindingFlags.Static | BindingFlags.NonPublic)), null, null);
                ModConsole.Log("Hooked VRC_EventDispatcherRFC");
            }
            catch
            {
                harmony.UnpatchAll();
                HookRPCEvents();
            }
         }

        private static void OnRPCEvent(Player __0, VRC_EventHandler.VrcEvent __1, VRC_EventHandler.VrcBroadcastType __2, int __3, float __4)
        {
            try
            {
                //var array = Networking.DecodeParameters(__1.ParameterBytes); // KIRAI SUGGESTS TO USE utf8 decode and discard the first 6 characters.
                string actionstring = string.Empty;
                string actiontext = string.Empty;
                string sender = string.Empty;
                string GameObjName = string.Empty;
                string name = string.Empty;
                string parameter = string.Empty;
                string eventtype = string.Empty;
                string broadcasttype = string.Empty;


                    if (__1.ParameterBytes != null && __1.ParameterBytes.Count != 0)
                    {
                            actionstring = System.Text.Encoding.UTF8.GetString(__1.ParameterBytes);
                            actiontext = actionstring.Substring(6);
                    }
                    else
                    {
                        actiontext = "null";
                    }


                    if (__1.ParameterObject != null)
                    {
                        name = __1.ParameterObject.name;
                    }
                    else
                    {
                        name = "null";
                    }


                    if (__1.ParameterString != null)
                    {
                        parameter = __1.ParameterString;
                    }
                    else
                    {
                        parameter = "null";
                    }

                    if(__1.EventType != null)
                    {
                        eventtype = __1.EventType.ToString();
                    }
                    else
                    {
                        eventtype = "null";
                    }

                if (__2 != null)
                {
                    broadcasttype = __2.ToString();
                }
                else
                {
                    broadcasttype = "Null";
                }
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
                    try
                    {
                     Event_OnUdonSyncRPC?.Invoke(null, new UdonSyncRPCEventArgs(__0, __1.ParameterObject, actiontext));
                    }
                    catch
                    {
                        ModConsole.Error("Error In Sending Internally OnUdonSyncRPC!");
                    }
                    }


                    if (log)
                    {

                        if (parameter != "UdonSyncRunProgramAsRPC")
                        {
                            ModConsole.DebugLog($"RPC: {sender}, {name}, {parameter}, [{actiontext}], {eventtype}, {broadcasttype}, {__3}, {__4}");

                        }
                    }
                    
                
            }

            catch (Exception e)
            {
                ModConsole.DebugError("Error Intercepting RPC Event!");
                ModConsole.DebugErrorExc(e);
            }
        }
    }
}
