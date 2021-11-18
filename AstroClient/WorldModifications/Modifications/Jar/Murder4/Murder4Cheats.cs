namespace AstroClient.WorldModifications.Modifications.Jar.Murder4
{
    #region Imports

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AstroMonos.Components.Cheats.PatronUnlocker;
    using AstroMonos.Components.Cheats.Worlds.JarWorlds;
    using AstroMonos.Components.ESP.Pickup;
    using ClientUI.Menu.ESP;
    using Constants;
    using Tools.Extensions;
    using Tools.Extensions.Components_exts;
    using Tools.UdonEditor;
    using Tools.UdonSearcher;
    using UdonCheats;
    using UnityEngine;
    using VRC;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;
    using static Constants.CustomLists;

    #endregion Imports

    internal class Murder4Cheats : AstroEvents
    {
        internal static void FindGameMurderObjects()
        {
            ModConsole.Log("Removing Anti-Peek Protection...");

            var occlusion = GameObjectFinder.Find("Environment/Occlusion");
            if (occlusion != null)
            {
                occlusion.DestroyMeLocal();
            }
            //var patronCheckFool = UdonSearch.FindUdonEvent("Patreon Data", "_start"); //  Not working.
            //if (patronCheckFool != null)
            //{
            //    ModConsole.Log("Unlocking Patron Perks.");
            //    if (!PlayerSpooferUtils.SpoofAsWorldAuthor)
            //    {
            //        PlayerSpooferUtils.SpoofAsWorldAuthor = true;
            //        patronCheckFool.ExecuteUdonEvent();
            //        PlayerSpooferUtils.SpoofAsWorldAuthor = false;
            //    }
            //    else
            //    {
            //        patronCheckFool.ExecuteUdonEvent();
            //    }
            //}

            item_DetectiveRevolver = GameObjectFinder.Find("Game Logic/Weapons/Revolver");
            if (item_DetectiveRevolver != null)
            {
                DetectiveGunPerkUnlocker = item_DetectiveRevolver.GetOrAddComponent<PatronUnlocker>();
            }
            Clue_photograph = GameObjectFinder.Find("Game Logic/Clues/Clue (photograph)");
            Clue_notebook = GameObjectFinder.Find("Game Logic/Clues/Clue (notebook)");
            Clue_Locket = GameObjectFinder.Find("Game Logic/Clues/Clue (locket)");
            Clue_PocketWatch = GameObjectFinder.Find("Game Logic/Clues/Clue (pocketwatch)");
            Clue_Postcard = GameObjectFinder.Find("Game Logic/Clues/Clue (postcard)");
            if (!IsChristmasMode)
            {
                Clue_Present = GameObjectFinder.Find("Game Logic/Clues (xmas)/Clue (present) (5)");
                if (Clue_Present != null)
                {
                    IsChristmasMode = true;
                }
                else
                {
                    ModConsole.Log("Could Not Find The Present Clue!");
                }
            }
            item_Knife_0 = GameObjectFinder.Find("Game Logic/Weapons/Knife (0)");
            item_Knife_1 = GameObjectFinder.Find("Game Logic/Weapons/Knife (1)");
            item_Knife_2 = GameObjectFinder.Find("Game Logic/Weapons/Knife (2)");
            item_Knife_3 = GameObjectFinder.Find("Game Logic/Weapons/Knife (3)");
            item_Knife_4 = GameObjectFinder.Find("Game Logic/Weapons/Knife (4)");
            item_Knife_5 = GameObjectFinder.Find("Game Logic/Weapons/Knife (5)");
            item_Bear_trap_0 = GameObjectFinder.Find("Game Logic/Weapons/Bear Trap (0)");
            item_Bear_trap_1 = GameObjectFinder.Find("Game Logic/Weapons/Bear Trap (1)");
            item_Bear_trap_2 = GameObjectFinder.Find("Game Logic/Weapons/Bear Trap (2)");
            item_Shotgun = GameObjectFinder.Find("Game Logic/Weapons/Unlockables/Shotgun (0)");
            item_Silenced_Revolver_0 = GameObjectFinder.Find("Game Logic/Weapons/Unlockables/Luger (0)");
            item_Silenced_Revolver_1 = GameObjectFinder.Find("Game Logic/Weapons/Unlockables/Luger (1)");
            item_Grenade = GameObjectFinder.Find("Game Logic/Weapons/Unlockables/Frag (0)");
            Snake_Crate = GameObjectFinder.Find("/Game Logic/Snakes/SnakeDispenser");
            foreach (var action in UdonParser.WorldBehaviours)
            {
                if (action.gameObject.name == "Game Logic")
                {
                    foreach (var subaction in action._eventTable)
                    {
                        if (subaction.key == "SyncStart")
                        {
                            StartGameEvent = new UdonBehaviour_Cached(action, subaction.key);
                            ModConsole.Log("Found Start Game Event.");
                        }
                        if (subaction.key == "SyncAbort")
                        {
                            AbortGameEvent = new UdonBehaviour_Cached(action, subaction.key);
                            ModConsole.Log("Found Abort Game Event.");
                        }
                        if (subaction.key == "SyncVictoryB")
                        {
                            VictoryBystanderEvent = new UdonBehaviour_Cached(action, subaction.key);
                            ModConsole.Log("Found Victory Bystander Event.");
                        }
                        if (subaction.key == "SyncVictoryM")
                        {
                            VictoryMurdererEvent = new UdonBehaviour_Cached(action, subaction.key);
                            ModConsole.Log("Found Victory Murderer Event.");
                        }
                        if (subaction.key == "OnPlayerUnlockedClues")
                        {
                            OnPlayerUnlockedClues = new UdonBehaviour_Cached(action, subaction.key);
                            ModConsole.Log("Found Unlocked Clues Sound.");
                        }
                        if (StartGameEvent != null && AbortGameEvent != null && VictoryBystanderEvent != null && VictoryMurdererEvent != null && OnPlayerUnlockedClues != null)
                        {
                            ModConsole.DebugLog("Finished Finding all Udon Events!");
                            break;
                        }
                    }
                }
            }

            if (GameStartbtn != null)
            {
                GameStartbtn.SetActive(StartGameEvent.IsNotNull());
                GameStartbtn.SetIntractable(StartGameEvent.IsNotNull());
            }
            if (GameAbortbtn != null)
            {
                GameAbortbtn.SetActive(AbortGameEvent.IsNotNull());
                GameAbortbtn.SetIntractable(AbortGameEvent.IsNotNull());
            }
            if (GameVictoryBystanderBtn != null)
            {
                GameVictoryBystanderBtn.SetActive(VictoryBystanderEvent.IsNotNull());
                GameVictoryBystanderBtn.SetIntractable(VictoryBystanderEvent.IsNotNull());
            }
            if (GameVictoryMurdererBtn != null)
            {
                GameVictoryMurdererBtn.SetActive(VictoryMurdererEvent.IsNotNull());
                GameVictoryMurdererBtn.SetIntractable(VictoryMurdererEvent.IsNotNull());
            }

            item_Grenade.RenameObject("Grenade");
            item_Silenced_Revolver_0.RenameObject("Silenced Revolver");
            item_Silenced_Revolver_1.RenameObject("Silenced Revolver 1");

            Clues.AddGameObject(Clue_photograph);
            Clues.AddGameObject(Clue_notebook);
            Clues.AddGameObject(Clue_Locket);
            Clues.AddGameObject(Clue_PocketWatch);
            Clues.AddGameObject(Clue_Postcard);
            if (Clue_Present != null)
            {
                Clues.AddGameObject(Clue_Present);
                Clues.RegisterChildsInPath("Game Logic/Clues (xmas)");
            }
            Clues.RegisterChildsInPath("Game Logic/Clues");

            var weapons = GameObjectFinder.ListFind("Game Logic/Weapons");

            DetectiveGuns.AddGameObject(item_DetectiveRevolver);
            SilencedGuns.AddGameObject(item_Silenced_Revolver_0);
            SilencedGuns.AddGameObject(item_Silenced_Revolver_1);
            Knifes.AddGameObject(item_Knife_0);
            Knifes.AddGameObject(item_Knife_1);
            Knifes.AddGameObject(item_Knife_2);
            Knifes.AddGameObject(item_Knife_3);
            Knifes.AddGameObject(item_Knife_4);
            Knifes.AddGameObject(item_Knife_5);
            ShotGuns.AddGameObject(item_Shotgun);
            BearTraps.AddGameObject(item_Bear_trap_0);
            BearTraps.AddGameObject(item_Bear_trap_1);
            BearTraps.AddGameObject(item_Bear_trap_2);
            Grenades.AddGameObject(item_Grenade);

            Clues.AddToWorldUtilsMenu();

            ModConsole.Log("Found Tot Clues : " + Clues.Count());
            ModConsole.Log("Found Tot Detective Guns : " + DetectiveGuns.Count());
            ModConsole.Log("Found Tot Silenced Guns  : " + SilencedGuns.Count());
            ModConsole.Log("Found Tot ShotGuns : " + ShotGuns.Count());
            ModConsole.Log("Found Tot Bear Traps : " + BearTraps.Count());
            ModConsole.Log("Found Tot Grenades : " + Grenades.Count());
            ModConsole.Log("Found Tot Knifes : " + Knifes.Count());
        }

        internal static void AllowTheft()
        {
            DetectiveGuns.Pickup_Set_DisallowTheft(false);
            SilencedGuns.Pickup_Set_DisallowTheft(false);
            ShotGuns.Pickup_Set_DisallowTheft(false);
            BearTraps.Pickup_Set_DisallowTheft(false);
            Grenades.Pickup_Set_DisallowTheft(false);
            Knifes.Pickup_Set_DisallowTheft(false);
        }

        internal static void MurderGunsRockets()
        {
            DetectiveGuns.Add_Rocket_Component(false);
            SilencedGuns.Add_Rocket_Component(false);
            ShotGuns.Add_Rocket_Component(false);
        }

        internal static void MurderGunsBounce()
        {
            DetectiveGuns.Add_Bouncer(false);
            SilencedGuns.Add_Bouncer(false);
            ShotGuns.Add_Bouncer(false);
        }

        internal static void RemoveRockets()
        {
            DetectiveGuns.Remove_RocketObject_Component();
            SilencedGuns.Remove_RocketObject_Component();
            ShotGuns.Remove_RocketObject_Component();
            BearTraps.Remove_RocketObject_Component();
            Grenades.Remove_RocketObject_Component();
            Knifes.Remove_RocketObject_Component();
        }

        internal static void RemoveCrazy()
        {
            DetectiveGuns.Remove_CrazyObject_Component();
            SilencedGuns.Remove_CrazyObject_Component();
            ShotGuns.Remove_CrazyObject_Component();
            BearTraps.Remove_CrazyObject_Component();
            Grenades.Remove_CrazyObject_Component();
            Knifes.Remove_CrazyObject_Component();
        }

        internal static void RemoveBouncers()
        {
            DetectiveGuns.Remove_Bouncer();
            SilencedGuns.Remove_Bouncer();
            ShotGuns.Remove_Bouncer();
            BearTraps.Remove_Bouncer();
            Grenades.Remove_Bouncer();
            Knifes.Remove_Bouncer();
        }

        internal static void MurderGunsCrazy()
        {
            DetectiveGuns.Add_Crazy_Component(false);
            SilencedGuns.Add_Crazy_Component(false);
            ShotGuns.Add_Crazy_Component(false);
        }

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.Murder4)
            {
                HasMurder4WorldLoaded = true;
                if (Murder4CheatPage != null)
                {
                    ModConsole.Log($"Recognized {Name} World, Unlocking Murder 4 cheats menu!", System.Drawing.Color.Green);
                    Murder4CheatPage.GetMainButton().SetIntractable(true);
                    Murder4CheatPage.GetMainButton().SetTextColor(Color.green);
                }
                FindGameMurderObjects();
            }
            else
            {
                HasMurder4WorldLoaded = false;
                if (Murder4CheatPage != null)
                {
                    Murder4CheatPage.GetMainButton().SetIntractable(false);
                    Murder4CheatPage.GetMainButton().SetTextColor(Color.red);
                }
            }
        }

        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            if (KnifesGrabbableToggle != null)
            {
                KnifesGrabbableToggle.SetToggleState(false);
            }
            item_Knife_0 = null;
            item_Knife_1 = null;
            item_Knife_2 = null;
            item_Knife_3 = null;
            item_Knife_4 = null;
            item_Knife_5 = null;
            item_Bear_trap_0 = null;
            item_Bear_trap_1 = null;
            item_Bear_trap_2 = null;
            item_Shotgun = null;
            item_Silenced_Revolver_0 = null;
            item_Silenced_Revolver_1 = null;
            item_Grenade = null;
            Clue_photograph = null;
            Clue_notebook = null;
            Clue_Locket = null;
            Clue_PocketWatch = null;
            Clue_Postcard = null;
            item_DetectiveRevolver = null;
            Clue_Present = null;
            StartGameEvent = null;
            AbortGameEvent = null;
            VictoryBystanderEvent = null;
            VictoryMurdererEvent = null;
            Clues.Clear();
            DetectiveGuns.Clear();
            SilencedGuns.Clear();
            ShotGuns.Clear();
            Knifes.Clear();
            BearTraps.Clear();
            Grenades.Clear();
            PatreonFlairtoggle = null;
            IsChristmasMode = false;
            DoUnlockedSound = false;
            OnPlayerUnlockedClues = null;
            AssignedSelfRole = string.Empty;
            AssignedTargetRole = string.Empty;
            TargetNode = null;
            SafetySwap = false;
            RoleSwapper_GetDetectiveRole = false;
            RoleSwapper_GetMurdererRole = false;
            EveryoneHasPatreonPerk = false;
            OnlySelfHasPatreonPerk = false;
            Snake_Crate = null;
            if (Murder4ESPtoggler != null)
            {
                Murder4ESPtoggler.SetToggleState(false);
            }
            UseGravity = true;
        }

        private static bool _UseGravity;

        internal static bool UseGravity
        {
            get
            {
                return _UseGravity;
            }
            set
            {
                DetectiveGuns.RigidBody_Set_Gravity(value);
                SilencedGuns.RigidBody_Set_Gravity(value);
                ShotGuns.RigidBody_Set_Gravity(value);
                BearTraps.RigidBody_Set_Gravity(value);
                Grenades.RigidBody_Set_Gravity(value);
                Knifes.RigidBody_Set_Gravity(value);
                if (ToggleGravityMode != null)
                {
                    ToggleGravityMode.SetToggleState(value);
                }
                _UseGravity = value;
            }
        }

        internal static void ToggleItemESP(bool value)
        {
            VRChat_Map_ESP_Menu.Toggle_Pickup_ESP = value; // ESSENTIAL

            if (value)
            {
                foreach (var item in Clues)
                {
                    var esp = item.GetOrAddComponent<ESP_Pickup>();
                }

                Snake_Crate.GetOrAddComponent<ESP_Pickup>();

                MiscUtils.DelayFunction(1, new Action(() =>
                {
                    Clues.Set_Pickup_ESP_Color("87F368");
                    DetectiveGuns.Set_Pickup_ESP_Color("688CF3");
                    SilencedGuns.Set_Pickup_ESP_Color("C8F36D");
                    ShotGuns.Set_Pickup_ESP_Color("C8F36D");
                    Knifes.Set_Pickup_ESP_Color("F96262");
                    BearTraps.Set_Pickup_ESP_Color("F96262");
                    Grenades.Set_Pickup_ESP_Color("F96262");
                    Snake_Crate.Set_Pickup_ESP_Color("F96262");
                }));
            }
            else
            {
                foreach (var item in Clues)
                {
                    var esp = item.GetComponent<ESP_Pickup>();
                    if (esp != null)
                    {
                        esp.DestroyMeLocal();
                    }
                }
                var Snake_Crate_ESP = Snake_Crate.GetComponent<ESP_Pickup>();
                if (Snake_Crate_ESP != null)
                {
                    Snake_Crate_ESP.DestroyMeLocal();
                }
            }
        }

        internal static void Murder4CheatsButtons(QMGridTab submenu)
        {
            Murder4CheatPage = new QMNestedGridMenu(submenu, "Murder 4 Cheats", "Manage Murder 4 Cheats");
            Murder4CheatPage.GetMainButton();

            QMNestedGridMenu MurderItemTeleporter = new QMNestedGridMenu(Murder4CheatPage,  "Item Teleporter", "Size Items Editor");

            #region Item Teleporter

            DoUnlockedSoundbtn = new QMToggleButton(MurderItemTeleporter, 0, 0, "Do Sound", new Action(() => { DoUnlockedSound = true; }), "Quiet Mode", new Action(() => { DoUnlockedSound = false; }), "Should i run the Sound action on pickups teleport.");
            _ = new QMSingleButton(MurderItemTeleporter, "Clues!", new Action(() => { Clues.TeleportToMe(); }), "Clue Teleporter!");
            _ = new QMSingleButton(MurderItemTeleporter, "Photograph!", new Action(() => { Clue_photograph.TeleportToMe(); }), "Clue Teleporter!");
            _ = new QMSingleButton(MurderItemTeleporter, "Notebook!", new Action(() => { Clue_notebook.TeleportToMe(); }), "Clue Teleporter!");
            _ = new QMSingleButton(MurderItemTeleporter, "Locket!", new Action(() => { Clue_Locket.TeleportToMe(); }), "Clue Teleporter!");
            _ = new QMSingleButton(MurderItemTeleporter, "PocketWatch!", new Action(() => { Clue_PocketWatch.TeleportToMe(); }), "Clue Teleporter!");
            _ = new QMSingleButton(MurderItemTeleporter, "Postcard!", new Action(() => { Clue_Postcard.TeleportToMe(); }), "Clue Teleporter!");
            _ = new QMSingleButton(MurderItemTeleporter, "Shotgun!", new Action(() => { item_Shotgun.TeleportToMe(); if (DoUnlockedSound) { OnPlayerUnlockedClues.ExecuteUdonEvent(); } }), "Shotgun Gun Teleporter!");
            _ = new QMSingleButton(MurderItemTeleporter, "Detective Gun!", new Action(() => { item_DetectiveRevolver.TeleportToMe(); if (DoUnlockedSound) { OnPlayerUnlockedClues.ExecuteUdonEvent(); } }), "Detective Gun Teleporter!");
            _ = new QMSingleButton(MurderItemTeleporter, "Silenced Gun 1!", new Action(() => { item_Silenced_Revolver_0.TeleportToMe(); if (DoUnlockedSound) { OnPlayerUnlockedClues.ExecuteUdonEvent(); } }), "Silenced Gun Teleporter!");
            _ = new QMSingleButton(MurderItemTeleporter, "Silenced Gun 2!", new Action(() => { item_Silenced_Revolver_1.TeleportToMe(); if (DoUnlockedSound) { OnPlayerUnlockedClues.ExecuteUdonEvent(); } }), "Silenced Gun Teleporter!");
            _ = new QMSingleButton(MurderItemTeleporter, "Grenade!", new Action(() => { item_Grenade.TeleportToMe(); if (DoUnlockedSound) { OnPlayerUnlockedClues.ExecuteUdonEvent(); } }), "Grenade Teleporter!");
            _ = new QMSingleButton(MurderItemTeleporter, "Traps!", new Action(() => { BearTraps.TeleportToMe(); if (DoUnlockedSound) { OnPlayerUnlockedClues.ExecuteUdonEvent(); } }), "Silenced Gun Teleporter!");
            PresentTeleporter = new QMSingleButton(MurderItemTeleporter, 1, 2, "Present!", new Action(() => { Clue_Present.TeleportToMe(); }), "Clue Teleporter!");

            #endregion Item Teleporter

            QMNestedGridMenu MurderItemTweaker = new QMNestedGridMenu(Murder4CheatPage, 1, 0f, "Item Tweaker", "Item Tweaks!");

            #region Item Tweaker

            new QMSingleButton(MurderItemTweaker,"Knifes (Bouncer)!", new Action(() => { Knifes.Add_Bouncer(false); }), "Bouncer!");
            new QMSingleButton(MurderItemTweaker, "Guns (Bouncer)!", new Action(() => { MurderGunsBounce(); }), "Bouncer!");
            new QMSingleButton(MurderItemTweaker,"Grenades (Bouncer)!", new Action(() => { Grenades.Add_Bouncer(false); }), "Bouncer!");
            new QMSingleButton(MurderItemTweaker, "Bear Trap (Bouncer)!", new Action(() => { BearTraps.Add_Bouncer(false); }), "Bouncer!");
            new QMSingleButton(MurderItemTweaker,"Clues (Bouncer)!", new Action(() => { Clues.Add_Bouncer(false); }), "Bouncer");
            new QMSingleButton(MurderItemTweaker, "Kill Bouncer Effects!", new Action(() => { RemoveBouncers(); }), "Remove Bouncing effect to all items");

            new QMSingleButton(MurderItemTweaker,"Knifes (Rockets)!", new Action(() => { Knifes.Add_Rocket_Component(false); }), "Rockets!");
            new QMSingleButton(MurderItemTweaker, "Guns (Rockets)!", new Action(() => { MurderGunsRockets(); }), "Rockets!");
            new QMSingleButton(MurderItemTweaker,"Grenades (Rockets)!", new Action(() => { Grenades.Add_Rocket_Component(false); }), "Rockets!");
            new QMSingleButton(MurderItemTweaker, "Bear Trap (Rockets)!", new Action(() => { BearTraps.Add_Rocket_Component(false); }), "Rockets!");
            new QMSingleButton(MurderItemTweaker,"Clues (Rockets)!", new Action(() => { Clues.Add_Rocket_Component(false); }), "Rockets");
            new QMSingleButton(MurderItemTweaker, "Kill Rocket Effects!", new Action(() => { RemoveRockets(); }), "Remove Rocket effect to all items");

            new QMSingleButton(MurderItemTweaker,"Knifes (Crazy)!", new Action(() => { Knifes.Add_Crazy_Component(false); }), "Make Knifes in Instance go nuts!");
            new QMSingleButton(MurderItemTweaker, "Guns (Crazy)!", new Action(MurderGunsCrazy), "Make Guns in Instance go nuts!");
            new QMSingleButton(MurderItemTweaker,"Clues (Crazy)!", new Action(() => { Clues.Add_Crazy_Component(false); }), "Make Clues in Instance go nuts!");
            new QMSingleButton(MurderItemTweaker, "Grenade (Crazy)!", new Action(() => { Grenades.Add_Crazy_Component(false); }), "Make Grenade in Instance go nuts!");
            new QMSingleButton(MurderItemTweaker,"Bear Trap (Crazy)!", new Action(() => { BearTraps.Add_Crazy_Component(false); }), "Make Grenade in Instance go nuts!");
            new QMSingleButton(MurderItemTweaker, "Kill Crazy Effects!", new Action(() => { RemoveCrazy(); }), "Remove Crazy effect to all items");

            _ = new QMSingleButton(MurderItemTweaker, "Allow Gun Theft in Murder!", new Action(AllowTheft), "Allows you to steal items from other people!");
            ToggleGravityMode = new QMToggleButton(MurderItemTweaker,"Fall (World Gravity)", new Action(() => { UseGravity = true; }), "Float (Space Mode)", new Action(() => { UseGravity = false; }), "Tweaks all Murder! items gravity!");

            KnifesGrabbableToggle = new QMToggleButton(MurderItemTweaker,  "Can Grab Knifes", new Action(() => { ToggleKnifesGrab(true); }), "Cannot Grab Knifes", new Action(() => { ToggleKnifesGrab(false); }), "Tweaks all Murder! items gravity!");
            new QMSingleButton(MurderItemTweaker,  "Knifes Grabbable from far!", new Action(() => { MakeKnifeGrabbableFromFar(); }), "Make Knifes Grabbable from far!"); ;
            new QMSingleButton(MurderItemTweaker,  "Restore Knifes Properties to world!", new Action(() => { RestoreKnifeToWorldControl(); }), "Restore Control to world!"); ;

            #endregion Item Tweaker

            QMNestedGridMenu MurderItemSpawner = new QMNestedGridMenu(Murder4CheatPage, 1, 1f, "Item Spawner", "Item Spawner!");

            #region Item Spawner

            _ = new QMSingleButton(MurderItemSpawner, "Spawn Detective Gun", new Action(() => { item_DetectiveRevolver.CloneObject(); }), "Detective Gun Cloner!");
            _ = new QMSingleButton(MurderItemSpawner,  "Spawn Silenced Gun", new Action(() => { item_Silenced_Revolver_0.CloneObject(); }), "Silenced Gun Cloner!");
            _ = new QMSingleButton(MurderItemSpawner, "Spawn Shotgun", new Action(() => { item_Shotgun.CloneObject(); }), "Shotgun Cloner!");
            _ = new QMSingleButton(MurderItemSpawner,  "Spawn Knife", new Action(() => { item_Knife_0.CloneObject(); }), "Knife Cloner!");
            _ = new QMSingleButton(MurderItemSpawner, "Spawn Grenade", new Action(() => { item_Grenade.CloneObject(); }), "Grenade Cloner!");
            _ = new QMSingleButton(MurderItemSpawner,  "Spawn Bear Trap", new Action(() => { item_Bear_trap_1.CloneObject(); }), "Bear Trap Cloner!");
            _ = new QMSingleButton(MurderItemSpawner, "Spawn photograph!", new Action(() => { Clue_photograph.CloneObject(); }), "Clue Cloner!");
            _ = new QMSingleButton(MurderItemSpawner,  "Spawn notebook!", new Action(() => { Clue_notebook.CloneObject(); }), "Clue Cloner!");
            _ = new QMSingleButton(MurderItemSpawner, "Spawn Locket!", new Action(() => { Clue_Locket.CloneObject(); }), "Clue Cloner!");
            _ = new QMSingleButton(MurderItemSpawner,  "Spawn PocketWatch!", new Action(() => { Clue_PocketWatch.CloneObject(); }), "Clue Cloner!");
            _ = new QMSingleButton(MurderItemSpawner, "Spawn Postcard!", new Action(() => { Clue_Postcard.CloneObject(); }), "Clue Cloner!");
            PresentSpawner = new QMSingleButton(MurderItemSpawner, "Spawn Present!", new Action(() => { Clue_Present.CloneObject(); }), "Clue Teleporter!");

            #endregion Item Spawner

            if (Bools.AllowAttackerComponent)
            {
                QMNestedGridMenu MurderItemAttackerMenu = new QMNestedGridMenu(Murder4CheatPage, 1, 1f, "Followers", "Murder item Followers!");

                #region Followers

                new QMSingleButton(MurderItemAttackerMenu, "Detective Gun (target)!", new Action(() => { DetectiveGuns.AttackTarget(); }), "Make Detective Gun follow Target");
                new QMSingleButton(MurderItemAttackerMenu, "Silenced Guns (target)!", new Action(() => { SilencedGuns.AttackTarget(); }), "Make Silenced Gun follow Target");
                new QMSingleButton(MurderItemAttackerMenu, "Knifes (target)!", new Action(() => { Knifes.AttackTarget(); }), "Make Knifes follow Target");
                new QMSingleButton(MurderItemAttackerMenu, "Clues (target)!", new Action(() => { Clues.AttackTarget(); }), "Make Clues follow Target");
                new QMSingleButton(MurderItemAttackerMenu,  "Grenade (target)!", new Action(() => { Grenades.AttackTarget(); }), "Make Grenade follow Target");
                new QMSingleButton(MurderItemAttackerMenu,  "Shotgun (target)!", new Action(() => { ShotGuns.AttackTarget(); }), "Make Bear Traps follow Target");
                new QMSingleButton(MurderItemAttackerMenu,  "Bear traps (target)!", new Action(() => { BearTraps.AttackTarget(); }), "Make Bear Traps follow Target");

                new QMSingleButton(MurderItemAttackerMenu,  "Detective Gun (you)!", new Action(() => { DetectiveGuns.AttackSelf(); }), "Make Detective Gun follow you");
                new QMSingleButton(MurderItemAttackerMenu,  "Silenced Guns (you)!", new Action(() => { SilencedGuns.AttackSelf(); }), "Make Silenced Gun follow you");
                new QMSingleButton(MurderItemAttackerMenu,  "Knifes (you)!", new Action(() => { Knifes.AttackSelf(); }), "Make Knifes follow you");
                new QMSingleButton(MurderItemAttackerMenu,  "Clues (you)!", new Action(() => { Clues.AttackSelf(); }), "Make Clues follow you");
                new QMSingleButton(MurderItemAttackerMenu, "Grenade (you)!", new Action(() => { Grenades.AttackSelf(); }), "Make Grenade follow you");
                new QMSingleButton(MurderItemAttackerMenu, "Shotgun (you)!", new Action(() => { ShotGuns.AttackSelf(); }), "Make Shotgun follow you");
                new QMSingleButton(MurderItemAttackerMenu, "Bear traps (you)!", new Action(() => { BearTraps.AttackSelf(); }), "Make Bear Traps follow you");

                #endregion Followers
            }
            if (Bools.AllowOrbitComponent)
            {
                QMNestedGridMenu MurderItemOrbiterMenu = new QMNestedGridMenu(Murder4CheatPage, 1, 2, "Orbiters", "Murder item Orbits!");

                #region orbiters

                new QMSingleButton(MurderItemOrbiterMenu, "Detective Gun (target)!", new Action(() => { DetectiveGuns.OrbitTarget(); }), "Make Detective Gun orbit around Target");
                new QMSingleButton(MurderItemOrbiterMenu, "Silenced Guns (target)!", new Action(() => { SilencedGuns.OrbitTarget(); }), "Make Silenced Gun around orbit Target");
                new QMSingleButton(MurderItemOrbiterMenu, "Shotgun (target)!", new Action(() => { ShotGuns.OrbitTarget(); }), "Make ShotGun orbit around Target");
                new QMSingleButton(MurderItemOrbiterMenu, "Knifes (target)!", new Action(() => { Knifes.OrbitTarget(); }), "Make Knifes orbit around Target");
                new QMSingleButton(MurderItemOrbiterMenu,  "Clues (target)!", new Action(() => { Clues.OrbitTarget(); }), "Make Clues orbit around Target");
                new QMSingleButton(MurderItemOrbiterMenu,  "Grenade (target)!", new Action(() => { Grenades.OrbitTarget(); }), "Make Grenade orbit around Target");
                new QMSingleButton(MurderItemOrbiterMenu,  "Bear Trap (target)!", new Action(() => { BearTraps.OrbitTarget(); }), "Make Bear Traps orbit around Target");

                new QMSingleButton(MurderItemOrbiterMenu,  "Detective Gun (you)!", new Action(() => { DetectiveGuns.OrbitSelf(); }), "Make Detective Gun orbit around you");
                new QMSingleButton(MurderItemOrbiterMenu,  "Silenced Guns (you)!", new Action(() => { SilencedGuns.OrbitSelf(); }), "Make Silenced Gun around orbit you");
                new QMSingleButton(MurderItemOrbiterMenu,  "Shotgun (you)!", new Action(() => { ShotGuns.OrbitSelf(); }), "Make ShotGun orbit around you");
                new QMSingleButton(MurderItemOrbiterMenu,  "Knifes (you)!", new Action(() => { Knifes.OrbitSelf(); }), "Make Knifes orbit around you");
                new QMSingleButton(MurderItemOrbiterMenu, "Clues (you)!", new Action(() => { Clues.OrbitSelf(); }), "Make Clues orbit around you");
                new QMSingleButton(MurderItemOrbiterMenu, "Grenade (you)!", new Action(() => { Grenades.OrbitSelf(); }), "Make Grenade orbit around you");
                new QMSingleButton(MurderItemOrbiterMenu, "Bear Trap (you)!", new Action(() => { BearTraps.OrbitSelf(); }), "Make Bear Traps orbit around you");

                #endregion orbiters
            }

            QMNestedGridMenu MurderItemClicker = new QMNestedGridMenu(Murder4CheatPage,  "Items Clicker", "Interact with Items!");

            #region Items Clicker

            _ = new QMSingleButton(MurderItemClicker, "Click photograph!", new Action(() => { Clue_photograph.VRC_Interactable_Click(); }), "Click!");
            _ = new QMSingleButton(MurderItemClicker,  "Click notebook!", new Action(() => { Clue_notebook.VRC_Interactable_Click(); }), "Click!");
            _ = new QMSingleButton(MurderItemClicker, "Click Locket!", new Action(() => { Clue_Locket.VRC_Interactable_Click(); }), "Click!");
            _ = new QMSingleButton(MurderItemClicker,  "Click PocketWatch!", new Action(() => { Clue_PocketWatch.VRC_Interactable_Click(); }), "Click!");
            _ = new QMSingleButton(MurderItemClicker, "Click Postcard!", new Action(() => { Clue_Postcard.VRC_Interactable_Click(); }), "Click!");
            PresentClicker = new QMSingleButton(MurderItemSpawner,  "Click Present!", new Action(() => { Clue_Present.VRC_Interactable_Click(); }), "Click!");

            _ = new QMSingleButton(MurderItemClicker,  "Unlock Random Weapon!", new Action(() => { Clues.VRC_Interactable_Click(); }), "Unlock Random Weapon!");

            #endregion Items Clicker

            QMNestedGridMenu MurderItemWatchMenu = new QMNestedGridMenu(Murder4CheatPage, "Watchers", "Murder item Watchers!");

            #region Watchers

            new QMSingleButton(MurderItemWatchMenu, "Detective Gun (target)!", new Action(() => { DetectiveGuns.WatchTarget(); }), "Make Detective Gun Watch Target");
            new QMSingleButton(MurderItemWatchMenu, "Silenced Guns (target)!", new Action(() => { SilencedGuns.WatchTarget(); }), "Make Silenced Gun Watch Target");
            new QMSingleButton(MurderItemWatchMenu, "Knifes (target)!", new Action(() => { Knifes.WatchTarget(); }), "Make Knifes Watch Target");
            new QMSingleButton(MurderItemWatchMenu, "Clues (target)!", new Action(() => { Clues.WatchTarget(); }), "Make Clues Watch Target");
            new QMSingleButton(MurderItemWatchMenu,  "Grenade (target)!", new Action(() => { Grenades.WatchTarget(); }), "Make Grenade Watch Target");
            new QMSingleButton(MurderItemWatchMenu,  "Shotgun (target)!", new Action(() => { ShotGuns.WatchTarget(); }), "Make Bear Traps Watch Target");
            new QMSingleButton(MurderItemWatchMenu,  "Bear traps (target)!", new Action(() => { BearTraps.WatchTarget(); }), "Make Bear Traps Watch Target");

            new QMSingleButton(MurderItemWatchMenu,  "Detective Gun (you)!", new Action(() => { DetectiveGuns.WatchSelf(); }), "Make Detective Gun Watch you");
            new QMSingleButton(MurderItemWatchMenu,  "Silenced Guns (you)!", new Action(() => { SilencedGuns.WatchSelf(); }), "Make Silenced Gun Watch you");
            new QMSingleButton(MurderItemWatchMenu,  "Knifes (you)!", new Action(() => { Knifes.WatchSelf(); }), "Make Knifes Watch you");
            new QMSingleButton(MurderItemWatchMenu,  "Clues (you)!", new Action(() => { Clues.WatchSelf(); }), "Make Clues Watch you");
            new QMSingleButton(MurderItemWatchMenu, "Grenade (you)!", new Action(() => { Grenades.WatchSelf(); }), "Make Grenade Watch you");
            new QMSingleButton(MurderItemWatchMenu, "Shotgun (you)!", new Action(() => { ShotGuns.WatchSelf(); }), "Make Bear Traps Watch you");
            new QMSingleButton(MurderItemWatchMenu, "Bear traps (you)!", new Action(() => { BearTraps.WatchSelf(); }), "Make Bear Traps Watch you");

            #endregion Watchers

            QMNestedGridMenu Cheats = new QMNestedGridMenu(Murder4CheatPage, 1, 2f, "World Cheats", "Some Powerful cheats!");

            GetSelfPatreonGunBtn = new QMToggleButton(Cheats,  "Private Golden Gun", new Action(() => { OnlySelfHasPatreonPerk = true; EveryoneHasPatreonPerk = false; }), "Private Golden Gun", new Action(() => { OnlySelfHasPatreonPerk = false; }), "Unlocks The Patreon Perks (Golden Gun) For You!");
            GetEveryonePatreonGunBtn = new QMToggleButton(Cheats,  "Public Golden Gun", new Action(() => { EveryoneHasPatreonPerk = true; OnlySelfHasPatreonPerk = false; }), "Public Golden Gun", new Action(() => { EveryoneHasPatreonPerk = false; }), "Unlocks The Patreon Perks (Golden Gun) For Everyone!");

            GetDetectiveRoleBtn = new QMToggleButton(Cheats,  "Get Detective Role", new Action(() => { RoleSwapper_GetDetectiveRole = true; RoleSwapper_GetMurdererRole = false; }), "Get Detective Role", new Action(() => { RoleSwapper_GetDetectiveRole = false; }), "Assign Yourself Detective Role on Next Round!");
            GetMurdererRoleBtn = new QMToggleButton(Cheats,  "Get Murderer Role", new Action(() => { RoleSwapper_GetMurdererRole = true; RoleSwapper_GetDetectiveRole = false; }), "Get Murderer Role", new Action(() => { RoleSwapper_GetMurdererRole = false; }), "Assign Yourself Murderer Role on Next Round!");

            Murder4ESPtoggler = new QMToggleButton(Cheats,  "Item ESP On", new Action(() => { ToggleItemESP(true); }), "Item ESP Off", new Action(() => { ToggleItemESP(false); }), "Reveals All murder items position.");
            JarRoleController.Murder4RolesRevealerToggle = new QMToggleButton(Cheats, "Reveal Roles", new Action(() => { JarRoleController.ViewRoles = true; }), new Action(() => { JarRoleController.ViewRoles = false; }), "Reveals Current Players Roles In nameplates.");
            

            Murder4_GameLogic.InitButtons(Cheats);
            Murder4_FilteredNodes.InitButtons(Cheats);
            Murder4_UnfilteredNodes.InitButtons(Cheats);
            Murder4_RoleSwapper.InitButtons(Cheats);

            GameAbortbtn = new QMSingleButton(Cheats, "Abort Game", new Action(() => { AbortGameEvent.ExecuteUdonEvent(); }), "Force Abort Game Event", System.Drawing.Color.Red);
            GameVictoryBystanderBtn = new QMSingleButton(Cheats, "Victory Bystander", new Action(() => { VictoryBystanderEvent.ExecuteUdonEvent(); }), "Force Victory Bystander Event", System.Drawing.Color.Red);
            GameVictoryMurdererBtn = new QMSingleButton(Cheats, "Victory Murderer", new Action(() => { VictoryMurdererEvent.ExecuteUdonEvent(); }), "Force Victory Murderer Event", System.Drawing.Color.Red);
            GameStartbtn = new QMSingleButton(Cheats, "Start Game", new Action(() => { StartGameEvent.ExecuteUdonEvent(); }), "Force Start Game Event", System.Drawing.Color.GreenYellow);

        }

        internal static void ToggleKnifesGrab(bool Pickupable)
        {
            foreach (var knife in Knifes)
            {
                knife.Pickup_Set_Pickupable(Pickupable);
            }
        }

        internal static void MakeKnifeGrabbableFromFar()
        {
            foreach (var knife in Knifes)
            {
                knife.Pickup_Set_PickupOrientation(VRC.SDKBase.VRC_Pickup.PickupOrientation.Grip);
                knife.Pickup_Set_proximity(500f);
            }
        }

        internal static void RestoreKnifeToWorldControl()
        {
            foreach (var knife in Knifes)
            {
                knife.Pickup_RestoreOriginalProperties();
            }
        }

        internal override void OnUdonSyncRPCEvent(Player sender, GameObject obj, string action)
        {
            try
            {
                if (HasMurder4WorldLoaded)
                {
                    if (action == "SyncVictoryB" || action == "SyncVictoryM" || action == "SyncAbort" || action == "SyncStart")
                    {
                        Knifes.KillCustomComponents(false);
                        DetectiveGuns.KillCustomComponents(false);
                        SilencedGuns.KillCustomComponents(false);
                        ShotGuns.KillCustomComponents(false);
                        BearTraps.KillCustomComponents(false);
                        Grenades.KillCustomComponents(false);
                        Knifes.KillCustomComponents(false);
                        if (!UseGravity)
                        {
                            UseGravity = true;
                        }
                    }

                    if (!RoleSwapper_GetDetectiveRole || RoleSwapper_GetMurdererRole || !SafetySwap) return;
                    if (obj != null && action.StartsWith("SyncAssign") && JarRoleController.CurrentPlayerRoleESP.LinkedNode.Node.gameObject != null)
                    {
                        if (RoleSwapper_GetDetectiveRole)
                        {
                            if (!SafetySwap)
                            {
                                if (obj == JarRoleController.CurrentPlayerRoleESP.LinkedNode.Node.gameObject)
                                {
                                    AssignedSelfRole = action;
                                }

                                if (action == "SyncAssignD")
                                {
                                    TargetNode = obj;
                                    AssignedTargetRole = action;
                                }

                                RoleSwapper_GetDetectiveRole = SwapRoles(JarRoleController.CurrentPlayerRoleESP.LinkedNode.Node.gameObject, TargetNode, AssignedSelfRole, AssignedTargetRole);
                            }
                        }
                        else if (RoleSwapper_GetMurdererRole)
                        {
                            if (!SafetySwap) // In case it grabs and update the current ones already!
                            {
                                if (obj == JarRoleController.CurrentPlayerRoleESP.LinkedNode.Node.gameObject)
                                {
                                    AssignedSelfRole = action;
                                }

                                if (action == "SyncAssignM")
                                {
                                    TargetNode = obj;
                                    AssignedTargetRole = action;
                                }

                                RoleSwapper_GetMurdererRole = SwapRoles(JarRoleController.CurrentPlayerRoleESP.LinkedNode.Node.gameObject, TargetNode, AssignedSelfRole, AssignedTargetRole);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ModConsole.ErrorExc(e);
            }
        }

        internal static bool SwapRoles(GameObject SelfNode, GameObject TargetNode, string AssignedSelfRole, string AssignedTargetRole)
        {
            if (SelfNode == null && TargetNode == null && AssignedSelfRole == null && AssignedTargetRole == null)
            {
                SafetySwap = false;
                return true; // Keep it active.
            }
            if (string.IsNullOrEmpty(AssignedSelfRole) && string.IsNullOrWhiteSpace(AssignedSelfRole))
            {
                SafetySwap = false;
                return true;
            }
            if (string.IsNullOrEmpty(AssignedTargetRole) && string.IsNullOrWhiteSpace(AssignedTargetRole))
            {
                SafetySwap = false;
                return true;
            }
            if (SelfNode == TargetNode)
            {
                ModConsole.DebugLog("Target Node and SelfNode are the same!");
                SafetySwap = false;
                return false; // Deactivate..
            }
            if (AssignedTargetRole == AssignedSelfRole)
            {
                ModConsole.DebugLog("Target Role String and Self Role String are the same!");
                SafetySwap = false;
                return false;
            }

            MiscUtils.DelayFunction(0.01f, new Action(() =>
            {
                var TargetEvent = UdonSearch.FindUdonEvent(TargetNode, AssignedSelfRole);
                if (TargetEvent != null)
                {
                    TargetEvent.ExecuteUdonEvent();
                }

                var selfevent = UdonSearch.FindUdonEvent(SelfNode, AssignedTargetRole);
                if (selfevent != null)
                {
                    selfevent.ExecuteUdonEvent();
                }
            }));

            SafetySwap = true;

            ModConsole.DebugLog($"Executing Role Swapping!, Target Has Role : {AssignedTargetRole}, You have {AssignedSelfRole}.");

            SafetySwap = false;
            return false; // Deactivate.
        }

        private static bool _OnlySelfHasPatreonPerk;

        internal static bool OnlySelfHasPatreonPerk
        {
            get
            {
                return _OnlySelfHasPatreonPerk;
            }
            set
            {
                _OnlySelfHasPatreonPerk = value;
                if (GetSelfPatreonGunBtn != null)
                {
                    GetSelfPatreonGunBtn.SetToggleState(value);
                }
                if (DetectiveGunPerkUnlocker != null)
                {
                    DetectiveGunPerkUnlocker.OnlySelfHasPatreonPerk = value;
                }
            }
        }

        private static bool _EveryoneHasPatreonPerk;

        internal static bool EveryoneHasPatreonPerk
        {
            get
            {
                return _EveryoneHasPatreonPerk;
            }
            set
            {
                _EveryoneHasPatreonPerk = value;
                if (GetEveryonePatreonGunBtn != null)
                {
                    GetEveryonePatreonGunBtn.SetToggleState(value);
                }

                if (DetectiveGunPerkUnlocker != null)
                {
                    DetectiveGunPerkUnlocker.EveryoneHasPatreonPerk = value;
                }
            }
        }

        private static PatronUnlocker DetectiveGunPerkUnlocker;

        private static GameObject TargetNode;
        private static string AssignedTargetRole;

        private static string AssignedSelfRole;

        private static bool SafetySwap;

        // MAP GameObjects Required for control.
        internal static QMToggleButton Murder4ESPtoggler;

        internal static QMSingleButton GameStartbtn;
        internal static QMSingleButton GameAbortbtn;
        internal static QMSingleButton GameVictoryBystanderBtn;
        internal static QMSingleButton GameVictoryMurdererBtn;

        private static QMSingleButton PresentTeleporter;
        private static QMSingleButton PresentSpawner;
        private static QMSingleButton PresentClicker;

        private static QMToggleButton DoUnlockedSoundbtn;

        private static bool _DoUnlockedSound;

        internal static bool DoUnlockedSound
        {
            get
            {
                return _DoUnlockedSound;
            }
            set
            {
                _DoUnlockedSound = value;
                if (DoUnlockedSoundbtn != null)
                {
                    DoUnlockedSoundbtn.SetToggleState(value);
                }
            }
        }

        internal static QMToggleButton KnifesGrabbableToggle;

        internal static QMSingleButton KnifesGrabFromFar;
        private static bool _isChristmasMode;

        internal static bool IsChristmasMode
        {
            get
            {
                return _isChristmasMode;
            }
            set
            {
                _isChristmasMode = value;
                if (PresentClicker != null)
                {
                    PresentClicker.SetActive(value);
                }
                if (PresentSpawner != null)
                {
                    PresentSpawner.SetActive(value);
                }
                if (PresentTeleporter != null)
                {
                    PresentTeleporter.SetActive(value);
                }
            }
        }

        internal static GameObject Clue_photograph = null;

        internal static GameObject Clue_notebook = null;
        internal static GameObject Clue_Locket = null;
        internal static GameObject Clue_PocketWatch = null;
        internal static GameObject Clue_Postcard = null;

        internal static GameObject item_Knife_0 = null;
        internal static GameObject item_Knife_1 = null;
        internal static GameObject item_Knife_2 = null;
        internal static GameObject item_Knife_3 = null;
        internal static GameObject item_Knife_4 = null;
        internal static GameObject item_Knife_5 = null;

        internal static GameObject item_Bear_trap_0 = null;
        internal static GameObject item_Bear_trap_1 = null;
        internal static GameObject item_Bear_trap_2 = null;

        internal static GameObject item_Shotgun = null;

        internal static GameObject item_Silenced_Revolver_0 = null;
        internal static GameObject item_Silenced_Revolver_1 = null;

        internal static GameObject item_Grenade = null;

        internal static GameObject item_DetectiveRevolver = null;

        internal static GameObject Clue_Present = null;
        internal static GameObject PatreonFlairtoggle = null;

        internal static GameObject Snake_Crate = null;

        internal static List<GameObject> Clues = new List<GameObject>();
        internal static List<GameObject> DetectiveGuns = new List<GameObject>();
        internal static List<GameObject> SilencedGuns = new List<GameObject>();
        internal static List<GameObject> ShotGuns = new List<GameObject>();

        internal static List<GameObject> Knifes = new List<GameObject>();
        internal static List<GameObject> BearTraps = new List<GameObject>();
        internal static List<GameObject> Grenades = new List<GameObject>();

        internal static QMNestedGridMenu Murder4CheatPage;

        internal static UdonBehaviour_Cached OnPlayerUnlockedClues;

        internal static UdonBehaviour_Cached StartGameEvent;
        internal static UdonBehaviour_Cached AbortGameEvent;

        internal static UdonBehaviour_Cached VictoryBystanderEvent;
        internal static UdonBehaviour_Cached VictoryMurdererEvent;

        internal static QMToggleButton GetDetectiveRoleBtn;
        internal static QMToggleButton GetMurdererRoleBtn;

        internal static QMToggleButton GetSelfPatreonGunBtn;
        internal static QMToggleButton GetEveryonePatreonGunBtn;
        internal static QMToggleButton ToggleGravityMode;

        internal static bool _RoleSwapper_GetDetectiveRole;

        internal static bool RoleSwapper_GetDetectiveRole
        {
            get
            {
                return _RoleSwapper_GetDetectiveRole;
            }
            set
            {
                if (value == _RoleSwapper_GetDetectiveRole)
                {
                    return;
                }
                _RoleSwapper_GetDetectiveRole = value;
                if (GetDetectiveRoleBtn != null)
                {
                    GetDetectiveRoleBtn.SetToggleState(value);
                }

                if (value)
                {
                    AssignedSelfRole = null;
                    AssignedTargetRole = null;
                    TargetNode = null;
                    SafetySwap = false;
                }
                if (!value)
                {
                    SafetySwap = false;
                }
            }
        }

        internal static bool _RoleSwapper_GetMurdererRole;

        internal static bool RoleSwapper_GetMurdererRole
        {
            get
            {
                return _RoleSwapper_GetMurdererRole;
            }
            set
            {
                if (value == _RoleSwapper_GetMurdererRole)
                {
                    return;
                }
                _RoleSwapper_GetMurdererRole = value;
                if (GetMurdererRoleBtn != null)
                {
                    GetMurdererRoleBtn.SetToggleState(value);
                }
                if (value)
                {
                    AssignedSelfRole = null;
                    AssignedTargetRole = null;
                    TargetNode = null;
                    SafetySwap = false;
                }
                if (!value)
                {
                    SafetySwap = false;
                }
            }
        }

        internal static bool HasMurder4WorldLoaded = false;
    }
}