namespace AstroClient
{
    #region Imports

    using AstroClient.Exploits;
    using AstroClient.Variables;
    using AstroLibrary;
    using AstroLibrary.Console;
    using AstroLibrary.Utility;
    using MelonLoader;
    using RubyButtonAPI;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using Transmtn.DTO.Notifications;
    using UnityEngine;
    using VRC.SDKBase;
    using static VRC.SDKBase.VRC_EventHandler;

    #endregion Imports

    /// <summary>
    /// Cheeto's temporary UI for new/wip features
    /// </summary>
    public class CheetosUI : GameEvents
    {
        public QMNestedButton MainButton { get; private set; }

        public QMScrollMenu MainScroller { get; private set; }

        public override void VRChat_OnUiManagerInit()
        {
            MainButton = new QMNestedButton("ShortcutMenu", 5, 4, "<color=cyan>WIP Menu</color>", "WIP Features", null, null, null, null, true);
            MainScroller = new QMScrollMenu(MainButton);
            _ = new QMSingleButton(MainButton, 0, 0, "Friend Everyone", () => { DoFriendEveryone(); }, "Friend Everyone!");
            _ = new QMSingleButton(MainButton, 4, 2, "Notorious\nHome 1", () => { WorldUtils.JoinWorld("wrld_9b92ff5d-d445-4a25-a4d5-0a776b869938#wrld_9b92ff5d-d445-4a25-a4d5-0a776b869938:42069"); }, "");
            _ = new QMSingleButton(MainButton, 4, 3, "Notorious\nHome 2", () => { WorldUtils.JoinWorld("wrld_1913f8f7-ec88-4ff4-acc9-f54b278d8d6d#wrld_1913f8f7-ec88-4ff4-acc9-f54b278d8d6d:42069"); }, "");
        }

        private void DoFriendEveryone()
        {
            _ = MelonCoroutines.Start(FriendEveryone());
        }

        private IEnumerator FriendEveryone()
        {
            for (int i = 0; i < WorldUtils.Players.Count; i++)
            {
                VRC.Player player = WorldUtils.Players[i];
                if (!player.GetAPIUser().isFriend && !player.GetUserID().Equals(Utils.LocalPlayer.GetPlayer().GetUserID()))
                {
                    try
                    {
                        Notification xx = FriendRequest.Create(player.GetUserID());
                        VRCWebSocketsManager.field_Private_Static_VRCWebSocketsManager_0.prop_Api_0.PostOffice.Send(xx);
                        PopupUtils.QueHudMessage($"Friend Request Sent: {player.GetDisplayName()}");
                    }
                    catch (Exception e)
                    {
                        ModConsole.Error(e.Message);
                    }
                }
                yield return new WaitForSeconds(5f);
            }

            ModConsole.Log("Friend Requests Done!");
            PopupUtils.QueHudMessage("Friend Requests Done!");
            yield break;
        }
    }
}