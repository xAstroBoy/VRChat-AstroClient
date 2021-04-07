using RubyButtonAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#region AstroClient Imports

using AstroClient.Finder;
using AstroClient.variables;
using AstroClient.ConsoleUtils;
using AstroClient.extensions;
using AstroClient.components;
using AstroClient.UdonExploits;
using AstroClient.Variables;
using static AstroClient.variables.CustomLists;
using VRC.Udon;
using VRC;
using DayClientML2.Utility.Extensions;
using MelonLoader;
using System.Collections;
using DayClientML2.Utility;

#endregion AstroClient Imports

namespace AstroClient
{
    public class Murder4Cheats : Overridables
    {
        public static void FindGameMurderObjects()
        {
            ModConsole.Log("Removing Anti-Peek Protection...");

            var occlusion = GameObjectFinder.Find("Environment/Occlusion");
            if (occlusion != null)
            {
                occlusion.DestroyMeLocal();
            }

            item_DetectiveRevolver = GameObjectFinder.Find("Game Logic/Weapons/Revolver");

            Clue_photograph = GameObjectFinder.Find("Game Logic/Clues/Clue (photograph)");
            Clue_notebook = GameObjectFinder.Find("Game Logic/Clues/Clue (notebook)");
            Clue_Locket = GameObjectFinder.Find("Game Logic/Clues/Clue (locket)");
            Clue_PocketWatch = GameObjectFinder.Find("Game Logic/Clues/Clue (pocketwatch)");
            Clue_Postcard = GameObjectFinder.Find("Game Logic/Clues/Clue (postcard)");
            if (!isChristmasMode)
            {
                Clue_Present = GameObjectFinder.Find("Game Logic/Clues (xmas)/Clue (present) (5)");
                if (Clue_Present != null)
                {
                    isChristmasMode = true;
                }
                else
                {
                    ModConsole.Log("Could Not Find The Present Clue!");
                }
            }
            item_DetectiveRevolver = GameObjectFinder.Find("Game Logic/Weapons/Revolver");
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

            foreach (var action in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
            {
                if (action.gameObject.name == "Game Logic")
                {
                    foreach (var subaction in action._eventTable)
                    {
                        if (subaction.key == "SyncStart")
                        {
                            StartGameEvent = new CachedUdonEvent(action, subaction.key);
                            ModConsole.Log("Found Start Game Event.");
                        }
                        if (subaction.key == "SyncAbort")
                        {
                            AbortGameEvent = new CachedUdonEvent(action, subaction.key);
                            ModConsole.Log("Found Abort Game Event.");
                        }
                        if (subaction.key == "SyncVictoryB")
                        {
                            VictoryBystanderEvent = new CachedUdonEvent(action, subaction.key);
                            ModConsole.Log("Found Victory Bystander Event.");
                        }
                        if (subaction.key == "SyncVictoryM")
                        {
                            VictoryMurdererEvent = new CachedUdonEvent(action, subaction.key);
                            ModConsole.Log("Found Victory Murderer Event.");
                        }
                        if (subaction.key == "OnPlayerUnlockedClues")
                        {
                            OnPlayerUnlockedClues = new CachedUdonEvent(action, subaction.key);
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
                GameStartbtn.setActive(StartGameEvent.isNotNull());
                GameStartbtn.setIntractable(StartGameEvent.isNotNull());
            }
            if (GameAbortbtn != null)
            {
                GameAbortbtn.setActive(AbortGameEvent.isNotNull());
                GameAbortbtn.setIntractable(AbortGameEvent.isNotNull());
            }
            if (GameVictoryBystanderBtn != null)
            {
                GameVictoryBystanderBtn.setActive(VictoryBystanderEvent.isNotNull());
                GameVictoryBystanderBtn.setIntractable(VictoryBystanderEvent.isNotNull());
            }
            if (GameVictoryMurdererBtn != null)
            {
                GameVictoryMurdererBtn.setActive(VictoryMurdererEvent.isNotNull());
                GameVictoryMurdererBtn.setIntractable(VictoryMurdererEvent.isNotNull());
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
            if (weapons.Count != 0)
            {
                weapons.RegisterMurderItemEsp();
            }

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
            BearTraps.AddGameObject(item_Bear_trap_0);
            BearTraps.AddGameObject(item_Bear_trap_0);
            Grenades.AddGameObject(item_Grenade);

            Clues.RegisterMurderItemEsp();
            DetectiveGuns.RegisterMurderItemEsp();
            SilencedGuns.RegisterMurderItemEsp();
            ShotGuns.RegisterMurderItemEsp();
            BearTraps.RegisterMurderItemEsp();
            Grenades.RegisterMurderItemEsp();
            Knifes.RegisterMurderItemEsp();

            Clues.AddToWorldUtilsMenu();

            ModConsole.Log("Found Tot Clues : " + Clues.Count());
            ModConsole.Log("Found Tot Detective Guns : " + DetectiveGuns.Count());
            ModConsole.Log("Found Tot Silenced Guns  : " + SilencedGuns.Count());
            ModConsole.Log("Found Tot ShotGuns : " + ShotGuns.Count());
            ModConsole.Log("Found Tot Bear Traps : " + BearTraps.Count());
            ModConsole.Log("Found Tot Grenades : " + Grenades.Count());
            ModConsole.Log("Found Tot Knifes : " + Knifes.Count());
        }

        public static void SetMurderItemsGravity(bool ShouldFloat)
        {
            DetectiveGuns.SetGravity(ShouldFloat);
            SilencedGuns.SetGravity(ShouldFloat);
            ShotGuns.SetGravity(ShouldFloat);
            BearTraps.SetGravity(ShouldFloat);
            Grenades.SetGravity(ShouldFloat);
            Knifes.SetGravity(ShouldFloat);
        }

        public static void AllowTheft()
        {
            DetectiveGuns.SetPickupTheft(false);
            SilencedGuns.SetPickupTheft(false);
            ShotGuns.SetPickupTheft(false);
            BearTraps.SetPickupTheft(false);
            Grenades.SetPickupTheft(false);
            Knifes.SetPickupTheft(false);
        }

        public static void MurderGunsRockets()
        {
            DetectiveGuns.AddRocketComponent(false);
            SilencedGuns.AddRocketComponent(false);
            ShotGuns.AddRocketComponent(false);
        }

        public static void MurderGunsCrazy()
        {
            DetectiveGuns.AddCrazyComponent(false);
            SilencedGuns.AddCrazyComponent(false);
            ShotGuns.AddCrazyComponent(false);
        }

        public override void OnWorldReveal(string id, string name, string asseturl)
        {
            if (id == WorldIds.Murder4)
            {
                HasMurder4WorldLoaded = true;
                if (Murder4CheatPage != null)
                {
                    ModConsole.Log($"Recognized {name} World, Unlocking Murder 4 cheats menu!", System.Drawing.Color.Green);
                    Murder4CheatPage.getMainButton().setIntractable(true);
                    Murder4CheatPage.getMainButton().setTextColor(Color.green);
                }
                FindGameMurderObjects();
            }
            else
            {
                HasMurder4WorldLoaded = false;
                if (Murder4CheatPage != null)
                {
                    Murder4CheatPage.getMainButton().setIntractable(false);
                    Murder4CheatPage.getMainButton().setTextColor(Color.red);
                }
            }
        }

        public override void OnLevelLoaded()
        {
            if (KnifesGrabbableToggle != null)
            {
                KnifesGrabbableToggle.setToggleState(false);
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
            ClonedKnife.Clear();
            Knifes.Clear();
            BearTraps.Clear();
            Grenades.Clear();
            PatreonFlairtoggle = null;
            isChristmasMode = false;
            DoUnlockedSound = false;
            OnPlayerUnlockedClues = null;
            AssignedSelfRole = string.Empty;
            AssignedTargetRole = string.Empty;
            TargetNode = null;
            SafetySwap = false;
            RoleSwapper_GetDetectiveRole = false;
            RoleSwapper_GetMurdererRole = false;
        }

        public static void Murder4CheatsButtons(QMNestedButton submenu, float BtnXLocation, float BtnYLocation, bool btnHalf)
        {
            Murder4CheatPage = new QMNestedButton(submenu, BtnXLocation, BtnYLocation, "Murder 4 Cheats", "Manage Murder 4 Cheats", null, null, null, null, btnHalf);
            Murder4CheatPage.getMainButton().SetResizeTextForBestFit(true);

            QMNestedButton MurderItemTeleporter = new QMNestedButton(Murder4CheatPage, 1, 0, "Item Teleporter", "Size Items Editor", null, null, null, null, true);

            #region Item Teleporter

            DoUnlockedSoundbtn = new QMSingleToggleButton(MurderItemTeleporter, 0, 0, "Do Sound", new Action(() => { DoUnlockedSound = true; }), "Quiet Mode", new Action(() => { DoUnlockedSound = false; }), "Should i run the Sound action on pickups teleport.", Color.green, Color.red, null, false, true);
            new QMSingleButton(MurderItemTeleporter, 1, 0, "Clues!", new Action(() => { Clues.TeleportToMe(); }), "Clue Teleporter!", null, null, true);
            new QMSingleButton(MurderItemTeleporter, 2, 0, "Photograph!", new Action(() => { Clue_photograph.TeleportToMe(); }), "Clue Teleporter!", null, null, true);
            new QMSingleButton(MurderItemTeleporter, 3, 0, "Notebook!", new Action(() => { Clue_notebook.TeleportToMe(); }), "Clue Teleporter!", null, null, true);
            new QMSingleButton(MurderItemTeleporter, 4, 0, "Locket!", new Action(() => { Clue_Locket.TeleportToMe(); }), "Clue Teleporter!", null, null, true);
            new QMSingleButton(MurderItemTeleporter, 1, 0.5f, "PocketWatch!", new Action(() => { Clue_PocketWatch.TeleportToMe(); }), "Clue Teleporter!", null, null, true);
            new QMSingleButton(MurderItemTeleporter, 2, 0.5f, "Postcard!", new Action(() => { Clue_Postcard.TeleportToMe(); }), "Clue Teleporter!", null, null, true);
            new QMSingleButton(MurderItemTeleporter, 3, 0.5f, "Shotgun!", new Action(() => { item_Shotgun.TeleportToMe(); if (DoUnlockedSound) { OnPlayerUnlockedClues.ExecuteUdonEvent(); } }), "Shotgun Gun Teleporter!", null, null, true);
            new QMSingleButton(MurderItemTeleporter, 4, 0.5f, "Detective Gun!", new Action(() => { item_DetectiveRevolver.TeleportToMe(); if (DoUnlockedSound) { OnPlayerUnlockedClues.ExecuteUdonEvent(); } }), "Detective Gun Teleporter!", null, null, true);
            new QMSingleButton(MurderItemTeleporter, 1, 1f, "Silenced Gun 1!", new Action(() => { item_Silenced_Revolver_0.TeleportToMe(); if (DoUnlockedSound) { OnPlayerUnlockedClues.ExecuteUdonEvent(); } }), "Silenced Gun Teleporter!", null, null, true);
            new QMSingleButton(MurderItemTeleporter, 2, 1f, "Silenced Gun 2!", new Action(() => { item_Silenced_Revolver_1.TeleportToMe(); if (DoUnlockedSound) { OnPlayerUnlockedClues.ExecuteUdonEvent(); } }), "Silenced Gun Teleporter!", null, null, true);
            new QMSingleButton(MurderItemTeleporter, 3, 1, "Grenade!", new Action(() => { item_Grenade.TeleportToMe(); if (DoUnlockedSound) { OnPlayerUnlockedClues.ExecuteUdonEvent(); } }), "Grenade Teleporter!", null, null, true);
            new QMSingleButton(MurderItemTeleporter, 4, 1f, "Traps!", new Action(() => { BearTraps.TeleportToMe(); if (DoUnlockedSound) { OnPlayerUnlockedClues.ExecuteUdonEvent(); } }), "Silenced Gun Teleporter!", null, null, true);
            PresentTeleporter = new QMSingleButton(MurderItemTeleporter, 1, 2, "Present!", new Action(() => { Clue_Present.TeleportToMe(); }), "Clue Teleporter!", null, null, true);

            #endregion Item Teleporter

            QMNestedButton MurderItemTweaker = new QMNestedButton(Murder4CheatPage, 1, 0.5f, "Item Tweaker", "Item Tweaks!", null, null, null, null, true);

            #region Item Tweaker

            new QMSingleButton(MurderItemTweaker, 3, 0, "Knifes (Rockets)!", new Action(() => { Knifes.AddRocketComponent(false); }), "Rockets!", null, null, true).SetResizeTextForBestFit(true);
            new QMSingleButton(MurderItemTweaker, 3, 0.5f, "Guns (Rockets)!", new Action(() => { MurderGunsRockets(); }), "Rockets!", null, null, true).SetResizeTextForBestFit(true);
            new QMSingleButton(MurderItemTweaker, 3, 1, "Grenades (Rockets)!", new Action(() => { Grenades.AddRocketComponent(false); }), "Rockets!", null, null, true).SetResizeTextForBestFit(true);
            new QMSingleButton(MurderItemTweaker, 3, 1.5f, "Bear Trap (Rockets)!", new Action(() => { BearTraps.AddRocketComponent(false); }), "Rockets!", null, null, true).SetResizeTextForBestFit(true);
            new QMSingleButton(MurderItemTweaker, 3, 2, "Clues (Rockets)!", new Action(() => { Clues.AddRocketComponent(false); }), "Rockets", null, null, true).SetResizeTextForBestFit(true);

            new QMSingleButton(MurderItemTweaker, 4, 0, "Knifes (Crazy)!", new Action(() => { Knifes.AddCrazyComponent(false); }), "Make Knifes in Instance go nuts!", null, null, true).SetResizeTextForBestFit(true);
            new QMSingleButton(MurderItemTweaker, 4, 0.5f, "Guns (Crazy)!", new Action(MurderGunsCrazy), "Make Guns in Instance go nuts!", null, null, true).SetResizeTextForBestFit(true);
            new QMSingleButton(MurderItemTweaker, 4, 1, "Clues (Crazy)!", new Action(() => { Clues.AddCrazyComponent(false); }), "Make Clues in Instance go nuts!", null, null, true).SetResizeTextForBestFit(true);
            new QMSingleButton(MurderItemTweaker, 4, 1.5f, "Grenade (Crazy)!", new Action(() => { Grenades.AddCrazyComponent(false); }), "Make Grenade in Instance go nuts!", null, null, true).SetResizeTextForBestFit(true);
            new QMSingleButton(MurderItemTweaker, 4, 2, "Bear Trap (Crazy)!", new Action(() => { BearTraps.AddCrazyComponent(false); }), "Make Grenade in Instance go nuts!", null, null, true).SetResizeTextForBestFit(true);

            new QMSingleButton(MurderItemTweaker, 1, 0, "Allow Gun Theft in Murder!", new Action(AllowTheft), "Allows you to steal items from other people!", null, null, true);
            new QMSingleToggleButton(MurderItemTweaker, 1, 0.5f, "Float (Space Mode)", new Action(() => { SetMurderItemsGravity(true); }), "Fall (World Gravity)", new Action(() => { SetMurderItemsGravity(false); }), "Tweaks all Murder! items gravity!", Color.green, Color.red, null, false, true);
            KnifesGrabbableToggle = new QMSingleToggleButton(MurderItemTweaker, 1, 1, "Can Grab Knifes", new Action(() => { ToggleKnifesGrab(true); }), "Cannot Grab Knifes", new Action(() => { ToggleKnifesGrab(false); }), "Tweaks all Murder! items gravity!", Color.green, Color.red, null, false, true);
            var one = new QMSingleButton(MurderItemTweaker, 1, 1.5f, "Knifes Grabbable from far!", new Action(() => { MakeKnifeGrabbableFromFar(); }), "Make Knifes Grabbable from far!", null, null, true);
            var two = new QMSingleButton(MurderItemTweaker, 1, 2, "Restore Knifes Properties to world!", new Action(() => { RestoreKnifeToWorldControl(); }), "Restore Control to world!", null, null, true);

            one.SetResizeTextForBestFit(true);
            two.SetResizeTextForBestFit(true);

            #endregion Item Tweaker

            QMNestedButton MurderItemSpawner = new QMNestedButton(Murder4CheatPage, 1, 1f, "Item Spawner", "Item Spawner!", null, null, null, null, true);

            #region Item Spawner

            new QMSingleButton(MurderItemSpawner, 1, 0, "Spawn Detective Gun", new Action(() => { item_DetectiveRevolver.CloneObject(); }), "Detective Gun Cloner!", null, null, true);
            new QMSingleButton(MurderItemSpawner, 1, 0.5f, "Spawn Silenced Gun", new Action(() => { item_Silenced_Revolver_0.CloneObject(); }), "Silenced Gun Cloner!", null, null, true);
            new QMSingleButton(MurderItemSpawner, 1, 1, "Spawn Shotgun", new Action(() => { item_Shotgun.CloneObject(); }), "Shotgun Cloner!", null, null, true);
            new QMSingleButton(MurderItemSpawner, 1, 1.5f, "Spawn Knife", new Action(() => { item_Knife_0.CloneObject(); }), "Knife Cloner!", null, null, true);
            new QMSingleButton(MurderItemSpawner, 1, 2, "Spawn Grenade", new Action(() => { item_Grenade.CloneObject(); }), "Grenade Cloner!", null, null, true);
            new QMSingleButton(MurderItemSpawner, 1, 2.5f, "Spawn Bear Trap", new Action(() => { item_Bear_trap_1.CloneObject(); }), "Bear Trap Cloner!", null, null, true);
            new QMSingleButton(MurderItemSpawner, 2, 0, "Spawn photograph!", new Action(() => { Clue_photograph.CloneObject(); }), "Clue Cloner!", null, null, true);
            new QMSingleButton(MurderItemSpawner, 2, 0.5f, "Spawn notebook!", new Action(() => { Clue_notebook.CloneObject(); }), "Clue Cloner!", null, null, true);
            new QMSingleButton(MurderItemSpawner, 2, 1, "Spawn Locket!", new Action(() => { Clue_Locket.CloneObject(); }), "Clue Cloner!", null, null, true);
            new QMSingleButton(MurderItemSpawner, 2, 1.5f, "Spawn PocketWatch!", new Action(() => { Clue_PocketWatch.CloneObject(); }), "Clue Cloner!", null, null, true);
            new QMSingleButton(MurderItemSpawner, 2, 2, "Spawn Postcard!", new Action(() => { Clue_Postcard.CloneObject(); }), "Clue Cloner!", null, null, true);
            PresentSpawner = new QMSingleButton(MurderItemSpawner, 2, 2.5f, "Spawn Present!", new Action(() => { Clue_Present.CloneObject(); }), "Clue Teleporter!", null, null, true);

            #endregion Item Spawner

            if (Bools.AllowAttackerComponent)
            {
                QMNestedButton MurderItemAttackerMenu = new QMNestedButton(Murder4CheatPage, 1, 1.5f, "Followers", "Murder item Followers!", null, null, null, null, true);

                #region Followers

                new QMSingleButton(MurderItemAttackerMenu, 1, 0, "Detective Gun (target)!", new Action(() => { DetectiveGuns.AttackTarget(); }), "Make Detective Gun follow Target", null, null, true).SetResizeTextForBestFit(true);
                new QMSingleButton(MurderItemAttackerMenu, 2, 0, "Silenced Guns (target)!", new Action(() => { SilencedGuns.AttackTarget(); }), "Make Silenced Gun follow Target", null, null, true).SetResizeTextForBestFit(true);
                new QMSingleButton(MurderItemAttackerMenu, 3, 0, "Knifes (target)!", new Action(() => { Knifes.AttackTarget(); }), "Make Knifes follow Target", null, null, true).SetResizeTextForBestFit(true);
                new QMSingleButton(MurderItemAttackerMenu, 4, 0, "Clues (target)!", new Action(() => { Clues.AttackTarget(); }), "Make Clues follow Target", null, null, true).SetResizeTextForBestFit(true);
                new QMSingleButton(MurderItemAttackerMenu, 1, 0.5f, "Grenade (target)!", new Action(() => { Grenades.AttackTarget(); }), "Make Grenade follow Target", null, null, true).SetResizeTextForBestFit(true);
                new QMSingleButton(MurderItemAttackerMenu, 2, 0.5f, "Shotgun (target)!", new Action(() => { ShotGuns.AttackTarget(); }), "Make Bear Traps follow Target", null, null, true).SetResizeTextForBestFit(true);
                new QMSingleButton(MurderItemAttackerMenu, 3, 0.5f, "Bear traps (target)!", new Action(() => { BearTraps.AttackTarget(); }), "Make Bear Traps follow Target", null, null, true).SetResizeTextForBestFit(true);

                new QMSingleButton(MurderItemAttackerMenu, 1, 1.5f, "Detective Gun (you)!", new Action(() => { DetectiveGuns.AttackSelf(); }), "Make Detective Gun follow you", null, null, true).SetResizeTextForBestFit(true);
                new QMSingleButton(MurderItemAttackerMenu, 2, 1.5f, "Silenced Guns (you)!", new Action(() => { SilencedGuns.AttackSelf(); }), "Make Silenced Gun follow you", null, null, true).SetResizeTextForBestFit(true);
                new QMSingleButton(MurderItemAttackerMenu, 3, 1.5f, "Knifes (you)!", new Action(() => { Knifes.AttackSelf(); }), "Make Knifes follow you", null, null, true).SetResizeTextForBestFit(true);
                new QMSingleButton(MurderItemAttackerMenu, 4, 1.5f, "Clues (you)!", new Action(() => { Clues.AttackSelf(); }), "Make Clues follow you", null, null, true).SetResizeTextForBestFit(true);
                new QMSingleButton(MurderItemAttackerMenu, 1, 2, "Grenade (you)!", new Action(() => { Grenades.AttackSelf(); }), "Make Grenade follow you", null, null, true).SetResizeTextForBestFit(true);
                new QMSingleButton(MurderItemAttackerMenu, 2, 2, "Shotgun (you)!", new Action(() => { ShotGuns.AttackSelf(); }), "Make Shotgun follow you", null, null, true).SetResizeTextForBestFit(true);
                new QMSingleButton(MurderItemAttackerMenu, 3, 2, "Bear traps (you)!", new Action(() => { BearTraps.AttackSelf(); }), "Make Bear Traps follow you", null, null, true).SetResizeTextForBestFit(true);

                #endregion Followers
            }
            if (Bools.AllowOrbitComponent)
            {
                QMNestedButton MurderItemOrbiterMenu = new QMNestedButton(Murder4CheatPage, 1, 2, "Orbiters", "Murder item Orbits!", null, null, null, null, true);

                #region orbiters

                new QMSingleButton(MurderItemOrbiterMenu, 1, 0, "Detective Gun (target)!", new Action(() => { DetectiveGuns.OrbitTarget(); }), "Make Detective Gun orbit around Target", null, null, true).SetResizeTextForBestFit(true);
                new QMSingleButton(MurderItemOrbiterMenu, 2, 0, "Silenced Guns (target)!", new Action(() => { SilencedGuns.OrbitTarget(); }), "Make Silenced Gun around orbit Target", null, null, true).SetResizeTextForBestFit(true);
                new QMSingleButton(MurderItemOrbiterMenu, 3, 0, "Shotgun (target)!", new Action(() => { ShotGuns.OrbitTarget(); }), "Make ShotGun orbit around Target", null, null, true).SetResizeTextForBestFit(true);
                new QMSingleButton(MurderItemOrbiterMenu, 4, 0, "Knifes (target)!", new Action(() => { Knifes.OrbitTarget(); }), "Make Knifes orbit around Target", null, null, true).SetResizeTextForBestFit(true);
                new QMSingleButton(MurderItemOrbiterMenu, 1, 0.5f, "Clues (target)!", new Action(() => { Clues.OrbitTarget(); }), "Make Clues orbit around Target", null, null, true).SetResizeTextForBestFit(true);
                new QMSingleButton(MurderItemOrbiterMenu, 2, 0.5f, "Grenade (target)!", new Action(() => { Grenades.OrbitTarget(); }), "Make Grenade orbit around Target", null, null, true).SetResizeTextForBestFit(true);
                new QMSingleButton(MurderItemOrbiterMenu, 3, 0.5f, "Bear Trap (target)!", new Action(() => { BearTraps.OrbitTarget(); }), "Make Bear Traps orbit around Target", null, null, true).SetResizeTextForBestFit(true);

                new QMSingleButton(MurderItemOrbiterMenu, 1, 1.5f, "Detective Gun (you)!", new Action(() => { DetectiveGuns.OrbitSelf(); }), "Make Detective Gun orbit around you", null, null, true).SetResizeTextForBestFit(true);
                new QMSingleButton(MurderItemOrbiterMenu, 2, 1.5f, "Silenced Guns (you)!", new Action(() => { SilencedGuns.OrbitSelf(); }), "Make Silenced Gun around orbit you", null, null, true).SetResizeTextForBestFit(true);
                new QMSingleButton(MurderItemOrbiterMenu, 3, 1.5f, "Shotgun (you)!", new Action(() => { ShotGuns.OrbitSelf(); }), "Make ShotGun orbit around you", null, null, true).SetResizeTextForBestFit(true);
                new QMSingleButton(MurderItemOrbiterMenu, 4, 1.5f, "Knifes (you)!", new Action(() => { Knifes.OrbitSelf(); }), "Make Knifes orbit around you", null, null, true).SetResizeTextForBestFit(true);
                new QMSingleButton(MurderItemOrbiterMenu, 1, 2, "Clues (you)!", new Action(() => { Clues.OrbitSelf(); }), "Make Clues orbit around you", null, null, true).SetResizeTextForBestFit(true);
                new QMSingleButton(MurderItemOrbiterMenu, 2, 2, "Grenade (you)!", new Action(() => { Grenades.OrbitSelf(); }), "Make Grenade orbit around you", null, null, true).SetResizeTextForBestFit(true);
                new QMSingleButton(MurderItemOrbiterMenu, 3, 2, "Bear Trap (you)!", new Action(() => { BearTraps.OrbitSelf(); }), "Make Bear Traps orbit around you", null, null, true).SetResizeTextForBestFit(true);

                #endregion orbiters
            }

            QMNestedButton MurderItemClicker = new QMNestedButton(Murder4CheatPage, 1, 2.5f, "Items Clicker", "Interact with Items!", null, null, null, null, true);

            #region Items Clicker

            new QMSingleButton(MurderItemClicker, 1, 0, "Click photograph!", new Action(() => { Clue_photograph.VRC_Interactable_Click(); }), "Click!", null, null, true);
            new QMSingleButton(MurderItemClicker, 1, 0.5f, "Click notebook!", new Action(() => { Clue_notebook.VRC_Interactable_Click(); }), "Click!", null, null, true);
            new QMSingleButton(MurderItemClicker, 1, 1, "Click Locket!", new Action(() => { Clue_Locket.VRC_Interactable_Click(); }), "Click!", null, null, true);
            new QMSingleButton(MurderItemClicker, 1, 1.5f, "Click PocketWatch!", new Action(() => { Clue_PocketWatch.VRC_Interactable_Click(); }), "Click!", null, null, true);
            new QMSingleButton(MurderItemClicker, 1, 2, "Click Postcard!", new Action(() => { Clue_Postcard.VRC_Interactable_Click(); }), "Click!", null, null, true);
            PresentClicker = new QMSingleButton(MurderItemSpawner, 2, 0, "Click Present!", new Action(() => { Clue_Present.VRC_Interactable_Click(); }), "Click!", null, null, true);

            new QMSingleButton(MurderItemClicker, 2, 0.5f, "Unlock Random Weapon!", new Action(() => { Clues.VRC_Interactable_Click(); }), "Unlock Random Weapon!", null, null, true);

            #endregion Items Clicker

            QMNestedButton MurderItemWatchMenu = new QMNestedButton(Murder4CheatPage, 2, 0f, "Watchers", "Murder item Watchers!", null, null, null, null, true);

            #region Watchers

            new QMSingleButton(MurderItemWatchMenu, 1, 0, "Detective Gun (target)!", new Action(() => { DetectiveGuns.WatchTarget(); }), "Make Detective Gun Watch Target", null, null, true).SetResizeTextForBestFit(true);
            new QMSingleButton(MurderItemWatchMenu, 2, 0, "Silenced Guns (target)!", new Action(() => { SilencedGuns.WatchTarget(); }), "Make Silenced Gun Watch Target", null, null, true).SetResizeTextForBestFit(true);
            new QMSingleButton(MurderItemWatchMenu, 3, 0, "Knifes (target)!", new Action(() => { Knifes.WatchTarget(); }), "Make Knifes Watch Target", null, null, true).SetResizeTextForBestFit(true);
            new QMSingleButton(MurderItemWatchMenu, 4, 0, "Clues (target)!", new Action(() => { Clues.WatchTarget(); }), "Make Clues Watch Target", null, null, true).SetResizeTextForBestFit(true);
            new QMSingleButton(MurderItemWatchMenu, 1, 0.5f, "Grenade (target)!", new Action(() => { Grenades.WatchTarget(); }), "Make Grenade Watch Target", null, null, true).SetResizeTextForBestFit(true);
            new QMSingleButton(MurderItemWatchMenu, 2, 0.5f, "Shotgun (target)!", new Action(() => { ShotGuns.WatchTarget(); }), "Make Bear Traps Watch Target", null, null, true).SetResizeTextForBestFit(true);
            new QMSingleButton(MurderItemWatchMenu, 3, 0.5f, "Bear traps (target)!", new Action(() => { BearTraps.WatchTarget(); }), "Make Bear Traps Watch Target", null, null, true).SetResizeTextForBestFit(true);

            new QMSingleButton(MurderItemWatchMenu, 1, 1.5f, "Detective Gun (you)!", new Action(() => { DetectiveGuns.WatchSelf(); }), "Make Detective Gun Watch you", null, null, true).SetResizeTextForBestFit(true);
            new QMSingleButton(MurderItemWatchMenu, 2, 1.5f, "Silenced Guns (you)!", new Action(() => { SilencedGuns.WatchSelf(); }), "Make Silenced Gun Watch you", null, null, true).SetResizeTextForBestFit(true);
            new QMSingleButton(MurderItemWatchMenu, 3, 1.5f, "Knifes (you)!", new Action(() => { Knifes.WatchSelf(); }), "Make Knifes Watch you", null, null, true).SetResizeTextForBestFit(true);
            new QMSingleButton(MurderItemWatchMenu, 4, 1.5f, "Clues (you)!", new Action(() => { Clues.WatchSelf(); }), "Make Clues Watch you", null, null, true).SetResizeTextForBestFit(true);
            new QMSingleButton(MurderItemWatchMenu, 1, 2, "Grenade (you)!", new Action(() => { Grenades.WatchSelf(); }), "Make Grenade Watch you", null, null, true).SetResizeTextForBestFit(true);
            new QMSingleButton(MurderItemWatchMenu, 2, 2, "Shotgun (you)!", new Action(() => { ShotGuns.WatchSelf(); }), "Make Bear Traps Watch you", null, null, true).SetResizeTextForBestFit(true);
            new QMSingleButton(MurderItemWatchMenu, 3, 2, "Bear traps (you)!", new Action(() => { BearTraps.WatchSelf(); }), "Make Bear Traps Watch you", null, null, true).SetResizeTextForBestFit(true);

            #endregion Watchers

            // FUCK NO CLUE WHERE TO PLACE THE NEW BUTTONS LOL BRB
            Murder4UdonExploits.Init_RoleSwap_Menu(Murder4CheatPage, 2, 0.5f, true);
            GetDetectiveRoleBtn = new QMSingleToggleButton(Murder4CheatPage, 2, 1, "Get Detective Role", new Action(() => {RoleSwapper_GetDetectiveRole = true; RoleSwapper_GetMurdererRole = false; }), "Get Detective Role", new Action(() => { RoleSwapper_GetDetectiveRole = false; }), "Assign Yourself Detective Role on Next Round!", Color.green, Color.red, null, false, true);
            GetMurdererRoleBtn = new QMSingleToggleButton(Murder4CheatPage, 2, 1.5f, "Get Murderer Role", new Action(() => { RoleSwapper_GetMurdererRole = true; RoleSwapper_GetDetectiveRole = false; }), "Get Murderer Role", new Action(() => {RoleSwapper_GetMurdererRole = false;}), "Assign Yourself Murderer Role on Next Round!", Color.green, Color.red, null, false, true);

            GameObjectESP.Murder4ESPtoggler = new QMSingleToggleButton(Murder4CheatPage, 3, 0, "Item ESP On", new Action(GameObjectESP.AddESPToMurderProps), "Item ESP Off", new Action(GameObjectESP.RemoveESPToMurderProps), "Reveals All murder items position.", Color.green, Color.red, null, false, true);
            JarRoleController.Murder4RolesRevealerToggle = new QMSingleToggleButton(Murder4CheatPage, 3, 0.5f, "Reveal Roles On", new Action(() => { JarRoleController.ViewRoles = true; }), "Reveals Roles Off", new Action(() => { JarRoleController.ViewRoles = false; }), "Reveals Current Players Roles In nameplates.", Color.green, Color.red, null, false, true);
            Murder4UdonExploits.Init_GameController_Btn(Murder4CheatPage, 4, 0, true);
            Murder4UdonExploits.Init_Filtered_Nodes_Btn(Murder4CheatPage, 4, 0.5f, true);
            Murder4UdonExploits.Init_Unfiltered_Nodes_btn(Murder4CheatPage, 4, 1f, true);



            GameStartbtn = new QMSingleButton(Murder4CheatPage, 3, 2, "Start Game", new Action(() => { StartGameEvent.ExecuteUdonEvent(); }), "Force Start Game Event", null, Color.green, true);
            GameAbortbtn = new QMSingleButton(Murder4CheatPage, 3, 2.5f, "Abort Game", new Action(() => { AbortGameEvent.ExecuteUdonEvent(); }), "Force Abort Game Event", null, Color.green, true);

            GameVictoryBystanderBtn = new QMSingleButton(Murder4CheatPage, 4, 2, "Victory Bystander", new Action(() => { VictoryBystanderEvent.ExecuteUdonEvent(); }), "Force Victory Bystander Event", null, Color.green, true);
            GameVictoryMurdererBtn = new QMSingleButton(Murder4CheatPage, 4, 2.5f, "Victory Murderer", new Action(() => { VictoryMurdererEvent.ExecuteUdonEvent(); }), "Force Victory Murderer Event", null, Color.red, true);
        }

        public static void ToggleKnifesGrab(bool Pickupable)
        {
            foreach (var knife in Knifes)
            {
                if (knife.GetComponent<PickupController>() == null)
                {
                    knife.AddComponent<PickupController>();
                }
                Pickup.SetPickupable(knife, Pickupable);
            }
        }

        public static void MakeKnifeGrabbableFromFar()
        {
            foreach (var knife in Knifes)
            {
                if (knife.GetComponent<PickupController>() == null)
                {
                    knife.AddComponent<PickupController>();
                }

                Pickup.SetPickupOrientation(knife, VRC.SDKBase.VRC_Pickup.PickupOrientation.Grip);
                Pickup.SetProximity(knife, 500f);
            }
        }

        public static void RestoreKnifeToWorldControl()
        {
            foreach (var knife in Knifes)
            {
                if (knife.GetComponent<PickupController>() == null)
                {
                    knife.AddComponent<PickupController>();
                }
                Pickup.RestoreOriginalProperty(knife);
            }
        }

        private static JarRoleESP GetLocalPlayerNode()
        {
            return JarRoleController.RoleEspComponents.Where(x => x.apiuser.displayName == LocalPlayerUtils.GetSelfPlayer().DisplayName()).First();
        }

        public override void OnUdonSyncRPCEvent(Player sender, GameObject obj, string action)
        {
            if (HasMurder4WorldLoaded)
            {

                if (obj != null && action.StartsWith("SyncAssign") && GetLocalPlayerNode().Node != null)
                {
                    if (RoleSwapper_GetDetectiveRole)
                    {
                        if (!SafetySwap)
                        {
                            if (obj == GetLocalPlayerNode().Node)
                            {
                                AssignedSelfRole = action;
                            }

                            if (action == "SyncAssignD")
                            {
                                TargetNode = obj;
                                AssignedTargetRole = action;
                            }

                            RoleSwapper_GetDetectiveRole = SwapRoles(GetLocalPlayerNode().Node, TargetNode, AssignedSelfRole, AssignedTargetRole);
                        }
                    }
                    else if (RoleSwapper_GetMurdererRole)
                    {
                        if (!SafetySwap) // In case it grabs and update the current ones already!
                        {
                            if (obj == GetLocalPlayerNode().Node)
                            {
                                AssignedSelfRole = action;
                            }

                            if (action == "SyncAssignM")
                            {
                                TargetNode = obj;
                                AssignedTargetRole = action;
                            }

                            RoleSwapper_GetMurdererRole = SwapRoles(GetLocalPlayerNode().Node, TargetNode, AssignedSelfRole, AssignedTargetRole);

                        }
                    }
                }
            }

        }





        public static bool SwapRoles(GameObject SelfNode, GameObject TargetNode, string AssignedSelfRole, string AssignedTargetRole)
        {
            if (SelfNode == null && TargetNode == null && AssignedSelfRole == null && AssignedTargetRole == null)
            {
                SafetySwap = false;
                return true; // Keep it active.
            }
            if(string.IsNullOrEmpty(AssignedSelfRole) && string.IsNullOrWhiteSpace(AssignedSelfRole))
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


            MiscUtility.DelayFunction(0.01f, new Action(() => {


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








        private static GameObject TargetNode;
        private static string AssignedTargetRole;

        private static string AssignedSelfRole;

        private static bool SafetySwap;

        // MAP GameObjects Required for control.

        public static QMSingleButton GameStartbtn;
        public static QMSingleButton GameAbortbtn;
        public static QMSingleButton GameVictoryBystanderBtn;
        public static QMSingleButton GameVictoryMurdererBtn;

        private static QMSingleButton PresentTeleporter;
        private static QMSingleButton PresentSpawner;
        private static QMSingleButton PresentClicker;

        private static QMSingleToggleButton DoUnlockedSoundbtn;

        private static bool _DoUnlockedSound;

        public static bool DoUnlockedSound
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
                    DoUnlockedSoundbtn.setToggleState(value);
                }
            }
        }

        public static QMSingleToggleButton KnifesGrabbableToggle;

        public static QMSingleButton KnifesGrabFromFar;
        private static bool _isChristmasMode;

        public static bool isChristmasMode
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
                    PresentClicker.setActive(value);
                }
                if (PresentSpawner != null)
                {
                    PresentSpawner.setActive(value);
                }
                if (PresentTeleporter != null)
                {
                    PresentTeleporter.setActive(value);
                }
            }
        }

        public static GameObject Clue_photograph = null;

        public static GameObject Clue_notebook = null;
        public static GameObject Clue_Locket = null;
        public static GameObject Clue_PocketWatch = null;
        public static GameObject Clue_Postcard = null;

        public static GameObject item_Knife_0 = null;
        public static GameObject item_Knife_1 = null;
        public static GameObject item_Knife_2 = null;
        public static GameObject item_Knife_3 = null;
        public static GameObject item_Knife_4 = null;
        public static GameObject item_Knife_5 = null;

        public static GameObject item_Bear_trap_0 = null;
        public static GameObject item_Bear_trap_1 = null;
        public static GameObject item_Bear_trap_2 = null;

        public static GameObject item_Shotgun = null;

        public static GameObject item_Silenced_Revolver_0 = null;
        public static GameObject item_Silenced_Revolver_1 = null;

        public static GameObject item_Grenade = null;

        public static GameObject item_DetectiveRevolver = null;

        public static GameObject Clue_Present = null;
        public static GameObject PatreonFlairtoggle = null;

        public static List<GameObject> Clues = new List<GameObject>();
        public static List<GameObject> DetectiveGuns = new List<GameObject>();
        public static List<GameObject> SilencedGuns = new List<GameObject>();
        public static List<GameObject> ShotGuns = new List<GameObject>();

        public static List<GameObject> ClonedKnife = new List<GameObject>();
        public static List<GameObject> Knifes = new List<GameObject>();
        public static List<GameObject> BearTraps = new List<GameObject>();
        public static List<GameObject> Grenades = new List<GameObject>();

        public static QMNestedButton Murder4CheatPage;

        public static CachedUdonEvent OnPlayerUnlockedClues;

        public static CachedUdonEvent StartGameEvent;
        public static CachedUdonEvent AbortGameEvent;

        public static CachedUdonEvent VictoryBystanderEvent;
        public static CachedUdonEvent VictoryMurdererEvent;

        public static QMSingleToggleButton GetDetectiveRoleBtn;
        public static QMSingleToggleButton GetMurdererRoleBtn;





        public static bool _RoleSwapper_GetDetectiveRole;

        public static bool RoleSwapper_GetDetectiveRole
        {
            get
            {
                return _RoleSwapper_GetDetectiveRole;
            }
            set
            {
                if(value == _RoleSwapper_GetDetectiveRole)
                {
                    return;
                }
                _RoleSwapper_GetDetectiveRole = value;
                if(GetDetectiveRoleBtn != null)
                {
                    GetDetectiveRoleBtn.setToggleState(value);
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

        public static bool _RoleSwapper_GetMurdererRole;
        public static bool RoleSwapper_GetMurdererRole
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
                    GetMurdererRoleBtn.setToggleState(value);
                }
                if (value)
                {
                    AssignedSelfRole = null;
                    AssignedTargetRole = null;
                    TargetNode = null;
                    SafetySwap = false;
                }
                if(!value)
                {
                    SafetySwap = false;
                }
            }
        }
        public static bool HasMurder4WorldLoaded = false;

    }
}