namespace AstroClientCore.Managers
{
	using AstroClientCore.Events;
	using AstroLibrary.Console;
	using DayClientML2.Utility;
	using ExitGames.Client.Photon;
	using Harmony;
	using Photon.Realtime;
	using System;
	using System.Reflection;
	using VRC.Core;

	public static class EventManager
	{
		public static EventHandler<EventArgs> ApplicationStart;
		public static EventHandler<EventArgs> ApplicationQuit;
		public static EventHandler<EventArgs> Update;
		public static EventHandler<EventArgs> LateUpdate;
		public static EventHandler<EventArgs> GUI;
		public static EventHandler<EventArgs> UiManagerInit;
		public static EventHandler<EventArgs> LevelLoaded;
		public static EventHandler<EventArgs> AvatarDownload;
		public static EventHandler<EventArgs> RaiseEvent;
		public static EventHandler<EventArgs> RPCEvent;
		public static EventHandler<PhotonPlayerEventArgs> PhotonPlayerJoined;
		public static EventHandler<PhotonPlayerEventArgs> PhotonPlayerLeft;

		public static void ApplyPatches()
		{
			PatchManager.AddPatch(new Patching.Patch(typeof(AssetBundleDownloadManager).GetMethod(nameof(AssetBundleDownloadManager.Method_Internal_Void_ApiAvatar_PDM_0)), GetPatch(nameof(OnAvatarDownload))));
			PatchManager.AddPatch(new Patching.Patch(typeof(NetworkManager).GetMethod(XrefTesting.OnPhotonPlayerJoinMethod.Name), GetPatch(nameof(OnPhotonPlayerJoin))));
			PatchManager.AddPatch(new Patching.Patch(typeof(NetworkManager).GetMethod(XrefTesting.OnPhotonPlayerJoinMethod.Name), GetPatch(nameof(OnPhotonPlayerLeft))));
			PatchManager.AddPatch(new Patching.Patch(typeof(LoadBalancingClient).GetMethod(nameof(LoadBalancingClient.Method_Public_Virtual_New_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0)), GetPatch(nameof(OnRaiseEvent))));
			PatchManager.AddPatch(new Patching.Patch(typeof(VRC_EventDispatcherRFC).GetMethod(nameof(VRC_EventDispatcherRFC.Method_Public_Void_Player_VrcEvent_VrcBroadcastType_Int32_Single_0)), GetPatch(nameof(OnRPCEvent))));
		}

		public static HarmonyMethod GetPatch(string name)
		{
			return new HarmonyMethod(typeof(EventManager).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
		}

		private static bool OnRPCEvent(Player __0, VRC.SDKBase.VRC_EventHandler.VrcEvent __1, VRC.SDKBase.VRC_EventHandler.VrcBroadcastType __2, int __3, float __4)
		{
			return true;
		}

		private static bool OnRaiseEvent(ref byte __0, ref Il2CppSystem.Object __1, ref RaiseEventOptions __2, ref SendOptions __3)
		{
			return true;
		}

		private static void OnAvatarDownload(ref ApiAvatar __0)
		{
			if (__0 != null)
			{
				AvatarDownload?.Invoke(__0, new OnAvatarDownloadArgs(__0));
			}
			else
			{
				ModConsole.Error($"[Photon] AvatarDownload Failed! __0 was null.");
			}
		}

		private static void OnPhotonPlayerJoin(ref Photon.Realtime.Player __0)
		{
			if (__0 != null)
			{
				PhotonPlayerJoined?.Invoke(__0, new PhotonPlayerEventArgs(__0));
			}
			else
			{
				ModConsole.Error($"[Photon] OnPhotonPlayerJoin Failed! __0 was null.");
			}
		}

		private static void OnPhotonPlayerLeft(ref Photon.Realtime.Player __0)
		{
			if (__0 != null)
			{
				PhotonPlayerLeft?.Invoke(__0, new PhotonPlayerEventArgs(__0));
			}
			else
			{
				ModConsole.Error($"[Photon] OnPhotonPlayerLeft Failed! __0 was null.");
			}
		}
	}
}
