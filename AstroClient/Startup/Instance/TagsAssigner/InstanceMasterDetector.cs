using System.Collections.Generic;
using AstroClient.ClientActions;
using AstroClient.ClientUI.Hud.Notifier;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy.Extensions;
using AstroClient.xAstroBoy.Utility;
using Photon.Realtime;

namespace AstroClient.Startup.Instance.TagsAssigner
{
    #region Imports

    #endregion Imports

    internal class InstanceMasterDetector : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnMasterClientSwitched += OnMasterClientSwitched;
            ClientEventActions.OnWorldReveal += OnWorldReveal;

            ClientEventActions.OnRoomJoined += OnRoomJoined;
            ClientEventActions.OnRoomLeft += OnRoomLeft;
        }

        private void OnMasterClientSwitched(Player player)
        {
            if (!WorldUtils.IsInWorld) return;

            if (player.GetPhotonPlayer().GetAPIUser().IsSelf)
            {
                NewHudNotifier.WriteHudMessage($"You are now the room master.");
            }
            else
            {
                NewHudNotifier.WriteHudMessage($"{player.GetPhotonPlayer().GetDisplayName()} is now the room master.");
            }
            if (CurrentMaster != player || CurrentMaster == null)
            {
                CurrentMaster = player;
                player.GetVRCPlayer().AddSingleTag(InstanceMasterTag, System.Drawing.Color.OrangeRed);
            }
        }


        private static string InstanceMasterTag => "<bounce><rainb>Instance Master</rainb></bounce>";
        private void OnRoomJoined()
        {
            Log.Write("You joined a room.");
        }

        private void OnRoomLeft()
        {
            Log.Write("You left a room.");
            CurrentMaster = null;
        }
        
        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            //VRC.Player player = PlayerUtils.GetPlayer();
            //if (player.gameObject.GetComponent<SitOnPlayer>() == null) player.gameObject.AddComponent<SitOnPlayer>();

            WorldUtils.InstanceMaster.GetPlayer().AddSingleTag(InstanceMasterTag, System.Drawing.Color.OrangeRed);
        }

        private static Player CurrentMaster { get; set; }
    }
}