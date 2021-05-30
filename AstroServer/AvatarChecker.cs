﻿namespace AstroServer
{
	using AstroServer.Serializable;
	using MongoDB.Driver;
	using MongoDB.Entities;
	using System;
	using System.Drawing;
	using System.IO;
	using System.Linq;
	using System.Net;
	using System.Timers;

	public static class AvatarChecker
	{
		private static Timer CheckTimer;

		public static void Initialize()
		{
			CheckTimer = new Timer(60000);
			CheckTimer.Enabled = true;
			CheckTimer.Elapsed += OnTimerElapsed;
			Console.WriteLine("AvatarChecker: Initialized.");
		}

		private static void OnTimerElapsed(object sender, ElapsedEventArgs e)
		{
			var toCheck = DB.Find<AvatarDataEntity>().ManyAsync(f => !f.CheckedRecently).Result.Take(10);

			if (toCheck.Any())
			{
				Console.WriteLine($"Avatar check in progress! Checking {toCheck.Count()} avatars..");
				foreach (var found in toCheck)
				{
					//CheckAvatar(found);
				}
				Console.WriteLine("Avatar check done!");
			}
			else
			{
				Console.WriteLine("Avatar checking is caught up!");
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

			if (!image1 || !image2)
			{
				Console.WriteLine($"Invalid avatar found: {avatarDataEntity.Name}, {avatarDataEntity.ThumbnailURL}, {avatarDataEntity.ImageURL}");
				avatarDataEntity.DeleteAsync().GetAwaiter().GetResult();
			}
			else
			{
				avatarDataEntity.CheckedRecently = true;
				avatarDataEntity.SaveAsync().GetAwaiter().GetResult();
			}
		}

		public static bool CheckImage(string url)
		{
			//string HeaderFake = $"{VRCApplicationSetup.field_Private_Static_VRCApplicationSetup_0.field_Public_String_0}-{VRCApplicationSetup.field_Private_Static_VRCApplicationSetup_0.field_Public_Int32_0}--Release";
			try
			{
				HttpWebRequest webRequest = (HttpWebRequest)System.Net.HttpWebRequest.Create(url);
				webRequest.AllowWriteStreamBuffering = true;
				webRequest.Timeout = 30000;

				webRequest.Headers.Add("User-Agent", "VRCX 2021.04.04");
				webRequest.Headers.Add("X-Platform", "standalonewindows");
				//webRequest.Headers.Add("X-Client-Version", HeaderFake);
				//webRequest.Headers.Add("User-Agent", "VRC.Core.BestHTTP");

				WebResponse webResponse = webRequest.GetResponse();
				webResponse.Close();
			}
			catch (WebException we)
			{
				HttpWebResponse errorResponse = we.Response as HttpWebResponse;
				if (errorResponse.StatusCode == HttpStatusCode.NotFound)
				{
					return false;
				}
			}

			return true;
		}
	}
}
