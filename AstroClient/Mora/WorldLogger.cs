namespace AstroClient
{
	using Harmony;
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Net.Http;
	using System.Reflection;
	using System.Text;
	using VRC.Core;

	internal class WorldLogger : GameEvents
	{
		private const string PublicWorldFile = "AstroClient\\WorldLog\\Worlds.html";
		private static string _WorldsIDs = "";
		private static readonly Queue<ApiWorld> WorldToPost = new Queue<ApiWorld>();
		private static readonly HttpClient WebHookClient = new HttpClient();

		private static HarmonyMethod GetPatch(string name)
		{
			return new HarmonyMethod(typeof(WorldLogger).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
		}

		public override void OnApplicationStart()
		{
			//Directory.CreateDirectory("AstroClient\\WorldLog");
			//if (!File.Exists(PublicWorldFile))
			//	File.AppendAllText(PublicWorldFile, $"{Environment.NewLine}{Environment.NewLine}");

			//foreach (var line in File.ReadAllLines(PublicWorldFile))
			//	if (line.Contains("World ID"))
			//		_WorldsIDs += line.Replace("World ID:", "");
		}

		public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)  //ApiWorldDownloadPatch(ApiWorld __0) //__0
		{
			DateTime now = DateTime.Now;
			if (!_WorldsIDs.Contains(RoomManager.field_Internal_Static_ApiWorld_0.id))
			{
				_WorldsIDs += RoomManager.field_Internal_Static_ApiWorld_0.id;
				var sb = new StringBuilder();
				sb.AppendLine($"<br> {now}");
				sb.AppendLine($"<br>World Name: {RoomManager.field_Internal_Static_ApiWorld_0.name}");
				sb.AppendLine($"<br>World ID: {RoomManager.field_Internal_Static_ApiWorld_0.id}");
				sb.AppendLine($"<br>World Author Name: {RoomManager.field_Internal_Static_ApiWorld_0.authorName}");
				sb.AppendLine($"<br>World Author ID: {RoomManager.field_Internal_Static_ApiWorld_0.authorId}");
				sb.AppendLine($"<br>World Release Status: {RoomManager.field_Internal_Static_ApiWorld_0.releaseStatus}");
				sb.AppendLine($"<br>World Asset URL: <a href='{RoomManager.field_Internal_Static_ApiWorld_0.assetUrl}' > Click Me </a> ");
				sb.AppendLine($"<br>World Version: {RoomManager.field_Internal_Static_ApiWorld_0.version} <br>World Thumbnail Image URL: <br><img src='{RoomManager.field_Internal_Static_ApiWorld_0.thumbnailImageUrl}' width=200 height=200 /><br><br><br>");
				sb.AppendLine(Environment.NewLine);
				File.AppendAllText(PublicWorldFile, sb.ToString());
				sb.Clear();
			}

			/*	WorldData data = new worldData();
				data.ID = __0.id;
				data.Name = __0.name;
				data.Description = __0.description;
				data.AuthorID = __0.authorId;
				data.AuthorName = __0.authorName;
				data.AssetURL = __0.assetUrl;
				data.ImageURL = __0.imageUrl;
				data.ThumbnailURL = __0.thumbnailImageUrl;
				data.ReleaseStatus = __0.releaseStatus;
				data.Version = __0.version;
				// NetworkingManager.SendAvatarLog(data);
				// NetworkingManager.SendLongAssShit();*/
			//return true;
		}
	}
}