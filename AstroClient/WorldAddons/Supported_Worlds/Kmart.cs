namespace AstroClient.WorldAddons
{
    using AstroClient.Variables;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Finder;
    using AstroLibrary.Utility;
    using System.Collections.Generic;
    using VRC.SDKBase;

    class Kmart : GameEvents
    {
        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
        {
            if (WorldUtils.GetWorldID() == WorldIds.Kmart)
            {
                MiscUtils.DelayFunction(2f, RemoveProtections);
            }
        }

        private static void RemoveProtections()
        {
            var rootObject = GameObjectFinder.Find("Fuck you for ripping/AssociateBoxes/Boxeas");
            if (rootObject != null)
            {
                for (int i = 0; i < rootObject.transform.childCount; i++)
                {
                    var transform = rootObject.transform.GetChild(i);

                    if (transform.gameObject.name.Contains("Cube") && transform.GetComponent<VRC_Trigger>() != null)
                    {
                        ModConsole.DebugLog($"Kmart Protection Deleted: {transform.gameObject.GetPath()}");
                        transform.gameObject.DestroyMeLocal();
                    }
                }

                ModConsole.Log($"Kmart Protections Deleted");
            }
            else
            {
                ModConsole.Error("Kmart: Failed to find the AssociateBox protections!");
            }
        }
    }
}
