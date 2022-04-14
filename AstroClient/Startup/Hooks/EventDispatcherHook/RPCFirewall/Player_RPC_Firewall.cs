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

    internal class SenderBlocker : AstroEvents
    {
        public Dictionary<Player, SingleTag> CurrentTags = new Dictionary<Player, SingleTag>();

        internal void AddPlayer(Player player)
        {
            var id = player.GetAPIUser().id;
            if (!ConfigManager.BlockedRPCPlayers.BlockedRPCPlayersList.Contains(id))
            {
                ConfigManager.BlockedRPCPlayers.BlockedRPCPlayersList.Add(id);
                CurrentTags.Add(player, player.AddSingleTag(Color.Crayola.Present.Razzmatazz, "RPC Blocked"));
            }
        }

        internal void RemovePlayer(Player player)
        {
            var id = player.GetAPIUser().id;
            if (ConfigManager.BlockedRPCPlayers.BlockedRPCPlayersList.Contains(id))
            {
                ConfigManager.BlockedRPCPlayers.BlockedRPCPlayersList.Remove(id);
                var tag = CurrentTags[player];
                tag.DestroyMeLocal();
                CurrentTags.Remove(player);
            }
        }

        internal bool IsBlocked(Player player)
        {
            var id = player.GetAPIUser().id;
            return ConfigManager.BlockedRPCPlayers.BlockedRPCPlayersList.Contains(id);
        }

        internal override void OnPlayerJoined(Player player)
        {
            if (IsBlocked(player))
            {
                CurrentTags.Add(player, player.AddSingleTag(Color.Crayola.Present.Razzmatazz, "RPC Blocked"));
            }
        }

        internal override void OnPlayerLeft(Player player)
        {
            if (IsBlocked(player))
            {
                var tag = CurrentTags[player];
                tag.DestroyMeLocal();
                CurrentTags.Remove(player);
            }
        }
    }
}
