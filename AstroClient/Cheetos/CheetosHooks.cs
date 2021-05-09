namespace AstroClient.Cheetos
{
	#region Imports

	using AstroClient.ConsoleUtils;
	using DayClientML2.Utility;
	using DayClientML2.Utility.Extensions;
	using Harmony;
	using MelonLoader;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Reflection;

	#endregion

	internal class CheetosHooks : GameEvents
	{
		public static EventHandler<PhotonPlayerEventArgs> Event_OnPhotonJoin;

		public static EventHandler<PhotonPlayerEventArgs> Event_OnPhotonLeft;

		public class Patch
		{
			private static List<Patch> Patches = new List<Patch>();
			public MethodInfo TargetMethod { get; set; }
			public HarmonyMethod PrefixMethod { get; set; }
			public HarmonyMethod PostfixMethod { get; set; }
			public HarmonyInstance Instance { get; set; }

			public Patch(MethodInfo targetMethod, HarmonyMethod Before = null, HarmonyMethod After = null)
			{
				if (targetMethod == null || (Before == null && After == null))
				{
					ModConsole.Error("[Patches] TargetMethod is NULL or Pre And PostFix are Null");
					return;
				}
				Instance = HarmonyInstance.Create($"Patch:{targetMethod.DeclaringType.FullName}.{targetMethod.Name}");
				TargetMethod = targetMethod;
				PrefixMethod = Before;
				PostfixMethod = After;
				Patches.Add(this);
			}

			public static async void DoPatches()
			{
				foreach (var patch in Patches)
				{
					try
					{
						ModConsole.DebugLog($"[Patches] Patching {patch.TargetMethod.DeclaringType.FullName}.{patch.TargetMethod.Name} | with AstroClient {(patch.PrefixMethod?.method.Name)}{(patch.PostfixMethod?.method.Name)}");
						patch.Instance.Patch(patch.TargetMethod, patch.PrefixMethod, patch.PostfixMethod);
					}
					catch (Exception e)
					{
						ModConsole.Error($"[Patches] Failed At {patch.TargetMethod?.Name} | {patch.PrefixMethod?.method.Name} | with AstroClient {patch.PostfixMethod?.method.Name}");
						ModConsole.ErrorExc(e);
					}
				}
				ModConsole.Log($"[Patches] Done! Patched {Patches.Count} Methods!");
			}

			public static async void UnDoPatches()
			{
				foreach (var patch in Patches)
				{
					try
					{
						patch.Instance.UnpatchAll();
					}
					catch (Exception e)
					{
						ModConsole.Error($"[Patches] Failed At {patch.TargetMethod?.Name} | {patch.PrefixMethod?.method.Name} | {patch.PostfixMethod?.method.Name}");
						ModConsole.ErrorExc(e);
					}
				}
				ModConsole.Log($"[Patches] Done! UnPatched {Patches.Count} Methods!");
			}
		}

		private static HarmonyMethod GetPatch(string name)
		{
			return new HarmonyMethod(typeof(CheetosHooks).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
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

		public static async void InitPatch()
		{
			try
			{
				ModConsole.DebugLog("[AstroClient Cheetos Patches] Start. . .");

				new Patch(typeof(NetworkManager).GetMethod(XrefTesting.OnPhotonPlayerJoinMethod.Name), GetPatch(nameof(OnPhotonPlayerJoin)));
				new Patch(typeof(NetworkManager).GetMethod(XrefTesting.OnPhotonPlayerLeftMethod.Name), GetPatch(nameof(OnPhotonPlayerLeft)));

				ModConsole.DebugLog("[AstroClient Cheetos Patches] DONE!");
				Patch.DoPatches();
			}
			catch (Exception e) { ModConsole.Error("Error in applying patches : " + e); }
			finally { }
		}

		private static void OnPhotonPlayerJoin(ref Photon.Realtime.Player __0)
		{
			if (__0 != null)
			{
				CheetosHelpers.SendHudNotification($"<color=cyan>[PHOTON]</color> {__0.GetDisplayName()} Joined!");
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
				CheetosHelpers.SendHudNotification($"<color=cyan>[PHOTON]</color> {__0.GetDisplayName()} Left!");
			}
			else
			{
				ModConsole.Error($"[Photon] OnPhotonPlayerLeft Failed! __0 was null.");
			}
		}
	}
}
