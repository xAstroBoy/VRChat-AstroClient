namespace AstroClient.Cheetos
{
	using AstroLibrary.Finder;
	using UnityEngine;
	using UnityEngine.UI;

	class AvatarSearch : GameEvents
	{
		public override void VRChat_OnUiManagerInit()
		{
			var content = GameObjectFinder.Find("UserInterface/MenuContent/Screens/Avatar/Vertical Scroll View/Viewport/Content");
			var pal = GameObjectFinder.Find("UserInterface/MenuContent/Screens/Avatar/Vertical Scroll View/Viewport/Content/Personal Avatar List");
			var search = GameObjectFinder.Find("UserInterface/MenuContent/Backdrop/Header/Tabs/ViewPort/Content/Search/InputField");

			search.GetComponent<Button>().interactable = true;

			var searchList = GameObject.Instantiate(pal, content.transform);
			searchList.GetComponent<UiAvatarList>().hideWhenEmpty = false;
			searchList.GetComponent<UiAvatarList>().field_Public_Text_0.text = "Astro Search";
			searchList.GetComponent<LayoutElement>().minHeight = 280f;
			searchList.name = "Astro Search";
		}
	}
}
