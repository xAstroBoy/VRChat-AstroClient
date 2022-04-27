using AstroClient.ClientActions;

namespace AstroClient.Moderation
{
    #region Usings

    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    using MelonLoader;
    using Photon.Realtime;
    using Tools.Extensions;
    using xAstroBoy.Utility;
    using System.Collections.Concurrent;

    #endregion

    internal class PhotonModerationHandler : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.Event_OnRoomLeft += OnRoomLeft;
            ClientEventActions.Event_OnPhotonPlayerLeft += OnPhotonPlayerLeft;
        }

        private static void RegisterPlayer(string id)
        {
            if (!PlayerModerations.ContainsKey(id))
            {
                PlayerModerations.Add(id, new ModerationData());
            }
        }

        private static void RemovePlayer(string id)
        {
            if (!PlayerModerations.ContainsKey(id))
            {
                PlayerModerations.Remove(id);
            }

        }

        internal static void OnPlayerBlockedYou_Invoker(Player player)
        {
            if (player != null)
            {
                var photonuserid = player.GetUserID();
                RegisterPlayer(photonuserid);
                if (PlayerModerations.ContainsKey(photonuserid))
                {
                    if (!PlayerModerations[photonuserid].Blocked)
                    {
                        PlayerModerations[photonuserid].Blocked = true;
                        ClientEventActions.Event_OnPlayerBlockedYou?.SafetyRaiseWithParams(player);
                    }
                }
            }
        }

        internal static void OnPlayerUnblockedYou_Invoker(Player player)
        {
            if (player != null)
            {
                var photonuserid = player.GetUserID();
                RegisterPlayer(photonuserid);
                if (PlayerModerations.ContainsKey(photonuserid))
                {
                    if (PlayerModerations[photonuserid].Blocked)
                    {
                        PlayerModerations[photonuserid].Blocked = false;
                        ClientEventActions.Event_OnPlayerUnblockedYou?.SafetyRaiseWithParams(player);
                    }
                }
            }
        }

        internal static void OnPlayerMutedYou_Invoker(Player player)
        {
            if (player != null)
            {
                var photonuserid = player.GetUserID();
                RegisterPlayer(photonuserid);
                if (PlayerModerations.ContainsKey(photonuserid))
                {
                    if (!PlayerModerations[photonuserid].Muted)
                    {
                        PlayerModerations[photonuserid].Muted = true;
                        ClientEventActions.Event_OnPlayerMutedYou?.SafetyRaiseWithParams(player);
                    }
                }
            }
        }

        internal static void OnPlayerUnmutedYou_Invoker(Player player)
        {
            if (player != null)
            {
                var photonuserid = player.GetUserID();
                RegisterPlayer(photonuserid);
                if (PlayerModerations.ContainsKey(photonuserid))
                {
                    if (PlayerModerations[photonuserid].Muted)
                    {
                        PlayerModerations[photonuserid].Muted= false;
                        ClientEventActions.Event_OnPlayerUnmutedYou?.SafetyRaiseWithParams(player);
                    }
                }
            }
        }


        #region PlayerModerations

        private void OnRoomLeft()
        {
            PlayerModerations.Clear();
        }

        private void OnPhotonPlayerLeft(Player player)
        {
            MelonCoroutines.Start(PlayerLeft(player));
        }

        private static IEnumerator PlayerLeft(Player player)
        {
            if (player == null) yield break;
            var photonuserid = player.GetUserID();
            RemovePlayer(photonuserid);
            yield return null;
        }

        internal static Dictionary<string, ModerationData> PlayerModerations = new Dictionary<string, ModerationData>();

        internal class ModerationData
        {
            internal bool Blocked { get; set; } = false;
            internal bool Muted { get; set; } = false;

            internal ModerationData(bool Blocked = false, bool Muted = false)
            {
                this.Blocked = Blocked;
                this.Muted = Muted;
            }
        }

        #endregion PlayerModerations
    }
}