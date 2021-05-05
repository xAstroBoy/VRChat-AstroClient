namespace AstroClient.Startup.Hooks
{
	#region Imports
	using AstroClient.ConsoleUtils;
	using DayClientML2.Utility;
	using DayClientML2.Utility.Extensions;
	using Harmony;
	using I18N.MidEast;
	using MelonLoader;
	using Photon.Realtime;
	using System;
	using System.Collections;
	using System.Reflection;
	#endregion

	class PhotonPlayerHooks : GameEvents
	{
		public static EventHandler<PhotonPlayerEventArgs> Event_OnPhotonPlayerJoin;

		public static EventHandler<PhotonPlayerEventArgs> Event_OnPhotonPlayerLeft;

		private HarmonyInstance harmony;

		private static HarmonyMethod GetPatch(string name)
		{
			return new HarmonyMethod(typeof(PhotonPlayerHooks).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
		}

		public override void ExecutePriorityPatches()
		{
			MelonCoroutines.Start(Init());
		}

		private IEnumerator Init()
		{
			InitPatch();
			yield break;
		}

		public async void InitPatch()
		{
			try
			{
				if (harmony == null)
				{
					harmony = HarmonyInstance.Create(BuildInfo.Name + " PhotonPlayerEvents");
				}

				if (XrefTesting.OnPhotonPlayerJoinMethod != null)
				{
					harmony.Patch(typeof(NetworkManager).GetMethod(XrefTesting.OnPhotonPlayerJoinMethod.Name), GetPatch(nameof(OnPhotonPlayerJoin)));
					ModConsole.Log("Hooked OnPhotonPlayerJoin");
				}
				else
				{
					ModConsole.Error("Did not patch PhotonJoin");
				}

				if (XrefTesting.OnPhotonPlayerLeftMethod != null)
				{
					harmony.Patch(typeof(NetworkManager).GetMethod(XrefTesting.OnPhotonPlayerLeftMethod.Name), GetPatch(nameof(OnPhotonPlayerLeft)));
					ModConsole.Log("Hooked OnPhotonPlayerLeft");
				}
				else
				{
					ModConsole.Error("Did not patch PhotonLeft");
				}
			}
			catch
			{
				harmony.UnpatchAll();
				InitPatch();
			}
		}

		private void OnPhotonPlayerJoin(ref Player __0)
		{
			try
			{
				ModConsole.Log($"[Photon] Player Joined: {__0.GetDisplayName()}");
				Event_OnPhotonPlayerJoin?.Invoke(null, new PhotonPlayerEventArgs(__0));
			}
			catch
			{
				ModConsole.Log($"[Photon] OnPhotonPlayerJoin Failed!");
			}
		}

		private void OnPhotonPlayerLeft(ref Player __0)
		{
			try
			{
				ModConsole.Log($"[Photon] Player Left: {__0.GetDisplayName()}");
				Event_OnPhotonPlayerLeft?.Invoke(null, new PhotonPlayerEventArgs(__0));
			}
			catch
			{
				ModConsole.Log($"[Photon] OnPhotonPlayerLeft Failed!");
			}
		}
	}
}
