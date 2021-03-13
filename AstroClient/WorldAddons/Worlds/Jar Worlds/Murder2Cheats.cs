using RubyButtonAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#region AstroClient Imports

using AstroClient.ConsoleUtils;
using AstroClient.variables;
using AstroClient.Finder;
using AstroClient.extensions;
using AstroClient.ButtonShortcut;

#endregion AstroClient Imports

namespace AstroClient
{
    public class Murder2Cheats
    {
        public static void FindGameMurderObjects()
        {

            



            item_detectiveGun = GameObjectFinder.Find("Murder Logic 3/Weapons/Gun Revolver");
            item_SilencedGun = GameObjectFinder.Find("Murder Logic 3/Weapons/Gun Silenced");
            item_clue_0 = GameObjectFinder.Find("Murder Logic 3/ClueCollecting/Clues/Clue/Clue hidden/Clue interact");
            item_clue_1 = GameObjectFinder.Find("Murder Logic 3/ClueCollecting/Clues/Clue (1)/Clue hidden/Clue interact");
            item_clue_2 = GameObjectFinder.Find("Murder Logic 3/ClueCollecting/Clues/Clue (2)/Clue hidden/Clue interact");
            item_clue_3 = GameObjectFinder.Find("Murder Logic 3/ClueCollecting/Clues/Clue (3)/Clue hidden/Clue interact");
            item_knife_0 = GameObjectFinder.Find("Murder Logic 3/Weapons/Knife");
            item_knife_1 = GameObjectFinder.Find("Murder Logic 3/Weapons/Knife (1)");
            item_knife_2 = GameObjectFinder.Find("Murder Logic 3/Weapons/Knife (2)");
            item_knife_3 = GameObjectFinder.Find("Murder Logic 3/Weapons/Knife (3)");
            item_knife_4 = GameObjectFinder.Find("Murder Logic 3/Weapons/Knife (4)");
            item_knife_5 = GameObjectFinder.Find("Murder Logic 3/Weapons/Knife (5)");
            item_knife_6 = GameObjectFinder.Find("Murder Logic 3/Weapons/Knife (6)");
            item_knife_7 = GameObjectFinder.Find("Murder Logic 3/Weapons/Knife (7)");
            item_knife_8 = GameObjectFinder.Find("Murder Logic 3/Weapons/Knife (8)");
            Death = GameObjectFinder.Find("Murder Logic 3/Death");

            Clues.AddGameObject(item_clue_0);
            Clues.AddGameObject(item_clue_1);
            Clues.AddGameObject(item_clue_2);
            Clues.AddGameObject(item_clue_3);
            SilencedGuns.AddGameObject(item_SilencedGun);
            DetectiveGuns.AddGameObject(item_detectiveGun);
            item_clue_0.RegisterMurderItemEsp();
            item_clue_1.RegisterMurderItemEsp();
            item_clue_2.RegisterMurderItemEsp();
            item_clue_3.RegisterMurderItemEsp();
            item_SilencedGun.RegisterMurderItemEsp();
            item_detectiveGun.RegisterMurderItemEsp();
            Knifes.AddGameObject(item_knife_0);
            Knifes.AddGameObject(item_knife_1);
            Knifes.AddGameObject(item_knife_2);
            Knifes.AddGameObject(item_knife_3);
            Knifes.AddGameObject(item_knife_4);
            Knifes.AddGameObject(item_knife_5);
            Knifes.AddGameObject(item_knife_6);
            Knifes.AddGameObject(item_knife_7);
            Knifes.AddGameObject(item_knife_8);

            item_knife_0.RegisterMurderItemEsp();
            item_knife_1.RegisterMurderItemEsp();
            item_knife_2.RegisterMurderItemEsp();
            item_knife_3.RegisterMurderItemEsp();
            item_knife_4.RegisterMurderItemEsp();
            item_knife_5.RegisterMurderItemEsp();
            item_knife_6.RegisterMurderItemEsp();
            item_knife_7.RegisterMurderItemEsp();
            item_knife_8.RegisterMurderItemEsp();

            item_knife_0.RegisterCustomCollider(true);
            item_knife_1.RegisterCustomCollider(true);
            item_knife_2.RegisterCustomCollider(true);
            item_knife_3.RegisterCustomCollider(true);
            item_knife_4.RegisterCustomCollider(true);
            item_knife_5.RegisterCustomCollider(true);
            item_knife_6.RegisterCustomCollider(true);
            item_knife_7.RegisterCustomCollider(true);
            item_knife_8.RegisterCustomCollider(true);

            ModConsole.Log("Found Tot Clues : " + Clues.Count());
            ModConsole.Log("Found Tot Detective Guns : " + DetectiveGuns.Count());
            ModConsole.Log("Found Tot Silenced Guns  : " + SilencedGuns.Count());
            ModConsole.Log("Found Tot Knifes : " + Knifes.Count());

            if (Death != null)
            {
                ModConsole.Log("Found Death Gameobject, God Mode is available!", ConsoleColor.Green);
                GodModeMurder2.setActive(true);
            }
            else
            {
                ModConsole.Log("Death Gameobject is Unknown, God Mode is unavailable!", ConsoleColor.Red);
                if (GodModeMurder2 != null)
                {
                    GodModeMurder2.setActive(false);
                }
            }
        }

        public static void SetMurderItemsGravity(bool ShouldFloat)
        {
            Clues.SetGravity(ShouldFloat);
            DetectiveGuns.SetGravity(ShouldFloat);
            SilencedGuns.SetGravity(ShouldFloat);
            Knifes.SetGravity(ShouldFloat);
        }

        public static void AllowTheft()
        {
            Clues.SetPickupTheft(false);
            DetectiveGuns.SetPickupTheft(false);
            SilencedGuns.SetPickupTheft(false);
            Knifes.SetPickupTheft(false);
        }

        public static void MurderGunsRockets()
        {
            DetectiveGuns.AddRocketComponent(false);
            SilencedGuns.AddRocketComponent(false);
        }

        public static void MurderGunsCrazy()
        {
            DetectiveGuns.AddCrazyComponent(false);
            SilencedGuns.AddCrazyComponent(false);
        }

        public static void ToggleDeathComponent()
        {
            if (Death != null)
            {
                Death.SetActive(!Death.active);
                if (GodModeMurder2 != null)
                {
                    GodModeMurder2.setToggleState(Death.active);
                }
            }
        }

        public static void OnWorldReveal()
        {
            if (WorldUtils.GetWorldID() == "wrld_858dfdfc-1b28-2e1e-8a23-f0edc611e5fe")
            {
                if (MurderCheatsPage != null)
                {
                    ModConsole.Log("Recognized Murder 2's world, Unlocking Murder 2 cheats menu!", ConsoleColor.Green);
                    MurderCheatsPage.getMainButton().setIntractable(true);
                    MurderCheatsPage.getMainButton().setTextColor(Color.green);
                    CheatsShortcutButton.SetActive(true);
                    CheatsShortcutButton.SetButtonColor(Color.green);
                    CheatsShortcutButton.SetButtonShortcut(MurderCheatsPage);
                    CheatsShortcutButton.SetButtonText("Murder 2 Cheats", "Murder 2 Cheats");
                }
                FindGameMurderObjects();
            }
            else
            {
                if (MurderCheatsPage != null)
                {
                    MurderCheatsPage.getMainButton().setIntractable(false);
                    MurderCheatsPage.getMainButton().setTextColor(Color.red);
                    CheatsShortcutButton.SetActive(false);
                    CheatsShortcutButton.SetButtonColor(Color.red);
                    CheatsShortcutButton.ClearButtonAction();
                    CheatsShortcutButton.SetButtonText("Empty", "Empty");
                }
            }
        }

        public static void OnLevelLoad()
        {
            Death = null;
            item_detectiveGun = null;
            item_SilencedGun = null;
            item_clue_0 = null;
            item_clue_1 = null;
            item_clue_2 = null;
            item_clue_3 = null;
            item_knife_0 = null;
            item_knife_1 = null;
            item_knife_2 = null;
            item_knife_3 = null;
            item_knife_4 = null;
            item_knife_5 = null;
            item_knife_6 = null;
            item_knife_7 = null;
            item_knife_8 = null;
            Clues.Clear();
            DetectiveGuns.Clear();
            SilencedGuns.Clear();
            Knifes.Clear();
        }

        public static void Murder2CheatsButtons(QMNestedButton submenu, float BtnXLocation, float BtnYLocation, bool btnHalf)
        {
            MurderCheatsPage = new QMNestedButton(submenu, BtnXLocation, BtnYLocation, "Murder 2 Cheats", "Manage Murder 2 Cheats", null, null, null, null, btnHalf);
            MurderCheatsPage.getMainButton().SetResizeTextForBestFit(true);
            QMNestedButton MurderItemTeleporter = new QMNestedButton(MurderCheatsPage, 1, 0, "Item Teleporter", "Size Items Editor", null, null, null, null);
            new QMSingleButton(MurderItemTeleporter, 1, 0, "Teleport The Clues to Your Pos!", new Action(() => { Clues.TeleportToMe(); }), "Clue Teleporter!", null, null);
            new QMSingleButton(MurderItemTeleporter, 2, 0, "Teleport the Detective Gun!", new Action(() => { item_detectiveGun.TeleportToMe(); }), "Detective Gun Teleporter!", null, null);
            new QMSingleButton(MurderItemTeleporter, 3, 0, "Teleport the Silenced Gun!", new Action(() => { item_SilencedGun.TeleportToMe(); }), "Silenced gun Teleporter!", null, null);

            QMNestedButton MurderItemTweaker = new QMNestedButton(MurderCheatsPage, 2, 0, "Item Tweaker", "Item Tweaks!", null, null, null, null);
            new QMSingleButton(MurderItemTweaker, 1, 0, "Allow Gun Theft in Murder!", new Action(AllowTheft), "Allows you to steal items from other people!", null, null);
            new QMToggleButton(MurderItemTweaker, 2, 0, "Float (Space Mode)", new Action(() => { SetMurderItemsGravity(true); }), "Fall (World Gravity)", new Action(() => { SetMurderItemsGravity(false); }), "Tweaks all Murder! items gravity!", null, null, null, false);
            new QMSingleButton(MurderItemTweaker, 3, 0, "Turn Knifes into rockets!", new Action(() => { Knifes.AddRocketComponent(false); }), "Make Knifes in Instance go nuts!", null, null);
            new QMSingleButton(MurderItemTweaker, 4, 0, "Turn Guns into rockets!", new Action(() => { MurderGunsRockets(); }), "Make Guns in Instance go nuts!", null, null);
            new QMSingleButton(MurderItemTweaker, 1, 1, "Turn Clues into rockets!", new Action(() => { Clues.AddRocketComponent(false); }), "Make Clues in Instance go nuts!", null, null);
            new QMSingleButton(MurderItemTweaker, 2, 1, "Turn Knifes into Crazy!", new Action(() => { Knifes.AddCrazyComponent(false); }), "Make Knifes in Instance go nuts!", null, null);
            new QMSingleButton(MurderItemTweaker, 3, 1, "Turn Guns into Crazy!", new Action(MurderGunsCrazy), "Make Guns in Instance go nuts!", null, null);
            new QMSingleButton(MurderItemTweaker, 4, 1, "Turn Clues into Crazy!", new Action(() => { Clues.AddCrazyComponent(false); }), "Make Clues in Instance go nuts!", null, null);

            QMNestedButton MurderItemSpawner = new QMNestedButton(MurderCheatsPage, 3, 0, "Item Spawner", "Item Spawner!", null, null, null, null);
            new QMSingleButton(MurderItemSpawner, 1, 0, "Spawn Detective Gun", new Action(() => { item_detectiveGun.CloneObject(); }), "Detective Gun Cloner!", null, null);
            new QMSingleButton(MurderItemSpawner, 2, 0, "Spawn Silenced Gun", new Action(() => { item_SilencedGun.CloneObject(); }), "Silenced Gun Cloner!", null, null);
            new QMSingleButton(MurderItemSpawner, 3, 0, "Spawn Knife", new Action(() => { item_knife_0.CloneObject(); }), "Knife Cloner!", null, null);

            if (Bools.AllowAttackerComponent)
            {
                QMNestedButton MurderItemAttackerMenu = new QMNestedButton(MurderCheatsPage, 2, 0, "Followers", "Murder item Followers!", null, null, null, null);
                QMNestedButton Follow_target_section = new QMNestedButton(MurderItemAttackerMenu, 1, 0, "Follows Target", "Murder item Followers!", null, null, null, null);
                new QMSingleButton(Follow_target_section, 1, 0, "Detective Gun follows target!", new Action(() => { DetectiveGuns.AttackTarget(); }), "Make Detective Gun follow Target", null, null);
                new QMSingleButton(Follow_target_section, 2, 0, "Silenced Gun follows target!", new Action(() => { SilencedGuns.AttackTarget(); }), "Make Silenced Gun follow Target", null, null);
                new QMSingleButton(Follow_target_section, 3, 0, "Knifes follows target!", new Action(() => { Knifes.AttackTarget(); }), "Make Knifes follow Target", null, null);
                new QMSingleButton(Follow_target_section, 4, 0, "Clues follows target!", new Action(() => { Clues.AttackTarget(); }), "Make Clues follow Target", null, null);
                QMNestedButton Follow_self_section = new QMNestedButton(MurderItemAttackerMenu, 2, 0, "Follows You", "Murder item Followers!", null, null, null, null);
                new QMSingleButton(Follow_self_section, 1, 0, "Detective Gun follows you!", new Action(() => { DetectiveGuns.AttackSelf(); }), "Make Detective Gun follow you", null, null);
                new QMSingleButton(Follow_self_section, 2, 0, "Silenced Guns follows you!", new Action(() => { SilencedGuns.AttackSelf(); }), "Make Silenced Gun follow you", null, null);
                new QMSingleButton(Follow_self_section, 3, 0, "Knifes follows you!", new Action(() => { Knifes.AttackSelf(); }), "Make Knifes follow you", null, null);
                new QMSingleButton(Follow_self_section, 4, 0, "Clues follows you!", new Action(() => { Clues.AttackSelf(); }), "Make Clues follow you", null, null);
            }
            if (Bools.AllowOrbitComponent)
            {
                QMNestedButton MurderItemOrbiterMenu = new QMNestedButton(MurderCheatsPage, 1, 1, "orbiters", "Murder item Orbits!", null, null, null, null);
                QMNestedButton Orbit_target_section = new QMNestedButton(MurderItemOrbiterMenu, 1, 0, "Orbit Around Target", "Murder item Orbits!", null, null, null, null);
                new QMSingleButton(Orbit_target_section, 1, 0, "Detective Gun orbits around target!", new Action(() => { DetectiveGuns.OrbitTarget(); }), "Make Detective Gun orbit around Target", null, null);
                new QMSingleButton(Orbit_target_section, 2, 0, "Silenced Guns orbits around target!", new Action(() => { SilencedGuns.OrbitTarget(); }), "Make Silenced Gun around orbit Target", null, null);
                new QMSingleButton(Orbit_target_section, 3, 0, "Knifes orbits around target!", new Action(() => { Knifes.OrbitTarget(); }), "Make Knifes orbit around Target", null, null);
                new QMSingleButton(Orbit_target_section, 4, 0, "Clues orbits around target!", new Action(() => { Clues.OrbitTarget(); }), "Make Clues orbit around Target", null, null);
                QMNestedButton Orbit_self_section = new QMNestedButton(MurderItemOrbiterMenu, 2, 0, "Orbit Around You", "Murder item Orbits!", null, null, null, null);
                new QMSingleButton(Orbit_self_section, 1, 0, "Detective Gun orbits around you!", new Action(() => { DetectiveGuns.OrbitSelf(); }), "Make Detective Gun orbit around you", null, null);
                new QMSingleButton(Orbit_self_section, 2, 0, "Silenced Guns orbits around you!", new Action(() => { SilencedGuns.OrbitSelf(); }), "Make Silenced Gun around orbit you", null, null);
                new QMSingleButton(Orbit_self_section, 3, 0, "Knifes orbits around you!", new Action(() => { Knifes.OrbitSelf(); }), "Make Knifes orbit around you", null, null);
                new QMSingleButton(Orbit_self_section, 4, 0, "Clues orbits around you!", new Action(() => { Clues.OrbitSelf(); }), "Make Clues orbit around you", null, null);
            }
            QMNestedButton MurderItemWatcherMenu = new QMNestedButton(MurderCheatsPage, 3, 0, "Watchers", "Murder item Watchers!", null, null, null, null);
            QMNestedButton Watch_target_section = new QMNestedButton(MurderItemWatcherMenu, 1, 0, "Watchs Target", "Murder item Watchers!", null, null, null, null);
            new QMSingleButton(Watch_target_section, 1, 0, "Detective Gun Watchs target!", new Action(() => { DetectiveGuns.WatchTarget(); }), "Make Detective Gun Watch Target", null, null);
            new QMSingleButton(Watch_target_section, 2, 0, "Silenced Gun Watchs target!", new Action(() => { SilencedGuns.WatchTarget(); }), "Make Silenced Gun Watch Target", null, null);
            new QMSingleButton(Watch_target_section, 3, 0, "Knifes Watchs target!", new Action(() => { Knifes.WatchTarget(); }), "Make Knifes Watch Target", null, null);
            new QMSingleButton(Watch_target_section, 4, 0, "Clues Watchs target!", new Action(() => { Clues.WatchTarget(); }), "Make Clues Watch Target", null, null);
            QMNestedButton Watch_self_section = new QMNestedButton(MurderItemWatcherMenu, 2, 0, "Watchs You", "Murder item Watchers!", null, null, null, null);
            new QMSingleButton(Watch_self_section, 1, 0, "Detective Gun Watchs you!", new Action(() => { DetectiveGuns.WatchSelf(); }), "Make Detective Gun Watch you", null, null);
            new QMSingleButton(Watch_self_section, 2, 0, "Silenced Guns Watchs you!", new Action(() => { SilencedGuns.WatchSelf(); }), "Make Silenced Gun Watch you", null, null);
            new QMSingleButton(Watch_self_section, 3, 0, "Knifes Watchs you!", new Action(() => { Knifes.WatchSelf(); }), "Make Knifes Watch you", null, null);
            new QMSingleButton(Watch_self_section, 4, 0, "Clues Watchs you!", new Action(() => { Clues.WatchSelf(); }), "Make Clues Watch you", null, null);



            GodModeMurder2 = new QMToggleButton(MurderCheatsPage, 1, 2, "Normal Mode", new Action(ToggleDeathComponent), "God Mode", new Action(ToggleDeathComponent), "Tweaks all Murder! items gravity!", null, null, null, false);
            GameObjectESP.MurderESPtoggler = new QMToggleButton(MurderCheatsPage, 2, 2, "Item ESP On", new Action(GameObjectESP.AddESPToMurderProps), "Item ESP Off", new Action(GameObjectESP.RemoveESPToMurderProps), "Reveals All murder items position.", null, null, null, false);
        }

        // MAP GameObjects Required for control.
        public static List<GameObject> Clues = new List<GameObject>();

        public static List<GameObject> DetectiveGuns = new List<GameObject>();
        public static List<GameObject> SilencedGuns = new List<GameObject>();
        public static List<GameObject> Knifes = new List<GameObject>();
        public static GameObject Death = null;

        public static GameObject item_detectiveGun = null;
        public static GameObject item_SilencedGun = null;

        public static GameObject item_clue_0 = null;
        public static GameObject item_clue_1 = null;
        public static GameObject item_clue_2 = null;
        public static GameObject item_clue_3 = null;

        public static GameObject item_knife_0 = null;
        public static GameObject item_knife_1 = null;
        public static GameObject item_knife_2 = null;
        public static GameObject item_knife_3 = null;
        public static GameObject item_knife_4 = null;
        public static GameObject item_knife_5 = null;
        public static GameObject item_knife_6 = null;
        public static GameObject item_knife_7 = null;
        public static GameObject item_knife_8 = null;
        public static QMNestedButton MurderCheatsPage;
        public static QMToggleButton GodModeMurder2;
    }
}