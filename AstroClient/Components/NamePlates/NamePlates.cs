namespace AstroClient.Cheetos
{
	using System;
	using UnityEngine;
	using VRC;

	public class NamePlates : GameEventsBehaviour
	{
		public NamePlates(IntPtr obj0) : base(obj0)
		{
		}

		private static float RefreshTime;

		private void Refresh()
		{
			//ModConsole.Log($"Updating {GetComponent<Player>().DisplayName()}'s nameplate");
		}

		public void Update()
		{
			if (RefreshTime >= 1f)
			{
				Refresh();
				RefreshTime = 0;
			}
			else
			{
				RefreshTime += 1f * Time.deltaTime;
			}
		}

		public void Start()
		{
			var player = GetComponent<Player>();
			if (player != null)
			{
			}
			
			////new BlazeTag(player, player.GetAPIUser().GetRank(), color);

			//var nameplate = player.transform.Find("Player Nameplate/Canvas/Nameplate/");
			//if (nameplate == null)
			//{
			//	ModConsole.Error($"Could not find Nameplate for {player.GetDisplayName()}");
			//}

			//var contents = nameplate.transform.Find("Contents/");
			//if (contents == null)
			//{
			//	ModConsole.Error($"Could not find Contents for {player.GetDisplayName()}");
			//}

			//var main = contents.transform.Find("Main/");
			//if (main == null)
			//{
			//	ModConsole.Error($"Could not find Main for {player.GetDisplayName()}");
			//}

			//var background = main.transform.Find("Background");
			//if (background == null)
			//{
			//	ModConsole.Error($"Could not find Background for {player.GetDisplayName()}");
			//}

			//var quickStats = contents.transform.Find("Quick Stats");
			//if (quickStats == null)
			//{
			//	ModConsole.Error($"Could not find Quick Stats for {player.GetDisplayName()}");
			//}

			//var trustIcon = quickStats.transform.Find("Trust Icon");
			//if (trustIcon == null)
			//{
			//	ModConsole.Error($"Could not find Trust Icon for {player.GetDisplayName()}");
			//}
			//trustIcon.gameObject.SetActive(false);

			//var performanceIcon = quickStats.transform.Find("Performance Icon");
			//if (performanceIcon == null)
			//{
			//	ModConsole.Error($"Could not find Performance Icon for {player.GetDisplayName()}");
			//}
			//performanceIcon.gameObject.SetActive(false);

			//var performanceText = quickStats.transform.Find("Performance Text");
			//if (performanceText == null)
			//{
			//	ModConsole.Error($"Could not find Performance Text for {player.GetDisplayName()}");
			//}
			//performanceText.gameObject.SetActive(false);

			//var friendAnchorStats = quickStats.transform.Find("Friend Anchor Stats");
			//if (friendAnchorStats == null)
			//{
			//	ModConsole.Error($"Could not find Friend Anchor Stats for {player.GetDisplayName()}");
			//}
			//friendAnchorStats.gameObject.SetActive(false);

			//var image = background.gameObject.GetComponent<ImageThreeSlice>();
			//if (image != null)
			//{
			//	image.color = color;
			//}
		}
	}
}
