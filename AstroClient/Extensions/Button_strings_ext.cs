namespace AstroLibrary.Extensions
{
	using UnityEngine;
	using VRC;

	public static class Button_strings_ext
	{
		public static string Generate_TeleportToMe_ButtonText(this GameObject obj)
		{
			string ObjectName;
			if (obj != null)
			{
				ObjectName = obj.name;
			}
			else
			{
				ObjectName = "null";
			}
			return $"Teleport to you:\n{ObjectName}";
		}

		public static string Generate_TeleportToTarget_ButtonText(GameObject obj, Player Target)
		{
			string TargetName;

			string ObjectName;
			if (obj != null)
			{
				ObjectName = obj.name;
			}
			else
			{
				ObjectName = "null";
			}
			if (Target != null)
			{
				TargetName = Target.GetAPIUser().displayName;
			}
			else
			{
				TargetName = "null";
			}

			return $"Teleport\n {ObjectName} to:\n {TargetName}";
		}
	}
}