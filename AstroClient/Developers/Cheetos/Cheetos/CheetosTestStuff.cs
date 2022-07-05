using AstroClient.ClientActions;

namespace AstroClient.Cheetos
{
    #region Imports

    using System.Collections.Generic;
    using AstroMonos.Components.Player;
    using AstroMonos.Components.Spoofer;
    using Constants;
    using Photon.Realtime;
    using Tools.Extensions;
    using UnityEngine;
    using UnityEngine.UI;
    using VRC.Core;
    using WebSocketSharp;
    using xAstroBoy;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;

    #endregion Imports

    internal class CheetosTestStuff : AstroEvents
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
                    PopupUtils.QueHudMessage(
                        $"'{PlayerSpooferUtils.SpooferInstance.Original_DisplayName}' is now the room master.");
                }
            }
            else
            {
                PopupUtils.QueHudMessage($"'{player.GetPhotonPlayer().GetDisplayName()}' is now the room master.");
            }

            player.GetVRCPlayer().AddSingleTag("Instance Master", System.Drawing.Color.OrangeRed);

        }

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

            WorldUtils.InstanceMaster.GetPlayer().AddSingleTag("<rainb>Instance Master</rainb>", System.Drawing.Color.OrangeRed);
        }
    }
}