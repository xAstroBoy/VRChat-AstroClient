namespace AstroClient.Cheetos
{
	using AstroLibrary.Console;
	using Harmony;
	using MelonLoader;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Reflection;
	using UnityEngine;
	using VRC.Core;

	public class AntiCrash : GameEvents
    {
		public class Patch
		{
			private static List<Patch> Patches = new List<Patch>();
			public MethodInfo TargetMethod { get; set; }
			public HarmonyMethod PrefixMethod { get; set; }
			public HarmonyMethod PostfixMethod { get; set; }
			public HarmonyLib.Harmony Instance { get; set; }

			public Patch(MethodInfo targetMethod, HarmonyMethod Before = null, HarmonyMethod After = null)
			{
				if (targetMethod == null || (Before == null && After == null))
				{
					ModConsole.Error("[Patches] TargetMethod is NULL or Pre And PostFix are Null");
					return;
				}
				Instance = new HarmonyLib.Harmony($"Patch:{targetMethod.DeclaringType.FullName}.{targetMethod.Name}");
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
						ModConsole.DebugLog($"[Patches] Patching {patch.TargetMethod.DeclaringType.FullName}.{patch.TargetMethod.Name} | with AstroClient {patch.PrefixMethod?.method.Name}{patch.PostfixMethod?.method.Name}");
						patch.Instance.Patch(patch.TargetMethod, patch.PrefixMethod, patch.PostfixMethod);
					}
					catch (Exception e)
					{
						ModConsole.Error($"[Patches] Failed At {patch.TargetMethod?.Name} | {patch.PrefixMethod?.method.Name} | with AstroClient {patch.PostfixMethod?.method.Name}");
						ModConsole.Error(e.Message);
						ModConsole.ErrorExc(e);
					}
				}
				ModConsole.DebugLog($"[Patches] Done! Patched {Patches.Count} Methods!");
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
				ModConsole.DebugLog($"[Patches] Done! UnPatched {Patches.Count} Methods!");
			}
		}

		private static HarmonyMethod GetPatch(string name)
		{
			return new HarmonyMethod(typeof(AntiCrash).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
		}

		public override void ExecutePriorityPatches()
		{
			MelonCoroutines.Start(Init());
		}

		public static async void InitPatch()
		{
			try
			{
				ModConsole.Log("[AstroClient AntiCrash Patches] Start. . .");

				//new Patch(typeof(AssetManagement).GetMethod(nameof(AssetManagement.Method_Public_Static_Object_Object_Vector3_Quaternion_Boolean_Boolean_Boolean_0)), null, GetPatch(nameof(OnAvatarPostCheck)));
				//new Patch(typeof(AssetManagement).GetMethod(nameof(AssetManagement.Method_Public_Static_Object_Object_Vector3_Quaternion_Boolean_Boolean_Boolean_0)), GetPatch(nameof(OnAvatarPreCheck)), null);

				ModConsole.DebugLog("[Client AntiCrash Patches] DONE!");
				Patch.DoPatches();
			}
			catch (System.Exception e) { ModConsole.Error("Error in applying patches : " + e); }
			finally { }
		}

		private IEnumerator Init()
		{
			InitPatch();
			yield break;
		}

		private static void OnAvatarPostCheck(ref UnityEngine.Object __0, ref Vector3 __1, ref Quaternion __2, ref bool __3, ref bool __4, ref bool __5, ref UnityEngine.Object __result)
		{
		}

		private static bool OnAvatarPreCheck(UnityEngine.Object __0, Vector3 __1, Quaternion __2, bool __3, bool __4, bool __5)
		{
			return true;
		}
	}
}