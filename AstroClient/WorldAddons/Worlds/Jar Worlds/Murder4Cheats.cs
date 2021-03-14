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
using System.Collections;
using UnityEngine.UI;
using VRC;
using MelonLoader;
using AstroClient.components;
using System.Threading.Tasks;
using System.Threading;
using AstroClient.UdonExploits;
using AstroClient.ButtonShortcut;
#endregion AstroClient Imports

namespace AstroClient
{
    public static class Murder4Cheats
    {
        // TODO: FIGURE HOW TO FIX PARTICLES (ONLY GOLD CAMO WORKS)
        public static void UnlockPatreonTiers()
        {

            //PatreonFlairtoggle = GameObjectFinder.Find("Game Logic/Options Canvas/Contents/Toggle (Patron Flair)");
            //if (PatreonFlairtoggle != null)
            //{
            //    var patreonlbl = PatreonFlairtoggle.transform.Find("Label (Patrons)");
            //    var nonpatreonlbl = PatreonFlairtoggle.transform.Find("Label (Non patrons)");
            //    if (patreonlbl != null && nonpatreonlbl != null)
            //    {
            //        var text1 = nonpatreonlbl.GetComponentInChildren<Text>();
            //        var text2 = patreonlbl.GetComponentInChildren<Text>();

            //        if (text1 != null && text2 != null)
            //        {
            //            text1.color = Color.yellow;
            //            text1.text = "Hacked " + text2.text;
            //        }
            //    }

            //    var toggle = PatreonFlairtoggle.GetComponent<UnityEngine.UI.Toggle>();
            //    if (toggle != null)
            //    {
            //        ModConsole.Log("Found Patreon Internal Toggle, Unlocking..!");
            //        toggle.interactable = true;
            //        toggle.isOn = true;
            //    }
            //}


            //ModConsole.Log("Unlocking Gold Revolver camo (patreon only)...");
            //var DetectiveRecoil = GameObjectFinder.Find("Game Logic/Weapons/Revolver/Recoil Anim/Recoil");
            //if (DetectiveRecoil != null)
            //{
            //    var patreonskin = DetectiveRecoil.transform.Find("geo (patron)");
            //    var nonpatreon = DetectiveRecoil.transform.Find("geo");
            //    if (patreonskin != null && nonpatreon != null)
            //    {
            //        ModConsole.Log("Replacing non patreon skin.");
            //        var oldrend = nonpatreon.GetComponent<MeshRenderer>();
            //        var patreonrend = patreonskin.GetComponent<MeshRenderer>();
            //        if (oldrend != null && patreonrend != null)
            //        {
            //            oldrend.DestroyMeLocal();
            //        }
            //        if (oldrend == null && patreonrend != null)
            //        {
            //            oldrend = nonpatreon.gameObject.CopyComponent(patreonrend);
            //            if (oldrend != null)
            //            {
            //                oldrend.enabled = true;
            //                ModConsole.Log("Replaced Revolver Skin with Patreon Camo");
            //                //ModConsole.Log("Adding Particles...");
            //                //var PatreonParticles = patreonskin.transform.Find("Patron gun particles");
            //                //if (PatreonParticles != null)
            //                //{

            //                //    var particleholder = new GameObject();
            //                //    if (particleholder != null)
            //                //    {
            //                //        particleholder.RenameObject("Gun Particles");

            //                //        var particlesystem = PatreonParticles.GetComponentInChildren<ParticleSystem>();
            //                //        var particlesystemrenderer = PatreonParticles.GetComponentInChildren<ParticleSystemRenderer>();

            //                //        var Clone_particlesystem = particleholder.GetComponentInChildren<ParticleSystem>();
            //                //        var Clone_particlesystemrenderer = particleholder.GetComponentInChildren<ParticleSystemRenderer>();
            //                //        if (Clone_particlesystem != null)
            //                //        {
            //                //            Clone_particlesystem.DestroyMeLocal();
            //                //        }
            //                //        if(Clone_particlesystemrenderer != null)
            //                //        {
            //                //            Clone_particlesystemrenderer.DestroyMeLocal();
            //                //        }
            //                //        //particleholder.transform.CopyTransform(PatreonParticles.transform);
            //                //        particleholder.transform.SetParent(nonpatreon);

            //                //        if(Clone_particlesystemrenderer == null)
            //                //        {
            //                //            Clone_particlesystemrenderer = particleholder.AddComponent<ParticleSystemRenderer>().GetCopyOf<ParticleSystemRenderer>(particlesystemrenderer);
            //                //            ModConsole.Log("Clone_particlesystemrenderer set to : " + Clone_particlesystemrenderer.transform.name);
            //                //        }
            //                //        if (Clone_particlesystem == null)
            //                //        {
            //                //            Clone_particlesystem = particleholder.AddComponent<ParticleSystem>().GetCopyOf<ParticleSystem>(particlesystem);
            //                //            ModConsole.Log("Clone_particlesystem set to : " + Clone_particlesystem.transform.name);

            //                //        }


            //                //        particleholder.SetActiveRecursively(true);
            //                //    }
            //                //}
            //            }
            //        }
            //    }
            //}
        }


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
            if (isChristmasMode)
            {
                Clue_Present = GameObjectFinder.Find("Game Logic/Clues (xmas)/Clue (present) (5)");
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

            item_Grenade.RenameObject("Grenade");
            item_Silenced_Revolver_0.RenameObject("Silenced Revolver");
            item_Silenced_Revolver_1.RenameObject("Silenced Revolver 1");

            Clues.AddGameObject(Clue_photograph);
            Clues.AddGameObject(Clue_notebook);
            Clues.AddGameObject(Clue_Locket);
            Clues.AddGameObject(Clue_PocketWatch);
            Clues.AddGameObject(Clue_Postcard);
            if (isChristmasMode)
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
            float box = 0.03f;
            Clues.AddBoxCollider(new Vector3(box, box, box));

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



        public static void OnWorldReveal()
        {
            if (WorldUtils.GetWorldID() == "wrld_858dfdfc-1b48-4e1e-8a43-f0edc611e5fe")
            {
                HasMurder4WorldLoaded = true;
                if (Murder4CheatPage != null)
                {
                    ModConsole.Log("Recognized Murder 4's world, Unlocking Murder 4 cheats menu!", ConsoleColor.Green);
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

        public static void OnLevelLoad()
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
            if (isChristmasMode)
            {
                Clue_Present = null;
            }
            Clues.Clear();
            DetectiveGuns.Clear();
            SilencedGuns.Clear();
            ShotGuns.Clear();
            ClonedKnife.Clear();
            Knifes.Clear();
            BearTraps.Clear();
            Grenades.Clear();
            PatreonFlairtoggle = null;
        }

        public static void Murder4CheatsButtons(QMNestedButton submenu, float BtnXLocation, float BtnYLocation, bool btnHalf)
        {
            Murder4CheatPage = new QMNestedButton(submenu, BtnXLocation, BtnYLocation, "Murder 4 Cheats", "Manage Murder 4 Cheats", null, null, null, null, btnHalf);
            Murder4CheatPage.getMainButton().SetResizeTextForBestFit(true);

            QMNestedButton MurderItemTeleporter = new QMNestedButton(Murder4CheatPage, 1, 0, "Item Teleporter", "Size Items Editor", null, null, null, null, true);
            #region Item Teleporter
            new QMSingleButton(MurderItemTeleporter, 1, 0, "Teleport The Clues to Your Pos!", new Action(() => { Clues.TeleportToMe(); }), "Clue Teleporter!", null, null);
            new QMSingleButton(MurderItemTeleporter, 2, 0, "Teleport photograph!", new Action(() => { Clue_photograph.TeleportToMe(); }), "Clue Teleporter!", null, null);
            new QMSingleButton(MurderItemTeleporter, 3, 0, "Teleport notebook!", new Action(() => { Clue_notebook.TeleportToMe(); }), "Clue Teleporter!", null, null);
            new QMSingleButton(MurderItemTeleporter, 4, 0, "Teleport Locket!", new Action(() => { Clue_Locket.TeleportToMe(); }), "Clue Teleporter!", null, null);
            new QMSingleButton(MurderItemTeleporter, 5, 0, "Teleport PocketWatch!", new Action(() => { Clue_PocketWatch.TeleportToMe(); }), "Clue Teleporter!", null, null);
            new QMSingleButton(MurderItemTeleporter, 6, 0, "Teleport Postcard!", new Action(() => { Clue_Postcard.TeleportToMe(); }), "Clue Teleporter!", null, null);
            if (isChristmasMode)
            {
                new QMSingleButton(MurderItemTeleporter, 7, 0, "Teleport Present!", new Action(() => { Clue_Present.TeleportToMe(); }), "Clue Teleporter!", null, null);
            }
            new QMSingleButton(MurderItemTeleporter, 1, 1, "Teleport Shotgun!", new Action(() => { item_Shotgun.TeleportToMe(); }), "Shotgun Gun Teleporter!", null, null);
            new QMSingleButton(MurderItemTeleporter, 2, 1, "Teleport Detective Gun!", new Action(() => { item_DetectiveRevolver.TeleportToMe(); }), "Detective Gun Teleporter!", null, null);
            new QMSingleButton(MurderItemTeleporter, 3, 1, "Teleport Grenade!", new Action(() => { item_Grenade.TeleportToMe(); }), "Grenade Teleporter!", null, null);
            new QMSingleButton(MurderItemTeleporter, 4, 1, "Teleport Traps!", new Action(() => { BearTraps.TeleportToMe(); }), "Silenced Gun Teleporter!", null, null);
            #endregion
            QMNestedButton MurderItemTweaker = new QMNestedButton(Murder4CheatPage, 1, 0.5f, "Item Tweaker", "Item Tweaks!", null, null, null, null, true);
            #region Item Tweaker
            new QMSingleButton(MurderItemTweaker, 1, 0, "Allow Gun Theft in Murder!", new Action(AllowTheft), "Allows you to steal items from other people!", null, null);
            new QMToggleButton(MurderItemTweaker, 2, 0, "Float (Space Mode)", new Action(() => { SetMurderItemsGravity(true); }), "Fall (World Gravity)", new Action(() => { SetMurderItemsGravity(false); }), "Tweaks all Murder! items gravity!", null, null, null, false);
            new QMSingleButton(MurderItemTweaker, 3, 0, "Turn Knifes into rockets!", new Action(() => { Knifes.AddRocketComponent(false); }), "Make Knifes in Instance go nuts!", null, null);
            new QMSingleButton(MurderItemTweaker, 4, 0, "Turn Guns into rockets!", new Action(() => { MurderGunsRockets(); }), "Make Guns in Instance go nuts!", null, null);
            new QMSingleButton(MurderItemTweaker, 5, 0, "Turn Grenades into rockets!", new Action(() => { Grenades.AddRocketComponent(false); }), "Make Grenade in Instance go nuts!", null, null);
            new QMSingleButton(MurderItemTweaker, 6, 0, "Turn Bear Trap into rockets!", new Action(() => { BearTraps.AddRocketComponent(false); }), "Make Grenade in Instance go nuts!", null, null);

            new QMSingleButton(MurderItemTweaker, 1, 1, "Turn Clues into rockets!", new Action(() => { Clues.AddRocketComponent(false); }), "Make Clues in Instance go nuts!", null, null);
            new QMSingleButton(MurderItemTweaker, 2, 1, "Turn Knifes into Crazy!", new Action(() => { Knifes.AddCrazyComponent(false); }), "Make Knifes in Instance go nuts!", null, null);
            new QMSingleButton(MurderItemTweaker, 3, 1, "Turn Guns into Crazy!", new Action(MurderGunsCrazy), "Make Guns in Instance go nuts!", null, null);
            new QMSingleButton(MurderItemTweaker, 4, 1, "Turn Clues into Crazy!", new Action(() => { Clues.AddCrazyComponent(false); }), "Make Clues in Instance go nuts!", null, null);
            new QMSingleButton(MurderItemTweaker, 5, 1, "Turn Grenade into Crazy!", new Action(() => { Grenades.AddCrazyComponent(false); }), "Make Grenade in Instance go nuts!", null, null);
            new QMSingleButton(MurderItemTweaker, 6, 1, "Turn Bear Trap into Crazy!", new Action(() => { BearTraps.AddCrazyComponent(false); }), "Make Grenade in Instance go nuts!", null, null);
            KnifesGrabbableToggle = new QMToggleButton(MurderItemTweaker, 1, 2, "Can Grab Knifes", new Action(() => { ToggleKnifesGrab(true); }), "Cannot Grab Knifes", new Action(() => { ToggleKnifesGrab(false); }), "Tweaks all Murder! items gravity!", null, null, null, false);
            var one = new QMSingleButton(MurderItemTweaker, 2, 2, "Knifes Grabbable from far!", new Action(() => { MakeKnifeGrabbableFromFar(); }), "Make Knifes Grabbable from far!", null, null, true);
            var two = new QMSingleButton(MurderItemTweaker, 2, 2.5f, "Restore Knifes Properties to world!", new Action(() => { RestoreKnifeToWorldControl(); }), "Restore Control to world!", null, null, true);
            one.SetResizeTextForBestFit(true);
            two.SetResizeTextForBestFit(true);
            #endregion

            QMNestedButton MurderItemSpawner = new QMNestedButton(Murder4CheatPage, 1, 1f, "Item Spawner", "Item Spawner!", null, null, null, null, true);
            #region Item Spawner

            new QMSingleButton(MurderItemSpawner, 1, 0, "Spawn Detective Gun", new Action(() => { item_DetectiveRevolver.CloneObject(); }), "Detective Gun Cloner!", null, null);
            new QMSingleButton(MurderItemSpawner, 2, 0, "Spawn Silenced Gun", new Action(() => { item_Silenced_Revolver_0.CloneObject(); }), "Silenced Gun Cloner!", null, null);
            new QMSingleButton(MurderItemSpawner, 3, 0, "Spawn Shotgun", new Action(() => { item_Shotgun.CloneObject(); }), "Shotgun Cloner!", null, null);
            new QMSingleButton(MurderItemSpawner, 4, 0, "Spawn Knife", new Action(() => { item_Knife_0.CloneObject(); }), "Knife Cloner!", null, null);
            new QMSingleButton(MurderItemSpawner, 5, 0, "Spawn Grenade", new Action(() => { item_Grenade.CloneObject(); }), "Grenade Cloner!", null, null);
            new QMSingleButton(MurderItemSpawner, 6, 0, "Spawn Bear Trap", new Action(() => { item_Bear_trap_1.CloneObject(); }), "Bear Trap Cloner!", null, null);
            new QMSingleButton(MurderItemSpawner, 1, 1, "Spawn photograph!", new Action(() => { Clue_photograph.CloneObject(); }), "Clue Teleporter!", null, null);
            new QMSingleButton(MurderItemSpawner, 2, 1, "Spawn notebook!", new Action(() => { Clue_notebook.CloneObject(); }), "Clue Teleporter!", null, null);
            new QMSingleButton(MurderItemSpawner, 3, 1, "Spawn Locket!", new Action(() => { Clue_Locket.CloneObject(); }), "Clue Teleporter!", null, null);
            new QMSingleButton(MurderItemSpawner, 4, 1, "Spawn PocketWatch!", new Action(() => { Clue_PocketWatch.CloneObject(); }), "Clue Teleporter!", null, null);
            new QMSingleButton(MurderItemSpawner, 5, 1, "Spawn Postcard!", new Action(() => { Clue_Postcard.CloneObject(); }), "Clue Teleporter!", null, null);
            if (isChristmasMode)
            {
                new QMSingleButton(MurderItemSpawner, 6, 1, "Spawn Present!", new Action(() => { Clue_Present.CloneObject(); }), "Clue Teleporter!", null, null);
            }
            #endregion

            if (Bools.AllowAttackerComponent)
            {
                QMNestedButton MurderItemAttackerMenu = new QMNestedButton(Murder4CheatPage, 1, 1.5f, "Followers", "Murder item Followers!", null, null, null, null, true);
                #region Followers
                QMNestedButton Follow_target_section = new QMNestedButton(MurderItemAttackerMenu, 1, 0, "Follow Target ", "Murder item Followers!", null, null, null, null);
                new QMSingleButton(Follow_target_section, 1, 0, "Detective Gun follows target!", new Action(() => { DetectiveGuns.AttackTarget(); }), "Make Detective Gun follow Target", null, null);
                new QMSingleButton(Follow_target_section, 2, 0, "Silenced Guns follows target!", new Action(() => { SilencedGuns.AttackTarget(); }), "Make Silenced Gun follow Target", null, null);
                new QMSingleButton(Follow_target_section, 3, 0, "Knifes follows target!", new Action(() => { Knifes.AttackTarget(); }), "Make Knifes follow Target", null, null);
                new QMSingleButton(Follow_target_section, 4, 0, "Clues follows target!", new Action(() => { Clues.AttackTarget(); }), "Make Clues follow Target", null, null);
                new QMSingleButton(Follow_target_section, 1, 1, "Grenade follows target!", new Action(() => { Grenades.AttackTarget(); }), "Make Grenade follow Target", null, null);
                new QMSingleButton(Follow_target_section, 2, 1, "Shotgun follows target!", new Action(() => { ShotGuns.AttackTarget(); }), "Make Bear Traps follow Target", null, null);
                new QMSingleButton(Follow_target_section, 3, 1, "Bear traps follows target!", new Action(() => { BearTraps.AttackTarget(); }), "Make Bear Traps follow Target", null, null);
                QMNestedButton Follow_self_section = new QMNestedButton(MurderItemAttackerMenu, 2, 0, "Follow You", "Murder item Followers!", null, null, null, null);
                new QMSingleButton(Follow_self_section, 1, 0, "Detective Gun follows you!", new Action(() => { DetectiveGuns.AttackSelf(); }), "Make Detective Gun follow you", null, null);
                new QMSingleButton(Follow_self_section, 2, 0, "Silenced Guns follows you!", new Action(() => { SilencedGuns.AttackSelf(); }), "Make Silenced Gun follow you", null, null);
                new QMSingleButton(Follow_self_section, 3, 0, "Knifes follows you!", new Action(() => { Knifes.AttackSelf(); }), "Make Knifes follow you", null, null);
                new QMSingleButton(Follow_self_section, 4, 0, "Clues follows you!", new Action(() => { Clues.AttackSelf(); }), "Make Clues follow you", null, null);
                new QMSingleButton(Follow_self_section, 1, 1, "Grenade follows you!", new Action(() => { Grenades.AttackSelf(); }), "Make Grenade follow you", null, null);
                new QMSingleButton(Follow_self_section, 2, 1, "Shotgun follows you!", new Action(() => { ShotGuns.AttackSelf(); }), "Make Bear Traps follow you", null, null);
                new QMSingleButton(Follow_self_section, 3, 1, "Bear traps follows you!", new Action(() => { BearTraps.AttackSelf(); }), "Make Bear Traps follow you", null, null);
                #endregion

            }
            if (Bools.AllowOrbitComponent)
            {
                QMNestedButton MurderItemOrbiterMenu = new QMNestedButton(Murder4CheatPage, 1, 2, "Orbiters", "Murder item Orbits!", null, null, null, null, true);
                #region orbiters

                QMNestedButton Orbit_target_section = new QMNestedButton(MurderItemOrbiterMenu, 0, 2, "Orbit Around Target", "Murder item Followers!", null, null, null, null);
                new QMSingleButton(Orbit_target_section, 1, 0, "Detective Gun orbits around target!", new Action(() => { DetectiveGuns.OrbitTarget(); }), "Make Detective Gun orbit around Target", null, null);
                new QMSingleButton(Orbit_target_section, 2, 0, "Silenced Guns orbits around target!", new Action(() => { SilencedGuns.OrbitTarget(); }), "Make Silenced Gun around orbit Target", null, null);
                new QMSingleButton(Orbit_target_section, 3, 0, "Shotgun orbits around target!", new Action(() => { ShotGuns.OrbitTarget(); }), "Make ShotGun orbit around Target", null, null);
                new QMSingleButton(Orbit_target_section, 4, 0, "Knifes orbits around target!", new Action(() => { Knifes.OrbitTarget(); }), "Make Knifes orbit around Target", null, null);
                new QMSingleButton(Orbit_target_section, 1, 1, "Clues orbits around target!", new Action(() => { Clues.OrbitTarget(); }), "Make Clues orbit around Target", null, null);
                new QMSingleButton(Orbit_target_section, 2, 1, "Grenade orbits around target!", new Action(() => { Grenades.OrbitTarget(); }), "Make Grenade orbit around Target", null, null);
                new QMSingleButton(Orbit_target_section, 3, 1, "Bear Trap orbits around target!", new Action(() => { BearTraps.OrbitTarget(); }), "Make Bear Traps orbit around Target", null, null);
                QMNestedButton Orbit_self_section = new QMNestedButton(MurderItemOrbiterMenu, 2, 0, "Orbit Around You", "Murder item Orbiters!", null, null, null, null);
                new QMSingleButton(Orbit_self_section, 1, 0, "Detective Gun orbits around you!", new Action(() => { DetectiveGuns.OrbitSelf(); }), "Make Detective Gun orbit around you", null, null);
                new QMSingleButton(Orbit_self_section, 2, 0, "Silenced Guns orbits around you!", new Action(() => { SilencedGuns.OrbitSelf(); }), "Make Silenced Gun around orbit you", null, null);
                new QMSingleButton(Orbit_self_section, 3, 0, "Shotgun orbits around you!", new Action(() => { ShotGuns.OrbitSelf(); }), "Make ShotGun orbit around you", null, null);
                new QMSingleButton(Orbit_self_section, 4, 0, "Knifes orbits around you!", new Action(() => { Knifes.OrbitSelf(); }), "Make Knifes orbit around you", null, null);
                new QMSingleButton(Orbit_self_section, 1, 1, "Clues orbits around you!", new Action(() => { Clues.OrbitSelf(); }), "Make Clues orbit around you", null, null);
                new QMSingleButton(Orbit_self_section, 2, 1, "Grenade orbits around you!", new Action(() => { Grenades.OrbitSelf(); }), "Make Grenade orbit around you", null, null);
                new QMSingleButton(Orbit_self_section, 3, 1, "Bear Trap orbits around you!", new Action(() => { BearTraps.OrbitSelf(); }), "Make Bear Traps orbit around you", null, null);
                #endregion
            }


            QMNestedButton MurderItemClicker = new QMNestedButton(Murder4CheatPage, 1, 2.5f, "Items Clicker", "Interact with Items!", null, null, null, null, true);
            #region Items Clicker

            new QMSingleButton(MurderItemClicker, 1, 0, "Click photograph!", new Action(() => { Clue_photograph.VRC_Interactable_Click(); }), "Click!", null, null, true);
            new QMSingleButton(MurderItemClicker, 1, 0.5f, "Click notebook!", new Action(() => { Clue_notebook.VRC_Interactable_Click(); }), "Click!", null, null, true);
            new QMSingleButton(MurderItemClicker, 1, 1, "Click Locket!", new Action(() => { Clue_Locket.VRC_Interactable_Click(); }), "Click!", null, null, true);
            new QMSingleButton(MurderItemClicker, 1, 1.5f, "Click PocketWatch!", new Action(() => { Clue_PocketWatch.VRC_Interactable_Click(); }), "Click!", null, null, true);
            new QMSingleButton(MurderItemClicker, 1, 2, "Click Postcard!", new Action(() => { Clue_Postcard.VRC_Interactable_Click(); }), "Click!", null, null, true);
            if (isChristmasMode)
            {
                new QMSingleButton(MurderItemSpawner, 2, 0, "Click Present!", new Action(() => { Clue_Present.CloneObject(); }), "Click!", null, null, true);
            }
            new QMSingleButton(MurderItemClicker, 2, 0.5f, "Unlock Random Weapon!", new Action(() => { Clues.VRC_Interactable_Click(); }), "Unlock Random Weapon!", null, null, true);
            #endregion

            QMNestedButton MurderItemWatchMenu = new QMNestedButton(Murder4CheatPage, 2, 0f, "Watchers", "Murder item Watchers!", null, null, null, null, true);
            #region Watchers

            QMNestedButton Watch_target_section = new QMNestedButton(MurderItemWatchMenu, 1, 0, "Watch Target ", "Murder item Watchers!", null, null, null, null);
            new QMSingleButton(Watch_target_section, 1, 0, "Detective Gun Watchs target!", new Action(() => { DetectiveGuns.WatchTarget(); }), "Make Detective Gun Watch Target", null, null);
            new QMSingleButton(Watch_target_section, 2, 0, "Silenced Guns Watchs target!", new Action(() => { SilencedGuns.WatchTarget(); }), "Make Silenced Gun Watch Target", null, null);
            new QMSingleButton(Watch_target_section, 3, 0, "Knifes Watchs target!", new Action(() => { Knifes.WatchTarget(); }), "Make Knifes Watch Target", null, null);
            new QMSingleButton(Watch_target_section, 4, 0, "Clues Watchs target!", new Action(() => { Clues.WatchTarget(); }), "Make Clues Watch Target", null, null);
            new QMSingleButton(Watch_target_section, 1, 1, "Grenade Watchs target!", new Action(() => { Grenades.WatchTarget(); }), "Make Grenade Watch Target", null, null);
            new QMSingleButton(Watch_target_section, 2, 1, "Shotgun Watchs target!", new Action(() => { ShotGuns.WatchTarget(); }), "Make Bear Traps Watch Target", null, null);
            new QMSingleButton(Watch_target_section, 3, 1, "Bear traps Watchs target!", new Action(() => { BearTraps.WatchTarget(); }), "Make Bear Traps Watch Target", null, null);
            QMNestedButton Watch_self_section = new QMNestedButton(MurderItemWatchMenu, 2, 0, "Watch You", "Murder item Watchers!", null, null, null, null);
            new QMSingleButton(Watch_self_section, 1, 0, "Detective Gun Watchs you!", new Action(() => { DetectiveGuns.WatchSelf(); }), "Make Detective Gun Watch you", null, null);
            new QMSingleButton(Watch_self_section, 2, 0, "Silenced Guns Watchs you!", new Action(() => { SilencedGuns.WatchSelf(); }), "Make Silenced Gun Watch you", null, null);
            new QMSingleButton(Watch_self_section, 3, 0, "Knifes Watchs you!", new Action(() => { Knifes.WatchSelf(); }), "Make Knifes Watch you", null, null);
            new QMSingleButton(Watch_self_section, 4, 0, "Clues Watchs you!", new Action(() => { Clues.WatchSelf(); }), "Make Clues Watch you", null, null);
            new QMSingleButton(Watch_self_section, 1, 1, "Grenade Watchs you!", new Action(() => { Grenades.WatchSelf(); }), "Make Grenade Watch you", null, null);
            new QMSingleButton(Watch_self_section, 2, 1, "Shotgun Watchs you!", new Action(() => { ShotGuns.WatchSelf(); }), "Make Bear Traps Watch you", null, null);
            new QMSingleButton(Watch_self_section, 3, 1, "Bear traps Watchs you!", new Action(() => { BearTraps.WatchSelf(); }), "Make Bear Traps Watch you", null, null);
            #endregion




            GameObjectESP.MurderESPtoggler = new QMToggleButton(Murder4CheatPage, 3, 0, "Item ESP On", new Action(GameObjectESP.AddESPToMurderProps), "Item ESP Off", new Action(GameObjectESP.RemoveESPToMurderProps), "Reveals All murder items position.", null, null, null, false);
            JarRoleController.Murder4RolesRevealerToggle = new QMToggleButton(Murder4CheatPage, 4, 0, "Reveal Roles On", new Action(() => { JarRoleController.ViewRoles = true; }), "Reveals Roles Off", new Action(() => { JarRoleController.ViewRoles = false; }), "Reveals Current Players Roles In nameplates.", null, null, null, false);
            Murder4UdonExploits.Init_GameController_Btn(Murder4CheatPage, 4, 1, true);
            Murder4UdonExploits.Init_Filtered_Nodes_Btn(Murder4CheatPage, 4, 1.5f, true);
            Murder4UdonExploits.Init_Unfiltered_Nodes_btn(Murder4CheatPage, 4, 2f, true);



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
                Pickup.SetProximity(knife, 450f);
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





        // MAP GameObjects Required for control.




        public static QMToggleButton KnifesGrabbableToggle;

        public static QMSingleButton KnifesGrabFromFar;

        public static readonly bool isChristmasMode = false;

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

        public static bool HasMurder4WorldLoaded = false;

    }
}