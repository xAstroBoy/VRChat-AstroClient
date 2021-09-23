namespace AstroClient
{
    #region Imports

    using AstroClient.Moderation;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using ExitGames.Client.Photon;
    using Harmony;
    using Photon.Realtime;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    #endregion Imports

    public class PhotonOnEventHook : GameEvents
    {
        //public static
        private HarmonyLib.Harmony harmony;

        public override void ExecutePriorityPatches()
        {
            MiscUtils.DelayFunction(1f, new System.Action(() =>
            {
                InitPatches();
            }));
        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyHookInit", Exclude = false)]
        public void InitPatches()
        {
            try
            {
                if (harmony == null)
                {
                    harmony = new HarmonyLib.Harmony(BuildInfo.Name + " PhotonOnEventHook");
                }

                _ = harmony.Patch(AccessTools.Method(typeof(LoadBalancingClient), nameof(LoadBalancingClient.OnEvent)), new HarmonyMethod(typeof(PhotonOnEventHook).GetMethod(nameof(OnEvent), BindingFlags.Static | BindingFlags.NonPublic)), null, null);
                ModConsole.DebugLog("Photon Hooks Done");
            }
            catch
            {
                harmony.UnpatchAll();
                InitPatches();
            }
        }

        private static void ModerationEventNotifier(int EventType, bool isPatched)
        {
            if (ConfigManager.General.LogEvents)
            {
                string blockText = string.Empty;
                if (isPatched)
                {
                    blockText = "[PATCHED] : ";
                }
                PopupUtils.QueHudMessage($"{blockText}Moderation Event: {EventType}");
            }
        }

        // UDON BEHAVIOURS GETS AFFECTED!
        // Best advice, make each event have his own handler class to translate and remove the useless translations so is faster and better.

        private static bool OnEvent(ref EventData __0)
        {
            if (__0.Parameters == null)
            {
                return true;
            }
                object RawData = Serialization.FromIL2CPPToManaged<object>(__0.Parameters);
                var code = __0.Code;
                var PhotonSender = Utils.LoadBalancingPeer.GetPhotonPlayer(__0.sender);
                var PhotonID = __0.sender;
                bool log = false;
                bool patched = false;
                StringBuilder line = new StringBuilder();
                StringBuilder prefix = new StringBuilder();
                prefix.Append($"[Event ({code})] ");
                line.Append($"from: ({__0.Sender}) ");
                if (WorldUtils.IsInWorld && PhotonSender != null)
                {
                    line.Append($"'{PhotonSender.GetDisplayName()}'");
                }
                else
                {
                    line.Append($"'NULL' ");
                }

                switch (code)
                {
                    case 1:// Voice Data TODO : (Parrot Mode)
                        break;

                    case 7: // I believe this is motion, key 245 appears to be base64
                        break;

                    case 2: // Kick Message?
                        string kickMessage = (RawData as Dictionary<byte, object>)[245].ToString();
                        break;

                    case 6:
                        break;

                    case 8: // Interest - Interested in events
                        break;

                    case 33: // Moderations
                        if (__0.Parameters == null || __0 == null || !__0.Parameters.ContainsKey(245))
                        {
                            break;
                        }
                        var infoData = __0.Parameters[245].Cast<Il2CppSystem.Collections.Generic.Dictionary<byte, Il2CppSystem.Object>>();
                        ModConsole.DebugLog("1.");
                        if (infoData != null && infoData.Keys.Count != 0)
                        {
                            var eventTypebyte = infoData[0].Unpack_Byte();
                            if (eventTypebyte.HasValue)
                            {
                                var eventType = Convert.ToInt32(eventTypebyte);
                                if (eventType == 21)
                                {
                                    ModConsole.DebugLog("2.");

                                    if (infoData[10] != null && infoData[11] != null)
                                    {
                                        // If Key 1 exists then this is a direct moderation
                                        if (infoData.ContainsKey(1))
                                        {
                                            var SenderID = infoData[1].Unpack_Int32();
                                            if (SenderID.HasValue)
                                            {
                                                ModConsole.DebugLog("3.");
                                                var PhotonPlayer = Utils.LoadBalancingPeer.GetPhotonPlayer(SenderID.Value);
                                                var Blocked = infoData[10].Unpack_Boolean();
                                                var Muted = infoData[11].Unpack_Boolean();
                                                if (PhotonPlayer != null)
                                                {
                                                    if (Blocked.HasValue)
                                                    {
                                                        if (Blocked.Value)
                                                        {
                                                            PhotonModerationHandler.OnPlayerBlockedYou_Invoker(PhotonPlayer);
                                                        }
                                                        else
                                                        {
                                                            PhotonModerationHandler.OnPlayerUnblockedYou_Invoker(PhotonPlayer);
                                                        }
                                                    }
                                                    if (Muted.HasValue)
                                                    {
                                                        if (Muted.Value)
                                                        {
                                                            PhotonModerationHandler.OnPlayerMutedYou_Invoker(PhotonPlayer);
                                                        }
                                                        else
                                                        {
                                                            PhotonModerationHandler.OnPlayerUnmutedYou_Invoker(PhotonPlayer);
                                                        }
                                                    }

                                                    if (Blocked.HasValue) // AntiBlock.
                                                    {
                                                        if (Blocked.Value)
                                                        {
                                                            ModConsole.DebugLog("patch.");
                                                        ModConsole.DebugLog("Remove Old Value.");

                                                        if (infoData.Remove(10))
                                                        {
                                                            ModConsole.DebugLog("Add New Key with modified Value");
                                                            infoData.Add(10, new Il2CppSystem.Boolean() { m_value = false }.BoxIl2CppObject());
                                                            patched = true;
                                                            ModConsole.DebugLog("Notify Of patch");
                                                            ModerationEventNotifier(eventType, true);
                                                            ModConsole.DebugLog("replace Current parameters with new Infodata.");
                                                            __0.Parameters[245] = infoData;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            // It sends the Arrays when the Block and Mute Event happen fast.
                                            // if 10 is an Array it has all the PhotonIds that Blocked You
                                            // if 11 is an Array it has all the PhotonIds that Muted You
                                            var BlockedList = infoData[10].Unpack_Array_Int32();
                                            var patchedlist = new Il2CppSystem.Collections.Generic.List<int>();
                                            bool hasPatchedBlockList = false;
                                            if (BlockedList != null)
                                            {
                                                if (BlockedList.Count() != 0)
                                                {
                                                    ModConsole.DebugLog("Blocked list detected.");
                                                    for (int i = 0; i < BlockedList.Length; i++)
                                                    {
                                                        int blockid = BlockedList[i];
                                                        var BlockPlayer = Utils.LoadBalancingPeer.GetPhotonPlayer(blockid);
                                                        if (BlockPlayer != null)
                                                        {
                                                            if (!PhotonModerationHandler.BlockedYouPlayers.Contains(BlockPlayer))
                                                            {
                                                                PhotonModerationHandler.BlockedYouPlayers.Add(BlockPlayer);
                                                            }
                                                        }
                                                        patchedlist.Add(-1);
                                                    }
                                                    hasPatchedBlockList = true;
                                                }
                                            }
                                            var MuteList = infoData[11].Unpack_Array_Int32();
                                            if (MuteList != null)
                                            {
                                                if (MuteList.Count() != 0)
                                                {
                                                    for (int i = 0; i < MuteList.Length; i++)
                                                    {
                                                        ModConsole.DebugLog("Muted list detected.");
                                                        int MuteID = MuteList[i];
                                                        var MutePlayer = Utils.LoadBalancingPeer.GetPhotonPlayer(MuteID);
                                                        if (MutePlayer != null)
                                                        {
                                                            if (!PhotonModerationHandler.MutedYouPlayers.Contains(MutePlayer))
                                                            {
                                                                PhotonModerationHandler.MutedYouPlayers.Add(MutePlayer);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            if (hasPatchedBlockList)
                                            {
                                                ModConsole.DebugLog("Blocked list Patch.");
                                                if (infoData.Remove(10))
                                                {
                                                    infoData.Add(10, Il2cppObjectConverter.Generate_Il2CppObject_Unmanaged<int>(patchedlist)); patched = true;
                                                    __0.Parameters[245] = infoData;
                                                    ModerationEventNotifier(eventType, true);
                                                }
                                            }
                                        }
                                    }
                                    ModerationEventNotifier(eventType, false);
                                }
                            }
                        }
                        log = true;
                        break;

                    case 203: // Destroy
                        prefix.Append("Destroy: ");
                        log = true;
                        break;

                    case 210:
                        break;

                    case 223: // This fired with what looked like base64 png data when I uploaded a VRC+ avatar
                        break;

                    case 253: // I think this is avatar switching related
                        break;

                    default:
                        log = true;
                        break;
                }

                string PatchedText = string.Empty;
                if (patched)
                {
                    PatchedText = "[PATCHED] ";
                }

                if (log && ConfigManager.General.LogEvents)
                {
                    line.Append($"\n{Newtonsoft.Json.JsonConvert.SerializeObject(Serialization.FromIL2CPPToManaged<object>(__0.Parameters), Newtonsoft.Json.Formatting.Indented)}");
                    ModConsole.Log($"{PatchedText}{prefix.ToString()}{line.ToString()}");
                }
                line.Clear();
            return true;
        }
    }
}