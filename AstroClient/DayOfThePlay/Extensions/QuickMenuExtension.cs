namespace DayClientML2.Utility.Extensions
{
	using Transmtn.DTO.Notifications;
	using UnityEngine;

	internal static class QuickMenuExtension
	{
		public static void SelectPlayer(this QuickMenu Instance, VRCPlayer Instance2)
		{
			Instance.Method_Public_Void_Player_0(Instance2.GetPlayer());
		}

		public static void ToggleQuickMenu(this QuickMenu Instance, bool state)
		{
			Instance.Method_Public_Void_Boolean_0(state);
		}

		public static Notification Notification(this QuickMenu Instance)
		{
			return Instance.field_Private_Notification_0;
		}

		public static void SetQuickMenuBackGround(this QuickMenu instance, float x, float y, bool doublesided = true)
		{
			Transform transform = Utils.QuickMenu.transform.Find("QuickMenu_NewElements/_Background");
			RectTransform rectTransform = transform.GetComponent<RectTransform>();
			if (doublesided)
				rectTransform.sizeDelta += new Vector2(x * 840, y * 840);
			else
			{
				rectTransform.sizeDelta += new Vector2(x * 420, y * 420);
				rectTransform.anchoredPosition += new Vector2(-x * 210, -y * 210);
			}
		}

		public static void SetQuickMenuCollider(this QuickMenu instance, float x, float y, bool doublesided = true)
		{
			var Collider = Utils.QuickMenu.GetComponent<BoxCollider>();
			if (doublesided)
				Collider.size += new Vector3(x * 840, y * 840);
			else
			{
				Collider.size += new Vector3(x * 420, y * 420);
				Collider.center += new Vector3(-x * 210, -y * 210);
			}
		}
	}
}