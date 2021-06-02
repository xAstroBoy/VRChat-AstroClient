namespace AstroClient.Cheetos
{
	using AstroLibrary.Console;
	using AstroLibrary.Finder;
	using AstroNetworkingLibrary.Serializable;
	using DayClientML2.Utility;
	using DayClientML2.Utility.Extensions;
	using DayClientML2.Utility.MenuApi;
	using System;
	using System.Collections;
	using System.Diagnostics;
	using System.Linq;
	using UnityEngine;
	using VRC.Core;

	public class AvatarSearch : GameEvents
	{
		public static SearchTypes SearchType = SearchTypes.ALL;

		public static bool IsSearching = false;

		private static GameObject publicAvatarList;

		private static Il2CppSystem.Collections.Generic.List<ApiAvatar> foundAvatars = new Il2CppSystem.Collections.Generic.List<ApiAvatar>();

		private static VRCList list;

		private static Stopwatch stopwatch;

		private static MenuButton SearchTypeButton;

		public enum SearchTypes
		{
			ALL,
			PUBLIC,
			PRIVATE
		}

		public override void VRChat_OnUiManagerInit()
		{
			// Avatar Search
			new MenuButton(MenuType.AvatarMenu, MenuButtonType.AvatarFavButton, "Astro Search", -850f, 125f, delegate ()
			{
				Utils.VRCUiPopupManager.AskInGameInput("Astro Avatar Search", "Search", delegate (string text)
				{
					Search(SearchType, text);
				}, "Enter Avatar name. . .");
			}, 1.45f, 1f);

			SearchTypeButton = new MenuButton(MenuType.AvatarMenu, MenuButtonType.AvatarFavButton, "All", -850f, 50f, delegate ()
			{
				if (SearchType == SearchTypes.ALL)
				{
					SearchType = SearchTypes.PRIVATE;
				}
				else if (SearchType == SearchTypes.PRIVATE)
				{
					SearchType = SearchTypes.PUBLIC;
				}
				else if (SearchType == SearchTypes.PUBLIC)
				{
					SearchType = SearchTypes.ALL;
				}
				UpdateButtons();

			}, 1.45f, 1f);

			publicAvatarList = GameObjectFinder.Find("/UserInterface/MenuContent/Screens/Avatar/Vertical Scroll View/Viewport/Content/Public Avatar List");

			list = new VRCList(publicAvatarList.transform.parent, "Astro Avatar Search Results", 0);
			list.Text.supportRichText = true;
		}

		private static void UpdateButtons()
		{
			SearchTypeButton.SetText(Enum.GetName(typeof(SearchTypes), SearchType).ToLower().ToUppercaseFirstCharacterOnly());
		}

		public static void Search(SearchTypes searchType, string query)
		{
			if (!IsSearching)
			{
				stopwatch = new Stopwatch();
				stopwatch.Start();

				// Refresh UI
				foundAvatars.Clear();
				NetworkingManager.AvatarSearch(searchType, query);

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
			list.Text.supportRichText = true;
			list.UiVRCList.expandedHeight *= 2f;
			list.UiVRCList.extendRows = 4;
			list.UiVRCList.startExpanded = false;
			//Utils.VRCUiManager.ShowScreen(currPageAvatar);

			foreach (var avatar in foundAvatars.ToArray().Where(a => a.releaseStatus.ToLower().Equals("private")))
			{
				avatar.name = $"<color=red>[P]</color> {avatar.name}";
			}

			list.RenderElement(foundAvatars);

			MiscUtility.DelayFunction(10f, () =>
			{
				foreach (var item in list.UiVRCList.pickers)
				{
					if (item.gameObject.active)
					{
						item.field_Public_Text_0.supportRichText = true;
						var texture = item.field_Public_RawImage_0.texture;
						var name = item.field_Public_Text_0.text;
						var id = item.field_Public_String_0;

						//ModConsole.Log(texture.name);
						if (texture.name.ToLower().Equals("no_image"))
						{
							item.field_Public_GameObject_0.SetActive(true);
							item.field_Public_ArrayOf_GameObject_0[0].SetActive(true);
							ModConsole.Log($"Found dead avatar: {name}, {id}");
						}
					}
				}
			});
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