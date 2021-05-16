using AstroClient.Components;
using System.Collections.Generic;
using System.Linq;
using VRC;

namespace AstroClient.Extensions
{
	public static class SingleTagExtension
	{


		public static bool HasTagWithText(this Player player, string text)
		{
			var tags = player.gameObject.GetComponentsInChildren<SingleTag>(true);
			if (tags.Count() != 0)
			{
				foreach (var tag in tags)
				{
					if (tag.Label_Text == text)
					{
						return true;
					}
				}
			}
			return false;
		}


		public static List<SingleTag> SearchTags(this Player player, string text)
		{
			List<SingleTag> FoundTags = new List<SingleTag>();

			var tags = player.gameObject.GetComponentsInChildren<SingleTag>(true);
			if (tags.Count() != 0)
			{
				foreach (var tag in tags)
				{
					if (tag.Label_Text == text)
					{
						FoundTags.Add(tag);
					}
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