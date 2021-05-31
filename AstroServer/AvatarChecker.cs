namespace AstroServer
{
	using AstroServer.Serializable;
	using MongoDB.Driver;
	using MongoDB.Entities;
	using System;
	using System.Linq;
	using System.Net;
	using System.Timers;

	public static class AvatarChecker
	{
		private static System.Timers.Timer CheckTimer;

		private static bool IsChecking;

		private static string[] proxies = {
			"104.214.38.138:8080",
			"213.232.127.223:8085",
			"157.230.103.189:46539",
			"88.82.95.146:3128",
			"2.50.154.149:53281",
			"146.185.234.144:3128",
			"167.172.180.46:43135",
			"165.22.64.68:37793",
		};

		public static void Initialize()
		{
			//CheckTimer = new System.Timers.Timer(60000);
			CheckTimer = new System.Timers.Timer(10000);
			CheckTimer.Enabled = true;
			CheckTimer.Elapsed += OnTimerElapsed;
			Console.WriteLine("AvatarChecker: Initialized.");
		}

		private static int GetChecked()
		{
			return DB.Find<AvatarDataEntity>().ManyAsync(a => a.CheckedRecently).Result.Count();
		}

		private static int GetNotChecked()
		{
			return DB.Find<AvatarDataEntity>().ManyAsync(a => !a.CheckedRecently).Result.Count();
		}

		private static void OnTimerElapsed(object sender, ElapsedEventArgs e)
		{
			if (!IsChecking)
			{
				IsChecking = true;
				//var rand = new Random();
				//CheckTimer.Interval = 2000;

				try
				{
					var toCheck = DB.Find<AvatarDataEntity>().Limit(60).ManyAsync(f => !f.CheckedRecently).Result;

					if (toCheck.Any())
					{
						Console.WriteLine($"Avatar check in progress! Checking {toCheck.Count()} avatars..");
						foreach (var found in toCheck)
						{
							CheckAvatar(found);
						}
						Console.WriteLine("Avatar check done!");
						Console.WriteLine($"There are {GetNotChecked()} avatars left to check.");
						Console.WriteLine($"There are {GetChecked()} avatars already checked.");
					}
					else
					{
						Console.WriteLine("Avatar checking is caught up!");
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}

				IsChecking = false;
			}
			else
			{
				Console.WriteLine("Avatar Check Already In Progress...");
			}
		}

		/// <summary>
		/// Adds the avatar to the checker which removes it from the database if it doesn't exist anymore.
		/// </summary>
		/// <param name="avatarDataEntity"></param>
		public static void CheckAvatar(AvatarDataEntity avatarDataEntity)
		{
			var image1 = CheckImage(avatarDataEntity.ThumbnailURL);
			var image2 = CheckImage(avatarDataEntity.ImageURL);

			if (image1 == 0 || image2 == 0)
			{
				Console.WriteLine($"Invalid avatar found: {avatarDataEntity.Name}, {avatarDataEntity.ThumbnailURL}, {avatarDataEntity.ImageURL}");
				avatarDataEntity.DeleteAsync().GetAwaiter().GetResult();
			}
			else if (image1 == 2 || image2 == 2)
			{
				avatarDataEntity.CheckedRecently = false;
				_ = avatarDataEntity.SaveAsync();
			}
			else
			{
				avatarDataEntity.CheckedRecently = true;
				_ = avatarDataEntity.SaveAsync();
			}
		}

		public static int CheckImage(string url)
		{
			var rand = new Random();
			var proxyObject = new WebProxy($"http://{proxies[rand.Next(0, proxies.Count())]}/");
			//string HeaderFake = $"{VRCApplicationSetup.field_Private_Static_VRCApplicationSetup_0.field_Public_String_0}-{VRCApplicationSetup.field_Private_Static_VRCApplicationSetup_0.field_Public_Int32_0}--Release";
			try
			{
				proxyObject.UseDefaultCredentials = true;
				HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
				webRequest.AllowWriteStreamBuffering = true;
				webRequest.Timeout = 30000;
				webRequest.Proxy = proxyObject;

				webRequest.Headers.Add("User-Agent", "VRCX 2021.04.04");
				webRequest.Headers.Add("X-Platform", "standalonewindows");
				//webRequest.Headers.Add("X-Client-Version", HeaderFake);
				//webRequest.Headers.Add("User-Agent", "VRC.Core.BestHTTP");

				using (var response = webRequest.GetResponse())
				{
					using (var responseStream = response.GetResponseStream())
					{
					}
				}
			}
			catch (WebException ex) when ((ex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.NotFound)
			{
				return 0;
			}
			catch (WebException we)
			{
				Console.WriteLine($"{we.Message}: {proxyObject.Address}, {url}");
				return 2;
			}
			catch (Exception e)
			{
				Console.WriteLine($"{e.Message}: {proxyObject.Address}, {url}");
				return 2;
			}

			return 1;
		}
	}
}
