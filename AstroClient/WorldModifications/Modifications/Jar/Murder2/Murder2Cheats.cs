namespace AstroClient.WorldModifications.Modifications.Jar.Murder2
{
    #region Imports

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ClientUI.Menu.ESP;
    using Constants;
    using Tools.Extensions;
    using Tools.Extensions.Components_exts;
    using UnityEngine;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;

    #endregion Imports

    internal class Murder2Cheats : AstroEvents
    {
        internal static void FindGameMurderObjects()
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

            Knifes.AddGameObject(item_knife_0);
            Knifes.AddGameObject(item_knife_1);
            Knifes.AddGameObject(item_knife_2);
            Knifes.AddGameObject(item_knife_3);
            Knifes.AddGameObject(item_knife_4);
            Knifes.AddGameObject(item_knife_5);
            Knifes.AddGameObject(item_knife_6);
            Knifes.AddGameObject(item_knife_7);
            Knifes.AddGameObject(item_knife_8);

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
                ModConsole.Log("Found Death Gameobject, God Mode is available!", System.Drawing.Color.Green);
                GodModeMurder2.QMButtonBase_SetActive(true);
            }
            else
            {
                ModConsole.Log("Death Gameobject is Unknown, God Mode is unavailable!", System.Drawing.Color.Red);
                if (GodModeMurder2 != null)
                {
                    GodModeMurder2.QMButtonBase_SetActive(false);
                }
            }
        }

        internal static void SetMurderItemsGravity(bool useGravity)
        {
            Clues.RigidBody_Set_Gravity(useGravity);
            DetectiveGuns.RigidBody_Set_Gravity(useGravity);
            SilencedGuns.RigidBody_Set_Gravity(useGravity);
            Knifes.RigidBody_Set_Gravity(useGravity);
        }

        internal static void AllowTheft()
        {
            Clues.Pickup_Set_DisallowTheft(false);
            DetectiveGuns.Pickup_Set_DisallowTheft(false);
            SilencedGuns.Pickup_Set_DisallowTheft(false);
            Knifes.Pickup_Set_DisallowTheft(false);
        }

        internal static void MurderGunsRockets()
        {
            DetectiveGuns.Add_Rocket_Component(false);
            SilencedGuns.Add_Rocket_Component(false);
        }

        internal static void MurderGunsCrazy()
        {
            DetectiveGuns.Add_Crazy_Component(false);
            SilencedGuns.Add_Crazy_Component(false);
        }

        internal static void ToggleDeathComponent()
        {
            if (Death != null)
            {
                Death.SetActive(!Death.active);
                if (GodModeMurder2 != null)
                {
                    GodModeMurder2.SetToggleState(Death.active);
                }
            }
        }

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.Murder2)
            {
                if (Murder2CheatPage != null)
                {
                    ModConsole.Log($"Recognized {Name} World, Unlocking Murder 2 cheats menu!", System.Drawing.Color.Green);
                    Murder2CheatPage.GetMainButton().SetIntractable(true);
                    Murder2CheatPage.GetMainButton().SetTextColor(Color.green);
                }
                FindGameMurderObjects();
            }
            else
            {
                if (Murder2CheatPage != null)
                {
                    Murder2CheatPage.GetMainButton().SetIntractable(false);
                    Murder2CheatPage.GetMainButton().SetTextColor(Color.red);
                }
            }
        }

        internal override void OnSceneLoaded(int buildIndex, string sceneName)
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
            if (Murder2ESPtoggler != null)
            {
                Murder2ESPtoggler.SetToggleState(false);
            }
        }

        internal static void ToggleItemESP(bool value)
        {
            VRChat_Map_ESP_Menu.Toggle_Pickup_ESP = value;
            if (value)
            {
                MiscUtils.DelayFunction(1, new Action(() =>
                {
                    Clues.Set_Pickup_ESP_Color("84F962");
                    DetectiveGuns.Set_Pickup_ESP_Color("62DBF9");
                    SilencedGuns.Set_Pickup_ESP_Color("D6F962");
                    Knifes.Set_Pickup_ESP_Color("F96262");
                }));
            }
        }

        internal static void Murder2CheatsButtons(QMGridTab submenu)
        {
            Murder2CheatPage = new QMNestedGridMenu(submenu, "Murder 2 Cheats", "Manage Murder 2 Cheats");

            QMNestedGridMenu MurderItemTeleporter = new QMNestedGridMenu(Murder2CheatPage, "Item Teleporter", "Item Teleporter");
            _ = new QMSingleButton(MurderItemTeleporter, "Teleport The Clues to Your Pos!", new Action(() => { Clues.TeleportToMe(); }), "Clue Teleporter!");
            _ = new QMSingleButton(MurderItemTeleporter, "Teleport the Detective Gun!", new Action(() => { item_detectiveGun.TeleportToMe(); }), "Detective Gun Teleporter!");
            _ = new QMSingleButton(MurderItemTeleporter, "Teleport the Silenced Gun!", new Action(() => { item_SilencedGun.TeleportToMe(); }), "Silenced gun Teleporter!");

            QMNestedGridMenu MurderItemTweaker = new QMNestedGridMenu(Murder2CheatPage, "Item Tweaker", "Item Tweaks!");
            _ = new QMSingleButton(MurderItemTweaker, 1, 0, "Allow Gun Theft in Murder!", new Action(AllowTheft), "Allows you to steal items from other people!");
            _ = new QMToggleButton(MurderItemTweaker, 2, 0, "Float (Space Mode)", new Action(() => { SetMurderItemsGravity(true); }), "Fall (World Gravity)", new Action(() => { SetMurderItemsGravity(false); }), "Tweaks all Murder! items gravity!");
            _ = new QMSingleButton(MurderItemTweaker, 3, 0, "Turn Knifes into rockets!", new Action(() => { Knifes.Add_Rocket_Component(false); }), "Make Knifes in Instance go nuts!");
            _ = new QMSingleButton(MurderItemTweaker, 4, 0, "Turn Guns into rockets!", new Action(() => { MurderGunsRockets(); }), "Make Guns in Instance go nuts!");
            _ = new QMSingleButton(MurderItemTweaker, 1, 1, "Turn Clues into rockets!", new Action(() => { Clues.Add_Rocket_Component(false); }), "Make Clues in Instance go nuts!");
            _ = new QMSingleButton(MurderItemTweaker, 2, 1, "Turn Knifes into Crazy!", new Action(() => { Knifes.Add_Crazy_Component(false); }), "Make Knifes in Instance go nuts!");
            _ = new QMSingleButton(MurderItemTweaker, 3, 1, "Turn Guns into Crazy!", new Action(MurderGunsCrazy), "Make Guns in Instance go nuts!");
            _ = new QMSingleButton(MurderItemTweaker, 4, 1, "Turn Clues into Crazy!", new Action(() => { Clues.Add_Crazy_Component(false); }), "Make Clues in Instance go nuts!");

            QMNestedGridMenu MurderItemSpawner = new QMNestedGridMenu(Murder2CheatPage, "Item Spawner", "Item Spawner!");
            _ = new QMSingleButton(MurderItemSpawner, 1, 0, "Spawn Detective Gun", new Action(() => { item_detectiveGun.CloneObject(); }), "Detective Gun Cloner!");
            _ = new QMSingleButton(MurderItemSpawner, 2, 0, "Spawn Silenced Gun", new Action(() => { item_SilencedGun.CloneObject(); }), "Silenced Gun Cloner!");
            _ = new QMSingleButton(MurderItemSpawner, 3, 0, "Spawn Knife", new Action(() => { item_knife_0.CloneObject(); }), "Knife Cloner!");

            if (Bools.AllowAttackerComponent)
            {
                QMNestedGridMenu MurderItemAttackerMenu = new QMNestedGridMenu(Murder2CheatPage, "Followers", "Murder item Followers!");
                _ = new QMSingleButton(MurderItemAttackerMenu, 1, 0, "Detective Gun follows target!", new Action(() => { DetectiveGuns.AttackTarget(); }), "Make Detective Gun follow Target");
                _ = new QMSingleButton(MurderItemAttackerMenu, 2, 0, "Silenced Gun follows target!", new Action(() => { SilencedGuns.AttackTarget(); }), "Make Silenced Gun follow Target");
                _ = new QMSingleButton(MurderItemAttackerMenu, 3, 0, "Knifes follows target!", new Action(() => { Knifes.AttackTarget(); }), "Make Knifes follow Target");
                _ = new QMSingleButton(MurderItemAttackerMenu, 4, 0, "Clues follows target!", new Action(() => { Clues.AttackTarget(); }), "Make Clues follow Target");
                _ = new QMSingleButton(MurderItemAttackerMenu, 1, 1, "Detective Gun follows you!", new Action(() => { DetectiveGuns.AttackSelf(); }), "Make Detective Gun follow you");
                _ = new QMSingleButton(MurderItemAttackerMenu, 2, 1, "Silenced Guns follows you!", new Action(() => { SilencedGuns.AttackSelf(); }), "Make Silenced Gun follow you");
                _ = new QMSingleButton(MurderItemAttackerMenu, 3, 1, "Knifes follows you!", new Action(() => { Knifes.AttackSelf(); }), "Make Knifes follow you");
                _ = new QMSingleButton(MurderItemAttackerMenu, 4, 1, "Clues follows you!", new Action(() => { Clues.AttackSelf(); }), "Make Clues follow you");
            }
            if (Bools.AllowOrbitComponent)
            {
                QMNestedGridMenu MurderItemOrbiterMenu = new QMNestedGridMenu(Murder2CheatPage, "orbiters", "Murder item Orbits!");
                _ = new QMSingleButton(MurderItemOrbiterMenu, 1, 0, "Detective Gun orbits around target!", new Action(() => { DetectiveGuns.OrbitTarget(); }), "Make Detective Gun orbit around Target");
                _ = new QMSingleButton(MurderItemOrbiterMenu, 2, 0, "Silenced Guns orbits around target!", new Action(() => { SilencedGuns.OrbitTarget(); }), "Make Silenced Gun around orbit Target");
                _ = new QMSingleButton(MurderItemOrbiterMenu, 3, 0, "Knifes orbits around target!", new Action(() => { Knifes.OrbitTarget(); }), "Make Knifes orbit around Target");
                _ = new QMSingleButton(MurderItemOrbiterMenu, 4, 0, "Clues orbits around target!", new Action(() => { Clues.OrbitTarget(); }), "Make Clues orbit around Target");
                _ = new QMSingleButton(MurderItemOrbiterMenu, 1, 1, "Detective Gun orbits around you!", new Action(() => { DetectiveGuns.OrbitSelf(); }), "Make Detective Gun orbit around you");
                _ = new QMSingleButton(MurderItemOrbiterMenu, 2, 1, "Silenced Guns orbits around you!", new Action(() => { SilencedGuns.OrbitSelf(); }), "Make Silenced Gun around orbit you");
                _ = new QMSingleButton(MurderItemOrbiterMenu, 3, 1, "Knifes orbits around you!", new Action(() => { Knifes.OrbitSelf(); }), "Make Knifes orbit around you");
                _ = new QMSingleButton(MurderItemOrbiterMenu, 4, 1, "Clues orbits around you!", new Action(() => { Clues.OrbitSelf(); }), "Make Clues orbit around you");
            }
            QMNestedGridMenu MurderItemWatcherMenu = new QMNestedGridMenu(Murder2CheatPage, "Watchers", "Murder item Watchers!");
            _ = new QMSingleButton(MurderItemWatcherMenu, 1, 0, "Detective Gun Watchs target!", new Action(() => { DetectiveGuns.WatchTarget(); }), "Make Detective Gun Watch Target");
            _ = new QMSingleButton(MurderItemWatcherMenu, 2, 0, "Silenced Gun Watchs target!", new Action(() => { SilencedGuns.WatchTarget(); }), "Make Silenced Gun Watch Target");
            _ = new QMSingleButton(MurderItemWatcherMenu, 3, 0, "Knifes Watchs target!", new Action(() => { Knifes.WatchTarget(); }), "Make Knifes Watch Target");
            _ = new QMSingleButton(MurderItemWatcherMenu, 4, 0, "Clues Watchs target!", new Action(() => { Clues.WatchTarget(); }), "Make Clues Watch Target");
            _ = new QMSingleButton(MurderItemWatcherMenu, 1, 1, "Detective Gun Watchs you!", new Action(() => { DetectiveGuns.WatchSelf(); }), "Make Detective Gun Watch you");
            _ = new QMSingleButton(MurderItemWatcherMenu, 2, 1, "Silenced Guns Watchs you!", new Action(() => { SilencedGuns.WatchSelf(); }), "Make Silenced Gun Watch you");
            _ = new QMSingleButton(MurderItemWatcherMenu, 3, 1, "Knifes Watchs you!", new Action(() => { Knifes.WatchSelf(); }), "Make Knifes Watch you");
            _ = new QMSingleButton(MurderItemWatcherMenu, 4, 1, "Clues Watchs you!", new Action(() => { Clues.WatchSelf(); }), "Make Clues Watch you");

            GodModeMurder2 = new QMToggleButton(Murder2CheatPage, "Normal Mode", new Action(ToggleDeathComponent), "God Mode", new Action(ToggleDeathComponent), "Tweaks all Murder! items gravity!");
            Murder2ESPtoggler = new QMToggleButton(Murder2CheatPage, "Item ESP On", new Action(() => { ToggleItemESP(true); }), "Item ESP Off", new Action(() => { ToggleItemESP(false); }), "Reveals All murder items position.");
        }

        // MAP GameObjects Required for control.
        internal static List<GameObject> Clues = new List<GameObject>();

        internal static List<GameObject> DetectiveGuns = new List<GameObject>();
        internal static List<GameObject> SilencedGuns = new List<GameObject>();
        internal static List<GameObject> Knifes = new List<GameObject>();
        internal static GameObject Death = null;

        internal static GameObject item_detectiveGun = null;
        internal static GameObject item_SilencedGun = null;

        internal static GameObject item_clue_0 = null;
        internal static GameObject item_clue_1 = null;
        internal static GameObject item_clue_2 = null;
        internal static GameObject item_clue_3 = null;

        internal static GameObject item_knife_0 = null;
        internal static GameObject item_knife_1 = null;
        internal static GameObject item_knife_2 = null;
        internal static GameObject item_knife_3 = null;
        internal static GameObject item_knife_4 = null;
        internal static GameObject item_knife_5 = null;
        internal static GameObject item_knife_6 = null;
        internal static GameObject item_knife_7 = null;
        internal static GameObject item_knife_8 = null;
        internal static QMNestedGridMenu Murder2CheatPage;
        internal static QMToggleButton GodModeMurder2;
        internal static QMToggleButton Murder2ESPtoggler;
    }
}