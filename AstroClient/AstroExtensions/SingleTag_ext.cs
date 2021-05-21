namespace AstroClient.Extensions
{
	using AstroClient.Components;
	using AstroLibrary.Console;
	using System.Collections.Generic;
	using VRC;

	public static class SingleTag_ext
	{


		public static bool HasTagWithText(this Player player, string searchtext)
		{
			var tags = player.transform.root.GetComponentsInChildren<SingleTag>(true);

			foreach (var tag in tags)
			{
				ModConsole.DebugLog($"Found Singletag with text : {tag.Label_Text} , With Search {searchtext}");
				if (tag.Label_Text.Equals(searchtext, System.StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}

			return false;
		}


		public static void DestroyTagsWithText(this Player player, string searchtext)
		{
			var tags = player.transform.root.GetComponentsInChildren<SingleTag>(true);
			foreach (var tag in tags)
			{
				ModConsole.DebugLog($"Found Singletag with text : {tag.Label_Text} , With Search {searchtext}");
				if (tag.Label_Text.Equals(searchtext, System.StringComparison.OrdinalIgnoreCase))
				{
					ModConsole.DebugLog($"Destroying...");

					UnityEngine.Object.Destroy(tag);
				}
			}

		}


		public static List<SingleTag> SearchTags(this Player player, string searchtext)
		{
			List<SingleTag> FoundTags = new List<SingleTag>();
			var tags = player.transform.root.GetComponentsInChildren<SingleTag>(true);
			foreach (var tag in tags)
			{
				ModConsole.DebugLog($"Found Singletag with text : {tag.Label_Text} , With Search {searchtext}");
				if (tag.Label_Text.Equals(searchtext, System.StringComparison.OrdinalIgnoreCase))
				{
					FoundTags.Add(tag);
				}
			}

			return FoundTags;
		}

		public static SingleTag AddSingleTag(this Player player)
		{
			return SingleTagsUtils.AddSingleTag(player);
		}
	}
}