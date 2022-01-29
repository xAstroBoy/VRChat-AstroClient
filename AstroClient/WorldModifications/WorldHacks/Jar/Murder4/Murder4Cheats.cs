namespace AstroClient.WorldModifications.Modifications.Jar.Murder4
{
    #region Imports

    using AstroMonos.Components.Cheats.PatronUnlocker;
    using AstroMonos.Components.Cheats.Worlds.JarWorlds;
    using AstroMonos.Components.Cheats.Worlds.JarWorlds.Roles;
    using AstroMonos.Components.ESP.Pickup;
    using ClientUI.Menu.ESP;
    using Constants;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using MelonLoader;
    using Tools.Extensions;
    using Tools.Extensions.Components_exts;
    using Tools.UdonEditor;
    using UdonCheats;
    using UnityEngine;
    using VRC;
    using VRC.SDKBase;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;
    using static Constants.CustomLists;
    using Color = System.Drawing.Color;

    #endregion Imports

    internal class Murder4Cheats : AstroEvents
    {
        private static bool _UseGravity;

        private static bool _OnlySelfHasPatreonPerk;

        private static bool _EveryoneHasPatreonPerk;

        private static PatronUnlocker DetectiveGunPerkUnlocker;

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

        internal static QMToggleButton KnifesGrabbableToggle;

        internal static QMSingleButton KnifesGrabFromFar;
        private static bool _isChristmasMode;

        internal static GameObject Clue_photograph;

        internal static GameObject Clue_notebook;
        internal static GameObject Clue_Locket;
        internal static GameObject Clue_PocketWatch;
        internal static GameObject Clue_Postcard;

        internal static GameObject item_Knife_0;
        internal static GameObject item_Knife_1;
        internal static GameObject item_Knife_2;
        internal static GameObject item_Knife_3;
        internal static GameObject item_Knife_4;
        internal static GameObject item_Knife_5;

        internal static GameObject item_Bear_trap_0;
        internal static GameObject item_Bear_trap_1;
        internal static GameObject item_Bear_trap_2;

        internal static GameObject item_Shotgun;

        internal static GameObject item_Silenced_Revolver_0;
        internal static GameObject item_Silenced_Revolver_1;

        internal static GameObject item_Grenade;

        internal static GameObject item_DetectiveRevolver;

        internal static GameObject Clue_Present;
        internal static GameObject PatreonFlairtoggle;

        internal static GameObject Snake_Crate;

        internal static List<GameObject> Clues = new();
        internal static List<GameObject> DetectiveGuns = new();
        internal static List<GameObject> SilencedGuns = new();
        internal static List<GameObject> ShotGuns = new();

        internal static List<GameObject> Knifes = new();
        internal static List<GameObject> BearTraps = new();
        internal static List<GameObject> Grenades = new();

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

        internal static bool _RoleSwapper_GetMurdererRole;

        internal static bool HasMurder4WorldLoaded;

        internal static bool UseGravity
        {
            get => _UseGravity;
            set
            {
                DetectiveGuns.RigidBody_Set_Gravity(value);
                SilencedGuns.RigidBody_Set_Gravity(value);
                ShotGuns.RigidBody_Set_Gravity(value);
                BearTraps.RigidBody_Set_Gravity(value);
                Grenades.RigidBody_Set_Gravity(value);
                Knifes.RigidBody_Set_Gravity(value);
                if (ToggleGravityMode != null) ToggleGravityMode.SetToggleState(value);
                _UseGravity = value;
            }
        }

        internal static bool OnlySelfHasPatreonPerk
        {
            get => _OnlySelfHasPatreonPerk;
            set
            {
                _OnlySelfHasPatreonPerk = value;
                if (GetSelfPatreonGunBtn != null) GetSelfPatreonGunBtn.SetToggleState(value);
                if (DetectiveGunPerkUnlocker != null) DetectiveGunPerkUnlocker.OnlySelfHasPatreonPerk = value;
            }
        }

        internal static bool EveryoneHasPatreonPerk
        {
            get => _EveryoneHasPatreonPerk;
            set
            {
                _EveryoneHasPatreonPerk = value;
                if (GetEveryonePatreonGunBtn != null) GetEveryonePatreonGunBtn.SetToggleState(value);

                if (DetectiveGunPerkUnlocker != null) DetectiveGunPerkUnlocker.EveryoneHasPatreonPerk = value;
            }
        }

        internal static bool DoUnlockedSound
        {
            get => _DoUnlockedSound;
            set
            {
                _DoUnlockedSound = value;
                if (DoUnlockedSoundbtn != null) DoUnlockedSoundbtn.SetToggleState(value);
            }
        }

        internal static bool IsChristmasMode
        {
            get => _isChristmasMode;
            set
            {
                _isChristmasMode = value;
                if (PresentClicker != null) PresentClicker.SetActive(value);
                if (PresentSpawner != null) PresentSpawner.SetActive(value);
                if (PresentTeleporter != null) PresentTeleporter.SetActive(value);
            }
        }

        internal static bool RoleSwapper_GetDetectiveRole
        {
            get => _RoleSwapper_GetDetectiveRole;
            set
            {
                if (value == _RoleSwapper_GetDetectiveRole) return;
                _RoleSwapper_GetDetectiveRole = value;
                if (GetDetectiveRoleBtn != null) GetDetectiveRoleBtn.SetToggleState(value);
            }
        }

        internal static bool RoleSwapper_GetMurdererRole
        {
            get => _RoleSwapper_GetMurdererRole;
            set
            {
                if (value == _RoleSwapper_GetMurdererRole) return;
                _RoleSwapper_GetMurdererRole = value;
                if (GetMurdererRoleBtn != null) GetMurdererRoleBtn.SetToggleState(value);
            }
        }

        internal static void FindGameMurderObjects()
        {
            ModConsole.Log("Removing Anti-Peek Protection...");

            var occlusion = GameObjectFinder.Find("Environment/Occlusion");
            if (occlusion != null) occlusion.DestroyMeLocal();
            //var patronCheckFool = UdonSearch.FindUdonEvent("Patreon Data", "_start"); //  Not working.
            //if (patronCheckFool != null)
            //{
            //    ModConsole.Log("Unlocking Patron Perks.");
            //    if (!PlayerSpooferUtils.SpoofAsWorldAuthor)
            //    {
            //        PlayerSpooferUtils.SpoofAsWorldAuthor = true;
            //        patronCheckFool.Invoke();
            //        PlayerSpooferUtils.SpoofAsWorldAuthor = false;
            //    }
            //    else
            //    {
            //        patronCheckFool.Invoke();
            //    }
            //}
            item_DetectiveRevolver = GameObjectFinder.Find("Game Logic/Weapons/Revolver");
            if (item_DetectiveRevolver != null) DetectiveGunPerkUnlocker = item_DetectiveRevolver.GetOrAddComponent<PatronUnlocker>();
            Clue_photograph = GameObjectFinder.Find("Game Logic/Clues/Clue (photograph)");
            Clue_notebook = GameObjectFinder.Find("Game Logic/Clues/Clue (notebook)");
            Clue_Locket = GameObjectFinder.Find("Game Logic/Clues/Clue (locket)");
            Clue_PocketWatch = GameObjectFinder.Find("Game Logic/Clues/Clue (pocketwatch)");
            Clue_Postcard = GameObjectFinder.Find("Game Logic/Clues/Clue (postcard)");
            if (!IsChristmasMode)
            {
                Clue_Present = GameObjectFinder.Find("Game Logic/Clues (xmas)/Clue (present) (5)");
                if (Clue_Present != null)
                    IsChristmasMode = true;
                else
                    ModConsole.Log("Could Not Find The Present Clue!");
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
                if (action.gameObject.name == "Game Logic")
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

            if (GameStartbtn != null)
            {
                GameStartbtn.SetActive(StartGameEvent.IsNotNull());
                GameStartbtn.SetInteractable(StartGameEvent.IsNotNull());
            }

            if (GameAbortbtn != null)
            {
                GameAbortbtn.SetActive(AbortGameEvent.IsNotNull());
                GameAbortbtn.SetInteractable(AbortGameEvent.IsNotNull());
            }

            if (GameVictoryBystanderBtn != null)
            {
                GameVictoryBystanderBtn.SetActive(VictoryBystanderEvent.IsNotNull());
                GameVictoryBystanderBtn.SetInteractable(VictoryBystanderEvent.IsNotNull());
            }

            if (GameVictoryMurdererBtn != null)
            {
                GameVictoryMurdererBtn.SetActive(VictoryMurdererEvent.IsNotNull());
                GameVictoryMurdererBtn.SetInteractable(VictoryMurdererEvent.IsNotNull());
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
            DetectiveGuns.Add_Bouncer();
            SilencedGuns.Add_Bouncer();
            ShotGuns.Add_Bouncer();
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
                    ModConsole.Log($"Recognized {Name} World, Unlocking Murder 4 cheats menu!", Color.Green);
                    Murder4CheatPage.GetMainButton().SetInteractable(true);
                    Murder4CheatPage.GetMainButton().SetTextColor(UnityEngine.Color.green);
                }

                FindGameMurderObjects();
            }
            else
            {
                HasMurder4WorldLoaded = false;
                if (Murder4CheatPage != null)
                {
                    Murder4CheatPage.GetMainButton().SetInteractable(false);
                    Murder4CheatPage.GetMainButton().SetTextColor(UnityEngine.Color.red);
                }
            }
        }

        internal override void OnRoomLeft()
        {
            if (KnifesGrabbableToggle != null) KnifesGrabbableToggle.SetToggleState(false);
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
            CancellationToken = null;
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
            RoleSwapper_GetDetectiveRole = false;
            RoleSwapper_GetMurdererRole = false;
            EveryoneHasPatreonPerk = false;
            OnlySelfHasPatreonPerk = false;
            Snake_Crate = null;
            if (Murder4ESPtoggler != null) Murder4ESPtoggler.SetToggleState(false);
            UseGravity = true;
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

                MiscUtils.DelayFunction(1, () =>
                {
                    Clues.Set_Pickup_ESP_Color("87F368");
                    DetectiveGuns.Set_Pickup_ESP_Color("688CF3");
                    SilencedGuns.Set_Pickup_ESP_Color("C8F36D");
                    ShotGuns.Set_Pickup_ESP_Color("C8F36D");
                    Knifes.Set_Pickup_ESP_Color("F96262");
                    BearTraps.Set_Pickup_ESP_Color("F96262");
                    Grenades.Set_Pickup_ESP_Color("F96262");
                    Snake_Crate.Set_Pickup_ESP_Color("F96262");
                });
            }
            else
            {
                foreach (var item in Clues)
                {
                    var esp = item.GetComponent<ESP_Pickup>();
                    if (esp != null) esp.DestroyMeLocal();
                }

                var Snake_Crate_ESP = Snake_Crate.GetComponent<ESP_Pickup>();
                if (Snake_Crate_ESP != null) Snake_Crate_ESP.DestroyMeLocal();
            }
        }

        internal static void Murder4CheatsButtons(QMGridTab submenu)
        {
            Murder4CheatPage = new QMNestedGridMenu(submenu, "Murder 4 Cheats", "Manage Murder 4 Cheats");
            Murder4CheatPage.GetMainButton();

            var MurderItemTeleporter = new QMNestedGridMenu(Murder4CheatPage, "Item Teleporter", "Size Items Editor");

            #region Item Teleporter

            DoUnlockedSoundbtn = new QMToggleButton(MurderItemTeleporter, 0, 0, "Do Sound", () => { DoUnlockedSound = true; }, "Quiet Mode", () => { DoUnlockedSound = false; }, "Should i run the Sound action on pickups teleport.");
            _ = new QMSingleButton(MurderItemTeleporter, "Clues!", () => { Clues.TeleportToMe(); }, "Clue Teleporter!");
            _ = new QMSingleButton(MurderItemTeleporter, "Photograph!", () => { Clue_photograph.TeleportToMe(); }, "Clue Teleporter!");
            _ = new QMSingleButton(MurderItemTeleporter, "Notebook!", () => { Clue_notebook.TeleportToMe(); }, "Clue Teleporter!");
            _ = new QMSingleButton(MurderItemTeleporter, "Locket!", () => { Clue_Locket.TeleportToMe(); }, "Clue Teleporter!");
            _ = new QMSingleButton(MurderItemTeleporter, "PocketWatch!", () => { Clue_PocketWatch.TeleportToMe(); }, "Clue Teleporter!");
            _ = new QMSingleButton(MurderItemTeleporter, "Postcard!", () => { Clue_Postcard.TeleportToMe(); }, "Clue Teleporter!");
            _ = new QMSingleButton(MurderItemTeleporter, "Shotgun!", () =>
            {
                item_Shotgun.TeleportToMe();
                if (DoUnlockedSound) OnPlayerUnlockedClues.InvokeBehaviour();
            }, "Shotgun Gun Teleporter!");
            _ = new QMSingleButton(MurderItemTeleporter, "Detective Gun!", () =>
            {
                item_DetectiveRevolver.TeleportToMe();
                if (DoUnlockedSound) OnPlayerUnlockedClues.InvokeBehaviour();
            }, "Detective Gun Teleporter!");
            _ = new QMSingleButton(MurderItemTeleporter, "Silenced Gun 1!", () =>
            {
                item_Silenced_Revolver_0.TeleportToMe();
                if (DoUnlockedSound) OnPlayerUnlockedClues.InvokeBehaviour();
            }, "Silenced Gun Teleporter!");
            _ = new QMSingleButton(MurderItemTeleporter, "Silenced Gun 2!", () =>
            {
                item_Silenced_Revolver_1.TeleportToMe();
                if (DoUnlockedSound) OnPlayerUnlockedClues.InvokeBehaviour();
            }, "Silenced Gun Teleporter!");
            _ = new QMSingleButton(MurderItemTeleporter, "Grenade!", () =>
            {
                item_Grenade.TeleportToMe();
                if (DoUnlockedSound) OnPlayerUnlockedClues.InvokeBehaviour();
            }, "Grenade Teleporter!");
            _ = new QMSingleButton(MurderItemTeleporter, "Traps!", () =>
            {
                BearTraps.TeleportToMe();
                if (DoUnlockedSound) OnPlayerUnlockedClues.InvokeBehaviour();
            }, "Silenced Gun Teleporter!");
            PresentTeleporter = new QMSingleButton(MurderItemTeleporter, 1, 2, "Present!", () => { Clue_Present.TeleportToMe(); }, "Clue Teleporter!");

            #endregion Item Teleporter

            var MurderItemTweaker = new QMNestedGridMenu(Murder4CheatPage, "Item Tweaker", "Item Tweaks!");

            #region Item Tweaker

            new QMSingleButton(MurderItemTweaker, "Knifes (Bouncer)!", () => { Knifes.Add_Bouncer(); }, "Bouncer!");
            new QMSingleButton(MurderItemTweaker, "Guns (Bouncer)!", () => { MurderGunsBounce(); }, "Bouncer!");
            new QMSingleButton(MurderItemTweaker, "Grenades (Bouncer)!", () => { Grenades.Add_Bouncer(); }, "Bouncer!");
            new QMSingleButton(MurderItemTweaker, "Bear Trap (Bouncer)!", () => { BearTraps.Add_Bouncer(); }, "Bouncer!");
            new QMSingleButton(MurderItemTweaker, "Clues (Bouncer)!", () => { Clues.Add_Bouncer(); }, "Bouncer");
            new QMSingleButton(MurderItemTweaker, "Kill Bouncer Effects!", () => { RemoveBouncers(); }, "Remove Bouncing effect to all items");

            new QMSingleButton(MurderItemTweaker, "Knifes (Rockets)!", () => { Knifes.Add_Rocket_Component(false); }, "Rockets!");
            new QMSingleButton(MurderItemTweaker, "Guns (Rockets)!", () => { MurderGunsRockets(); }, "Rockets!");
            new QMSingleButton(MurderItemTweaker, "Grenades (Rockets)!", () => { Grenades.Add_Rocket_Component(false); }, "Rockets!");
            new QMSingleButton(MurderItemTweaker, "Bear Trap (Rockets)!", () => { BearTraps.Add_Rocket_Component(false); }, "Rockets!");
            new QMSingleButton(MurderItemTweaker, "Clues (Rockets)!", () => { Clues.Add_Rocket_Component(false); }, "Rockets");
            new QMSingleButton(MurderItemTweaker, "Kill Rocket Effects!", () => { RemoveRockets(); }, "Remove Rocket effect to all items");

            new QMSingleButton(MurderItemTweaker, "Knifes (Crazy)!", () => { Knifes.Add_Crazy_Component(false); }, "Make Knifes in Instance go nuts!");
            new QMSingleButton(MurderItemTweaker, "Guns (Crazy)!", MurderGunsCrazy, "Make Guns in Instance go nuts!");
            new QMSingleButton(MurderItemTweaker, "Clues (Crazy)!", () => { Clues.Add_Crazy_Component(false); }, "Make Clues in Instance go nuts!");
            new QMSingleButton(MurderItemTweaker, "Grenade (Crazy)!", () => { Grenades.Add_Crazy_Component(false); }, "Make Grenade in Instance go nuts!");
            new QMSingleButton(MurderItemTweaker, "Bear Trap (Crazy)!", () => { BearTraps.Add_Crazy_Component(false); }, "Make Grenade in Instance go nuts!");
            new QMSingleButton(MurderItemTweaker, "Kill Crazy Effects!", () => { RemoveCrazy(); }, "Remove Crazy effect to all items");

            _ = new QMSingleButton(MurderItemTweaker, "Allow Gun Theft in Murder!", AllowTheft, "Allows you to steal items from other people!");
            ToggleGravityMode = new QMToggleButton(MurderItemTweaker, "Fall (World Gravity)", () => { UseGravity = true; }, "Float (Space Mode)", () => { UseGravity = false; }, "Tweaks all Murder! items gravity!");

            KnifesGrabbableToggle = new QMToggleButton(MurderItemTweaker, "Can Grab Knifes", () => { ToggleKnifesGrab(true); }, "Cannot Grab Knifes", () => { ToggleKnifesGrab(false); }, "Tweaks all Murder! items gravity!");
            new QMSingleButton(MurderItemTweaker, "Knifes Grabbable from far!", () => { MakeKnifeGrabbableFromFar(); }, "Make Knifes Grabbable from far!");
            ;
            new QMSingleButton(MurderItemTweaker, "Restore Knifes Properties to world!", () => { RestoreKnifeToWorldControl(); }, "Restore Control to world!");
            ;

            #endregion Item Tweaker

            var MurderItemSpawner = new QMNestedGridMenu(Murder4CheatPage, "Item Spawner", "Item Spawner!");

            #region Item Spawner

            _ = new QMSingleButton(MurderItemSpawner, "Spawn Detective Gun", () => { item_DetectiveRevolver.CloneObject(); }, "Detective Gun Cloner!");
            _ = new QMSingleButton(MurderItemSpawner, "Spawn Silenced Gun", () => { item_Silenced_Revolver_0.CloneObject(); }, "Silenced Gun Cloner!");
            _ = new QMSingleButton(MurderItemSpawner, "Spawn Shotgun", () => { item_Shotgun.CloneObject(); }, "Shotgun Cloner!");
            _ = new QMSingleButton(MurderItemSpawner, "Spawn Knife", () => { item_Knife_0.CloneObject(); }, "Knife Cloner!");
            _ = new QMSingleButton(MurderItemSpawner, "Spawn Grenade", () => { item_Grenade.CloneObject(); }, "Grenade Cloner!");
            _ = new QMSingleButton(MurderItemSpawner, "Spawn Bear Trap", () => { item_Bear_trap_1.CloneObject(); }, "Bear Trap Cloner!");
            _ = new QMSingleButton(MurderItemSpawner, "Spawn photograph!", () => { Clue_photograph.CloneObject(); }, "Clue Cloner!");
            _ = new QMSingleButton(MurderItemSpawner, "Spawn notebook!", () => { Clue_notebook.CloneObject(); }, "Clue Cloner!");
            _ = new QMSingleButton(MurderItemSpawner, "Spawn Locket!", () => { Clue_Locket.CloneObject(); }, "Clue Cloner!");
            _ = new QMSingleButton(MurderItemSpawner, "Spawn PocketWatch!", () => { Clue_PocketWatch.CloneObject(); }, "Clue Cloner!");
            _ = new QMSingleButton(MurderItemSpawner, "Spawn Postcard!", () => { Clue_Postcard.CloneObject(); }, "Clue Cloner!");
            PresentSpawner = new QMSingleButton(MurderItemSpawner, "Spawn Present!", () => { Clue_Present.CloneObject(); }, "Clue Teleporter!");

            #endregion Item Spawner

            if (Bools.AllowAttackerComponent)
            {
                var MurderItemAttackerMenu = new QMNestedGridMenu(Murder4CheatPage, "Followers", "Murder item Followers!");

                #region Followers

                new QMSingleButton(MurderItemAttackerMenu, "Detective Gun (target)!", () => { DetectiveGuns.AttackTarget(); }, "Make Detective Gun follow Target");
                new QMSingleButton(MurderItemAttackerMenu, "Silenced Guns (target)!", () => { SilencedGuns.AttackTarget(); }, "Make Silenced Gun follow Target");
                new QMSingleButton(MurderItemAttackerMenu, "Knifes (target)!", () => { Knifes.AttackTarget(); }, "Make Knifes follow Target");
                new QMSingleButton(MurderItemAttackerMenu, "Clues (target)!", () => { Clues.AttackTarget(); }, "Make Clues follow Target");
                new QMSingleButton(MurderItemAttackerMenu, "Grenade (target)!", () => { Grenades.AttackTarget(); }, "Make Grenade follow Target");
                new QMSingleButton(MurderItemAttackerMenu, "Shotgun (target)!", () => { ShotGuns.AttackTarget(); }, "Make Bear Traps follow Target");
                new QMSingleButton(MurderItemAttackerMenu, "Bear traps (target)!", () => { BearTraps.AttackTarget(); }, "Make Bear Traps follow Target");

                new QMSingleButton(MurderItemAttackerMenu, "Detective Gun (you)!", () => { DetectiveGuns.AttackSelf(); }, "Make Detective Gun follow you");
                new QMSingleButton(MurderItemAttackerMenu, "Silenced Guns (you)!", () => { SilencedGuns.AttackSelf(); }, "Make Silenced Gun follow you");
                new QMSingleButton(MurderItemAttackerMenu, "Knifes (you)!", () => { Knifes.AttackSelf(); }, "Make Knifes follow you");
                new QMSingleButton(MurderItemAttackerMenu, "Clues (you)!", () => { Clues.AttackSelf(); }, "Make Clues follow you");
                new QMSingleButton(MurderItemAttackerMenu, "Grenade (you)!", () => { Grenades.AttackSelf(); }, "Make Grenade follow you");
                new QMSingleButton(MurderItemAttackerMenu, "Shotgun (you)!", () => { ShotGuns.AttackSelf(); }, "Make Shotgun follow you");
                new QMSingleButton(MurderItemAttackerMenu, "Bear traps (you)!", () => { BearTraps.AttackSelf(); }, "Make Bear Traps follow you");

                #endregion Followers
            }

            if (Bools.AllowOrbitComponent)
            {
                var MurderItemOrbiterMenu = new QMNestedGridMenu(Murder4CheatPage, "Orbiters", "Murder item Orbits!");

                #region orbiters

                new QMSingleButton(MurderItemOrbiterMenu, "Detective Gun (target)!", () => { DetectiveGuns.OrbitTarget(); }, "Make Detective Gun orbit around Target");
                new QMSingleButton(MurderItemOrbiterMenu, "Silenced Guns (target)!", () => { SilencedGuns.OrbitTarget(); }, "Make Silenced Gun around orbit Target");
                new QMSingleButton(MurderItemOrbiterMenu, "Shotgun (target)!", () => { ShotGuns.OrbitTarget(); }, "Make ShotGun orbit around Target");
                new QMSingleButton(MurderItemOrbiterMenu, "Knifes (target)!", () => { Knifes.OrbitTarget(); }, "Make Knifes orbit around Target");
                new QMSingleButton(MurderItemOrbiterMenu, "Clues (target)!", () => { Clues.OrbitTarget(); }, "Make Clues orbit around Target");
                new QMSingleButton(MurderItemOrbiterMenu, "Grenade (target)!", () => { Grenades.OrbitTarget(); }, "Make Grenade orbit around Target");
                new QMSingleButton(MurderItemOrbiterMenu, "Bear Trap (target)!", () => { BearTraps.OrbitTarget(); }, "Make Bear Traps orbit around Target");

                new QMSingleButton(MurderItemOrbiterMenu, "Detective Gun (you)!", () => { DetectiveGuns.OrbitSelf(); }, "Make Detective Gun orbit around you");
                new QMSingleButton(MurderItemOrbiterMenu, "Silenced Guns (you)!", () => { SilencedGuns.OrbitSelf(); }, "Make Silenced Gun around orbit you");
                new QMSingleButton(MurderItemOrbiterMenu, "Shotgun (you)!", () => { ShotGuns.OrbitSelf(); }, "Make ShotGun orbit around you");
                new QMSingleButton(MurderItemOrbiterMenu, "Knifes (you)!", () => { Knifes.OrbitSelf(); }, "Make Knifes orbit around you");
                new QMSingleButton(MurderItemOrbiterMenu, "Clues (you)!", () => { Clues.OrbitSelf(); }, "Make Clues orbit around you");
                new QMSingleButton(MurderItemOrbiterMenu, "Grenade (you)!", () => { Grenades.OrbitSelf(); }, "Make Grenade orbit around you");
                new QMSingleButton(MurderItemOrbiterMenu, "Bear Trap (you)!", () => { BearTraps.OrbitSelf(); }, "Make Bear Traps orbit around you");

                #endregion orbiters
            }

            var MurderItemClicker = new QMNestedGridMenu(Murder4CheatPage, "Items Clicker", "Interact with Items!");

            #region Items Clicker

            _ = new QMSingleButton(MurderItemClicker, "Click photograph!", () => { Clue_photograph.VRC_Interactable_Click(); }, "Click!");
            _ = new QMSingleButton(MurderItemClicker, "Click notebook!", () => { Clue_notebook.VRC_Interactable_Click(); }, "Click!");
            _ = new QMSingleButton(MurderItemClicker, "Click Locket!", () => { Clue_Locket.VRC_Interactable_Click(); }, "Click!");
            _ = new QMSingleButton(MurderItemClicker, "Click PocketWatch!", () => { Clue_PocketWatch.VRC_Interactable_Click(); }, "Click!");
            _ = new QMSingleButton(MurderItemClicker, "Click Postcard!", () => { Clue_Postcard.VRC_Interactable_Click(); }, "Click!");
            PresentClicker = new QMSingleButton(MurderItemSpawner, "Click Present!", () => { Clue_Present.VRC_Interactable_Click(); }, "Click!");

            _ = new QMSingleButton(MurderItemClicker, "Unlock Random Weapon!", () => { Clues.VRC_Interactable_Click(); }, "Unlock Random Weapon!");

            #endregion Items Clicker

            var MurderItemWatchMenu = new QMNestedGridMenu(Murder4CheatPage, "Watchers", "Murder item Watchers!");

            #region Watchers

            new QMSingleButton(MurderItemWatchMenu, "Detective Gun (target)!", () => { DetectiveGuns.WatchTarget(); }, "Make Detective Gun Watch Target");
            new QMSingleButton(MurderItemWatchMenu, "Silenced Guns (target)!", () => { SilencedGuns.WatchTarget(); }, "Make Silenced Gun Watch Target");
            new QMSingleButton(MurderItemWatchMenu, "Knifes (target)!", () => { Knifes.WatchTarget(); }, "Make Knifes Watch Target");
            new QMSingleButton(MurderItemWatchMenu, "Clues (target)!", () => { Clues.WatchTarget(); }, "Make Clues Watch Target");
            new QMSingleButton(MurderItemWatchMenu, "Grenade (target)!", () => { Grenades.WatchTarget(); }, "Make Grenade Watch Target");
            new QMSingleButton(MurderItemWatchMenu, "Shotgun (target)!", () => { ShotGuns.WatchTarget(); }, "Make Bear Traps Watch Target");
            new QMSingleButton(MurderItemWatchMenu, "Bear traps (target)!", () => { BearTraps.WatchTarget(); }, "Make Bear Traps Watch Target");

            new QMSingleButton(MurderItemWatchMenu, "Detective Gun (you)!", () => { DetectiveGuns.WatchSelf(); }, "Make Detective Gun Watch you");
            new QMSingleButton(MurderItemWatchMenu, "Silenced Guns (you)!", () => { SilencedGuns.WatchSelf(); }, "Make Silenced Gun Watch you");
            new QMSingleButton(MurderItemWatchMenu, "Knifes (you)!", () => { Knifes.WatchSelf(); }, "Make Knifes Watch you");
            new QMSingleButton(MurderItemWatchMenu, "Clues (you)!", () => { Clues.WatchSelf(); }, "Make Clues Watch you");
            new QMSingleButton(MurderItemWatchMenu, "Grenade (you)!", () => { Grenades.WatchSelf(); }, "Make Grenade Watch you");
            new QMSingleButton(MurderItemWatchMenu, "Shotgun (you)!", () => { ShotGuns.WatchSelf(); }, "Make Bear Traps Watch you");
            new QMSingleButton(MurderItemWatchMenu, "Bear traps (you)!", () => { BearTraps.WatchSelf(); }, "Make Bear Traps Watch you");

            #endregion Watchers

            var Cheats = new QMNestedGridMenu(Murder4CheatPage, "World Cheats", "Some Powerful cheats!");

            GetSelfPatreonGunBtn = new QMToggleButton(Cheats, "Private Golden Gun", () =>
            {
                OnlySelfHasPatreonPerk = true;
                EveryoneHasPatreonPerk = false;
            }, "Private Golden Gun", () => { OnlySelfHasPatreonPerk = false; }, "Unlocks The Patreon Perks (Golden Gun) For You!");
            GetEveryonePatreonGunBtn = new QMToggleButton(Cheats, "Public Golden Gun", () =>
            {
                EveryoneHasPatreonPerk = true;
                OnlySelfHasPatreonPerk = false;
            }, "Public Golden Gun", () => { EveryoneHasPatreonPerk = false; }, "Unlocks The Patreon Perks (Golden Gun) For Everyone!");

            GetDetectiveRoleBtn = new QMToggleButton(Cheats, "Get Detective Role", () =>
            {
                RoleSwapper_GetDetectiveRole = true;
                RoleSwapper_GetMurdererRole = false;
            }, "Get Detective Role", () => { RoleSwapper_GetDetectiveRole = false; }, "Assign Yourself Detective Role on Next Round!");
            GetMurdererRoleBtn = new QMToggleButton(Cheats, "Get Murderer Role", () =>
            {
                RoleSwapper_GetMurdererRole = true;
                RoleSwapper_GetDetectiveRole = false;
            }, "Get Murderer Role", () => { RoleSwapper_GetMurdererRole = false; }, "Assign Yourself Murderer Role on Next Round!");

            Murder4ESPtoggler = new QMToggleButton(Cheats, "Item ESP On", () => { ToggleItemESP(true); }, "Item ESP Off", () => { ToggleItemESP(false); }, "Reveals All murder items position.");
            JarRoleController.Murder4RolesRevealerToggle = new QMToggleButton(Cheats, "Reveal Roles", () => { JarRoleController.ViewRoles = true; }, () => { JarRoleController.ViewRoles = false; }, "Reveals Current Players Roles In nameplates.");

            Murder4_GameLogic.InitButtons(Cheats);
            Murder4_FilteredNodes.InitButtons(Cheats);
            Murder4_UnfilteredNodes.InitButtons(Cheats);
            Murder4_RoleSwapper.InitButtons(Cheats);

            GameAbortbtn = new QMSingleButton(Cheats, "Abort Game", () => { AbortGameEvent.InvokeBehaviour(); }, "Force Abort Game Event", Color.Red);
            GameVictoryBystanderBtn = new QMSingleButton(Cheats, "Victory Bystander", () => { VictoryBystanderEvent.InvokeBehaviour(); }, "Force Victory Bystander Event", Color.Red);
            GameVictoryMurdererBtn = new QMSingleButton(Cheats, "Victory Murderer", () => { VictoryMurdererEvent.InvokeBehaviour(); }, "Force Victory Murderer Event", Color.Red);
            GameStartbtn = new QMSingleButton(Cheats, "Start Game", () => { StartGameEvent.InvokeBehaviour(); }, "Force Start Game Event", Color.GreenYellow);
        }

        internal static void ToggleKnifesGrab(bool Pickupable)
        {
            foreach (var knife in Knifes) knife.Pickup_Set_Pickupable(Pickupable);
        }

        internal static void MakeKnifeGrabbableFromFar()
        {
            foreach (var knife in Knifes)
            {
                knife.Pickup_Set_PickupOrientation(VRC_Pickup.PickupOrientation.Grip);
                knife.Pickup_Set_proximity(500f);
            }
        }

        internal static void RestoreKnifeToWorldControl()
        {
            foreach (var knife in Knifes) knife.Pickup_RestoreOriginalProperties();
        }

        internal static Murder4_ESP FindNodeWithRole(Murder4_Roles role)
        {
            for (var index = 0; index < JarRoleController.Murder4_ESPs.Count; index++)
            {
                var item = JarRoleController.Murder4_ESPs[index];
                if (item != null)
                    if (item.CurrentRole == role)
                        return item;
            }

            return null;
        }

        internal override void OnUdonSyncRPCEvent(Player sender, GameObject obj, string action)
        {
            try
            {
                if (obj == null) return;
                if (sender == null) return;
                if (HasMurder4WorldLoaded)
                {
                    if (action is "SyncVictoryB" or "SyncVictoryM" or "SyncAbort" or "SyncStart")
                    {
                        Knifes.KillCustomComponents(false);
                        DetectiveGuns.KillCustomComponents(false);
                        SilencedGuns.KillCustomComponents(false);
                        ShotGuns.KillCustomComponents(false);
                        BearTraps.KillCustomComponents(false);
                        Grenades.KillCustomComponents(false);
                        Knifes.KillCustomComponents(false);
                        if (!UseGravity) UseGravity = true;
                        return;
                    }
                    if (action.StartsWith("SyncAssign"))
                    {
                        if (RoleSwapper_GetDetectiveRole)
                        {
                            RoleSwapper_GetDetectiveRole = false;
                            ModConsole.DebugLog("Starting Swapping for Detective Role!");
                            if (CancellationToken == null)
                            {
                                CancellationToken = MelonCoroutines.Start(SwapRole(Murder4_Roles.Detective));
                            }
                        }
                        if (RoleSwapper_GetMurdererRole)
                        {
                            RoleSwapper_GetMurdererRole = false;
                            ModConsole.DebugLog("Starting Swapping for Murderer role!");
                            if (CancellationToken == null)
                            {
                                CancellationToken = MelonCoroutines.Start(SwapRole(Murder4_Roles.Murderer));
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private static object CancellationToken;
        private static IEnumerator SwapRole(Murder4_Roles Selectedrole)
        {
            while (JarRoleController.CurrentPlayer_Murder4ESP.CurrentRole == Murder4_Roles.None)
                yield return new WaitForEndOfFrame();
            while (FindNodeWithRole(Selectedrole) == null)
                yield return new WaitForEndOfFrame();
            ModConsole.DebugLog("Initiating Swap!");
            var TargetNode = FindNodeWithRole(Selectedrole);
            if (TargetNode != null)
            {
                SwapRoles(TargetNode);
            }

            CancellationToken = null;
        }

        internal static void SwapRoles(Murder4_ESP TargetESP)
        {
            var AssignedSelfRole = JarRoleController.CurrentPlayer_Murder4ESP.CurrentRole;
            var AssignedTargetRole = TargetESP.CurrentRole;
            if (JarRoleController.CurrentPlayer_Murder4ESP == TargetESP)
            {
                ModConsole.DebugLog("Target Node and SelfNode are the same!");
                return;
            }

            if (AssignedTargetRole == JarRoleController.CurrentPlayer_Murder4ESP.CurrentRole)
            {
                ModConsole.DebugLog("Target Role  and Self Role  are the same!");
                return;
            }

            //MiscUtils.DelayFunction(0.1f, new Action(() =>
            //{
            //}));

            if (TargetESP != null) TargetESP.SetRole(AssignedSelfRole);
            if (JarRoleController.CurrentPlayer_Murder4ESP != null) JarRoleController.CurrentPlayer_Murder4ESP.SetRole(AssignedTargetRole);
            ModConsole.DebugLog($"Executed Role Swapping!, {TargetESP.Player.DisplayName()} Has Role : {AssignedSelfRole}, You have {AssignedTargetRole}.");
        }
    }
}