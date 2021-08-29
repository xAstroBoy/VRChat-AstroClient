namespace AstroClient.WorldAddons
{
    using AstroClient.Variables;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Finder;
    using AstroLibrary.Utility;
    using System.Collections.Generic;
    using VRCSDK2;

    class Kmart : GameEvents
    {
        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
        {
            if (WorldUtils.GetWorldID() == WorldIds.Kmart)
            {
                BypassSpawn();
                MiscUtils.DelayFunction(2f, RemoveProtections);
            }
        }

        private static void RemoveProtections()
        {
            var boxes = GameObjectFinder.Find("Fuck you for ripping/AssociateBoxes/Boxeas");
            if (boxes != null)
            {
                boxes.DestroyMeLocal();
                ModConsole.Log($"Kmart Protections Deleted");
            }
            else
            {
                ModConsole.Error("Kmart: Failed to find the AssociateBox protections!");
            }
        }

        private static void BypassSpawn()
        {
            var trigger1 = GameObjectFinder.Find("Fuck you for ripping/SpawnRoom/patsign (23)");
            var comp1 = trigger1.GetComponent<VRC_Trigger>();
            if (trigger1 != null && comp1 != null)
            {
                comp1.Interact();
            }
            else
            {
                ModConsole.Error("Kmart spawn bypass failed! trigger1 or comp1 was null!");
            }

            var trigger2 = GameObjectFinder.Find("Fuck you for ripping/SpawnRoom/Group356 (1)/Group367/Mesh4453");
            var comp2 = trigger2.GetComponent<VRC_Trigger>();
            if (trigger2 != null && comp2 != null)
            {
                comp2.Interact();
            }
            else
            {
                ModConsole.Error("Kmart spawn bypass failed! trigger1 or comp1 was null!");
            }
        }
    }
}
