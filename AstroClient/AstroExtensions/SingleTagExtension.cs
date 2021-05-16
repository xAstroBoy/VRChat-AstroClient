using AstroClient.Components;
using System.Collections.Generic;
using System.Linq;
using VRC;

namespace AstroClient.Extensions
{
	public static class SingleTagExtension
	{


		public static bool HasTagWithText(this Player player, string searchtext)
		{
			var tags = player.GetComponents<SingleTag>();

			foreach (var tag in tags)
			{
				if (tag.Label_Text.ToLower() == searchtext.ToLower())
				{
					return true;
				}
			}

			return false;
		}


		public static List<SingleTag> SearchTags(this Player player, string searchtext)
		{
			List<SingleTag> FoundTags = new List<SingleTag>();

			var tags = player.GetComponents<SingleTag>();

			foreach (var tag in tags)
			{
				if (tag.Label_Text == searchtext)
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