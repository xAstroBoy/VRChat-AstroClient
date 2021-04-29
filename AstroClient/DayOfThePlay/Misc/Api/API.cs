using AstroClient.ConsoleUtils;
using DayClientML2.Managers;
using DayClientML2.Utility.Api.Object;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using UnityEngine;
using VRC.Core;

namespace DayClientML2.Utility.Api
{
	internal class API
	{
		private const string APIKEYLONG = "?apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26";
		private const string APIKEY = "JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26";
		private const string APIURL = "https://api.vrchat.cloud/api/1/";

		private const string WorldCommand = "worlds/";
		private const string UserCommand = "users/";
		private const string JoinCommand = "joins/";
		private const string VisitCommand = "visits/";
		private const string AuthCommand = "auth/user";
		private const string GetAgainstCommand = "playermoderated";
		private const string GetPlayersCommand = "playermoderations";
		private const string AvatarCommand = "avatars";

		private static string _ContentType = "application/json";
		public static string Username = "";
		public static string password = "";
		private static string Auth = "";
		public static string[] WorldArray;
		public static DayBots.VRCAPI.API Client;

		public static void InitAPI()
		{
			try
			{
				try
				{
					Client = new DayBots.VRCAPI.API(ApiCredentials.authToken);
				}
				catch (Exception)
				{
					MelonLoader.MelonLogger.Error("[Avatar Search] Didn't Find Password need to enter");
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public static IEnumerator RankUp()
		{
			if (WorldArray == null)
			{
				WorldArray = File.ReadAllLines(FileManager.ClientPath + "\\Worlds.txt");
			}
			ModConsole.Log($"[World Travel] Start!");
			for (; ; )
			{
				string World = WorldArray[new System.Random().Next(0, WorldArray.Length - 1)];
				int RandString = new System.Random().Next(0, 10000);
				Join(World, $"{RandString}");

				yield return new WaitForSeconds(0.1f);
			}
			ModConsole.Log($"[World Travel] Stop!");
			yield break;
		}

		public static void Join(string WorldID, string InstanceID)
		{
			Il2CppSystem.Collections.Generic.Dictionary<string, Il2CppSystem.Object> DickTionary = new Il2CppSystem.Collections.Generic.Dictionary<string, Il2CppSystem.Object>();
			DickTionary.Add("userId", APIUser.CurrentUser.id);
			DickTionary.Add("worldId", $"{WorldID}:{InstanceID}");
			VRC.Core.API.SendPutRequest("joins", null, DickTionary, null);
			VRC.Core.API.SendPutRequest("visits", null, DickTionary, null);
		}

		private static Stopwatch RecursiveWatchTime = new Stopwatch();

		// -Day: start from 0 | Max search = 100;
		public static void AvatarSearch(string userid, int startingfrom, int amount, Il2CppSystem.Collections.Generic.List<ApiAvatar> list)
		{
			if (!RecursiveWatchTime.IsRunning)
				RecursiveWatchTime = Stopwatch.StartNew();
			var param = new Il2CppSystem.Collections.Generic.Dictionary<string, Il2CppSystem.Object>();
			param.Add("userId", userid);
			param.Add("offset", startingfrom.ToString());
			param.Add("n", amount.ToString());
			param.Add("order", "descending");
			VRC.Core.API.SendGetRequest(string.Concat(new object[]
			{
					DayClientML2.Utility.Api.API.AvatarCommand,
			}), new ApiModelListContainer<ApiAvatar>()
			{
				OnSuccess = new Action<ApiContainer>((m) =>
				{
					ApiModelListContainer<ApiAvatar> container = new ApiModelListContainer<ApiAvatar>();
					container.setFromContainer(m);
					foreach (var avatarobject in container.ResponseList)
					{
						if (avatarobject != null)
						{
							var dictonary = avatarobject.Cast<Il2CppSystem.Collections.Generic.Dictionary<string, Il2CppSystem.Object>>();
							var avi = new AvatarObject(dictonary);
							list.Add(avi.ToApiAvatar());
						}
					}
					if (container.ResponseList.Count >= amount)
					{
						AvatarSearch(userid, startingfrom + amount, amount, list);
					}
					else
					{
						ModConsole.Log($"[Search] Api Returned in {RecursiveWatchTime.ElapsedMilliseconds} MS and returned " + list.Count);
						RecursiveWatchTime.Stop();
					}
				}),
				OnError = new Action<ApiContainer>((m) =>
				{
					Console.WriteLine("[Avatar Search] OnError Called with: " + m.responseError);
				}),
			}, param, false, 3600);
		}

		public static List<ApiAvatar> AvatarSearch(string userid, int startingfrom, int amount)
		{
			var _return = new List<ApiAvatar>();
			var avatars = Client.Avatar.GetPublicAvatars(userid, startingfrom, amount).GetAwaiter().GetResult();
			foreach (var avi in avatars)
				_return.Add(avi.ToApiAvatar());
			return _return;
		}

		public static void GetInstance(string worldId, string instanceId, WorldInstanceResponse response)
		{
			VRC.Core.API.SendGetRequest(string.Concat(new object[]
			{
					DayClientML2.Utility.Api.API.WorldCommand,
					worldId,
					"/",
					instanceId
			}), new ApiModelListContainer<ApiAvatar>()
			{
				OnSuccess = new Action<ApiContainer>((m) =>
				{
					Console.WriteLine(m.Data.ToString());
					response = Newtonsoft.Json.JsonConvert.DeserializeObject<WorldInstanceResponse>(m.Data.ToString());
				}),
				OnError = new Action<ApiContainer>((m) =>
				{
				}),
			});
		}

		private static string GetRespondsStream(WebResponse webResponse_0)
		{
			string result = "";
			using (Stream responseStream = webResponse_0.GetResponseStream())
			{
				using (StreamReader streamReader = new StreamReader(responseStream))
				{
					result = streamReader.ReadToEnd();
				}
			}
			webResponse_0.Dispose();
			return result;
		}
	}
}