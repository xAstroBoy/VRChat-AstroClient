namespace AstroClient.ClientUI.Menu.Menus.UserMenu
{
    using System;
    using System.Collections;
    using AstroMonos.Components.Tools;
    using Cheetos;
    using Target;
    using Tools.ObjectEditor;
    using UnityEngine;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenu;
    using xAstroBoy.UIPaths;
    using xAstroBoy.Utility;

    internal class UserInteractMenuBtns : AstroEvents
    {
        private static IEnumerator WaitForCloneBtnInit()
        {
            while (VRChatObjects.UICloneAvatarButton == null)
                yield return new WaitForSeconds(0.001f);
            if (VRChatObjects.UICloneAvatarButton != null)
            {
                VRChatObjects.UICloneAvatarButton.GetOrAddComponent<Disabler>();
            }

            yield return null;
        }

        internal static void InitUserButtons()
        {
            //MelonCoroutines.Start(WaitForCloneBtnInit());

            Init_UserMenu();

            //  NO TOUCH!
        }

        internal static void Init_UserMenu()
        {
            var menu = new QMNestedGridMenu(MenuAPI_New.QA_SelectedUser, 1, 0, "AstroClient User Options", "AstroClient User Options", Color.cyan, true);
            PickupProtector.InitButtons(menu);
            OrbitUserMenu.InitButtons(menu);
            AttackerUserMenu.InitButtons(menu);
            WatcherUserMenu.InitButtons(menu);
            SitUserMenu.InitButtons(menu);
            new QMSingleButton(menu, "AstroClient : Set Target.", new Action(TargetSelector.MarkPlayerAsTarget), "Mark this player as target.");
            new QMSingleButton(menu, "Force Clone", () => { ForceClone.ClonePlayer(); }, "Force Clone This Player's Avatar");
            _ = new QMSingleButton(menu, 1, 0, "Teleport All\nPickups\nTo\nplayer.", new Action(ObjectMiscOptions.TeleportAllWorldPickupsToPlayer), "Teleport World Pickups To Player.", null, null); ;
            _ = new QMSingleButton(menu, 2, 2, "Teleport\nTo\nPlayer", () => { PlayerUtils.GetPlayer().gameObject.transform.position = QuickMenuUtils.SelectedPlayer.transform.position; }, "Teleport To Player");
            _ = new QMSingleButton(menu, 4, 2, "Remove\n Everything", () =>
              {
                  ObjectMiscOptions.RemoveAllAttackPlayer();
                  ObjectMiscOptions.RemoveAllOrbitPlayer();
                  ObjectMiscOptions.RemoveAllWatchersPlayer();
              }
            , "Removes everything bound to this player.", null, null);
        }
    }
}