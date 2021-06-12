namespace AstroClient
{
	using AstroLibrary.Console;
	using AstroLibrary.Extensions;
	using HarmonyLib;
	using System.Reflection;
	using VRC.Core;
	using VRC.SDKBase;
	using harm = HarmonyLib.Harmony;

	public class BullshitTest : GameEvents
	{
		public override void OnApplicationStart()
		{
			StartPatchTest();
		}

		public static void StartPatchTest()
		{
			var instance = harm.CreateAndPatchAll(typeof(BullshitTest));
			ModConsole.Log("Started Test patches.");
			instance.Patch(AccessTools.Property(typeof(VRCPlayerApi), nameof(VRCPlayerApi.isInstanceOwner)).GetMethod, new HarmonyMethod(typeof(BullshitTest).GetMethod(nameof(Force_IsInstanceOwner), BindingFlags.Static | BindingFlags.NonPublic)));
			instance.Patch(AccessTools.Property(typeof(VRCPlayerApi), nameof(VRCPlayerApi.isSuper)).GetMethod, new HarmonyMethod(typeof(BullshitTest).GetMethod(nameof(Force_IsSuper), BindingFlags.Static | BindingFlags.NonPublic)));
			instance.Patch(AccessTools.Property(typeof(VRCPlayerApi), nameof(VRCPlayerApi.isInstanceOwner)).GetMethod, new HarmonyMethod(typeof(BullshitTest).GetMethod(nameof(Force_IsInstanceOwner), BindingFlags.Static | BindingFlags.NonPublic)));


		}

		private static bool Force_IsMaster(VRCPlayerApi __instance, ref bool __result)
		{
			if (__instance != null)
			{
				if (__instance.isLocal)
				{
					ModConsole.Log($"Marked {__instance.GetPlayer().DisplayName()} as Instance Master!");
					__result = true;
					return false;
				}
			}

			return true;
		}

		private static bool Force_IsSuper(VRCPlayerApi __instance, ref bool __result)
		{
			if (__instance != null)
			{
				if (__instance.isLocal)
				{
					ModConsole.Log($"Marked {__instance.GetPlayer().DisplayName()} as Super!");
					__result = true;
					return false;
				}
			}

			return true;
		}

		private static bool Force_IsInstanceOwner(VRCPlayerApi __instance, ref bool __result)
		{
			if (__instance != null)
			{
				if (__instance.isLocal)
				{
					ModConsole.Log($"Marked {__instance.GetPlayer().DisplayName()} as Instance Owner!");
					__result = true;
					return false;
				}
			}

			return true;
		}

		private static string _currentDisplayName = string.Empty;

		public static string CurrentDisplayName
		{
			get
			{
				if (!string.IsNullOrEmpty(_currentDisplayName) && !string.IsNullOrWhiteSpace(_currentDisplayName))
				{
					return _currentDisplayName;
				}
				else
				{
					if (Utils.LocalPlayer != null && Utils.LocalPlayer.GetPlayer() != null && Utils.LocalPlayer.GetPlayer().GetAPIUser() != null)
					{
						return _currentDisplayName = Utils.LocalPlayer.GetPlayer().GetAPIUser().displayName;
					}
					return null;
				}
			}
		}
	}
}