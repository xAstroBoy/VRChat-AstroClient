namespace AstroClient.Cheetos
{
	#region Imports

	using AstroClient.ModDetector;
	using AstroClient.Variables;
	using AstroLibrary;
	using AstroLibrary.Console;
	using AstroLibrary.Enums;
	using AstroLibrary.Finder;
	using AstroLibrary.Utility;
	using AstroNetworkingLibrary;
	using AstroNetworkingLibrary.Serializable;
	using DayClientML2.Utility;
	using DayClientML2.Utility.MenuApi;
	using System.Collections;
	using System.Diagnostics;
	using System.Linq;
	using UnityEngine;
	using VRC.Core;

	#endregion Imports

	public class AvatarResult : VRCUiContentButton
	{
		public string AvatarID = string.Empty;
	}

	public class AvatarSearch : GameEvents
	{
		public static SearchTypes SearchType = SearchTypes.ALL;

		public static bool IsSearching = false;

		private static GameObject publicAvatarList;

		private static Il2CppSystem.Collections.Generic.List<ApiAvatar> foundAvatars = new Il2CppSystem.Collections.Generic.List<ApiAvatar>();

		private static VRCList list;

		private static Stopwatch stopwatch;

		private static MenuButton searchTypeButton;

		private static MenuButton deleteButton;

		private static MenuButton WorldAvatarDumper;

		private static VRCStandaloneInputModule inputModule;

		private static string selectedID;

		public enum SearchTypes
		{
			ALL,
			PUBLIC,
			PRIVATE
		}

		public override void VRChat_OnUiManagerInit()
		{
			inputModule = GameObject.Find("_Application/UiEventSystem").GetComponent<VRCStandaloneInputModule>();

			// Avatar Search
			new MenuButton(MenuType.AvatarMenu, MenuButtonType.AvatarFavButton, "Astro Search", 921f, 470f, delegate ()
			{
				CheetosHelpers.PopupCall("Astro Avatar Search", "Search", "Enter Avatar name. . .", false, delegate (string text)
				{
					Search(SearchType, text);
				});
			}, 1.45f, 1f);

			searchTypeButton = new MenuButton(MenuType.AvatarMenu, MenuButtonType.AvatarFavButton, "All", 921f, 410f, delegate ()
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

			if (Bools.IsDeveloper)
			{
				deleteButton = new MenuButton(MenuType.AvatarMenu, MenuButtonType.AvatarFavButton, "Delete From Database", 921f, 350f, delegate ()
				{
					ModConsole.Log($"Sent Avatar Deletion For: {selectedID}");
					AstroNetworkClient.Client.Send(new PacketData(PacketClientType.AVATAR_DELETE, selectedID));
				}, 1.45f, 1f);
			}

			//	WorldAvatarDumper = new MenuButton(MenuType.AvatarMenu, MenuButtonType.AvatarFavButton, "Show Avatars Pedestrals from World", 921f, 200f, delegate ()
			//	{
			//		//Favcat_Utils.Run_RevealWorldPedestrials();
			//	}, 1.45f, 1f);
			//}
			//else
			//{
			//	WorldAvatarDumper = new MenuButton(MenuType.AvatarMenu, MenuButtonType.AvatarFavButton, "Show Avatars Pedestrals from World", 921f, 170f, delegate ()
			//	{
			//		//Favcat_Utils.Run_RevealWorldPedestrials();
			//	}, 1.45f, 1f);
			//}

			publicAvatarList = GameObjectFinder.Find("/UserInterface/MenuContent/Screens/Avatar/Vertical Scroll View/Viewport/Content/Public Avatar List");

			list = new VRCList(publicAvatarList.transform.parent, "Astro Search Results", 0);
			list.Text.supportRichText = true;
		}

		public static void OnSelect()
		{
			// Add a check here later
			var selected = inputModule.field_Public_Selectable_0;
			if (selected != null)
			{
				var comp = selected.gameObject.GetComponent<VRCUiContentButton>();
				if (comp != null)
				{
					var id = comp.field_Public_String_0;
					if (id != string.Empty)
					{
						selectedID = inputModule.field_Public_Selectable_0.gameObject.GetComponent<VRCUiContentButton>().field_Public_String_0;
					}
				}
			}
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

			//MiscUtils.DelayFunction(4f, () =>
			//         {
			//             foreach (var item in list.UiVRCList.pickers)
			//             {
			//                 if (item.gameObject.active)
			//                 {
			//                     item.field_Public_Text_0.supportRichText = true;
			//                     var texture = item.field_Public_RawImage_0.texture;
			//                     var name = item.field_Public_Text_0.text;
			//                     var id = item.field_Public_String_0;

			//                     //ModConsole.Log(texture.name);
			//                     if (texture.name.ToLower().Equals("no_image"))
			//                     {
			//                         item.field_Public_GameObject_0.SetActive(true);
			//                         item.field_Public_ArrayOf_GameObject_0[0].SetActive(true);
			//                         ModConsole.Log($"Found dead avatar: {name}, {id}");
			//                     }
			//                 }
			//             }
			//         });
			list.Text.text = $"<color=cyan>Astro Search</color> Found: <color=yellow>{foundAvatars.Count}</color> in {stopwatch.ElapsedMilliseconds}ms";
			ModConsole.Log($"Avatar Search Completed: found {foundAvatars.Count} avatars in {stopwatch.ElapsedMilliseconds}ms");
		}

		public static void AddAvatar(AvatarData avatarData)
		{
			foundAvatars.Add(avatarData.ToApiAvatar());
		}

		private static void UpdateButtons()
		{
			searchTypeButton.SetText(System.Enum.GetName(typeof(SearchTypes), SearchType).ToLower().ToUppercaseFirstCharacterOnly());
		}
	}
}