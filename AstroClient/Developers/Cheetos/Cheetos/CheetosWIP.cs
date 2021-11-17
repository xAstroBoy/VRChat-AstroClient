namespace AstroClient.Cheetos
{
    #region Imports

    using System;
    using System.Collections;
    using MelonLoader;
    using Transmtn.DTO.Notifications;
    using UnityEngine;
    using VRC;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.Utility;

    #endregion Imports

    /// <summary>
    /// Cheeto's temporary UI for new/wip features
    /// </summary>
    internal class CheetosWIP : AstroEvents
    {
        internal QMNestedButton MainButton { get; private set; }

        internal QMScrollMenu MainScroller { get; private set; }

        internal override void VRChat_OnQuickMenuInit()
        {
            MainButton = new QMNestedButton("MainMenu", 5, 4, "<color=cyan>WIP Menu</color>", "WIP Features", null, null, null, null, true);
            MainScroller = new QMScrollMenu(MainButton);

            var actions = new Action[4];
            var labels = new string[4];

            actions[0] = () => { ModConsole.Log("Toggle State: 1"); };
            actions[1] = () => { ModConsole.Log("Toggle State: 2"); };
            actions[2] = () => { ModConsole.Log("Toggle State: 3"); };
            actions[3] = () => { ModConsole.Log("Toggle State: 4"); };
            labels[0] = "First";
            labels[1] = "Second";
            labels[2] = "Third";
            labels[3] = "Fourth";

            //var quadToggle = new QMQuadToggleButton(MainButton, 3, 0, labels, actions);

            _ = new QMSingleButton(MainButton, 0, 0, "Friend Everyone", () => { DoFriendEveryone(); }, "Friend Everyone!");
            _ = new QMSingleButton(MainButton, 3, 2, "Notorious\nHome 1", () => { WorldUtils.JoinWorld("wrld_9b92ff5d-d445-4a25-a4d5-0a776b869938#wrld_9b92ff5d-d445-4a25-a4d5-0a776b869938:42069"); }, "");
            _ = new QMSingleButton(MainButton, 4, 2, "Notorious\nHome 2", () => { WorldUtils.JoinWorld("wrld_1913f8f7-ec88-4ff4-acc9-f54b278d8d6d#wrld_1913f8f7-ec88-4ff4-acc9-f54b278d8d6d:42069"); }, "");
        }

        private void DoFriendEveryone()
        {
            _ = MelonCoroutines.Start(FriendEveryone());
        }

        private IEnumerator FriendEveryone()
        {
            for (int i = 0; i < WorldUtils.Players.Count; i++)
            {
                Player player = WorldUtils.Players[i];
                if (!player.GetAPIUser().isFriend && !player.GetUserID().Equals(GameInstances.LocalPlayer.GetPlayer().GetUserID()))
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
        }
    }
}