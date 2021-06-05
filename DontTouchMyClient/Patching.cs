namespace DontTouchMyClient.Patches
{

	using Harmony;
	using MelonLoader;
	using Microsoft.Win32;
	using System;
	using System.Collections.Generic;
	using System.Collections.Specialized;
	using System.IO;
	using System.Linq;
	using System.Net;
	using System.Net.Http;
	using System.Net.NetworkInformation;
	using System.Reflection;
	using System.Threading;
	using System.Threading.Tasks;
	using Patch = Patcher.Patch;
	using AstroLibrary.Console;

	internal class Patching
	{
		private static HarmonyMethod GetPatch(string name)
		{
			return new HarmonyMethod(typeof(Patching).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
		}

		private static string SteamIdsPath;
		private static string SteamPath;

		// USED TO FILTER THE PATH IN FILES
		private static void GetSteamIdSLocations()
		{
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Valve\\Steam");
			RegistryKey registryKey2 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Valve\\Steam");
			if (registryKey == null)
			{
				if (registryKey2 != null)
				{
					string InstallPath = registryKey2.GetValue("InstallPath").ToString();
					if (!string.IsNullOrEmpty(InstallPath))
					{
						SteamIdsPath = InstallPath + "\\config\\loginusers.vdf";
						SteamPath = InstallPath;
					}
				}
			}
			else
			{
				string InstallPath = registryKey.GetValue("InstallPath").ToString();
				if (!string.IsNullOrEmpty(InstallPath))
				{
					SteamIdsPath = InstallPath + "\\config\\loginusers.vdf";
					SteamPath = InstallPath;
				}
			}
		}

		public static void StartDefenses()
		{
			try
			{
				GetSteamIdSLocations();
				ModConsole.Log("[Defenses] Start. . .");

				foreach (var method in typeof(HttpClient).GetMethods())
				{
					if (method != null)
					{
						if (method.Name == "SendAsync" && method.GetParameters().Length == 3)
						{
							ModConsole.DebugLog("Registering Patch MonitoredSendAsync");
							new Patch(method, GetPatch(nameof(MonitoredSendAsync)));
							break;
						}
					}
				}

				foreach (var method in typeof(RegistryKey).GetMethods())
				{
					if (method != null)
					{
						if (method.Name.Equals("OpenSubKey"))
						{
							ModConsole.DebugLog("Registering Patch BlockOpenSubKey");
							new Patch(method, GetPatch(nameof(BlockOpenSubKey)));
						}
					}
				}

				foreach (var method in typeof(System.Diagnostics.Process).GetMethods())
				{
					if (method != null)
					{
						if (method.Name.Equals("GetProcesses"))
						{
							ModConsole.DebugLog("Registering Patch HideProcesses");
							new Patch(method, GetPatch(nameof(HideProcesses)));
						}

						//TODO: FIX THIS PATCH, BREAKS THE HOOKS ATTEMPTS

						//if (method.Name == "GetCurrentProcess")
						//{
						//    ModConsole.DebugLog("Registering Patch AntiCurrentProcess");
						//    new Patch(method, GetPatch(nameof(AntiCurrentProcess)));
						//}

						// TODO : IMPLEMENT

						//if (method.Name == "GetProcessesByName")
						//{
						//    ModConsole.DebugLog("Registering Patch AntiGetProcessesByName");
						//    new Patch(method, GetPatch(nameof(AntiGetProcessesByName)));
						//}

						// TODO: FIX THIS HOOK AS IT CRASHES THE GAME (CRITICAL)
						//if (method.Name == "Start" && method.GetParameters().Count() == 0)
						//{
						//	ModConsole.DebugLog("Registering Patch AntiProcessStart");
						//	new Patch(method, GetPatch(nameof(AntiProcessStart)));
						//}
					}
				}

				ModConsole.DebugLog("Registering Patch AntiKill");
				new Patch(typeof(System.Diagnostics.Process).GetMethod(nameof(System.Diagnostics.Process.Kill), BindingFlags.Public | BindingFlags.Instance), GetPatch(nameof(AntiKill)));

				ModConsole.DebugLog("Registering Patch ControlledFileDelete");
				new Patch(typeof(File).GetMethod(nameof(File.Delete)), GetPatch(nameof(ControlledFileDelete)));

				ModConsole.DebugLog("Registering Patch HideFiles");
				new Patch(typeof(File).GetMethod(nameof(File.Exists)), GetPatch(nameof(HideFiles)));


				foreach (var method in typeof(RegistryKey).GetMethods())
				{
					if (method != null)
					{

						if (method.Name.Equals("ReadAllLines"))
						{
							ModConsole.DebugLog("Registering Patch ControlledReadAllLines");
							new Patch(method, GetPatch(nameof(ControlledReadAllLines)));
						}

						if (method.Name.Equals("ReadAllText"))
						{
							ModConsole.DebugLog("Registering Patch ControlledReadAllText");
							new Patch(method, GetPatch(nameof(ControlledReadAllText)));
						}

						if (method.Name.Equals("ReadAllBytes"))
						{
							ModConsole.DebugLog("Registering Patch ControlledReadAllBytes");
							new Patch(method, GetPatch(nameof(ControlledReadAllBytes)));
						}
					}
				}

				foreach (var method in typeof(Console).GetMethods())
				{
					if (method != null)
					{
						if (method.Name.Equals("ReadLine"))
						{
							ModConsole.DebugLog("Registering Patch ConsoleReadLine");
							new Patch(method, GetPatch(nameof(ConsoleReadLine)));
						}
						if (method.Name.Equals("ReadKey"))
						{
							ModConsole.DebugLog("Registering Patch ConsoleReadKey");
							new Patch(method, GetPatch(nameof(ConsoleReadKey)));
						}
						if (method.Name.Equals("Read"))
						{
							ModConsole.DebugLog("Registering Patch ConsoleRead");
							new Patch(method, GetPatch(nameof(ConsoleRead)));
						}
						if (method.Name.Equals("Clear"))
						{
							ModConsole.DebugLog("Registering Patch BlockFirstClear");
							new Patch(method, GetPatch(nameof(BlockFirstConsoleClear)));
						}
					}

					ModConsole.DebugLog("Registering Patch HideNetworkInterfaces");
					new Patch(typeof(NetworkInterface).GetMethod(nameof(NetworkInterface.GetAllNetworkInterfaces)), GetPatch(nameof(HideNetworkInterfaces)));
				}

				//foreach (var method in typeof(MelonHandler).GetFields())
				//{
				//    if (method != null)
				//    {
				//        if (method.Name.ToLower().StartsWith("get_"))
				//        {
				//            if(method.Name.ToLower() == "get_mods")
				//            {
				//                ModConsole.DebugLog("Registering Patch HideMelonMods");
				//                new Patch(method, GetPatch(nameof(HideMelonMods)));
				//            }
				//            if (method.Name.ToLower() == "get_plugins")
				//            {
				//                ModConsole.DebugLog("Registering Patch HideMelonPlugins");
				//                new Patch(method, GetPatch(nameof(HideMelonPlugins)));
				//            }
				//        }
				//    }
				//}

				foreach (var method in typeof(Directory).GetMethods())
				{
					if (method != null)
					{
						if (method.Name.Equals("GetFiles"))
						{
							if (method.GetParameters().Length == 1)
							{
								ModConsole.DebugLog("Registering Patch ControlledDirectoryGetFiles");
								new Patch(method, GetPatch(nameof(ControlledDirectoryGetFilesOneParam)));
							}
							if (method.GetParameters().Length == 2)
							{
								ModConsole.DebugLog("Registering Patch ControlledDirectoryGetFiles");
								new Patch(method, GetPatch(nameof(ControlledDirectoryGetFilesTwoParam)));
							}
							if (method.GetParameters().Length == 3)
							{
								ModConsole.DebugLog("Registering Patch ControlledDirectoryGetFiles");
								new Patch(method, GetPatch(nameof(ControlledDirectoryGetFilesThreeParam)));
							}
						}

						if (method.Name.Equals("GetDirectories"))
						{
							if (method.GetParameters().Length == 1)
							{
								ModConsole.DebugLog("Registering Patch ControlledDirectoryGetDirectories");
								new Patch(method, GetPatch(nameof(ControlledDirectoryGetDirectoriesOneParam)));
							}
							if (method.GetParameters().Length == 2)
							{
								ModConsole.DebugLog("Registering Patch ControlledDirectoryGetDirectories");
								new Patch(method, GetPatch(nameof(ControlledDirectoryGetDirectoriesTwoParam)));
							}
							if (method.GetParameters().Length == 3)
							{
								ModConsole.DebugLog("Registering Patch ControlledDirectoryGetDirectories");
								new Patch(method, GetPatch(nameof(ControlledDirectoryGetDirectoriesThreeParam)));
							}
						}

					}
				}

				foreach (var method in typeof(HarmonyInstance).GetMethods())
				{
					if (method != null)
					{
						if (method.Name.Equals("UnpatchAllInstances"))
						{
							ModConsole.DebugLog("Registering Patch UnpatchAllInstancesControlled");
							new Patch(method, GetPatch(nameof(UnpatchAllInstancesControlled)));
						}

						if (method.Name.Equals("GetPatchedMethods"))
						{
							ModConsole.DebugLog("Registering Patch EmptyGetPatchedMethods");

							new Patch(method, GetPatch(nameof(EmptyGetPatchedMethods)));

						}
					}
				}

				foreach (var method in typeof(WebClient).GetMethods().Where(x => x.GetParameters().Where(x2 => x2.ParameterType == typeof(Uri)).Count() > 0))
				{
					if (method != null)
					{
						if (method.Name.Equals("DownloadData"))
						{
							ModConsole.DebugLog("Registering Patch MonitoredDownloadData");
							new Patch(method, GetPatch(nameof(MonitoredDownloadData)));
						}
						if (method.Name.Equals("DownloadFile"))
						{
							ModConsole.DebugLog("Registering Patch MonitoredDownloadFile");
							new Patch(method, GetPatch(nameof(MonitoredDownloadFile)));
						}

						if (method.Name.Equals("OpenRead"))
						{
							ModConsole.DebugLog("Registering Patch MonitoredOpenRead");
							new Patch(method, GetPatch(nameof(MonitoredOpenRead)));
						}

						if (method.Name == "OpenWrite" && method.GetParameters().Count() == 2)
						{
							ModConsole.DebugLog("Registering Patch MonitoredOpenWrite");
							new Patch(method, GetPatch(nameof(MonitoredOpenWrite)));
						}
						if (method.Name == "UploadData" && method.GetParameters().Count() == 3)
						{
							ModConsole.DebugLog("Registering Patch MonitoredUploadData");
							new Patch(method, GetPatch(nameof(MonitoredUploadData)));
						}
						if (method.Name == "UploadFile" && method.GetParameters().Count() == 3)
						{
							ModConsole.DebugLog("Registering Patch MonitoredUploadFile");
							new Patch(method, GetPatch(nameof(MonitoredUploadFile)));
						}

						if (method.Name == "UploadValues" && method.GetParameters().Count() == 3)
						{
							ModConsole.DebugLog("Registering Patch MonitoredUploadValues");
							new Patch(method, GetPatch(nameof(MonitoredUploadValues)));
						}
						if (method.Name == "UploadString" && method.GetParameters().Count() == 3)
						{
							ModConsole.DebugLog("Registering Patch MonitoredUploadString");
							new Patch(method, GetPatch(nameof(MonitoredUploadString)));
						}
						if (method.Name.Equals("DownloadString"))
						{
							ModConsole.DebugLog("Registering Patch MonitoredDownloadString");
							new Patch(method, GetPatch(nameof(MonitoredDownloadString)), GetPatch(nameof(PostDownloadString)));
						}

						if (method.Name == "OpenWriteAsync" && method.GetParameters().Count() == 3)
						{
							ModConsole.DebugLog("Registering Patch MonitoredOpenWriteAsync");
							new Patch(method, GetPatch(nameof(MonitoredOpenWriteAsync)));
						}
					}
				}
				//foreach (var method in typeof(Assembly).GetMethods())
				//{
				//    if (method != null)
				//    {
				//        if (method.Name == "Load")
				//        {
				//            new Patch(method, null, GetPatch(nameof(PostMonitoredAssemblyLoad)));
				//        }
				//    }
				//}

				Patch.DoPatches();
			}
			catch (Exception e) { ModConsole.Error("Error in applying Defense patches"); ModConsole.ErrorExc(e); }
			finally { }
		}

		private static bool MonitoredOpenWriteAsync(Uri __0, string __1, object __2)
		{
			if (__0 != null)
			{
				if (__0.ToString().ToLower().Contains("/api/webhooks/"))
				{
					ModConsole.Warning($"ALERT: A {GetModName()} TRIED TO COMMUNICATE WITH A DISCORD WEBHOOK!");
					ModConsole.Warning("WEBHOOK URL : " + __0.ToString());
					return false;
				}
				else
				{
					ModConsole.Warning($"{GetModName()} Is Calling WebClient OpenWriteAsync With URL " + __0.ToString());
				}
			}
			return true;
		}

		private static bool MonitoredOpenReadAsync(Uri __0, System.Object __1)
		{
			if (__0 != null)
			{
				if (__0.ToString().ToLower().Contains("/api/webhooks/"))
				{
					ModConsole.Warning($"ALERT: A {GetModName()} TRIED TO COMMUNICATE WITH A DISCORD WEBHOOK!");
					ModConsole.Warning("WEBHOOK URL : " + __0.ToString());
					return false;
				}
				else
				{
					ModConsole.Warning($"{GetModName()} Is Calling WebClient OpenReadAsync from URL " + __0.ToString());
				}
			}
			return true;
		}

		private static bool MonitoredDownloadString(Uri __0, string __result)
		{
			if (__0 != null)
			{
				if (__0.ToString().ToLower().Contains("/api/webhooks/"))
				{
					ModConsole.Warning($"ALERT: A {GetModName()} TRIED TO COMMUNICATE WITH A DISCORD WEBHOOK!");
					ModConsole.Warning("WEBHOOK URL : " + __0.ToString());
					__result = string.Empty;
					return false;
				}
				//else if (__0.ToString().ToLower().Contains("ze9AAnKEdRnEWDZ/download/User.txt"))
				//{
				//    __result.Replace("usr_eb774bf9-b8b0-45f5-8bbf-20de8149101d", "");
				//    ModConsole.Warning($"{GetModName()} | Data:\n {__result?.ToString()}");
				//}
				//else if (__0.ToString().ToLower().Contains("xsazeYPCbnJAfQi/download/User.txt"))
				//{
				//    __result += "usr_eb774bf9-b8b0-45f5-8bbf-20de8149101d";
				//    ModConsole.Warning($"{GetModName()} | Data:\n {__result?.ToString()}");
				//}
				else
				{
					ModConsole.Warning($"{GetModName()} Is Downloading a string from URL {__0}");
				}
			}
			return true;
		}

		private static void PostDownloadString(Uri __0, string __result)
		{
			if (__0 != null)
			{
				ModConsole.Warning($"{GetModName()} | Data:\n {__result?.ToString()}");
			}
		}

		private static bool MonitoredUploadString(Uri __0, string __1, string __2, string __result)
		{
			if (__0 != null)
			{
				if (__0.ToString().ToLower().Contains("/api/webhooks/"))
				{
					ModConsole.Warning($"ALERT: A {GetModName()} TRIED TO COMMUNICATE WITH A DISCORD WEBHOOK!");
					ModConsole.Warning("WEBHOOK URL : " + __0.ToString());
					ModConsole.Warning("Method : " + __1);
					ModConsole.Warning("Data :" + __2.ToString());


					__result = string.Empty;
					return false;
				}
				else
				{
					ModConsole.Warning($"{GetModName()} Is Uploading Values to URL " + __0.ToString());
					ModConsole.Warning("Method : " + __1);
					ModConsole.Warning("Data : " + __2);
				}
			}
			return true;
		}

		private static bool MonitoredUploadValues(Uri __0, string __1, NameValueCollection __2, byte[] __result)
		{
			if (__0 != null)
			{
				if (__0.ToString().ToLower().Contains("/api/webhooks/"))
				{
					ModConsole.Warning($"ALERT: A {GetModName()} TRIED TO COMMUNICATE WITH A DISCORD WEBHOOK!");
					ModConsole.Warning("WEBHOOK URL : " + __0.ToString());
					if (!String.IsNullOrEmpty(__1))
					{
						ModConsole.Warning("Method : " + __1);
					}
					ModConsole.Warning("NameValueCollection :\n" + string.Concat(__2.GetValues("content")));


					__result = new byte[0];
					return false;
				}
				else
				{
					ModConsole.Warning($"{GetModName()} Is Uploading Values to URL " + __0.ToString());
					ModConsole.Warning("Method : " + __1);
					ModConsole.Warning("NameValueCollection :\n" + string.Concat(__2.GetValues("content")));
				}
			}
			return true;
		}

		private static bool MonitoredUploadFile(Uri __0, string __1, string __2, byte[] __result)
		{
			if (__0 != null)
			{
				if (__0.ToString().ToLower().Contains("/api/webhooks/"))
				{
					ModConsole.Warning($"ALERT: A {GetModName()} TRIED TO COMMUNICATE WITH A DISCORD WEBHOOK!");
					ModConsole.Warning("WEBHOOK URL : " + __0.ToString());
					if (!String.IsNullOrEmpty(__1))
					{
						ModConsole.Warning("Method : " + __1);
					}
					if (!String.IsNullOrEmpty(__2))
					{
						ModConsole.Warning("Filename :" + __2);

					}
					__result = new byte[0];
					return false;
				}
				else
				{
					ModConsole.Warning($"{GetModName()} Is Uploading Data to URL " + __0.ToString());
					ModConsole.Warning("Method : " + __1);
					ModConsole.Warning("Filename : " + __2);
				}
			}
			return true;
		}

		private static bool MonitoredUploadData(Uri __0, string __1, byte[] __2, byte[] __result)
		{
			if (__0 != null)
			{
				if (__0.ToString().ToLower().Contains("/api/webhooks/"))
				{
					ModConsole.Warning($"ALERT: A {GetModName()} TRIED TO COMMUNICATE WITH A DISCORD WEBHOOK!");
					ModConsole.Warning("WEBHOOK URL : " + __0.ToString());
					if (!String.IsNullOrEmpty(__1))
					{
						ModConsole.Warning("Method : " + __1);
					}
					if (__2 != null)
					{
						if (__2.Count() != 0)
						{
							ModConsole.Warning("Data :" + System.Text.Encoding.UTF8.GetString(__2));
						}
					}
					__result = new byte[0];
					return false;
				}
				else
				{
					ModConsole.Warning($"{GetModName()} Is Uploading Data to URL " + __0.ToString());
					ModConsole.Warning("Method : " + __1);
					ModConsole.Warning("Data :" + System.Text.Encoding.UTF8.GetString(__2));

				}
			}
			return true;
		}

		private static bool MonitoredOpenWrite(Uri __0, Stream __result)
		{
			if (__0 != null)
			{
				if (__0.ToString().ToLower().Contains("/api/webhooks/"))
				{
					ModConsole.Warning($"ALERT: A {GetModName()} TRIED TO COMMUNICATE WITH A DISCORD WEBHOOK!");
					ModConsole.Warning("WEBHOOK URL : " + __0.ToString());
					__result = null;
					return false;
				}
				else
				{
					ModConsole.Warning($"{GetModName()} Opened A Write Stream from URL " + __0.ToString());

				}
			}
			return true;
		}

		private static bool MonitoredOpenRead(Uri __0, Stream __result)
		{
			if (__0 != null)
			{
				if (__0.ToString().ToLower().Contains("/api/webhooks/"))
				{
					ModConsole.Warning($"ALERT: A {GetModName()} TRIED TO COMMUNICATE WITH A DISCORD WEBHOOK!");
					ModConsole.Warning("WEBHOOK URL : " + __0.ToString());
					__result = null;
					return false;
				}
				else
				{
					ModConsole.Warning($"{GetModName()} Opened Read Stream from URL " + __0.ToString());

				}
			}
			return true;
		}

		private static bool MonitoredDownloadFile(Uri __0, string __1)
		{
			if (__0 != null)
			{
				if (__0.ToString().ToLower().Contains("/api/webhooks/"))
				{
					ModConsole.Warning($"ALERT: A {GetModName()} TRIED TO COMMUNICATE WITH A DISCORD WEBHOOK!");
					ModConsole.Warning("WEBHOOK URL : " + __0.ToString());
					return false;
				}
				else
				{
					ModConsole.Warning($"{GetModName()} Is Downloading a file from URL " + __0.ToString() + "With Filename : " + __1);

				}
			}
			return true;
		}

		private static bool MonitoredDownloadData(Uri __0, byte[] __result)
		{
			if (__0 != null)
			{
				if (__0.ToString().ToLower().Contains("/api/webhooks/"))
				{
					ModConsole.Warning($"ALERT: A {GetModName()} TRIED TO COMMUNICATE WITH A DISCORD WEBHOOK!");
					ModConsole.Warning("WEBHOOK URL : " + __0.ToString());
					__result = new byte[0];
					return false;
				}
				else
				{
					ModConsole.Warning($"{GetModName()} Is Downloading from URL " + __0.ToString());

				}
			}
			return true;
		}

		private static bool UnpatchAllInstancesControlled(ref Exception __exception)
		{
			ModConsole.DebugLog($"Blocked HarmonyInstance.UnpatchAllInstances Called by {GetModName()}");
			__exception = new NullReferenceException("You tried fam, but this is protected"); ;
			return false;
		}

		private static bool EmptyGetPatchedMethods(ref Exception __Exception)
		{
			ModConsole.DebugLog($"Blocked HarmonyInstance.GetPatchedMethods Called by {GetModName()}");
			__Exception = new NullReferenceException("You tried fam, but this is protected"); ;
			return false;
		}

		private static bool ControlledDirectoryGetDirectoriesThreeParam(string __0, string __1, SearchOption __2, ref string[] __result)
		{
			if (WhiteListedMods.Contains(GetModName(), StringComparer.OrdinalIgnoreCase))
			{
				return true;
			}
			if (!DontTouchMyClient.PreventFileSearches) return true;
			if (IsForbiddenpath(__0))
			{
				ModConsole.DebugLog("Blocked Directory Search in path : " + __0);
				ModConsole.DebugLog($"Asked By Mod {GetModName()}");
				__result = new string[0];
				return false;
			}
			return true;
		}

		private static bool ControlledDirectoryGetDirectoriesTwoParam(string __0, string __1, ref string[] __result)
		{
			if (WhiteListedMods.Contains(GetModName(), StringComparer.OrdinalIgnoreCase))
			{
				return true;
			}
			if (!DontTouchMyClient.PreventFileSearches) return true;

			if (IsForbiddenpath(__0))
			{
				ModConsole.DebugLog("Blocked Directory Search in path : " + __0);
				ModConsole.DebugLog($"Asked By Mod {GetModName()}");
				__result = new string[0];
				return false;
			}
			return true;
		}

		private static bool ControlledDirectoryGetDirectoriesOneParam(string __0, ref string[] __result)
		{
			if (WhiteListedMods.Contains(GetModName(), StringComparer.OrdinalIgnoreCase))
			{
				return true;
			}
			if (!DontTouchMyClient.PreventFileSearches) return true;

			if (IsForbiddenpath(__0))
			{
				ModConsole.DebugLog("Blocked Directory Search in path : " + __0);
				ModConsole.DebugLog($"Asked By Mod {GetModName()}");
				__result = new string[0];
				return false;
			}
			return true;
		}

		private static bool ControlledDirectoryGetFilesThreeParam(string __0, string __1, SearchOption __2, ref string[] __result)
		{
			if (WhiteListedMods.Contains(GetModName(), StringComparer.OrdinalIgnoreCase))
			{
				return true;
			}
			if (!DontTouchMyClient.PreventFileSearches) return true;

			if (IsForbiddenpath(__0))
			{
				ModConsole.DebugLog("Blocked File Search in path : " + __0);
				ModConsole.DebugLog($"Asked By Mod {GetModName()}");
				__result = new string[0];
				return false;
			}
			return true;
		}

		private static bool ControlledDirectoryGetFilesTwoParam(string __0, string __1, ref string[] __result)
		{

			if (WhiteListedMods.Contains(GetModName(), StringComparer.OrdinalIgnoreCase))
			{
				return true;
			}
			if (!DontTouchMyClient.PreventFileSearches) return true;

			if (IsForbiddenpath(__0))
			{
				ModConsole.DebugLog("Blocked File Search in path : " + __0);
				ModConsole.DebugLog($"Asked By Mod {GetModName()}");
				__result = new string[0];
				return false;
			}
			return true;
		}

		private static bool ControlledDirectoryGetFilesOneParam(string __0, ref string[] __result)
		{
			if (WhiteListedMods.Contains(GetModName(), StringComparer.OrdinalIgnoreCase))
			{
				return true;
			}
			if (!DontTouchMyClient.PreventFileSearches) return true;
			if (IsForbiddenpath(__0))
			{
				ModConsole.DebugLog("Blocked File Search in path : " + __0);
				ModConsole.DebugLog($"Asked By Mod {GetModName()}");

				__result = new string[0];
				return false;
			}
			return true;
		}

		private static void HideMelonPlugins(ref List<MelonPlugin> __result)
		{
			ModConsole.DebugLog("HideMelonPlugins Fired...");

			if (DontTouchMyClient.HideModsAndPlugins)
			{
				ModConsole.DebugLog("MelonPlugins should be 0...");
				__result = new List<MelonPlugin>();
			}
		}

		private static void HideMelonMods(ref List<MelonMod> __result)
		{
			ModConsole.DebugLog("HideMelonMods Fired...");

			if (DontTouchMyClient.HideModsAndPlugins)
			{
				ModConsole.DebugLog("MelonMods should be 0...");
				__result = new List<MelonMod>();
			}
		}

		private static bool ControlledReadAllBytes(string __0, ref byte[] __result)
		{
			if (__0.ToLower() == SteamIdsPath.ToLower())
			{
				ModConsole.Warning($"{GetModName()} just tried to access the Steamids!");
				__result = new byte[0];
				return false;
			}
			if (__0.ToLower().Contains(SteamPath.ToLower()))
			{
				ModConsole.Warning($"{GetModName()} just tried to access A File in Steam path!");
				__result = new byte[0];
				return false;
			}
			return true;
		}

		private static bool ControlledReadAllLines(string __0, ref string[] __result)
		{
			if (__0.ToLower() == SteamIdsPath.ToLower())
			{
				ModConsole.Warning($"{GetModName()} just tried to access the Steamids!");
				__result = new string[0];
				return false;
			}
			//if (__0.ToLower().Contains(SteamPath.ToLower()))
			//{
			//    ModConsole.Warning($"{GetModName()} just tried to access A File in Steam path!");
			//    __result = new string[0];
			//    return false;
			//}
			return true;
		}


		private static bool ControlledReadAllText(string __0, ref string[] __result)
		{
			if (__0.ToLower() == SteamIdsPath.ToLower())
			{
				ModConsole.Warning($"{GetModName()} just tried to access the Steamids!");
				__result = new string[0];
				return false;
			}
			if (__0.ToLower().Contains(SteamPath.ToLower()))
			{
				ModConsole.Warning($"{GetModName()} just tried to access A File in Steam path!");
				__result = new string[0];
				return false;
			}
			return true;
		}


		private static void HideNetworkInterfaces(ref NetworkInterface[] __result)
		{
			ModConsole.DebugLog($"{GetModName()} Has Tried To Get all Network Interfaces!");
			__result = new NetworkInterface[0];
			return;
		}


		static readonly string[] WhitelistedRegistries = new string[]
		{
			@"SOFTWARE\Microsoft\Cryptography",
			@"SYSTEM\CurrentControlSet\services\Tcpip\Parameters",
		};

		static readonly string[] BlockedRegisterys = new string[]
		{
			"Windows",
			"Internet Settings",
			"CurrentVersion",
			"Software",
		};

		private static bool BlockOpenSubKey(ref string __0, ref RegistryKey __result)
		{
			if (WhiteListedMods.Contains(GetModName(), StringComparer.OrdinalIgnoreCase))
			{
				return true;
			}
			if (WhitelistedRegistries.Contains(__0))
			{
				ModConsole.DebugLog($"{GetModName()} Accessed Registry Key  : " + __0);
				return true;
			}
			else if (__0 == "SOFTWARE\\WOW6432Node\\Valve\\Steam")
			{
				ModConsole.Warning($"{GetModName()} Tried to Access Steam Key  : " + __0);
				__result = null;
				return false;
			}
			else if (__0 == "SOFTWARE\\Valve\\Steam")
			{
				ModConsole.Warning($"{GetModName()} Tried to Access Steam Key  : " + __0);
				__result = null;
				return false;
			}
			else if (BlockedRegisterys.Contains(__0))
			{
				ModConsole.DebugLog($"{GetModName()} Tried to Access Registry Key  : " + __0);
				__result = null;
				return false;
			}
			else if (DontTouchMyClient.NeedsToBlockRegistry)
			{
				ModConsole.DebugLog($"{GetModName()} Tried to Access Registry Key  : " + __0);
				__result = null;
				return false;
			}
			else
			{
				ModConsole.DebugLog($"{GetModName()} Accessed Registry Key  : " + __0);
				return true;
			}
		}

		private static bool MonitoredSendAsync(HttpRequestMessage __0, HttpCompletionOption __1, CancellationToken __2, ref Task<HttpResponseMessage> __result)
		{
			try
			{
				if (__0 != null)
				{
					if (__0.RequestUri.ToString().ToLower().Contains("/api/webhooks/"))
					{
						ModConsole.Warning($"ALERT: A {GetModName()} TRIED TO COMMUNICATE WITH A DISCORD WEBHOOK!");
						ModConsole.Warning("WEBHOOK URL : " + __0.RequestUri.ToString());
						ModConsole.Warning("Content Of Message Was : " + __0.Content.ReadAsStringAsync().Result);
						__result.Result.StatusCode = HttpStatusCode.Unauthorized;
						__result.Result.Content = null;
						__result.Result.RequestMessage = null;
						return false;
					}
					if (__0.RequestUri.ToString().ToLower().Contains(("auth/user?apiKey=").ToLower()))
					{
						ModConsole.Warning($"{GetModName()} Is communicating With VRChat API (using APIKEY)");
						ModConsole.DebugWarning($"{GetModName()} Is communicating with " + __0.RequestUri.ToString());
					}
					else
					{
						ModConsole.Warning($"{GetModName()} Is communicating with " + __0.RequestUri.ToString());
					}
					ModConsole.DebugLog("Content Of Message is : " + __0.Content.ReadAsStringAsync().Result);
					return true;
				}
			}
			catch { }
			return true;
		}

		private static bool isFirstConsoleClear = true;

		private static bool BlockFirstConsoleClear()
		{
			if (WhiteListedMods.Contains(GetModName(), StringComparer.OrdinalIgnoreCase))
			{
				return true;
			}
			if (isFirstConsoleClear)
			{
				ModConsole.DebugLog($"blocked Console.Clear() Called by {GetModName()}");
				return false;
			}
			ModConsole.DebugLog($"Permitted Console.Clear() Called by {GetModName()}");
			return true;
		}

		private static bool BlockConsoleBeeps()
		{

			ModConsole.DebugLog($"blocked Console.Beep() Called by {GetModName()}");
			return false;
		}

		private static bool ConsoleReadLine(ref string __result)
		{
			ModConsole.DebugLog($"Skipped Console.ReadLine, asked by {GetModName()}");
			__result = "";
			return false;
		}

		private static bool ConsoleReadKey(ref ConsoleKeyInfo __result)
		{
			ModConsole.DebugLog($"Skipped Console.ReadKey, asked by {GetModName()}");
			__result = new ConsoleKeyInfo('\b', ConsoleKey.Enter, false, false, false);
			return false;
		}

		private static bool ConsoleRead(ref int __result)
		{
			ModConsole.DebugLog($"Skipped Console.Read, asked by {GetModName()}");
			__result = 0;
			return false;
		}

		private static bool HideProcesses(ref System.Diagnostics.Process[] __result)
		{
			if (WhiteListedMods.Contains(GetModName().ToLower()))
			{
				return true;
			}
			//ModConsole.DebugLog($"{GetModName()} tried to access All running processes!");
			__result = new System.Diagnostics.Process[0];
			return false;
		}

		private static bool HideFiles(string __0, ref bool __result)
		{
			//ModConsole.DebugLog($"FileExist has been fired with path : {__0}");
			if (__0.ToLower().Contains((PluginsFolderPath + "\\DontTouchMyClient.dll").ToLower()))
			{
				ModConsole.Log($"Protected DontTouchMyClient from Being Detected by {GetModName()}!");
				__result = false;
				return false;
			}
			if (__0.ToLower().Contains(SteamIdsPath.ToLower()))
			{
				ModConsole.Log($"Protected Steam IDs from Being Detected by {GetModName()}!");
				__result = false;
				return false;
			}
			//if (__0.ToLower().Contains(SteamPath.ToLower()))
			//{
			//    ModConsole.Log($"Protected Steam Folder from Being Detected by {GetModName()}!");
			//    __result = false;
			//    return false;
			//}
			return true;
		}

		private static string ModsFolderPath
		{
			get
			{
				return Environment.CurrentDirectory + "\\Mods";
			}
		}
		private static string PluginsFolderPath
		{
			get
			{
				return Environment.CurrentDirectory + "\\Plugins";
			}
		}

		private static bool IsForbiddenpath(string Path)
		{
			if (WhiteListedMods.Contains(GetModName(), StringComparer.OrdinalIgnoreCase))
			{
				return true;
			}

			if (Path.ToLower().Contains(ModsFolderPath.ToLower()))
			{
				ModConsole.DebugLog("Detected Access to Forbidden path :" + Path);
				return true;
			}
			else if (Path.ToLower().Contains(PluginsFolderPath.ToLower()))
			{
				ModConsole.DebugLog("Detected Access to Forbidden path :" + Path);

				return true;
			}
			else if (Path.ToLower().Contains("/mods"))
			{
				ModConsole.DebugLog("Detected Access to Forbidden path :" + Path);

				return true;
			}
			else if (Path.ToLower().Contains("/Plugins"))
			{
				ModConsole.DebugLog("Detected Access to Forbidden path :" + Path);

				return true;
			}
			else if (Path.ToLower().Contains("/AstroClient"))
			{
				ModConsole.DebugLog("Detected Access to Extremely Forbidden path! :" + Path);

				return true;
			}
			else if (Path.ToLower().Contains(SteamIdsPath.ToLower()))
			{
				ModConsole.DebugLog("Detected Access to Forbidden path :" + Path);

				return true;
			}
			//else if (Path.ToLower().Contains(SteamPath.ToLower()))
			//{
			//    ModConsole.DebugLog("Detected Access to Forbidden path :" + Path);

			//    return true;
			//}
			return false;
		}


		private static string GetModName()
		{
			int ModsIndex = 0;
			foreach (var frame in new System.Diagnostics.StackTrace().GetFrames())
			{
				foreach (var item in MelonHandler.Mods)
				{
					if (item.Assembly.GetName().Name == new System.Diagnostics.StackTrace().GetFrame(ModsIndex).GetMethod().DeclaringType.Assembly.GetName().Name)
					{
						if (item.Assembly.GetName().Name != BuildInfo.Name)
						{
							return item.Assembly.GetName().Name;
						}
					}
				}
				foreach (var item in MelonHandler.Plugins)
				{
					if (item.Assembly.GetName().Name == new System.Diagnostics.StackTrace().GetFrame(ModsIndex).GetMethod().DeclaringType.Assembly.GetName().Name)
					{
						if (item.Assembly.GetName().Name != BuildInfo.Name)
						{
							return item.Assembly.GetName().Name;
						}
					}
				}
				ModsIndex++;
			}
			return "Unknown Mod";

		}

		private readonly static string[] WhiteListedMods = new string[]
		{
			"AstroClient",
			"BlazeVRMod",
			"vrcmodupdater",
			"vrcmodupdater.loader-merged",
			"vrcmodupdater.core"
		};

		private static bool ControlledFileDelete(string __0)
		{
			if (WhiteListedMods.Contains(GetModName(), StringComparer.OrdinalIgnoreCase))
			{
				return true;
			}
			if (IsForbiddenpath(__0))
			{
				ModConsole.Warning($"A {GetModName()} has Tried to Delete {__0}");
				return false;
			}
			var msg = $"{GetModName()} Deleted {__0}";
			if (PreviousString.Equals(msg))
			{

				// SKIP
				return true;
			}
			else
			{
				ModConsole.DebugWarning($"{GetModName()} Deleted {__0}");
				return true;
			}
			return true;
		}
		private static string PreviousString = "";

		// TODO: FIGURE A WAY TO HIDE IT AFTER THE INITS HAVE BEEN DONE.
		private static bool AntiCurrentProcess(ref System.Diagnostics.Process __result)
		{
			ModConsole.Warning($"{GetModName()} Is Asking for {__result.ProcessName}!");
			if (WhiteListedMods.Contains(GetModName(), StringComparer.OrdinalIgnoreCase))
			{
				return true;
			}

			__result = System.Diagnostics.Process.GetCurrentProcess();
			//ModConsole.Warning($"{GetModName()} Got The current Process!");
			return false;
		}

		private static bool AntiProcessStart(System.Diagnostics.Process __instance)
		{
			if (WhiteListedMods.Contains(GetModName(), StringComparer.OrdinalIgnoreCase))
			{
				return true;
			}
			var assemblyname = GetModName();
			try
			{
				if (__instance.StartInfo.UseShellExecute)
				{
					if (__instance.StartInfo.Arguments.ToLower().Contains("taskkill"))
					{
						if (__instance.StartInfo.Arguments.Contains("svchost.exe"))
						{
							Console.Beep();
							Console.Beep();
							Console.Beep();
							ModConsole.Warning($"{assemblyname} tried to BSOD YOU ! {__instance.StartInfo.Arguments}", System.Drawing.Color.Red);
							return false;
						}
					}
					if (__instance.StartInfo.Arguments.ToLower().Contains("shutdown"))
					{
						Console.Beep();

						Console.Beep();
						Console.Beep();
						ModConsole.Warning($"{assemblyname} tried to Shut Down Your PC! {__instance.StartInfo.Arguments}");
						return false;
					}
				}
				ModConsole.Warning($"{assemblyname} Started a Process! {__instance.ProcessName} With Params : {__instance.StartInfo.Arguments}");
			}
			catch
			{
			}
			return true;
		}

		private static bool AntiGetProcessesByName(System.Diagnostics.Process __instance)
		{
			if (WhiteListedMods.Contains(GetModName(), StringComparer.OrdinalIgnoreCase))
			{
				return true;
			}
			ModConsole.Warning($"{GetModName()} Tried to Get Current process ");
			return false;
		}


		private static bool AntiKill(System.Diagnostics.Process __instance)
		{
			if (WhiteListedMods.Contains(GetModName(), StringComparer.OrdinalIgnoreCase))
			{
				return true;
			}
			if (__instance.Id == System.Diagnostics.Process.GetCurrentProcess().Id)
			{
				ModConsole.Warning($"{GetModName()} tried to Ruin your Game Session (Trying to kill VRChat)!");
				return false;
			}
			else
			{
				ModConsole.Warning($"{GetModName()} tried to kill {System.Diagnostics.Process.GetProcessById(__instance.Id)}!");
				return false;
			}
		}

		private static bool Il2CPPAntiGameKill(Il2CppSystem.Diagnostics.Process __instance)
		{
			if (WhiteListedMods.Contains(GetModName(), StringComparer.OrdinalIgnoreCase))
			{
				return true;
			}
			if (__instance.Id == Il2CppSystem.Diagnostics.Process.GetCurrentProcess().Id)
			{
				ModConsole.Warning($"{GetModName()} tried to kill the current process!");
				return false;
			}

			return true;
		}

		static readonly string[] SafeAssemblys = new string[]
		{
			"UnityEngine",
			"VRC",
			"System",
			"Microsoft",
			"Il2Cpp"
		};

		private static void PostMonitoredAssemblyLoad(Assembly __result)
		{
			if (__result != null)
			{
				if (!SafeAssemblys.Contains(__result.FullName))
				{
					ModConsole.Warning($"{GetModName()} Loaded {__result?.FullName}");
				}
			}
		}

	}
}
