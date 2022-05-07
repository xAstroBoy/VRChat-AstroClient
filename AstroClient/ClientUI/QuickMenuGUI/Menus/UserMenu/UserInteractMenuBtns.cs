﻿using System;
using AstroClient.AstroMonos;
using AstroClient.PickupBlockerSystem;

namespace AstroClient.ClientUI.Menu.Menus.UserMenu
{
    using System.Collections;
    using AstroMonos.Components.Spoofer;
    using AstroMonos.Components.Tools;
    using Cheetos;
    using Startup.Hooks;
    using Target;
    using Tools.ObjectEditor;
    using UnityEngine;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.UIPaths;
    using xAstroBoy.Utility;

    internal class UserInteractMenuBtns : AstroEvents
    {
        internal static void InitUserButtons()
        {
            //MelonCoroutines.Start(WaitForCloneBtnInit());

            Init_UserMenu();

            //  NO TOUCH!
        }

        internal static void Init_UserMenu()
        {
            var menu = new QMNestedGridMenu(MenuAPI_New.QA_SelectedUser_Remote, 1, 0, "AstroClient User Options", "AstroClient User Options", Color.white, true);
            new QMSingleButton(MenuAPI_New.QA_SelectedUser_Remote, 2, 0, "Local Clone", () => { SoftCloneHook.LocalCloneAvatarPlayer(QuickMenuUtils.SelectedUser); }, "Force Clone This Player's Avatar");
            new QMSingleButton(MenuAPI_New.QA_SelectedUser_Remote, 3, 0, "Dump Avatar Hashtable in Console", () => { SoftCloneHook.PrintCurrentAvatarHashtable(QuickMenuUtils.SelectedUser); }, "Locally Clone Clone This Player's Avatar");
            new QMSingleButton(MenuAPI_New.QA_SelectedUser_Remote, 4, 0, "Deny Pickups to Player.", new Action(() => { PickupBlocker.RegisterPlayer(QuickMenuUtils.SelectedUser); }), "Block Pickups from being used by this player!.");
            new QMSingleButton(MenuAPI_New.QA_SelectedUser_Remote, 5, 0, "Re-allow Pickups to Player.", new Action(() => { PickupBlocker.RemovePlayer(QuickMenuUtils.SelectedUser); }), "Allows Pickups To be used by this player!.");
            PickupProtector.InitButtons(menu);
            OrbitUserMenu.InitButtons(menu);
            AttackerUserMenu.InitButtons(menu);
            WatcherUserMenu.InitButtons(menu);
            //SitUserMenu.InitButtons(menu);
            new QMSingleButton(menu, "AstroClient : Set Target.", TargetSelector.MarkPlayerAsTarget, "Mark this player as target.");
            new QMSingleButton(menu, "Local Clone", () => { SoftCloneHook.LocalCloneAvatarPlayer(QuickMenuUtils.SelectedUser); }, "Locally Clone Clone This Player's Avatar");
            new QMSingleButton(menu, "Dump Avatar Hashtable in Console", () => { SoftCloneHook.PrintCurrentAvatarHashtable(QuickMenuUtils.SelectedUser); }, "Locally Clone Clone This Player's Avatar");

            new QMSingleButton(menu, "Force Clone", () => { ForceClone.ClonePlayer(); }, "Force Clone This Player's Avatar");
            new QMSingleButton(menu, "Spoof As Selected Player", () => { PlayerSpooferUtils.SpoofAs(QuickMenuUtils.SelectedUser.GetDisplayName()); }, "Spoof as this player ! ");
            _ = new QMSingleButton(menu, "Teleport All\nPickups\nTo\nplayer.", ObjectMiscOptions.TeleportAllWorldPickupsToPlayer, "Teleport World Pickups To Player.");
            ;
            _ = new QMSingleButton(menu, "Teleport\nTo\nPlayer", () => { PlayerUtils.GetPlayer().gameObject.transform.position = QuickMenuUtils.SelectedPlayer.transform.position; }, "Teleport To Player");
            _ = new QMSingleButton(menu, "Remove\n Everything", () =>
                {
                    ObjectMiscOptions.RemoveAllAttackPlayer();
                    ObjectMiscOptions.RemoveAllOrbitPlayer();
                    ObjectMiscOptions.RemoveAllWatchersPlayer();
                }
                , "Removes everything bound to this player.");

            var Shortcut = new QMSingleButton(MenuAPI_New.QA_SelectedUser_Local, 1, 0, "AstroClient User Options", null, "AstroClient User Options", true);
            Shortcut.SetButtonShortcut(menu);
            new QMSingleButton(MenuAPI_New.QA_SelectedUser_Local, 2, 0, "Local Clone", () => { SoftCloneHook.LocalCloneAvatarPlayer(QuickMenuUtils.SelectedUser); }, "Force Clone This Player's Avatar");
            new QMSingleButton(MenuAPI_New.QA_SelectedUser_Local, 3, 0, "Dump Avatar Hashtable in Console", () => { SoftCloneHook.PrintCurrentAvatarHashtable(QuickMenuUtils.SelectedUser); }, "Locally Clone Clone This Player's Avatar");
            new QMSingleButton(MenuAPI_New.QA_SelectedUser_Local, 4, 0, "Deny Pickups to Player.", new Action(() => { PickupBlocker.RegisterPlayer(QuickMenuUtils.SelectedUser); }), "Block Pickups from being used by this player!.");
            new QMSingleButton(MenuAPI_New.QA_SelectedUser_Local, 5, 0, "Re-allow Pickups to Player.", new Action(() => { PickupBlocker.RemovePlayer(QuickMenuUtils.SelectedUser); }), "Allows Pickups To be used by this player!.");
                                           
        }

    }
}