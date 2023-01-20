namespace AstroClient.Startup.Hooks.PhotonHook.PhotonHandlers;

using AstroClient.Tools.Extensions;
using AstroClient.Tools.UdonEditor;
using Il2CppSystem;
using Moderation;
using Structs;
using Structs.ModerationStructures;
using System.Collections.Generic;
using UnhollowerBaseLib;
using xAstroBoy.Utility;
using Exception = System.Exception;

internal class Photon_PlayerModerationHandler
{
    internal static HookAction HandleEvent(ref Dictionary<byte, Object> Dictionary)
    {
        try
        {
            HookAction result = HookAction.Nothing;
            if (Dictionary.ContainsKey(ModerationCode.EventCode))
            {
                var moderationevent = Dictionary[ModerationCode.EventCode].Unbox<byte>();
                switch (moderationevent)
                {
                    case ModerationCode.Warning: // Warnings.
                        return HookAction.Nothing;
                        break;

                    case ModerationCode.Mod_Mute: // Mod Mute
                        return HookAction.Nothing;
                        break;

                    case ModerationCode.VoteKick:
                        return HookAction.Nothing;

                    case ModerationCode.Friend_State: // Friend State
                        return HookAction.Nothing;
                        break;

                    case ModerationCode.Block_Or_Mute:

                        #region Blocking and Muting Events.

                        // Single Moderation Event (one player)
                        if (Dictionary.Count == 4)
                        {
                            if (Dictionary.ContainsKey(PlayerModerationCode.ActorID))
                            {
                                var RemoteModerationPhotonID = Dictionary[PlayerModerationCode.ActorID].Unpack_Int32().Value;
                                var PhotonPlayer = GameInstances.LoadBalancingPeer.GetPhotonPlayer(RemoteModerationPhotonID);
                                if (Dictionary.ContainsKey(PlayerModerationCode.Block))
                                {
                                    var blocked = Dictionary[PlayerModerationCode.Block].Unbox<bool>();
                                    switch (blocked)
                                    {
                                        case true:
                                            {
                                                PhotonModerationHandler.OnPlayerBlockedYou_Invoker(PhotonPlayer);
                                                Dictionary[PlayerModerationCode.Block] = Il2CppConverter.Generate_Il2CPPObject(false);
                                                result = HookAction.Patch;
                                                break;
                                            }
                                        case false:
                                            {
                                                PhotonModerationHandler.OnPlayerUnblockedYou_Invoker(PhotonPlayer);
                                                break;
                                            }
                                    }
                                }

                                if (Dictionary.ContainsKey(PlayerModerationCode.Mute))
                                {
                                    var muted = Dictionary[PlayerModerationCode.Mute].Unbox<bool>();
                                    switch (muted)
                                    {
                                        case true:
                                            {
                                                PhotonModerationHandler.OnPlayerMutedYou_Invoker(PhotonPlayer);
                                                break;
                                            }
                                        case false:
                                            {
                                                PhotonModerationHandler.OnPlayerUnmutedYou_Invoker(PhotonPlayer);
                                                break;
                                            }
                                    }
                                }
                            }
                        }

                        // Multiple Moderation Events (Usually happens when you enter the room)
                        else if (Dictionary.Count == 3)
                        {
                            // Blocked List
                            if (Dictionary.ContainsKey(PlayerModerationCode.Block))
                            {
                                var blockedlistObject = Dictionary[PlayerModerationCode.Block];
                                if (blockedlistObject != null)
                                {
                                    var BlockedPlayersArray = blockedlistObject.Cast<Il2CppStructArray<int>>();
                                    if (BlockedPlayersArray != null)
                                        if (BlockedPlayersArray.Count != 0)
                                        {
                                            for (var i = 0; i < BlockedPlayersArray.Count; i++)
                                            {
                                                var blockedplayers = GameInstances.LoadBalancingPeer.GetPhotonPlayer(BlockedPlayersArray[i]);
                                                PhotonModerationHandler.OnPlayerBlockedYou_Invoker(blockedplayers);
                                                BlockedPlayersArray[i] = -1;
                                            }

                                            Dictionary[PlayerModerationCode.Block] = new Object(BlockedPlayersArray.Pointer);
                                            result = HookAction.Patch;
                                        }
                                }
                            }

                            // Muted List
                            if (Dictionary.ContainsKey(PlayerModerationCode.Mute))
                            {
                                var MutedlistObject = Dictionary[PlayerModerationCode.Mute];
                                if (MutedlistObject != null)
                                {
                                    var MutePlayersArray = MutedlistObject.Cast<Il2CppStructArray<int>>();
                                    {
                                        if (MutePlayersArray != null)
                                        {
                                            if (MutePlayersArray.Count != ModerationCode.EventCode)
                                            {
                                                for (var i = 0; i < MutePlayersArray.Count; i++)
                                                {
                                                    var MutePlayer = GameInstances.LoadBalancingPeer.GetPhotonPlayer(MutePlayersArray[i]);
                                                    PhotonModerationHandler.OnPlayerMutedYou_Invoker(MutePlayer);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        #endregion Blocking and Muting Events.

                        break;

                    default:
                        break;
                }

                return result;
            }
        }
        catch (Exception e)
        {
            Log.Error("Exception in OnEvent Moderation Handler");
            Log.Exception(e);
        }

        return HookAction.Nothing;
    }
}