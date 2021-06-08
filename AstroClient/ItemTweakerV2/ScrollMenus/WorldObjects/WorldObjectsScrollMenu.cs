namespace AstroClient.ItemTweakerV2.Submenus.ScrollMenus
{
	using AstroClient.Extensions;
	using AstroClient.ItemTweakerV2.Selector;
	using RubyButtonAPI;
	using System;
	using System.Collections.Generic;
	using UnityEngine;

	public class WorldObjectsScrollMenu : GameEvents
	{
		public static void Init_WorldObjectScrollMenu(QMTabMenu main, float x, float y, bool btnHalf)
		{
			var menu = new QMNestedButton(main, x, y, "Select W.Objects", "Select World Objects to edit", null, null, null, null, btnHalf);
			var scroll = new QMScrollMenu(menu);
			new QMSingleButton(menu, 0, -1, "Refresh", delegate
			{
				scroll.Refresh();
			}, "", null, null, true);

			// SelWorld_TeleportToMePickup = new QMSingleButton(menu, 0, -0.5f, GetTeleportToMeBtnText, delegate
			//{
			//    Tweaker_Object.GetGameObjectToEdit().TeleportToMe();
			//}, GetTeleportToMeBtnText);
			// SelWorld_TeleportToMePickup.SetResizeTextForBestFit(true);

			// SelWorld_TeleportToTargetPickup = new QMSingleButton(menu, 0, 0.5f, GetTeleportToTargetText, delegate
			// {
			//     Tweaker_Object.GetGameObjectToEdit().TeleportToTarget();
			// }, GetTeleportToTargetText);
			// SelWorld_TeleportToTargetPickup.SetResizeTextForBestFit(true);
			new QMSingleButton(menu, 0, 1.5f, "Spawn Clone", new Action(() => { Cloner.ObjectCloner.CloneGameObject(Tweaker_Object.GetGameObjectToEdit()); }), "Instantiates a copy of The selected object.", null, null, true);

			scroll.SetAction(delegate
			{
				foreach (var item in WorldObjects)
				{
					scroll.Add(
					new QMSingleButton(scroll.BaseMenu, 0, 0, $"Select {item.name}", delegate
					{
						item.Set_As_Object_To_Edit();
					}, $"Select {item.name}", null, item.Get_GameObject_Active_ToColor()));
				}
			});
		}

		public static void AddToWorldUtilsMenu(GameObject obj)
		{
			if (obj != null)
			{
				if (!WorldObjects.Contains(obj))
				{
					WorldObjects.Add(obj);
				}
			}
		}

		public override void OnLevelLoaded()
		{
			WorldObjects.Clear();
		}

		public static List<GameObject> WorldObjects = new List<GameObject>();
	}
}