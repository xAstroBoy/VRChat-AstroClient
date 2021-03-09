using AstroClient.AstroUtils.ItemTweaker;
using AstroClient.ConsoleUtils;
using AstroClient.extensions;
using AstroClient.Finder;
using System;
using VRC.SDKBase;

namespace AstroClient.Worlds
{
    internal class WorldUnlocker
    {
        public static void OnWorldReveal()
        {
            if (WorldUtils.GetWorldID() == "wrld_9c72e56b-d2b0-4c9b-b816-07a857f6ae4e")
            {
                ModConsole.Log("Recognized Meroom, Spawning Lockpick Trigger.");

                var PrivateRoomSwitchTrigger = GameObjectFinder.Find("Private room/Switch /switch (1)/trigger");
                var DisplaySwitchTrigger = GameObjectFinder.Find("Living room/Switch/switch/trigger");
                if (PrivateRoomSwitchTrigger == null)
                {
                    ModConsole.Log("Failed to Find Private Room Switch, Has MeRoom World updated?", ConsoleColor.Red);
                }
                else
                {
                    ModConsole.Log("Found Private room Switch!", ConsoleColor.Green);
                }
                if (DisplaySwitchTrigger == null)
                {
                    ModConsole.Log("Failed to Find Living Room Display Switch, Has MeRoom World updated?", ConsoleColor.Red);
                }
                else
                {
                    ModConsole.Log("Found Living Room Display Switch!", ConsoleColor.Green);
                }
                if (PrivateRoomSwitchTrigger == null || DisplaySwitchTrigger == null)
                {
                    ModConsole.Log("Aborted LockPick Button Generation.", ConsoleColor.Yellow);
                    return;
                }

                if (PrivateRoomSwitchTrigger != null && DisplaySwitchTrigger != null)
                {
                    var DeleteTrigger = DisplaySwitchTrigger.GetComponentInChildren<VRCSDK2.VRC_Trigger>(true);
                    var WorkingTrigger = PrivateRoomSwitchTrigger.GetComponentInChildren<VRCSDK2.VRC_Trigger>(true);
                    VRCSDK2.VRC_Trigger Cloned_trigger = null;

                    if (DeleteTrigger != null)
                    {
                        DeleteTrigger.DestroyMeLocal();
                    }
                    if (WorkingTrigger != null)
                    {
                        Cloned_trigger = DisplaySwitchTrigger.AddComponent<VRCSDK2.VRC_Trigger>().GetCopyOf(WorkingTrigger);
                        if (Cloned_trigger != null)
                        {
                            Cloned_trigger.interactText = "Lockpick Door";
                        }
                    }
                    
                    if (Cloned_trigger != null)
                    {
                        Cloned_trigger.gameObject.AddCollider();
                        ModConsole.Log("Added Successfully Lockpick Door");
                    }
                }
            }

            else if (WorldUtils.GetWorldID() == "wrld_d319c58a-dcec-47de-b5fc-21200116462c")
            {
                ModConsole.Log("Recognized FBT Heaven! Removing Blinders and Dividers...");
                var blinders = GameObjectFinder.Find("[AREA_DEVIDERS]");
                if (blinders != null)
                {
                    blinders.DestroyMeLocal();
                }

                ModConsole.Log("Editing Door Handlers Signs to be interactive...");
                var Door_1_Interactive = GameObjectFinder.Find("[STATIC]/Building/FBT_Heaven/Private_Room_Hallway/Room1/Door/Door_Handle_Sign_Button_Unlock_1");
                var Door_2_Interactive = GameObjectFinder.Find("[STATIC]/Building/FBT_Heaven/Private_Room_Hallway/Room2/Door/Door_Handle_Sign_Button_Unlock_2");
                var Door_3_Interactive = GameObjectFinder.Find("[STATIC]/Building/FBT_Heaven/Private_Room_Hallway/Room3/Door/Door_Handle_Sign_Button_Unlock_3");
                var Door_4_Interactive = GameObjectFinder.Find("[STATIC]/Building/FBT_Heaven/Private_Room_Hallway/Room4/Door/Door_Handle_Sign_Button_Unlock_4");

                var Door_1_Visual = GameObjectFinder.Find("[STATIC]/Building/FBT_Heaven/Private_Room_Hallway/Room_Doors/Room_1/Door_Handle_Sign_1");
                var Door_2_Visual = GameObjectFinder.Find("[STATIC]/Building/FBT_Heaven/Private_Room_Hallway/Room_Doors/Room_2/Door_Handle_Sign_2");
                var Door_3_Visual = GameObjectFinder.Find("[STATIC]/Building/FBT_Heaven/Private_Room_Hallway/Room_Doors/Room_3/Door_Handle_Sign_3");
                var Door_4_Visual = GameObjectFinder.Find("[STATIC]/Building/FBT_Heaven/Private_Room_Hallway/Room_Doors/Room_4/Door_Handle_Sign_4");

                if (Door_1_Interactive != null && Door_1_Visual != null)
                {
                    ModConsole.Log("Editing Port 1 Sign..");
                    var DeleteTrigger = Door_1_Visual.GetComponentInChildren<VRCSDK2.VRC_Trigger>(true);
                    var WorkingTrigger = Door_1_Interactive.GetComponentInChildren<VRCSDK2.VRC_Trigger>(true);
                    VRC_Trigger Cloned_trigger = null;

                    if (DeleteTrigger != null)
                    {
                        DeleteTrigger.DestroyMeLocal();
                    }
                    if (WorkingTrigger != null)
                    {
                        Cloned_trigger = Door_1_Visual.AddComponent<VRCSDK2.VRC_Trigger>().GetCopyOf(WorkingTrigger);
                        if (Cloned_trigger != null)
                        {
                            Cloned_trigger.interactText = "Force Unlock Door 1";
                        }
                    }
                    if (Cloned_trigger != null)
                    {
                        Door_1_Visual.AddCollider();
                        ModConsole.Log("Added Successfully Force unlock Door 1");
                    }
                }
                if (Door_2_Interactive != null && Door_2_Visual != null)
                {
                    ModConsole.Log("Editing Port 2 Sign..");
                    var DeleteTrigger = Door_2_Visual.GetComponentInChildren<VRCSDK2.VRC_Trigger>(true);

                    var WorkingTrigger = Door_2_Interactive.GetComponentInChildren<VRCSDK2.VRC_Trigger>(true);

                    VRC_Trigger Cloned_trigger = null;

                    if (DeleteTrigger != null)
                    {
                        DeleteTrigger.DestroyMeLocal();
                    }
                    if (WorkingTrigger != null)
                    {
                        Cloned_trigger = Door_2_Visual.AddComponent<VRCSDK2.VRC_Trigger>().GetCopyOf(WorkingTrigger);
                        if (Cloned_trigger != null)
                        {
                            Cloned_trigger.interactText = "Force Unlock Door 2";
                        }
                    }

                    if (Cloned_trigger != null)
                    {
                        Door_2_Visual.AddCollider();
                        ModConsole.Log("Added Successfully Force unlock Door 2");
                    }
                }
                if (Door_3_Interactive != null && Door_3_Visual != null)
                {
                    ModConsole.Log("Editing Port 3 Sign..");
                    var DeleteTrigger = Door_3_Visual.GetComponentInChildren<VRCSDK2.VRC_Trigger>(true);
                    var WorkingTrigger = Door_3_Interactive.GetComponentInChildren<VRCSDK2.VRC_Trigger>(true);

                    VRC_Trigger Cloned_trigger = null;
                    if (DeleteTrigger != null)
                    {
                        DeleteTrigger.DestroyMeLocal();
                    }
                    if (WorkingTrigger != null)
                    {
                        Cloned_trigger = Door_3_Visual.AddComponent<VRCSDK2.VRC_Trigger>().GetCopyOf(WorkingTrigger);
                        if (Cloned_trigger != null)
                        {
                            Cloned_trigger.interactText = "Force Unlock Door 3";
                        }
                    }


                    if (Cloned_trigger != null)
                    {
                        Door_3_Visual.AddCollider();
                        ModConsole.Log("Added Successfully Force unlock Door 3");
                    }
                }
                if (Door_4_Interactive != null && Door_4_Visual != null)
                {
                    ModConsole.Log("Editing Port 4 Sign..");
                    var DeleteTrigger = Door_4_Visual.GetComponentInChildren<VRCSDK2.VRC_Trigger>(true);

                    var WorkingTrigger = Door_4_Interactive.GetComponentInChildren<VRCSDK2.VRC_Trigger>(true);

                    VRC_Trigger Cloned_trigger = null;

                    if (DeleteTrigger != null)
                    {
                        DeleteTrigger.DestroyMeLocal();
                    }
                    if (WorkingTrigger != null)
                    {
                        Cloned_trigger = Door_4_Visual.AddComponent<VRCSDK2.VRC_Trigger>().GetCopyOf(WorkingTrigger);
                        if (Cloned_trigger != null)
                        {
                            Cloned_trigger.interactText = "Force Unlock Door 4";
                        }
                    }
                    if (Cloned_trigger != null)
                    {
                        Door_4_Visual.AddCollider();
                        ModConsole.Log("Added Successfully Force unlock Door 4");
                    }
                }
            }

            else if (WorldUtils.GetWorldID() == "wrld_953eff93-20c9-457b-8ef0-1ac2130d5b8a")
            {
                ModConsole.Log("Recognized The Snooze's Scary Maze 5, Removing Anti-cheat protections..");
                var roofanticheat = GameObjectFinder.Find("World/Roof & Preventions");
                var cheatingroom = GameObjectFinder.Find("World/Cheating Room");
                cheatingroom.DestroyMeLocal();
                roofanticheat.DestroyMeLocal();
                var hammer = GameObjectFinder.Find("Snooze Tools/GameObject/Object");
                if (hammer != null)
                {
                    ModConsole.Log("Prepping Snooze Hammer for be used...");
                    ModConsole.Log("Found Hammer! Modifying ...");
                    //if (!HasAlreadyAColliderAdded(hammer))
                    //{
                    //    Add_new_Collider(hammer);
                    //}
                    hammer.RenameObject("Hammer");
                    hammer.enablecolliders();
                    hammer.SetPickupable(true);
                    hammer.SetPickupOrientation(VRC.SDKBase.VRC_Pickup.PickupOrientation.Gun);
                    hammer.SetPickupTheft(false);
                    hammer.PreventOthersFromPicking(true);
                    ItemTweakerMain.WorldObjects.AddGameObject(hammer);
                }
            }

            else if (WorldUtils.GetWorldID() == "wrld_6caf5200-70e1-46c2-b043-e3c4abe69e0f")
            {
                ModConsole.Log("Recognized The Great Pug World, Removing Basement Door & Kitchen Door.");
                var BasementDoor = GameObjectFinder.Find(" - Props/Props (Static) - Hallways - First Floor/door-private");
                var Kitchen1 = GameObjectFinder.Find("great_pug/kitchen_door");
                var kitchen2 = GameObjectFinder.Find("great_pug/kitchen_door_chrome");
                var frame = GameObjectFinder.Find("great_pug/door-frame_004");
                var kitchen4 = GameObjectFinder.Find("great_pug/Cube_022  (GLASS)");
                var Signs = GameObjectFinder.Find(" - Props/Props (Static) - Global - Udon In Progress");
                var rope = GameObjectFinder.Find(" - Props/Props (Static) - Hallways - First Floor/Velvet Rope (1)");
                rope.DestroyMeLocal();
                Signs.DestroyMeLocal();
                BasementDoor.DestroyMeLocal();
                Kitchen1.DestroyMeLocal();
                kitchen2.DestroyMeLocal();
                frame.removeCollider();
                rope.removeCollider();
            }
            else
            {
                ModConsole.Log("No Known Worlds Recognized.");
            }
        }
    }
}