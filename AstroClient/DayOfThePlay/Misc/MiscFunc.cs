namespace DayClientML2.Utility
{
	#region Imports
	using AstroLibrary.Console;
	using DayClientML2.Managers;
	using DayClientML2.Utility.Extensions;
	using MelonLoader;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.IO;
	using System.Linq;
	using System.Net;
	using System.Runtime.InteropServices;
	using Transmtn.DTO.Notifications;
	using UnityEngine;
	using UnityEngine.UI;
	using VRC;
	using VRC.Core;
	using VRC.SDKBase;
	using VRC.UI;
	using VRC_EventHandler = VRC.SDKBase.VRC_EventHandler;
	#endregion

	internal class MiscFunc
	{
		public static void CleanRoom()
		{
			GameObject gameObject = (from x in UnityEngine.Object.FindObjectsOfType<GameObject>()
									 where x.name == "DrawingManager"
									 select x).First();
			Networking.RPC(0, gameObject, "CleanRoomRPC", null);
		}

		public static void DropPortal(string RoomId)
		{
			string[] Location = RoomId.Split(':');
			DropPortal(Location[0], Location[1], 0,
				Utils.CurrentUser.transform.position + (Utils.CurrentUser.transform.forward * 2f),
				Utils.CurrentUser.transform.rotation);
		}

		public static void DropPortal(string WorldID, string InstanceID, int players, Vector3 vector3,
			Quaternion quaternion)
		{
			GameObject gameObject = Networking.Instantiate(VRC_EventHandler.VrcBroadcastType.Always,
				"Portals/PortalInternalDynamic", vector3, quaternion);
			string world = WorldID;
			string instance = InstanceID;
			int count = players;
			Networking.RPC(RPC.Destination.AllBufferOne, gameObject, "ConfigurePortal", new Il2CppSystem.Object[]
			{
				(Il2CppSystem.String) world,
				(Il2CppSystem.String) instance,
				new Il2CppSystem.Int32
				{
					m_value = count
				}.BoxIl2CppObject()
			});
			// MelonCoroutines.Start(MiscUtility.DestroyDelayed(1f, gameObject.GetComponent<PortalInternal>()));
		}

		//public static void ShowWorldDetails(ApiWorld World) { UiWorldListFixed.Method_Public_Static_Void_ApiWorld_PDM_0(World); }
		private static GameObject Capsule;

		public static void CustomSerialize(bool Toggle)
		{
			try
			{
				if (Toggle)
				{
					Capsule = UnityEngine.Object.Instantiate(Utils.CurrentUser.prop_VRCAvatarManager_0.prop_GameObject_0, null, true);
					var animator = Capsule.GetComponent<Animator>();
					if (animator != null
						&& animator.isHuman)
					{
						var headTransform = animator.GetBoneTransform(HumanBodyBones.Head);
						if (headTransform != null)
							headTransform.localScale = Vector3.one;
					}
					Capsule.name = "Serialize Capsule";
					foreach (var comp in Capsule.GetComponents<Component>())
					{
						if (!(comp is Transform))
						{
							UnityEngine.Object.Destroy(comp);
						}
					}
					Capsule.transform.position = Utils.CurrentUser.transform.position;
					Capsule.transform.rotation = Utils.CurrentUser.transform.rotation;
				}
				if (!Toggle)
				{
					UnityEngine.Object.Destroy(Capsule);
					//Utils.CurrentUser.gameObject.GetComponentInChildren<FlatBufferNetworkSerializer>().enabled = true;
				}
			}
			catch { }
		}

		private static Vector3 SavePosition;

		//public static void SecrectSerialize(bool State)
		//{
		//    if (State)
		//    {
		//        SavePosition = Utils.CurrentUser.transform.position;
		//        Utils.CurrentUser.transform.position = Vector3.positiveInfinity;
		//        MiscUtility.DelayFunction(0.1f, delegate
		//         {
		//             GlobalSettings.Serialize = true;
		//         });
		//        MiscUtility.DelayFunction(0.2f, delegate
		//        {
		//            Utils.CurrentUser.transform.position = SavePosition;
		//        });
		//    }
		//    else
		//    {
		//        GlobalSettings.Serialize = false;
		//    };
		//}

		public static void Respawn()
		{
			Utils.QuickMenu.transform.Find("ShortcutMenu/RespawnButton").GetComponent<Button>().onClick.Invoke();
		}

		private static VRC_Trigger cached;

		public static void GodMode(bool state)
		{
			cached = null;
			foreach (VRC_Trigger trigger in UnityEngine.Object.FindObjectsOfType<VRC_Trigger>())
			{
				if (trigger.name == "Death")
				{
					cached = trigger;
				}
			}
			if (cached == null)
			{
				MelonLogger.Warning("Failed to find Murder Logic 3 Death trigger.");
				return;
			}
			cached.gameObject.SetActive(!state);
		}

		public static void CopyToClipboard(string copytext)
		{
			TextEditor textEditor = new TextEditor();
			textEditor.text = copytext;
			textEditor.SelectAll();
			textEditor.Copy();
			Utils.VRCUiManager.QueHudMessage("Copied to Clipboard");
		}

		public static void EXECUTEORDER66()
		{
			string[] Friends = File.ReadAllLines(FileManager.PathFriends);
			foreach (string line in APIUser.CurrentUser.friendIDs)
				if (!Friends.Contains(line))
				{
					ModConsole.Log("[Friends] Added: " + line);
					File.AppendAllText(FileManager.PathFriends, $"{line},{null},{null}" + Environment.NewLine);
				}
		}

		public static void RemoveOrder66(string id)
		{
			try
			{
				List<string> Friends = File.ReadAllLines(FileManager.PathFriends).ToList();
				Friends.Remove(id);
				File.Delete(FileManager.PathFriends);
				File.WriteAllLines(FileManager.PathFriends, Friends);
			}
			catch (Exception)
			{
				throw;
			}
		}

		public static IEnumerator UNEXECUTEORDER66()
		{
			string[] Friends = File.ReadAllLines(FileManager.PathFriends);
			Console.WriteLine(
				$"[Friends] About to Send {Friends.Length} Friend Requests. ETC {(Friends.Length * 5) + (Friends.Length / 20 * 75)} Seconds");
			Stopwatch stopwatch = Stopwatch.StartNew();
			int i = 0;
			int requests = 0;
			foreach (string line in Friends)
			{
				if (!line.Contains("usr_")) continue;
				var id = line;
				if (line.Contains(","))
				{
					var split = line.Split(',');
					id = split[0];
				}
				if (!APIUser.IsFriendsWith(id))
				{
					yield return new WaitForSeconds(5);
					ModConsole.Log("[Friends] send a Request to " + id);
					Notification xx = FriendRequest.Create(id);
					Utils.VRCWebSocketsManager.SendNotification(xx);
					i++;
					requests++;
					if (i >= 20)
					{
						i = 0;
						ModConsole.Log("[Friends] Waiting to not get rate limited!");
						yield return new WaitForSeconds(75);
					}
				}
				else
				{
					ModConsole.Error("[Friends] Skipping " + id);
				}
				ModConsole.Log($"[Friends] {(float)requests * 100 / Friends.Length:0.00}%");
			}

			stopwatch.Stop();
			Console.WriteLine("=============================");
			Console.WriteLine(
				$"Summary:\n with {File.ReadAllLines(FileManager.PathFriends).Length} friends\n Took {stopwatch.Elapsed}");
			yield break;
		}

		public static void ForceJoin(string roomID)
		{
			if (Networking.GoToRoom(roomID))
			{
				ModConsole.Log("[Join] Success");
				ModConsole.DebugLog("<color=#59D365>[Join] Success</color>");
			}
			else
			{
				new PortalInternal().EnterPortal(roomID.Split(':')[0], roomID.Split(':')[1]);
				ModConsole.Log("[Join] Failure Using Backup");
				ModConsole.DebugLog("<color=red>[Join] Failure Using Backup</color>");
			}
		}

		public static void DeletePortals()
		{
			PortalTrigger[] array = Resources.FindObjectsOfTypeAll<PortalTrigger>();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].gameObject.activeInHierarchy &&
					!(array[i].gameObject.GetComponentInParent<VRC_PortalMarker>() != null))
				{
					UnityEngine.Object.Destroy(array[i].gameObject);
				}
			}
		}

		public static void PortalColor(Color color)
		{
			Resources.FindObjectsOfTypeAll<PortalInternal>().Where(portal => portal.gameObject.activeInHierarchy &&
																			 !(bool)portal.gameObject
																				 .GetComponentInParent<VRC_PortalMarker
																				 >()).ToList()
				.ForEach(p =>
				{
					var childGraph = p.transform.root.gameObject.GetComponentInChildren<Graphic>();
					childGraph.color = color;
				});
		}

		internal static void ResetTimer()
		{
			SetTimer(0);
		}

		internal static void PortalZeroTime()
		{
			SetTimer(1000000f);
		}

		internal static void SetTimer(float timee)
		{
			if (UnityEngine.Object.FindObjectsOfType<PortalInternal>() == null)
				return;
			var time = new Il2CppSystem.Single { m_value = timee }.BoxIl2CppObject();
			PortalTrigger[] array = Resources.FindObjectsOfTypeAll<PortalTrigger>();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].gameObject.activeInHierarchy &&
					!(array[i].gameObject.GetComponentInParent<VRC_PortalMarker>() != null))
				{
					Networking.RPC(RPC.Destination.AllBufferOne, array[i].gameObject, "SetTimerRPC",
					new Il2CppSystem.Object[]
					{
						time,
					});
				}
			}
		}

		internal static void HardResetTimer()
		{
			SetTimer(float.MinValue);
		}

		public static void ChangeAvatar(string avatarID)
		{
			new PageAvatar
			{
				field_Public_SimpleAvatarPedestal_0 = new SimpleAvatarPedestal
				{
					field_Internal_ApiAvatar_0 = new ApiAvatar
					{
						id = avatarID
					}
				}
			}.ChangeToSelectedAvatar();
		}

		public static void ChangeAvatar2(string AvatarID)
		{
			PageAvatar component = GameObject.Find("Screens").transform.Find("Avatar").GetComponent<PageAvatar>();
			component.field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0.id = AvatarID;
			component.ChangeToSelectedAvatar();
		}

		public static void PortalToInstance(APIUser user)
		{
			if (user.location == "private")
			{
				Utils.VRCUiPopupManager.ShowAlert("[DayClient] Error", user.displayName + " Is a Private World");
				return;
			}

			if (user.id == APIUser.CurrentUser.id)
			{
				Utils.VRCUiPopupManager.ShowAlert("[DayClient] Error", "Cant Drop Portal on Yourself");
				return;
			}

			if (user.location == null || user.location == "")
			{
				Utils.VRCUiPopupManager.ShowAlert("[DayClient] Error",
					"Player " + user.displayName + " has no valid location!");
				return;
			}

			DropPortal(user.location);
		}

		public static void ChangePedestals(string ID)
		{
			foreach (VRC_AvatarPedestal pedestal in UnityEngine.Object.FindObjectsOfType<VRC_AvatarPedestal>())
			{
				Networking.RPC(RPC.Destination.All, pedestal.gameObject, "SwitchAvatar", new Il2CppSystem.Object[]
				{
					ID
				});
			}
		}

		public static void ForceAvatarChange(Player player)
		{
			Networking.RPC(RPC.Destination.All, player.gameObject, "ReloadAvatarNetworkedRPC", new Il2CppSystem.Object[]
			{
			});
		}

		public static void AddEveryone()
		{
			NotificationManager xxx = Utils.NotificationManager;
			Console.Clear();
			Console.WriteLine(
				"[DAY]-----------------------------------Add players-----------------------------------");
			Player[] allPlayers = Utils.PlayerManager.AllPlayers().ToArray();
			for (int i = 0; i < allPlayers.Length; i++)
			{
				Player x = allPlayers[i];
				string id = x.GetAPIUser().id;
				if (x.field_Private_APIUser_0.isFriend)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("[DAY] Not Adding Friend ---> [" + x.GetAPIUser().displayName +
											 " [User ID] = " + id + "]");
					Console.ForegroundColor = ConsoleColor.White;
				}
				else
				{
					Notification xx = FriendRequest.Create(id);
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("[DAY] Adding ---> " + x.GetAPIUser().displayName + " [User ID] = " + id);
					VRCWebSocketsManager.field_Private_Static_VRCWebSocketsManager_0.prop_Api_0.PostOffice.Send(xx);
					Console.ForegroundColor = ConsoleColor.White;
				}
			}

			Console.WriteLine(
				"[DAY]----------------------------Done Adding players--------------------------------");
		}

		public static void SendInvite(string Message, string WorldID, string worldname, string playerID)
		{
			try
			{
				NotificationDetails notificationDetails = new NotificationDetails();
				notificationDetails.Add("worldId", (Il2CppSystem.String)WorldID);
				notificationDetails.Add("worldName", (Il2CppSystem.String)worldname);
				notificationDetails.Add("inviteMessage", (Il2CppSystem.String)Message);
				//notificationDetails.Add("imageUrl", (Il2CppSystem.String)APIUser.CurrentUser.currentAvatarThumbnailImageUrl);
				Notification xx = Notification.Create(playerID, "invite", "",
					notificationDetails);
				VRCWebSocketsManager.field_Private_Static_VRCWebSocketsManager_0.prop_Api_0.PostOffice.Send(xx);
				ModConsole.Log("Send Invite to: " + playerID);
			}
			catch
			{
				MelonLogger.Msg("Invite Failed");
			}
		}

		public static void SendRequestMessage(string Message, string playerID)
		{
			try
			{
				NotificationDetails notificationDetails = new NotificationDetails();
				notificationDetails.Add("requestMessage", (Il2CppSystem.String)Message);
				notificationDetails.Add("imageUrl", (Il2CppSystem.String)APIUser.CurrentUser.currentAvatarThumbnailImageUrl);
				Notification xx = Notification.Create(playerID, Notification.NotificationType.Requestinvite, "",
					notificationDetails);
				VRCWebSocketsManager.field_Private_Static_VRCWebSocketsManager_0.prop_Api_0.PostOffice.Send(xx);
				//VRCWebSocketsManager.field_Private_Static_VRCWebSocketsManager_0.prop_Api_0.PostOffice.Send(Invite.Create(playerID, WorldName, new Location(WorldName, new Instance("", playerID, "", "", "", false)), WorldName));
				// Utils.NotificationManager.SendNotification(playerID, "invite", WorldName, notificationDetails);
				ModConsole.Log("Send Invite to: " + playerID);
			}
			catch
			{
				MelonLogger.Msg("Invite Failed");
			}
		}

		public static void RequestInvite(string UserID, int NumOfTimes)
		{
			for (int i = 0; i < NumOfTimes; i++)
			{
				try
				{
					NotificationDetails notificationDetails = new NotificationDetails();
					NotificationManager.field_Private_Static_NotificationManager_0
						.SendNotification(UserID, "requestInvite",
							string.Empty, notificationDetails);
				}
				catch (Exception e)
				{
					ModConsole.Error("Request Invite Failed, Exception | " + e);
					Utils.VRCUiPopupManager.Alert("Request Invite Failed", "Please report this to Love#3000", "Okay",
						new Action(() => { Utils.VRCUiPopupManager.HideCurrentPopUp(); }));
				}
			}

			ModConsole.Log("Sent " + NumOfTimes + " request invites to " + UserID);
			ModConsole.DebugLog("<color=#59D365>Succesfully sent</color> <color=yellow>" + NumOfTimes +
								"</color> <color=#59D365>request invites</color>");
		}

		public static void EmojiRPC(int i)
		{
			try
			{
				var x = new Il2CppSystem.Int32();
				x.m_value = i;
				var obj = x.BoxIl2CppObject();
				Networking.RPC(0, Utils.CurrentUser.gameObject, "SpawnEmojiRPC", new Il2CppSystem.Object[]
				{
					obj,
				});
			}
			catch
			{
			}
		}

		public static void PlayEmoteRPC(int i)
		{
			try
			{
				var x = new Il2CppSystem.Int32();
				x.m_value = i;
				var obj = x.BoxIl2CppObject();
				Networking.RPC(0, Utils.CurrentUser.gameObject, "PlayEmoteRPC", new Il2CppSystem.Object[]
				{
					obj,
				});
			}
			catch
			{
			}
		}

		public static void TransferOwnership(VRCPlayerApi PLR, GameObject gameObject)
		{
			Networking.SetOwner(PLR, gameObject);
		}

		public static void TakeOwnershipIfNecessary(GameObject gameObject)
		{
			if (GetOwnerOfGameObject(gameObject) != Utils.CurrentUser._player)
				Networking.SetOwner(Utils.CurrentUser.field_Private_VRCPlayerApi_0, gameObject);
		}

		public static Player GetOwnerOfGameObject(GameObject gameObject)
		{
			foreach (Player player in Utils.PlayerManager.AllPlayers())
			{
				if (player.field_Private_VRCPlayerApi_0.IsOwner(gameObject))
					return player;
			}

			return null;
		}

		public static void DownloadAvatar(ApiAvatar avatar)
		{
			try
			{
				string assetUrl = avatar.assetUrl;
				string pictureUrl = avatar.imageUrl;
				using (WebClient webClient = new WebClient())
				{
					webClient.DownloadFileAsync(new Uri(assetUrl), FileManager.VRCAPath + '\\' + avatar.name + ".vrca");
				}

				using (WebClient webClient = new WebClient())
				{
					webClient.DownloadFileAsync(new Uri(pictureUrl),
						FileManager.VRCAPath + '\\' + avatar.name + ".png");
				}

				ModConsole.Log("[VRCA] Downloaded " + avatar.name);
				ModConsole.DebugLog(
					"<color=#59D365>VRCA Downloaded</color> <color=yellow>(" + avatar.name + ")</color>");
			}
			catch (Exception e)
			{
				ModConsole.Error("[VRCA]Download Error");
				ModConsole.ErrorExc(e);
			}
		}

		public static void InviteALLFriends()
		{
			try
			{
				Console.Clear();
				Console.WriteLine(
					"[DAY]-----------------------------------Invite Friends-----------------------------------");
				APIUser.CurrentUser.Fetch();
				int number = APIUser.CurrentUser.friendIDs.Count;
				int invite = 0;
				foreach (string id in APIUser.CurrentUser.friendIDs)
				{
					//SendInvite("",
					//    RoomManager.field_Internal_Static_ApiWorld_0.id + ":" +
					//    RoomManager.field_Internal_Static_ApiWorldInstance_0.idWithTags, id);
					invite++;
				}

				Console.WriteLine(string.Concat(new object[]
				{
					"[Day]---~-Summary-~---",
					Environment.NewLine,
					"~Total Invites: ",
					invite,
					Environment.NewLine,
					"~Friend Count: ",
					number,
					Environment.NewLine,
				}));
			}
			catch (Exception)
			{
				throw;
			}
		}

		public static void RequestALLFriends()
		{
			try
			{
				Console.Clear();
				Console.WriteLine(
					"[DAY]-----------------------------------Request Friends-----------------------------------");
				APIUser.CurrentUser.Fetch();
				int number = APIUser.CurrentUser.friendIDs.Count;
				int invite = 0;
				foreach (string id in APIUser.CurrentUser.friendIDs)
				{
					RequestInvite(id, 1);
					invite++;
				}

				Console.WriteLine(string.Concat(new object[]
				{
					"[Day]---~-Summary-~---",
					Environment.NewLine,
					"~Total Requests: ",
					invite,
					Environment.NewLine,
					"~Friend Count: ",
					number,
					Environment.NewLine,
				}));
			}
			catch (Exception)
			{
				throw;
			}
		}

		internal static void ClearCache()
		{
			try
			{
				var pathWithEnv = @"%USERPROFILE%\AppData\LocalLow\VRChat\VRChat\Cache-WindowsPlayer";
				var filePath = Environment.ExpandEnvironmentVariables(pathWithEnv);
				if (Directory.Exists(filePath))
				{
					ModConsole.Log("[Utils] Checking your Cache size...");
					DirectoryInfo fi = new DirectoryInfo(filePath);
					if (fi.GetFiles().Length >= 1800000)
					{
						ModConsole.Log("[Utils] Your Cache could potentially cause lag... Cleaning...");
						foreach (FileInfo file in fi.GetFiles())
						{
							file.Delete();
						}

						foreach (DirectoryInfo dir in fi.GetDirectories())
						{
							dir.Delete(true);
						}

						ModConsole.Log("[Utils] Cache cleaned!");
					}
					else
					{
						ModConsole.Log("[Utils] Checked your Cache and its fine :)");
					}
				}
			}
			catch (Exception)
			{
				ModConsole.Error("[Utils] Failed to clear your cache");
			}
		}

		public static void SetVideoLink(string url)
		{
			var videoPlayers = Resources.FindObjectsOfTypeAll<VRCSDK2.VRC_SyncVideoPlayer>();
			if (videoPlayers.Count() > 0)
				foreach (VRCSDK2.VRC_SyncVideoPlayer videoPlayer in videoPlayers)
				{
					Networking.RPC(RPC.Destination.Owner, videoPlayers[0].gameObject, "AddURL", new Il2CppSystem.Object[]
				{
						(Il2CppSystem.String)url
				});
				}
		}

		public static void CopyVideoLink()
		{
			var videoPlayers = Resources.FindObjectsOfTypeAll<VRCSDK2.VRC_SyncVideoPlayer>();
			if (videoPlayers.Count() > 0)
			{
				if (videoPlayers[0].Videos.Count > 0)
				{
					System.Windows.Forms.Clipboard.SetText(videoPlayers[0].Videos[0].URL);
					Utils.VRCUiManager.QueHudMessage("Copied video player url to clipboard");
				}
				else
				{
					Utils.VRCUiManager.QueHudMessage("Video player does not contain any videos");
				}
			}
			else
			{
				Utils.VRCUiManager.QueHudMessage("There are no video players in the world");
			}
		}

		public static void VidePlayerRPC(string method)
		{
			var videoPlayers = Resources.FindObjectsOfTypeAll<VRCSDK2.VRC_SyncVideoPlayer>();
			if (videoPlayers.Count() > 0)
				foreach (VRCSDK2.VRC_SyncVideoPlayer videoPlayer in videoPlayers)
				{
					Networking.RPC(RPC.Destination.Owner, videoPlayer.gameObject, method, new Il2CppSystem.Object[0]);
				}
		}

		internal static void OpenLinkInBrowser(string url)
		{
			try
			{
				Process.Start(url);
			}
			catch
			{
				if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
				{
					url = url.Replace("&", "^&");
					Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
				}
				if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
				{
					Process.Start("xdg-open", url);
				}
				if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
				{
					Process.Start("open", url);
				}
				else
				{
					throw;
				}
			}
		}

		public static void Invisible()
		{
			for (int i = 0; i < 20; i++)
			{
				VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position = new Vector3(999999999999 * 2, 999999999999 * 2, 999999999999 * 2);
				VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position = new Vector3(999999999999 * 2, 999999999999 * 2, 999999999999 * 2);
				VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position = new Vector3(999999999999 * 2, 999999999999 * 2, 999999999999 * 2);
				VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position = new Vector3(999999999999 * 2, 999999999999 * 2, 999999999999 * 2);
				VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position = new Vector3(999999999999 * 2, 999999999999 * 2, 999999999999 * 2);
			}
		}
	}
}