namespace AstroClient.Startup.Hooks.PhotonHook.Startup;

using System.Reflection;
using Cheetos;
using ExitGames.Client.Photon;
using Harmony;
using Il2CppSystem;
using Il2CppSystem.Collections;
using Il2CppSystem.Collections.Generic;
using Photon.Realtime;
using PhotonHandlers;
using Structs;
using Structs.PhotonBytes;
using Tools.PhotonLogger;
using Tools.Replacers;
using UnhollowerRuntimeLib;
using Exception = System.Exception;

[Obfuscation(Feature = "HarmonyRenamer")]
internal class PhotonOnEventHook : AstroEvents
{
    internal override void ExecutePriorityPatches()
    {
        HookPhotonOnEvent();
    }

    [Obfuscation(Feature = "HarmonyGetPatch")]
    private static HarmonyMethod GetPatch(string name)
    {
        return new HarmonyMethod(typeof(PhotonOnEventHook).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
    }

    private static void HookPhotonOnEvent()
    {
        ModConsole.DebugLog("Hooking Photon OnEvent");
        new AstroPatch(typeof(LoadBalancingClient).GetMethod(nameof(LoadBalancingClient.OnEvent)), GetPatch(nameof(OnEventPatch)));
    }

    // Current Targeted Byte 

    private static bool OnEventPatch(ref EventData __0)
    {
        try
        {
            if (__0 != null)
            {
                HookAction CurrentAction = HookAction.Nothing;
                bool isHashtable = false;
                bool isDictionary = false;
                bool isUnknownType = false;

                // These two exists For easily edit and rebuild them instead of editing Original data (Unhollower crashes)

                System.Collections.Generic.Dictionary<byte, Il2CppSystem.Object> Dictionary_EditableCopy = new System.Collections.Generic.Dictionary<byte, Object>();
                // System.Collections.Hashtable Hashtable_EditableCopy = new System.Collections.Hashtable();

                // Identify what Type.
                if (__0.CustomData != null)
                {
                    //ModConsole.DebugLog($"Received CustomData with Type : {__0.CustomData}");
                    if (__0.CustomData.GetIl2CppType().Equals(Il2CppType.Of<Dictionary<byte, Object>>()))
                    {
                        // Flag and convert the item that needs to be processed into a Editable copy .
                        isDictionary = true;

                        // This casts the dictionary still to a Il2cpp one, we need a system one!

                        var casted = __0.CustomData.Cast<Dictionary<byte, Il2CppSystem.Object>>();
                        if (casted != null)
                        {
                            // Copy all the stuff contained into The System Dictionary!
                            foreach (var item in casted)
                            {
                                ModConsole.DebugLog($"Copying Item Key {item.Key}");

                                // Copy using only the Existing keys!
                                Dictionary_EditableCopy.Add(item.Key, casted[item.Key]);
                            }

                        }
                    }

                    else if (__0.CustomData.GetIl2CppType().Equals(Il2CppType.Of<Hashtable>()))
                    {
                        isHashtable = true;
                        // TODO: ADD A CAST SYSTEM TO CONVERT IL2CPP HASHTABLE BACK TO A SYSTEM HASHTABLE (not important unless needed)!

                    }
                    else
                        isUnknownType = true;
                }

                switch (__0.Code)
                {

                    case VRChat_Photon_Events.Moderations:

                        // Feed only the Editable copy and let it process
                        if (isDictionary)
                        {
                            CurrentAction = Photon_PlayerModerationHandler.HandleEvent(ref Dictionary_EditableCopy);
                        }

                        break;

                }

                switch (CurrentAction)
                {
                    case HookAction.Patch:
                        // Do Patching and Report
                        if (isDictionary)
                        {
                            Photon_DictionaryEditor.ReplaceData(ref __0, isDictionary, isHashtable, Dictionary_EditableCopy);
                        }
                        PhotonLogger.PrintEvent(ref __0, CurrentAction, isDictionary, isHashtable, isUnknownType);
                        return true;
                        break;
                    case HookAction.Empty:
                        // Do Patching and Report
                        if (isDictionary)
                        {
                            Photon_DictionaryEditor.ReplaceData(ref __0, isDictionary, isHashtable, new System.Collections.Generic.Dictionary<byte, Object>());
                        }
                        PhotonLogger.PrintEvent(ref __0, CurrentAction, isDictionary, isHashtable, isUnknownType);
                        return true;
                        break;

                    case HookAction.Nothing:
                        PhotonLogger.PrintEvent(ref __0, CurrentAction, isDictionary, isHashtable, isUnknownType);
                        return true;
                        break;
                    case HookAction.Block:
                        PhotonLogger.PrintEvent(ref __0, CurrentAction, isDictionary, isHashtable, isUnknownType);
                        return false;
                        break;
                    case HookAction.Reset:
                        PhotonLogger.PrintEvent(ref __0, CurrentAction, isDictionary, isHashtable, isUnknownType);
                        __0.Reset();
                        return true;
                        break;
                    default:
                        PhotonLogger.PrintEvent(ref __0, CurrentAction, isDictionary, isHashtable, isUnknownType);
                        return true;
                        break;
                }
            }
        }
        catch (Exception e)
        {
            ModConsole.DebugError("Exception in OnEvent");
            ModConsole.ErrorExc(e);
            return true;
        }
        return true;
    }
}