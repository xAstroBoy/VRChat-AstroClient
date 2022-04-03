using System.Collections.Concurrent;

namespace AstroClient.Moderation
{
    #region Imports

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using AstroEventArgs;
    using MelonLoader;
    using Photon.Realtime;
    using Tools.Extensions;
    using xAstroBoy.Utility;

    #endregion

    internal class PhotonModerationHandler : AstroEvents
    {
        private static void RegisterPlayer(string id)
        {
            if (!PlayerModerations.ContainsKey(id))
            {
                PlayerModerations.TryAdd(id, new ModerationData());
            }
        }


        private static void RemovePlayer(string id)
        {
            if (!PlayerModerations.ContainsKey(id))
            {
                PlayerModerations.TryRemove(id, out _);
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
                        Event_OnPlayerBlockedYou?.SafetyRaise(player);
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
                        Event_OnPlayerUnblockedYou?.SafetyRaise(player);
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
                        Event_OnPlayerMutedYou?.SafetyRaise(player);
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
                        Event_OnPlayerUnmutedYou?.SafetyRaise(player);
                    }
                }
            }
        }

        #region EventHandlers

        internal static event Action<Player> Event_OnPlayerBlockedYou;
        internal static event Action<Player> Event_OnPlayerUnblockedYou;
        internal static event Action<Player> Event_OnPlayerMutedYou;
        internal static event Action<Player> Event_OnPlayerUnmutedYou;

        #endregion

        #region PlayerModerations

        internal override void OnRoomLeft()
        {
            PlayerModerations.Clear();
        }

        internal override void OnPhotonPlayerLeft(Player player)
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


        internal static ConcurrentDictionary<string, ModerationData> PlayerModerations = new ConcurrentDictionary<string, ModerationData>();

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