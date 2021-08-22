namespace AstroLibrary.Extensions
{
	using UnityEngine;
	using VRC;

	public static class Button_strings_ext
	{
		public static string Generate_TeleportToMe_ButtonText(this GameObject obj)
		{
			string ObjectName = obj != null ? obj.name : "null";
			return $"Teleport to you:\n{ObjectName}";
		}

		public static string Generate_TeleportToTarget_ButtonText(GameObject obj, Player Target)
		{
			string TargetName;

			string ObjectName = obj != null ? obj.name : "null";
			TargetName = Target != null ? Target.GetAPIUser().displayName : "null";

			return $"Teleport\n {ObjectName} to:\n {TargetName}";
		}
	}
}