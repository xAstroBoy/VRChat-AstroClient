namespace AstroClient.Cheetos
{
	using AstroClient.ConsoleUtils;
	using AstroClient.extensions;
	using UnityEngine;
	using VRC;
	using VRC.SDKBase;

	public class AvatarHider : GameEvents
	{
		public static bool HideAvatar = false;

		public static void DestroyAvatar(GameObject avatar)
		{
			avatar.transform.root.Find("ForwardDirection/Avatar").gameObject.DestroyMeLocal();
		}

		public override void OnAvatarSpawn(GameObject avatar, VRC_AvatarDescriptor DescriptorObj, bool state)
		{
			if (HideAvatar)
			{
				var self = LocalPlayerUtils.GetSelfPlayer();
				var owner = avatar.transform.root.GetComponent<Player>();

				if (self == owner)
				{
					DestroyAvatar(avatar);
					ModConsole.DebugLog("Your avatar was hidden.");
				}
			}
		}
	}
}