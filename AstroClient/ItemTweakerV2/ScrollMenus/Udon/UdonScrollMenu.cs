﻿namespace AstroClient.ItemTweakerV2.Submenus.ScrollMenus
{
	using AstroClient.Extensions;
	using AstroClient.ItemTweakerV2.Selector;
	using AstroClient.variables;
	using RubyButtonAPI;
	using VRC.Udon.Common.Interfaces;

	public class UdonScrollMenu
	{
		public static void Init_Internal_UdonEvents(QMTabMenu main, float x, float y, bool btnHalf)
		{
			if (!Bools.IsDeveloper) // TODO : Add permission check for udon events.
			{
				return;
			}
			var Menu = new QMNestedButton(main, x, y, "Internal Udon Events ", "Interact with Internal Udon Events", null, null, null, null, btnHalf);
			var whytfisthishere = new QMNestedButton(Menu, -5f, -5f, "", "");
			whytfisthishere.GetMainButton().SetActive(false);
			var MainScroll = new QMScrollMenu(whytfisthishere);
			var subscroll = new QMScrollMenu(Menu);
			new QMSingleButton(Menu, 0, -1.5f, "Refresh", delegate
			{
				MainScroll.Refresh();
				subscroll.Refresh();
			}, "", null, null, true);
			subscroll.SetAction(delegate
			{
				foreach (var action in Tweaker_Object.GetGameObjectToEdit().Get_UdonBehaviours())
				{
					subscroll.Add(new QMSingleButton(Menu, 0f, 0f, action.gameObject.name, delegate
					{
						MainScroll.SetAction(delegate
						{
							foreach (var subaction in action._eventTable)
							{
								MainScroll.Add(new QMSingleButton(MainScroll.BaseMenu, 0f, 0f, subaction.Key, delegate
								{
									if (subaction.key.StartsWith("_"))
									{
										action.SendCustomEvent(subaction.Key);
									}
									else
									{
										action.SendCustomNetworkEvent(NetworkEventTarget.All, subaction.Key);
									}
								}, action.gameObject?.ToString() + " Run " + subaction.Key));
							}
						});
						MainScroll.BaseMenu.GetMainButton().GetGameObject().GetComponent<UnityEngine.UI.Button>()
							.onClick.Invoke();
					}, action.interactText));
				}
			});
		}
	}
}