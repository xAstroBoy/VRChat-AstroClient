﻿using System.Collections.Generic;
using AstroClient.AstroMonos.Components.Spoofer;
using AstroClient.ClientActions;
using AstroClient.Constants;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy.Extensions;
using AstroClient.xAstroBoy.Utility;
using Photon.Realtime;

namespace AstroClient.Streamer
{
    #region Imports

    #endregion Imports

    internal class InstanceMasterDetector : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnMasterClientSwitched += OnMasterClientSwitched;
            ClientEventActions.OnWorldReveal += OnWorldReveal;

            ClientEventActions.OnRoomLeft += OnRoomJoined;
            ClientEventActions.OnRoomLeft += OnRoomLeft;
        }

        private static bool DoOnce;

        private void OnMasterClientSwitched(Player player)
        {
            if (!WorldUtils.IsInWorld) return;

            if (player.GetPhotonPlayer().GetAPIUser().IsSelf)
            {
                if (PlayerSpooferUtils.IsSpooferActive)
                {
                    PopupUtils.QueHudMessage($"'{PlayerSpooferUtils.SpooferInstance.Original_DisplayName}' is now the room master.");
                }
            }
            else
            {
                PopupUtils.QueHudMessage($"'{player.GetPhotonPlayer().GetDisplayName()}' is now the room master.");
            }

            player.GetVRCPlayer().AddSingleTag(InstanceMasterTag, System.Drawing.Color.OrangeRed);

        }


        private static string InstanceMasterTag => "<bounce><rainb>Instance Master</rainb></bounce>";
        private void OnRoomJoined()
        {
            Log.Write("You joined a room.");
        }

        private void OnRoomLeft()
        {
            Log.Write("You left a room.");
        }
        
        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            //VRC.Player player = PlayerUtils.GetPlayer();
            //if (player.gameObject.GetComponent<SitOnPlayer>() == null) player.gameObject.AddComponent<SitOnPlayer>();

            if (Bools.IsDeveloper && !DoOnce)
            {
                PopupUtils.QueHudMessage("Developer Mode!".RainbowRichText());
                DoOnce = true;
            }

            WorldUtils.InstanceMaster.GetPlayer().AddSingleTag(InstanceMasterTag, System.Drawing.Color.OrangeRed);
        }
    }
}