namespace AstroClient
{
	using AstroLibrary.Extensions;
	using RubyButtonAPI;
	using System;
	using UnityEngine;

	public static class MapEditorMenu
	{
		public static void InitButtons(QMTabMenu main, float x, float y, bool btnHalf)
		{
			var menu = new QMNestedButton(main, x, y, "Map Editor Utils", "Map Editor", null, null, null, null, btnHalf);
			new QMSingleButton(menu, 1, 0, "Spawn Empty Button", new Action(() =>
			{
				Vector3? buttonPosition = Utils.LocalPlayer.GetPlayer().Get_Center_Of_Player();
				Quaternion? buttonRotation = Utils.LocalPlayer.GetPlayer().gameObject.transform.rotation;
				if (buttonRotation != null && buttonRotation != null)
				{
					var btn = ButtonCreator.Create("Template", buttonPosition.Value, buttonRotation.Value, null);
					btn.TeleportToMe();
					btn.Pickup_Set_ForceComponent();
					btn.Pickup_Set_Pickupable(true);
					btn.Set_As_Object_To_Edit();
					btn.AddToWorldUtilsMenu();
				}
			}), "Spawn Preset Button", null, null, true);
		}
	}
}