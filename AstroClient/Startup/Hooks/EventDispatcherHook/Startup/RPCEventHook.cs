
using System;
using System.Reflection;
using AstroClient.Cheetos;
using AstroClient.Constants;
using AstroClient.Startup.Hooks.EventDispatcherHook.Handlers;
using AstroClient.Startup.Hooks.EventDispatcherHook.RPCFirewall;
using AstroClient.Startup.Hooks.EventDispatcherHook.Tools.Ext;
using AstroClient.Startup.Hooks.PhotonHook.PhotonHandlers;
using AstroClient.xAstroBoy.Extensions;
using UnityEngine;
using VRC;
using VRC.SDKBase;

namespace AstroClient.Startup.Hooks.EventDispatcherHook.Startup
{
    #region Imports

    #endregion Imports
    [Obfuscation(Feature = "HarmonyRenamer")]

    internal class RPCEventHook : AstroEvents
    {

        internal static event System.Action<Player, GameObject, string> Event_OnUdonSyncRPC;

        //internal static 
        private HarmonyLib.Harmony harmony;

        internal override void ExecutePriorityPatches()
        {
            new AstroPatch(HarmonyLib.AccessTools.Method(typeof(VRC_EventDispatcherRFC), nameof(VRC_EventDispatcherRFC.Method_Public_Void_Player_VrcEvent_VrcBroadcastType_Int32_Single_0)), GetPatch(nameof(OnRPCEvent)));
        }

        [Obfuscation(Feature = "HarmonyGetPatch")]
        private static HarmonyLib.HarmonyMethod GetPatch(string name)
        {
            return new HarmonyLib.HarmonyMethod(typeof(RPCEventHook).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }


        // TODO : Clean and reorganize the entire event system 

        private static bool OnRPCEvent(ref VRC.Player __0, ref VRC_EventHandler.VrcEvent __1, ref VRC_EventHandler.VrcBroadcastType __2, ref int __3, ref float __4)
        {
            try
            {
                // First Check if is a  irregular RPC Being sent.
                if(Irregular_RPC_Firewall.isIrregularRPC(ref __1, ref __0))
                {
                    return false;
                }


                if (__1.Get_Parameter_GameObject_Name().Equals("USpeak"))
                {
                    return EventDispatcher_HandleUSpeak.Handle_USpeak(); // TODO: if we need to use Uspeak or filter it, we can edit this handler (for now it just returns true)
                }
                var parameter = __1.Get_parameterString();

                if (parameter.Equals("TeleportRPC"))
                {
                    return EventDispatcher_HandleTeleportRPC.HandleTeleportRPC(ref __1, __0, __1.Get_Parameter_GameObject(), __1.Get_parameterString(), __1.Get_EventType(), __2.Get_VrcBroadcastType());
                }
                else if (parameter.Equals("UdonSyncRunProgramAsRPC"))
                {
                    return EventDispatcher_HandleUdonEvent.Handle_UdonEvent(ref __1, __0, __1.Get_Parameter_GameObject(), __1.Get_ActionText());
                }
                else
                {
                    return EventDispatcher_HandleRPCEvents.Handle_OtherRPCEvent(ref __1, __0, __1.Get_Parameter_GameObject(), __1.Get_ActionText(), parameter, __1.Get_EventType(), __2.Get_VrcBroadcastType());   
                }
                return true;
            }
            catch (Exception e)
            {
                Log.Exception(e);
                return true;
            }

            return true;
        }
    }
}