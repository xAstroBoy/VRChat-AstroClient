namespace AstroLibrary.Utility
{
	using UnityEngine;
	using VRC;
	using VRC.SDKBase;

	public static class GameObjectUtils
	{
		public static bool TakeOwnershipIfNecessary(GameObject gameObject)
		{
			if (GetOwnerOfGameObject(gameObject) != Utils.CurrentUser._player)
				Networking.SetOwner(Utils.CurrentUser.field_Private_VRCPlayerApi_0, gameObject);
			return GetOwnerOfGameObject(gameObject) != Utils.CurrentUser._player;
		}

		public static Player GetOwnerOfGameObject(GameObject gameObject)
		{
			foreach (Player player in WorldUtils.GetPlayers())
			{
				if (player.GetVRCPlayerApi().IsOwner(gameObject))
				{
					return player;
				}
			}
			return null;
		}
	}
}
