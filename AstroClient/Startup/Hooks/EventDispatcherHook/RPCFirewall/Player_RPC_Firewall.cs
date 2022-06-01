using System.Collections.Concurrent;
using AstroClient.ClientActions;
using Cheetah;

namespace AstroClient.Startup.Hooks.EventDispatcherHook.RPCFirewall
{
    using AstroClient.AstroMonos.Components.UI.SingleTag;
    using AstroClient.Config;
    using AstroClient.Tools.Extensions;
    using AstroClient.xAstroBoy.Utility;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using VRC;

    internal class Player_RPC_Firewall : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnRoomLeft += OnRoomLeft;
            ClientEventActions.OnPlayerJoin += OnPlayerJoined;
            ClientEventActions.OnPlayerLeft += OnPlayerLeft;

        }

        internal static ConcurrentDictionary<Player, SingleTag> CurrentTags = new ConcurrentDictionary<Player, SingleTag>();

        private void OnRoomLeft()
        {
            CurrentTags.Clear(); 
        }

        internal static void AddPlayer(Player player)
        {
            var id = player.GetAPIUser().id;
            if (!ConfigManager.BlockedRPCPlayers.BlockedRPCPlayersList.Contains(id))
            {
                ConfigManager.BlockedRPCPlayers.BlockedRPCPlayersList.Add(id);
                if (!CurrentTags.ContainsKey(player))
                {
                    CurrentTags.TryAdd(player, player.AddSingleTag("RPC Blocked", Color.Crayola.Present.Razzmatazz));
                }
            }
        }

        internal static void RemovePlayer(Player player)
        {
            var id = player.GetAPIUser().id;
            if (ConfigManager.BlockedRPCPlayers.BlockedRPCPlayersList.Contains(id))
            {
                ConfigManager.BlockedRPCPlayers.BlockedRPCPlayersList.Remove(id);
                var tag = CurrentTags[player];
                tag.DestroyMeLocal();
                CurrentTags.TryRemove(player, out _);
            }
        }

        internal static bool IsBlocked(Player player)
        {
            if (player != null)
            {
                var user = player.GetAPIUser();
                if (!user.IsSelf)
                {
                    return ConfigManager.BlockedRPCPlayers.BlockedRPCPlayersList.Contains(user.id);
                }
            }
            return false;
        }

        private void OnPlayerJoined(Player player)
        {
            if (IsBlocked(player))
            {
                if (!CurrentTags.ContainsKey(player))
                {
                    CurrentTags.TryAdd(player, player.AddSingleTag("RPC Blocked", Color.Crayola.Present.Razzmatazz));
                }
            }
        }

        private void OnPlayerLeft(Player player)
        {
            if (IsBlocked(player))
            {
                var tag = CurrentTags[player];
                tag.DestroyMeLocal();
                CurrentTags.TryRemove(player, out _);
            }
        }
    }
}
