namespace AstroClient
{
	using AstroLibrary.Console;
	using AstroLibrary.Extensions;
	using AstroLibrary.Utility;
	using HarmonyLib;
	using Il2CppSystem.Collections.Generic;
	using Photon.Realtime;
	using System.Reflection;
	using UnhollowerBaseLib;
	using UnityEngine;
	using VRC.Core;
	using VRC.SDKBase;
	using static VRC.Core.ApiWorld;
	using static VRC.Core.ApiWorldInstance;
	using harm = HarmonyLib.Harmony;

	public class BullshitTest : GameEvents
	{
		public override void OnApplicationStart()
		{
			//StartPatchTest();
		}

		public static void StartPatchTest()
		{
			var instance = harm.CreateAndPatchAll(typeof(BullshitTest));
			ModConsole.Log("Started Instance Hijack Patcher.");
			//instance.Patch(AccessTools.Property(typeof(VRCPlayerApi), nameof(VRCPlayerApi.isInstanceOwner)).GetMethod, new HarmonyMethod(typeof(BullshitTest).GetMethod(nameof(Force_IsInstanceOwner), BindingFlags.Static | BindingFlags.NonPublic)));
			//instance.Patch(AccessTools.Property(typeof(VRCPlayerApi), nameof(VRCPlayerApi.isSuper)).GetMethod, new HarmonyMethod(typeof(BullshitTest).GetMethod(nameof(Force_IsSuper), BindingFlags.Static | BindingFlags.NonPublic)));
			//instance.Patch(AccessTools.Property(typeof(VRCPlayerApi), nameof(VRCPlayerApi.isInstanceOwner)).GetMethod, new HarmonyMethod(typeof(BullshitTest).GetMethod(nameof(Force_IsInstanceOwner), BindingFlags.Static | BindingFlags.NonPublic)));

			//			instance.Patch(typeof(ApiWorld).GetMethod(nameof(ApiWorld.FetchList)),
			//new HarmonyMethod(typeof(BullshitTest).GetMethod(nameof(ModifiedFetchList), BindingFlags.Static | BindingFlags.NonPublic)));

			//instance.Patch(typeof(ApiWorldInstance).GetMethod(nameof(ApiWorldInstance.GetAccessType)),
			//new HarmonyMethod(typeof(BullshitTest).GetMethod(nameof(ModifiedGetAccessType), BindingFlags.Static | BindingFlags.NonPublic)));

			//instance.Patch(AccessTools.Property(typeof(ApiWorld), nameof(ApiWorld.currentInstanceAccess)).GetMethod, new HarmonyMethod(typeof(BullshitTest).GetMethod(nameof(Force_PublicInstanceType), BindingFlags.Static | BindingFlags.NonPublic)));


		}

		private static bool Force_PublicInstanceType(ref InstanceAccessType __result)
		{
			ModConsole.Log($"Marked a World Instance as Public Instance!");
			__result = InstanceAccessType.Public;
			return false;
		}

		private static void ModifiedFetchList(
			ref Il2CppSystem.Action<IEnumerable<ApiWorld>> __0,
			ref Il2CppSystem.Action<string> __1,
			ref SortHeading __2,
			ref SortOwnership __3,
			ref SortOrder __4,
			ref int __5,
			ref int __6,
			ref string __7,
			ref Il2CppStringArray __8,
			ref Il2CppStringArray __9,
			ref Il2CppStringArray __10,
			ref string __11,
			ref ReleaseStatus __12,
			ref string __13,
			ref string __14,
			ref bool __15,
			ref bool __16)
		{

			//SortHeading heading = __2;
			//SortOwnership owner = __3;
			//SortOrder order = __4;
			//int offset = __5;
			//int count = __6;
			//string search = __7;
			//Il2CppStringArray tags = __8;
			//Il2CppStringArray excludeTags = __9;
			//Il2CppStringArray userTags = __10;
			//string userId = __11;
			//ReleaseStatus releaseStatus = __12;
			//string includePlatforms = __13;
			//string excludePlatforms = __14;
			//bool disableCache = __15;
			//bool compatibleVersionsOnly = __16;

			string heading = "null";
			if(__2 != null)
			{
				heading = __2.ToString();
			}
			string owner = "null";
			if (__3 != null)
			{
				heading = __3.ToString();
			}
			string order = "null";
			if (__4 != null)
			{
				heading = __4.ToString();
			}
			string offset = "null";
			if (__5 != null)
			{
				offset = __5.ToString();
			}
			string count = "null";
			if (__6 != null)
			{
				count = __6.ToString();
			}
			string search = "null";
			if (__7 != null)
			{
				search = __7;
			}
			string tags = "null";
			if (__8 != null)
			{
				if (__8.Count != 0)
				{
					foreach (var item in __8)
					{
						if (item != null)
						{
							tags += item + ", ";
						}
					}
				}
			}
			string excludeTags = "null";
			if (__9 != null)
			{
				if (__9.Count != 0)
				{
					foreach (var item in __9)
					{
						if (item != null)
						{
							excludeTags += item + ", ";
						}
					}
				}
			}


			string userTags = string.Empty;
			if (__10 != null)
			{
				if (__10.Count != 0)
				{
					foreach (var item in __10)
					{
						if (item != null)
						{
							userTags += item + ", ";
						}
					}
				}
			}
			string userId = "null";
			if (__11 != null)
			{
				userId = __11;
			}

			string releaseStatus = "null";
			if (__12 != null)
			{
				releaseStatus = __12.ToString();
			}

			string includePlatforms = "null";
			if (__13 != null)
			{
				includePlatforms = __13.ToString();
			}

			string excludePlatforms = "null";
			if (__14 != null)
			{
				excludePlatforms = __14.ToString();
			}

			string disableCache = "null";
			if (__15 != null)
			{
				disableCache = __15.ToString();
			}


			string compatibleVersionsOnly = "null";
			if (__16 != null)
			{
				compatibleVersionsOnly = __16.ToString();
			}

			ModConsole.DebugLog($"Currently Parsing Worlds with Parameters  \n" +

				$"Heading: {heading}, \n" +
				$"owner: {owner}, \n" +
				$"order: {order}, \n" +
				$"offset: {offset}, \n" +
				$"count: {count}, \n" +
				$"search: {search}, \n" +
				$"tags: {tags}, \n" +
				$"excludeTags: {excludeTags}, \n" +
				$"userTags: {userTags}, \n" +
				$"userId: {userId}, \n" +
				$"releaseStatus: {releaseStatus}, \n" +
				$"includePlatforms: {includePlatforms}, \n" +
				$"excludePlatforms: {excludePlatforms}, \n" +
				$"disableCache: {disableCache}, \n" +
				$"compatibleVersionsOnly: {compatibleVersionsOnly}"



				);


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