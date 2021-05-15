namespace AstroClient
{
	using AstroLibrary.Console;
	using AstroClient.Extensions;
	using AstroClient.Finder;
	using AstroClient.Variables;
	using VRC.SDKBase;

	public class SnoozeScaryMaze5 : GameEvents
	{
		public override void OnWorldReveal(string id, string name, string asseturl)
		{
			if (id == WorldIds.SnoozeScaryMaze5)
			{
				ModConsole.Log($"Recognized {name} World, Removing Anti-cheat protections..");
				var roofanticheat = GameObjectFinder.Find("World/Roof & Preventions");
				var cheatingroom = GameObjectFinder.Find("World/Cheating Room");
				cheatingroom.DestroyMeLocal();
				roofanticheat.DestroyMeLocal();
				var snoozetools = GameObjectFinder.FindRootSceneObject("Snooze Tools");
				if (snoozetools != null)
				{
					var hammer = snoozetools.transform.FindObject("GameObject/Object").gameObject;
					if (hammer != null)
					{
						ModConsole.Log("Prepping Snooze Hammer for be used...");
						ModConsole.Log("Found Hammer! Modifying ...");
						hammer.RenameObject("Hammer");
						hammer.enablecolliders();
						hammer.SetPickupable(true);
						hammer.SetPickupOrientation(VRC.SDKBase.VRC_Pickup.PickupOrientation.Gun);
						hammer.SetPickupTheft(false);
						foreach (var item in hammer.GetComponentsInChildren<VRC_Trigger>(true))
						{
							ModConsole.DebugLog("Disabling SDK 1 Internal Trigger on Hammer..");
							item.enabled = false;
						}
						foreach (var item in hammer.GetComponentsInChildren<VRCSDK2.VRC_Trigger>(true))
						{
							ModConsole.DebugLog("Disabling SDK 2 Internal Trigger on Hammer..");
							item.enabled = false;
						}
						hammer.AddToWorldUtilsMenu();
					}
				}
				else
				{
					ModConsole.Warning("Failed to find Snooze Tools!");
				}
			}
		}
	}
}