namespace AstroClient.Cheetos
{
	using AstroLibrary.Console;
	using AstroLibrary.Finder;
	using AstroNetworkingLibrary.Serializable;
	using DayClientML2.Utility;
	using DayClientML2.Utility.Extensions;
	using DayClientML2.Utility.MenuApi;
	using System.Collections;
	using System.Diagnostics;
	using UnityEngine;
	using VRC.Core;

	class AvatarSearch : GameEvents
	{
		private static GameObject publicAvatarList;
		private static Il2CppSystem.Collections.Generic.List<ApiAvatar> foundAvatars = new Il2CppSystem.Collections.Generic.List<ApiAvatar>();

		private static VRCList list;

		private static Stopwatch stopwatch;

		public static bool IsSearching = false;

		public override void VRChat_OnUiManagerInit()
		{
			// Avatar Search
			new MenuButton(MenuType.AvatarMenu, MenuButtonType.AvatarFavButton, "Astro Search", -850f, 125f, delegate ()
			{
				Utils.VRCUiPopupManager.AskInGameInput("Astro Avatar Search", "Search", delegate (string text)
				{
					Search(text);
				}, "Enter Avatar name. . .");
			}, 1.45f, 1f);

			publicAvatarList = GameObjectFinder.Find("/UserInterface/MenuContent/Screens/Avatar/Vertical Scroll View/Viewport/Content/Public Avatar List");

			list = new VRCList(publicAvatarList.transform.parent, "Astro Avatar Search Results", 0);
			list.Text.supportRichText = true;
		}

		public static void Search(string query)
		{
			if (!IsSearching)
			{
				stopwatch = new Stopwatch();
				stopwatch.Start();

				// Refresh UI
				foundAvatars.Clear();
				NetworkingManager.AvatarSearch(query);

				IsSearching = true;
				MelonLoader.MelonCoroutines.Start(LoopCheck());
			}
		}

		public static IEnumerator LoopCheck()
		{
			if (!IsSearching) yield break;

			for (; ; )
			{
				yield return new WaitForEndOfFrame();
				if (!IsSearching)
				{
					Done();
					yield break;
				}
			}
		}

		public static void Done()
		{
			IsSearching = false;
			stopwatch.Stop();
			list.UiVRCList.expandedHeight *= 2f;
			list.UiVRCList.extendRows = 4;
			list.UiVRCList.startExpanded = false;
			//Utils.VRCUiManager.ShowScreen(currPageAvatar);
			list.RenderElement(foundAvatars);
			list.Text.text = $"<color=cyan>Astro Search</color> Found: <color=yellow>{foundAvatars.Count}</color> in {stopwatch.ElapsedMilliseconds}ms";
			ModConsole.Log($"Avatar Search Completed: found {foundAvatars.Count} avatars in {stopwatch.ElapsedMilliseconds}ms");
		}

		public static void AddAvatar(AvatarData avatarData)
		{
			var apiAvatar = avatarData.ToApiAvatar();
			foundAvatars.Add(apiAvatar);
		}
	}
}