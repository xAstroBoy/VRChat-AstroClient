namespace AstroClient.Cheetos
{
	using AstroLibrary.Console;
	using Blaze.API;
	using Blaze.Utils;
	using UnityEngine;
	using VRC;

	public class NamePlates : GameEvents
	{
		public override void OnPlayerJoined(Player player)
		{
			var color = player.GetAPIUser().GetRankColor();

			MainThreadRunner.Run(() =>
			{
				new BlazeTag(player, player.GetAPIUser().GetRank(), color);
			});

			var nameplate = player.transform.Find("Player Nameplate/Canvas/Nameplate/");
			if (nameplate == null)
			{
				ModConsole.Error($"Could not find Nameplate for {player.GetDisplayName()}");
				return;
			}

			var contents = nameplate.transform.Find("Contents/");
			if (contents == null)
			{
				ModConsole.Error($"Could not find Contents for {player.GetDisplayName()}");
				return;
			}

			var main = contents.transform.Find("Main/");
			if (main == null)
			{
				ModConsole.Error($"Could not find Main for {player.GetDisplayName()}");
				return;
			}

			var background = main.transform.Find("Background");
			if (background == null)
			{
				ModConsole.Error($"Could not find Background for {player.GetDisplayName()}");
				return;
			}

			var image = background.gameObject.GetComponent<ImageThreeSlice>();
			if (image != null)
			{
				image.color = color;
			}
		}
	}
}
