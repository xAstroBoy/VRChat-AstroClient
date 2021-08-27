namespace AstroClient.Cheetos
{
	using AstroLibrary.Console;
	using UnityEngine;

	public class AntiCrash : GameEvents
    {
		public override void OnAvatarSpawn(VRCAvatarManager VRCAvatarManager, GameObject AvatarObject)
		{
			ModConsole.Log($"[AntiCrash] Scanning Avatar");
		}
	}
}