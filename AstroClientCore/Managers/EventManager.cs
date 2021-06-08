namespace AstroClientCore.Managers
{
	using AstroClientCore.Events;
	using AstroLibrary.Console;
	using DayClientML2.Utility;
	using Harmony;
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
		public static EventHandler<PhotonPlayerEventArgs> PhotonPlayerJoined;
		public static EventHandler<PhotonPlayerEventArgs> PhotonPlayerLeft;

		public static void ApplyPatches()
		{
			//PatchManager.AddPatch(new Patching.Patch(typeof(AssetBundleDownloadManager).GetMethod(nameof(AssetBundleDownloadManager.Method_Internal_Void_ApiAvatar_PDM_0)), GetPatch(nameof(OnAvatarDownload))));
			PatchManager.AddPatch(new Patching.Patch(typeof(NetworkManager).GetMethod(XrefTesting.OnPhotonPlayerJoinMethod.Name), GetPatch(nameof(OnPhotonPlayerJoin))));
			PatchManager.AddPatch(new Patching.Patch(typeof(NetworkManager).GetMethod(XrefTesting.OnPhotonPlayerJoinMethod.Name), GetPatch(nameof(OnPhotonPlayerLeft))));
		}

		public static HarmonyMethod GetPatch(string name)
		{
			return new HarmonyMethod(typeof(EventManager).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
		}

		//private static bool OnAvatarDownload(ref ApiAvatar __0)
		//{
		//	if (__0 != null)
		//	{
		//		PhotonPlayerJoined?.Invoke(__0, new EventArgs(__0));
		//	}
		//	else
		//	{
		//		ModConsole.Error($"[Photon] OnPhotonPlayerJoin Failed! __0 was null.");
		//	}
		//}

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
