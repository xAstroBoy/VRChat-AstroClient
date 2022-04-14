using System.Collections.Concurrent;

namespace AstroClient.Startup.Hooks.EventDispatcherHook.RPCFirewall
{
    using AstroClient.AstroMonos.Components.UI.SingleTag;
    using AstroClient.Config;
    using AstroClient.Tools.Extensions;
    using AstroClient.xAstroBoy.Utility;
    using Cheetah;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using VRC;

    internal class Player_RPC_Firewall : AstroEvents
    {
        internal static ConcurrentDictionary<Player, SingleTag> CurrentTags = new ConcurrentDictionary<Player, SingleTag>();

        internal override void OnRoomLeft()
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
                    CurrentTags.TryAdd(player, player.AddSingleTag(Color.Crayola.Present.Razzmatazz, "RPC Blocked"));
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
            var id = player.GetAPIUser().id;
            return ConfigManager.BlockedRPCPlayers.BlockedRPCPlayersList.Contains(id);
        }

        internal override void OnPlayerJoined(Player player)
        {
            if (IsBlocked(player))
            {
                if (!CurrentTags.ContainsKey(player))
                {
                    CurrentTags.TryAdd(player, player.AddSingleTag(Color.Crayola.Present.Razzmatazz, "RPC Blocked"));
                }
            }
        }

        internal override void OnPlayerLeft(Player player)
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
