namespace AstroClient
{
	using AstroLibrary.Console;
	using AstroLibrary.Finder;
	using AstroClient.Variables;
	using System.Drawing;
	using System.Collections.Generic;

	public class Meroom : GameEvents
	{
		public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
		{
			if (id == WorldIds.Meroom)
			{
				ModConsole.Log($"Recognized {Name} World, Spawning Lockpick Trigger.");

				var PrivateRoomSwitchTrigger = GameObjectFinder.Find("Private room/Button/switch");
				var DisplaySwitchTrigger = GameObjectFinder.Find("Living room/Button/switch (1)");
				if (PrivateRoomSwitchTrigger == null)
				{
					ModConsole.Log("Failed to Find Private Room Switch, Has MeRoom World updated?", Color.Red);
				}
				else
				{
					ModConsole.Log("Found Private room Switch!", Color.Green);
				}
				if (DisplaySwitchTrigger == null)
				{
					ModConsole.Log("Failed to Find Living Room Display Switch, Has MeRoom World updated?", Color.Red);
				}
				else
				{
					ModConsole.Log("Found Living Room Display Switch!", Color.Green);
				}
				if (PrivateRoomSwitchTrigger == null || DisplaySwitchTrigger == null)
				{
					ModConsole.Log("Aborted LockPick Button Generation.", Color.Yellow);
					return;
				}

				if (PrivateRoomSwitchTrigger != null && DisplaySwitchTrigger != null)
				{
					TriggersCloner.CloneVRC2SDKTrigger(PrivateRoomSwitchTrigger, DisplaySwitchTrigger, "Lockpick Door");
				}
			}
		}
	}
}