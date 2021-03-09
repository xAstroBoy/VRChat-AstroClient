using AstroClient.ConsoleUtils;
using AstroClient.extensions;
using AstroClient.Finder;
using AstroClient.World.Hub;
using RubyButtonAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static AstroClient.HandsUtils;

namespace AstroClient.Worlds
{
    public static class WorldAddons
    {
        public static void OnLevelLoad()
        {
            PatreonDoorTrigger = null;
            HasDeletedBlockingPortal = false;
            SandBag = null;
        }

        public static void InitButtons(QMNestedButton menu, float x, float y, bool btnHalf)
        {
            var WorldCheats = new QMNestedButton(menu, x, y, "World Cheats", "Manage Cheats", null, null, null, null, btnHalf);
            Murder2Cheats.Murder2CheatsButtons(WorldCheats, 1, 0, true);
            Murder4Cheats.Murder4CheatsButtons(WorldCheats, 1, 0.5f, true);
            AmongUSCheats.AmongUSCheatsButtons(WorldCheats, 1, 1f, true);
            HubButtonsControl.InitButtons(WorldCheats, 1, 1.5f, true);
            MovieRoomPatreonRoomUnlock = new QMSingleButton(WorldCheats, 1, 2f, "Unlock Patreon Room", new Action(ForcePatreonRoomUnlock), "Enables Patreon Room Door Without the password in the Room.", null, null, true);
            MovieRoomPatreonRoomUnlock.SetResizeTextForBestFit(true);
            SandBagCheat = new QMSingleButton(WorldCheats, 1, 2.5f, "Select SandBag", new Action(SelectSandBag), "Select SandBag in Item Tweaker", null, null, true);
            SandBagCheat.SetResizeTextForBestFit(true);
        }

        public static void OnWorldReveal()
        {
            if (WorldUtils.GetWorldID() == "wrld_c87d9e7a-d46a-4ca4-9077-a6322ac0f7e7")
            {
                if (SandBagCheat != null)
                {
                    ModConsole.Log("Recognized Smash Contest's world, revealing SandBag Selector Button!", ConsoleColor.Green);
                    SandBagCheat.setIntractable(true);
                    SandBagCheat.setTextColor(Color.green);

                    FindSandBag();
                }
            }
            else
            {
                if (SandBagCheat != null)
                {
                    SandBagCheat.setIntractable(false);
                    SandBagCheat.setTextColor(Color.red);
                }
            }

            if (WorldUtils.GetWorldID() == "wrld_4f826865-8501-4de2-b83a-f7eeb86b26a1")
            {
                ModConsole.Log("Recognized Root Movies & Anime room World, Enabled Unlock Patreon Room!");
                if (MovieRoomPatreonRoomUnlock != null)
                {
                    MovieRoomPatreonRoomUnlock.setIntractable(true);
                    MovieRoomPatreonRoomUnlock.setTextColor(Color.green);
                }
            }
            else
            {
                if (MovieRoomPatreonRoomUnlock != null)
                {
                    MovieRoomPatreonRoomUnlock.setIntractable(false);
                    MovieRoomPatreonRoomUnlock.setTextColor(Color.red);
                }
            }
            if (WorldUtils.GetWorldID() == "wrld_ba913a96-fac4-4048-a062-9aa5db092812")
            {
                if (HubButtonsControl.VRChat_Hub_Addons != null)
                {
                    ModConsole.Log("Recognized VRCHat Hub's world, revealing Hub Addons Submenu Button!", ConsoleColor.Green);
                    HubButtonsControl.VRChat_Hub_Addons.getMainButton().setIntractable(true);
                    HubButtonsControl.VRChat_Hub_Addons.getMainButton().setTextColor(Color.green);
                }
            }
            else
            {
                if (HubButtonsControl.VRChat_Hub_Addons != null)
                {
                    HubButtonsControl.VRChat_Hub_Addons.getMainButton().setIntractable(false);
                    HubButtonsControl.VRChat_Hub_Addons.getMainButton().setTextColor(Color.red);
                }
            }

            if (WorldUtils.GetWorldID() == "wrld_d010695a-3e7c-43a1-ac38-d80f3ffeab17")
            {
                ModConsole.Log("Recognized Thermal Treatment World, Finding Platforms Gameobjects!...");
                var list = new List<GameObject>();
                list = GameObjectFinder.ListFind("Platforms");
                if (list != null && list.Count() != 0)
                {
                    list.AddToWorldUtilsMenu();
                }
            }
            if (WorldUtils.GetWorldID() == "wrld_a1b9fcc4-1ed1-4e67-8b16-f1edc5a5d6e9")
            {
                ModConsole.Log("Recognized Dont Trip World, Finding Entity Gameobjects!...");
                GameObjectFinder.Find("GameObject/Level/cube (5)/what the fuck").AddToWorldUtilsMenu();
            }
        }

        private static void ForcePatreonRoomUnlock()
        {
            if (WorldUtils.GetWorldID() == "wrld_4f826865-8501-4de2-b83a-f7eeb86b26a1")
            {
                if (!HasDeletedBlockingPortal)
                {
                    var portal = GameObjectFinder.Find("ROOT'sHomev2/VRCPortalMarker-00");

                    if (portal != null)
                    {
                        portal.DestroyMeOnline();
                    }
                    if (portal != null)
                    {
                        portal.DestroyMeLocal();
                    }
                    if (portal == null)
                    {
                        HasDeletedBlockingPortal = true;
                    }
                }
                if (PatreonDoorTrigger == null)
                {
                    PatreonDoorTrigger = GameObjectFinder.Find("ROOT'sHomev2/Main Room Walls/DoorFrame.001/Door.001").GetComponent<VRCSDK2.VRC_Trigger>();
                }

                if (!PatreonDoorTrigger.enabled)
                {
                    PatreonDoorTrigger.enabled = true;
                }
            }
        }

        private static void SelectSandBag()
        {
            if (SandBag != null)
            {
                if (SandBag.GetComponent<VRCSDK2.VRC_Pickup>() == null)
                {
                    var pickup = SandBag.AddComponent<VRCSDK2.VRC_Pickup>();
                    if (pickup != null)
                    {
                        var col = SandBag.AddComponent<BoxCollider>();
                        {
                            col.isTrigger = true;
                            col.size = col.size / 0.3f;
                        }
                        Pickup.SetAutoHoldMode(SandBag, VRC.SDKBase.VRC_Pickup.AutoHoldMode.No);
                        Pickup.SetallowManipulationWhenEquipped(SandBag, true);
                    }
                }
                SetObjectToEdit(SandBag);
            }
            else
            {
                FindSandBag();
                SetObjectToEdit(SandBag);
            }
        }

        private static void FindSandBag()
        {
            var list = Resources.FindObjectsOfTypeAll<GameObject>();
            foreach (var obj in list)
            {
                if (obj.name.ToLower() == "sandbag")
                {
                    if (obj.transform.parent == null)
                    {
                        ModConsole.Log("Object Found : " + obj.transform.name);
                        SandBag = obj;
                    }
                }
            }
        }

        private static VRCSDK2.VRC_Trigger PatreonDoorTrigger = null;
        private static bool HasDeletedBlockingPortal = false;
        private static QMSingleButton MovieRoomPatreonRoomUnlock;
        private static QMSingleButton SandBagCheat;
        public static GameObject SandBag = null;
    }
}