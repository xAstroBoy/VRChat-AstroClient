namespace AstroClient
{
    using AstroClient.Variables;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Finder;
    using System.Collections.Generic;

    public class SnoozeScaryMaze5 : GameEvents
    {
        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
        {
            if (id == WorldIds.SnoozeScaryMaze5)
            {
                ModConsole.Log($"Recognized {Name} World, Removing Anti-cheat protections..");
                var world = GameObjectFinder.Find("World");
                if (world != null)
                {
                    var roofAndPreventionsanticheat1 = world.transform.FindObject("Etc../Roof & Preventions");
                    var cheatingroom = world.transform.FindObject("Cheating Room");
                    var anticheat2 = world.transform.FindObject("The Wilderness/Cheat Prevention");

                    cheatingroom.DestroyMeLocal();
                    roofAndPreventionsanticheat1.DestroyMeLocal();
                    anticheat2.DestroyMeLocal();
                }

                // Rest In peace hammer.

                //var snoozetools = GameObjectFinder.FindRootSceneObject("Snooze Tools");
                //if (snoozetools != null)
                //{
                //    var hammer = snoozetools.transform.FindObject("GameObject/Object").gameObject;
                //    if (hammer != null)
                //    {
                //        ModConsole.Log("Prepping Snooze Hammer for be used...");
                //        ModConsole.Log("Found Hammer! Modifying ...");
                //        hammer.RenameObject("Hammer");
                //        hammer.EnableColliders();
                //        hammer.Pickup_Set_Pickupable(true);
                //        hammer.Pickup_Set_PickupOrientation(VRC_Pickup.PickupOrientation.Gun);
                //        hammer.Pickup_Set_DisallowTheft(true);
                //        foreach (var item in hammer.GetComponentsInChildren<VRC_Trigger>(true))
                //        {
                //            ModConsole.DebugLog("Disabling SDK 1 Internal Trigger on Hammer..");
                //            item.enabled = false;
                //        }
                //        foreach (var item in hammer.GetComponentsInChildren<VRCSDK2.VRC_Trigger>(true))
                //        {
                //            ModConsole.DebugLog("Disabling SDK 2 Internal Trigger on Hammer..");
                //            item.enabled = false;
                //        }
                //        hammer.AddToWorldUtilsMenu();
                //    }
                //}
                //else
                //{
                //    ModConsole.Warning("Failed to find Snooze Tools!");
                //}
            }
        }
    }
}