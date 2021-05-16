﻿namespace AstroServer
{
	using AstroServer.Serializable;
	using MongoDB.Entities;
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Threading.Tasks;

	internal static class KeyManager
	{
		/// <summary>
		/// Returns the auth token for the DiscordBot
		/// </summary>
		/// <returns></returns>
		public static string GetBotToken()
		{
			return File.ReadAllText("/root/discordtoken.txt");
		}

		public static void AddKey(string key, ulong discordID)
		{
			using (StreamWriter sw = File.AppendText("/root/keys.txt"))
			{
				sw.WriteLine($"{Environment.NewLine}{key}:{discordID}");
			}
		}

		public static int GetDevKeyCount()
		{
			return File.ReadAllLines("/root/devs.txt").Length;
		}

		public static int GetKeyCount()
		{
			return File.ReadAllLines("/root/keys.txt").Length;
		}

		public static Dictionary<string, ulong> GetAllDevKeyInfo()
		{
			Dictionary<string, ulong> pairs = new Dictionary<string, ulong>();
			foreach (var keyinfo in File.ReadLines("/root/devs.txt"))
			{
				var info = keyinfo.Split(":");
				pairs.Add(info[0], ulong.Parse(info[1]));
			}
			return pairs;
		}

		public static Dictionary<string, ulong> GetAllKeyInfo()
		{
			Dictionary<string, ulong> pairs = new Dictionary<string, ulong>();
			foreach (var keyinfo in File.ReadLines("/root/keys.txt"))
			{
				var info = keyinfo.Split(":");
				pairs.Add(info[0], ulong.Parse(info[1]));
			}
			return pairs;
		}

		public static bool IsDevKey(string authKey)
		{
			foreach (var keyinfo in File.ReadLines("/root/devs.txt"))
			{
				var info = keyinfo.Split(":");

				if (info[0].Equals(authKey))
				{
					return true;
				}
			}
			return false;
		}

		//public static bool IsValidKey(string authKey)
		//{
		//	foreach (var keyinfo in File.ReadLines("/root/devs.txt"))
		//	{
		//		var info = keyinfo.Split(":");

		//		if (info[0].Equals(authKey))
		//		{
		//			return true;
		//		}
		//	}
		//	foreach (var keyinfo in File.ReadLines("/root/keys.txt"))
		//	{
		//		var info = keyinfo.Split(":");

		//		if (info[0].Equals(authKey))
		//		{
		//			return true;
		//		}
		//	}
		//	return false;
		//}

		public static async Task<bool> IsKeyValidAsync(string key)
		{
			return (await DB.Find<AccountData>().ManyAsync(a => a.Key.Equals(key))).Any();
		}

		public static ulong GetKeysDiscordOwner(string authKey)
		{
			foreach (var keyinfo in File.ReadLines("/root/devs.txt"))
			{
				var info = keyinfo.Split(":");

				if (info[0].Equals(authKey))
				{
					return ulong.Parse(info[1]);
				}
			}
			foreach (var keyinfo in File.ReadLines("/root/keys.txt"))
			{
				var info = keyinfo.Split(":");

				if (info[0].Equals(authKey))
				{
					return ulong.Parse(info[1]);
				}
			}
			return 0;
		}
	}
}