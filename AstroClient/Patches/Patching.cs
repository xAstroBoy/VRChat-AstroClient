namespace AstroClient.BetterPatch
{
	#region Imports
	using AstroClient.AstroUtils.PlayerMovement;
	using AstroClient.ConsoleUtils;
	using AstroClient.Startup.Hooks;
	using DayClientML2.Utility;
	using DayClientML2.Utility.Extensions;
	using ExitGames.Client.Photon;
	using Harmony;
	using MelonLoader;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	#endregion

	using PhotonHandler = MonoBehaviour1PrivateObInPrInBoInInInInUnique;

	internal class Patching : GameEvents
	{
		public static event EventHandler<PhotonPlayerEventArgs> Event_OnPhotonPlayerJoin;

		public static event EventHandler<PhotonPlayerEventArgs> Event_OnPhotonPlayerLeft;

		private static HarmonyMethod GetPatch(string name)
		{
			return new HarmonyMethod(typeof(Patching).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
		}

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

		public override void ExecutePriorityPatches()
		{
			MelonCoroutines.Start(Init());
		}

		private IEnumerator Init()
		{
			Patching.InitPatch();
			yield break;
		}

		public static async void InitPatch()
		{
			try
			{
				ModConsole.DebugLog("[Patches] Start. . .");

				new Patch(typeof(Photon.Realtime.LoadBalancingClient).GetMethod(nameof(Photon.Realtime.LoadBalancingClient.Method_Public_Virtual_New_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0)), GetPatch(nameof(OpRaiseEvent)));
				//new Patch(typeof(Photon.Realtime.LoadBalancingClient).GetMethod(nameof(Photon.Realtime.LoadBalancingClient.Method_Public_Virtual_Final_New_Void_Player_0)), GetPatch(nameof(OpRaiseEvent2)));
				new Patch(typeof(NetworkManager).GetMethod(XrefTesting.OnPhotonPlayerJoinMethod.Name), GetPatch(nameof(OnPhotonPlayerJoin)));
				new Patch(typeof(NetworkManager).GetMethod(XrefTesting.OnPhotonPlayerLeftMethod.Name), GetPatch(nameof(OnPhotonPlayerLeft)));

				ModConsole.DebugLog("[AstroClient Patches] DONE!");
				Patch.DoPatches();
			}
			catch (Exception e) { ModConsole.Error("Error in applying patches : " + e); }
			finally { }
		}

		private static void OnPhotonPlayerJoin(Photon.Realtime.Player __0)
		{
			if (__0 != null)
			{
				try
				{
					ModConsole.Log($"[PHOTON] {__0.GetDisplayName()} [{__0.field_Private_Int32_0}] -> Joined!");
				}
				catch (Exception e)
				{
					ModConsole.Error($"[Photon] OnPhotonPlayerJoin Failed!");
					ModConsole.ErrorExc(e);
				}
			}
			else
			{
				ModConsole.Error($"[Photon] OnPhotonPlayerJoin Failed! __0 was null.");
			}
		}

		private static void OnPhotonPlayerLeft(Photon.Realtime.Player __0)
		{
			if (__0 != null)
			{
				try
				{
					ModConsole.Log($"[PHOTON] {__0.GetDisplayName()} [{__0.field_Private_Int32_0}] -> Left!");
				}
				catch (Exception e)
				{
					ModConsole.Error($"[Photon] OnPhotonPlayerLeft Failed!");
					ModConsole.ErrorExc(e);
				}
			}
			else
			{
				ModConsole.Error($"[Photon] OnPhotonPlayerLeft Failed! __0 was null.");
			}
		}

		private static bool OpRaiseEvent(ref byte __0, ref Il2CppSystem.Collections.Generic.Dictionary<byte, Il2CppSystem.Object> __1, ref SendOptions __2)
		{
			try
			{
				if (__0 == 7 || __0 == 206 || __0 == 201 || __0 == 1)
				{
					return !Movement.SerializerEnabled;
				}
			}
			catch { }
			return true;
		}
	}
}