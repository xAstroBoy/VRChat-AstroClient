namespace AstroClient.Managers
{
	using AstroLibrary.Console;
	using AstroLibrary.Extensions;
	using AstroLibrary.Utility;
	using Newtonsoft.Json;
	using System.Collections.Generic;
	using System.IO;
	using VRC.Core;

	public class Achievments_Managers : GameEvents
	{
		public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
		{
			Achievmentss = Achievments.Load();
			CheckFriends();
			CheckTrustRank();
		}

		private static void CheckTrustRank()
		{
			if (Achievmentss.TrustRank == string.Empty)
			{
				Achievmentss.TrustRank = APIUser.CurrentUser.GetRank();
				Achievmentss.SaveConfig();
				Utils.VRCUiPopupManager.ShowAlert("Congratulations ", $"You Reached {Achievmentss.TrustRank}");
			}
			else
			{
				switch (APIUser.CurrentUser.GetRankEnum())
				{
					case PlayerExtensions.RankType.visitor:
						if (Achievmentss.TrustRank == "New User")
						{
							Achievmentss.DownRankCounter++;
							Utils.VRCUiPopupManager.ShowAlert("Aww ", $"You lost Your New User Rank\n and are now Visitor");
						}

						break;

					case PlayerExtensions.RankType.newUser:
						switch (Achievmentss.TrustRank)
						{
							case "Visitor":
								Achievmentss.UpRankCounter++;
								Utils.VRCUiPopupManager.ShowAlert("Congratulations ", $"You Reached New User");
								break;

							case "New User":
								break;

							case "User":
								Utils.VRCUiPopupManager.ShowAlert("Aww ", $"You lost Your User Rank\n and are now New User");
								Achievmentss.DownRankCounter++;
								break;

							case "Known":
								Utils.VRCUiPopupManager.ShowAlert("Aww ", $"You lost Your Known Rank\n and are now New User");
								Achievmentss.DownRankCounter += 2;
								break;

							case "Trusted":
								Utils.VRCUiPopupManager.ShowAlert("Aww ", $"You lost Your Trusted Rank\n and are now New User");
								Achievmentss.DownRankCounter += 3;
								break;

							case "Veteran":
								Utils.VRCUiPopupManager.ShowAlert("Aww ", $"You lost Your Veteran Rank\n and are now New User");
								Achievmentss.DownRankCounter += 4;
								break;

							case "Legend":
								Utils.VRCUiPopupManager.ShowAlert("Aww ", $"You lost Your Legend Rank\n and are now New User");
								Achievmentss.DownRankCounter += 5;
								break;
						}
						break;

					case PlayerExtensions.RankType.User:
						switch (Achievmentss.TrustRank)
						{
							case "Visitor":
								Achievmentss.UpRankCounter += 2;
								Utils.VRCUiPopupManager.ShowAlert("Congratulations ", $"You Reached User");
								break;

							case "New User":
								Achievmentss.UpRankCounter++;
								Utils.VRCUiPopupManager.ShowAlert("Congratulations ", $"You Reached User");
								break;

							case "User":
								break;

							case "Known":
								Utils.VRCUiPopupManager.ShowAlert("Aww ", $"You lost Your Known Rank\n and are now User");
								Achievmentss.DownRankCounter++;
								break;

							case "Trusted":
								Utils.VRCUiPopupManager.ShowAlert("Aww ", $"You lost Your Trusted Rank\n and are now User");
								Achievmentss.DownRankCounter += 2;
								break;

							case "Veteran":
								Utils.VRCUiPopupManager.ShowAlert("Aww ", $"You lost Your Veteran Rank\n and are now User");
								Achievmentss.DownRankCounter += 3;
								break;

							case "Legend":
								Utils.VRCUiPopupManager.ShowAlert("Aww ", $"You lost Your Legend Rank\n and are now User");
								Achievmentss.DownRankCounter += 4;
								break;
						}
						break;

					case PlayerExtensions.RankType.Known:
						switch (Achievmentss.TrustRank)
						{
							case "Visitor":
								Achievmentss.UpRankCounter += 3;
								Utils.VRCUiPopupManager.ShowAlert("Congratulations ", $"You Reached Known");
								break;

							case "New User":
								Achievmentss.UpRankCounter += 2;
								Utils.VRCUiPopupManager.ShowAlert("Congratulations ", $"You Reached Known");
								break;

							case "User":
								Achievmentss.UpRankCounter++;
								Utils.VRCUiPopupManager.ShowAlert("Congratulations ", $"You Reached Known");
								break;

							case "Known":
								break;

							case "Trusted":
								Utils.VRCUiPopupManager.ShowAlert("Aww ", $"You lost Your Trusted Rank\n and are now Known");
								Achievmentss.DownRankCounter += 1;
								break;

							case "Veteran":
								Utils.VRCUiPopupManager.ShowAlert("Aww ", $"You lost Your Veteran Rank\n and are now Known");
								Achievmentss.DownRankCounter += 2;
								break;

							case "Legend":
								Utils.VRCUiPopupManager.ShowAlert("Aww ", $"You lost Your Legend Rank\n and are now Known");
								Achievmentss.DownRankCounter += 3;
								break;
						}
						break;

					case PlayerExtensions.RankType.Trusted:
						switch (Achievmentss.TrustRank)
						{
							case "Visitor":
								Achievmentss.UpRankCounter += 4;
								Utils.VRCUiPopupManager.ShowAlert("Congratulations ", $"You Reached Trusted");
								break;

							case "New User":
								Achievmentss.UpRankCounter += 3;
								Utils.VRCUiPopupManager.ShowAlert("Congratulations ", $"You Reached Trusted");
								break;

							case "User":
								Achievmentss.UpRankCounter += 2;
								Utils.VRCUiPopupManager.ShowAlert("Congratulations ", $"You Reached Trusted");
								break;

							case "Known":
								Achievmentss.UpRankCounter++;
								Utils.VRCUiPopupManager.ShowAlert("Congratulations ", $"You Reached Trusted");
								break;

							case "Trusted":
								break;

							case "Veteran":
								Utils.VRCUiPopupManager.ShowAlert("Aww ", $"You lost Your Veteran Rank\n and are now Trusted");
								Achievmentss.DownRankCounter += 1;
								break;

							case "Legend":
								Utils.VRCUiPopupManager.ShowAlert("Aww ", $"You lost Your Legend Rank\n and are now Trusted");
								Achievmentss.DownRankCounter += 2;
								break;
						}
						break;

					case PlayerExtensions.RankType.Veteran:
						switch (Achievmentss.TrustRank)
						{
							case "Visitor":
								Achievmentss.UpRankCounter += 5;
								Utils.VRCUiPopupManager.ShowAlert("Congratulations ", $"You Reached Veteran");
								break;

							case "New User":
								Achievmentss.UpRankCounter += 4;
								Utils.VRCUiPopupManager.ShowAlert("Congratulations ", $"You Reached Veteran");
								break;

							case "User":
								Achievmentss.UpRankCounter += 3;
								Utils.VRCUiPopupManager.ShowAlert("Congratulations ", $"You Reached Veteran");
								break;

							case "Known":
								Achievmentss.UpRankCounter += 2;
								Utils.VRCUiPopupManager.ShowAlert("Congratulations ", $"You Reached Veteran");
								break;

							case "Trusted":
								Achievmentss.UpRankCounter++;
								Utils.VRCUiPopupManager.ShowAlert("Congratulations ", $"You Reached Veteran");
								break;

							case "Veteran":
								break;

							case "Legend":
								Utils.VRCUiPopupManager.ShowAlert("Aww ", $"You lost Your Legend Rank\n and are now Trusted");
								Achievmentss.DownRankCounter += 1;
								break;
						}
						break;

					case PlayerExtensions.RankType.Legend:
						switch (Achievmentss.TrustRank)
						{
							case "Visitor":
								Achievmentss.UpRankCounter += 6;
								Utils.VRCUiPopupManager.ShowAlert("Congratulations ", $"You Reached Legend");
								break;

							case "New User":
								Achievmentss.UpRankCounter += 5;
								Utils.VRCUiPopupManager.ShowAlert("Congratulations ", $"You Reached Legend");
								break;

							case "User":
								Achievmentss.UpRankCounter += 4;
								Utils.VRCUiPopupManager.ShowAlert("Congratulations ", $"You Reached Legend");
								break;

							case "Known":
								Achievmentss.UpRankCounter += 3;
								Utils.VRCUiPopupManager.ShowAlert("Congratulations ", $"You Reached Legend");
								break;

							case "Trusted":
								Achievmentss.UpRankCounter += 2;
								Utils.VRCUiPopupManager.ShowAlert("Congratulations ", $"You Reached Legend");
								break;

							case "Veteran":
								Achievmentss.UpRankCounter++;
								Utils.VRCUiPopupManager.ShowAlert("Congratulations ", $"You Reached Legend");
								break;

							case "Legend":
								break;
						}
						break;
				}
				if (Achievmentss.TrustRank != APIUser.CurrentUser.GetRank())
				{
					ModConsole.Log($"[Achievments] You were {Achievmentss.TrustRank} and now {APIUser.CurrentUser.GetRank()}");
				}
				Achievmentss.TrustRank = APIUser.CurrentUser.GetRank();
				Achievmentss.SaveConfig();
			}
		}

		private static void CheckFriends()
		{
			int friendsCount = Achievmentss.FriendCount;
			int friendsCount2 = APIUser.CurrentUser.friendIDs.Count;
			if (friendsCount2 > 10 && friendsCount < 10 && friendsCount2 < 50)
			{
				Utils.VRCUiPopupManager.ShowAlert("Congratulations ", "You reached Over 10 Friends");
				ModConsole.Log("Congratulations You reached Over 10 Friends");
			}
			if (friendsCount2 > 50 && friendsCount < 50 && friendsCount2 < 100)
			{
				Utils.VRCUiPopupManager.ShowAlert("Congratulations ", "You reached Over 50 Friends");
				ModConsole.Log("Congratulations You reached Over 50 Friends");
			}
			if (friendsCount2 > 100 && friendsCount < 100 && friendsCount2 < 250)
			{
				Utils.VRCUiPopupManager.ShowAlert("Congratulations ", "You reached Over 100 Friends");
				ModConsole.Log("Congratulations You reached Over 100 Friends");
			}
			if (friendsCount2 > 250 && friendsCount < 250 && friendsCount2 < 500)
			{
				Utils.VRCUiPopupManager.ShowAlert("Congratulations ", "You reached Over 250 Friends");
				ModConsole.Log("Congratulations You reached Over 250 Friends");
			}
			if (friendsCount2 > 500 && friendsCount < 500 && friendsCount2 < 1000)
			{
				Utils.VRCUiPopupManager.ShowAlert("Congratulations ", "You reached Over 500 Friends");
				ModConsole.Log("Congratulations You reached Over 500 Friends");
			}
			if (friendsCount2 > 1000 && friendsCount < 1000)
			{
				Utils.VRCUiPopupManager.ShowAlert("Congratulations ", "You reached Over 1000 Friends");
				ModConsole.Log("Congratulations You reached Over 1000 Friends");
			}
			Achievmentss.FriendCount = friendsCount2;
			Achievmentss.SaveConfig();
		}

		private static Achievments Achievmentss;

		private static string AchievementsPath = @"AstroClient\Achievements.json";

		public class Achievments
		{
			public bool AchievmentsTracking = true;
			public string CommentForUser = "These are Achievments. Pls dont Fucking Change it @Anthony add good Description";
			public int FriendCount = 0;
			public int UpRankCounter = 0;
			public int DownRankCounter = 0;
			public string TrustRank = "";

			public void SaveConfig()
			{
				string contents = JsonConvert.SerializeObject(this, Formatting.Indented);
				File.WriteAllText(AchievementsPath, contents);
			}

			public static Achievments Load()
			{
				string path = AchievementsPath;
				if (!File.Exists(path))
				{
					string contents = JsonConvert.SerializeObject(new Achievments(), Formatting.Indented);
					File.WriteAllText(AchievementsPath, contents);
					return new Achievments();
				}
				return JsonConvert.DeserializeObject<Achievments>(File.ReadAllText(path));
			}
		}
	}
}