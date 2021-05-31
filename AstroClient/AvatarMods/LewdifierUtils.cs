namespace AstroClient.AvatarMods
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using UnityEngine;
	using AstroClient.Extensions;
	using AstroLibrary.Console;
	using AstroNetworkingLibrary;
	using RubyButtonAPI;

	public class LewdifierUtils : GameEvents
	{


		public override void OnLevelLoaded()
		{
			RefreshAll();
		}

		public override void OnApplicationQuit()
		{
			SaveAll();
		}

		public static QMSingleButton LewdifyLists;

		public static List<string> TermsToToggleOn { get; set; } = new List<string>();
		public static List<string> TermsToToggleOff { get; set; } = new List<string>();
		public static List<string> AvatarsToSkip { get; set; } = new List<string>();


		private static string TermsToEnableOnPath { get; } = Path.Combine(Environment.CurrentDirectory, @"\AstroClient\Lewdify\TermsToEnable.json");
		private static string TermsToEnableOffPath { get; } = Path.Combine(Environment.CurrentDirectory, @"\AstroClient\Lewdify\TermsToDisable.json");
		private static string AvatarsToSkipPath { get; } = Path.Combine(Environment.CurrentDirectory, @"\AstroClient\Lewdify\IgnoredAvatars.json");


		public static void SaveAll()
		{
			Save_TermsToToggleOn();
			Save_TermsToToggleOff();
			Save_AvatarToSkip();
		}

		public static void Save_TermsToToggleOn()
		{
			JSonWriter.WriteToJsonFile(TermsToEnableOnPath, TermsToToggleOn);
		}

		public static void Save_TermsToToggleOff()
		{
			JSonWriter.WriteToJsonFile(TermsToEnableOffPath, TermsToToggleOff);
		}

		public static void Save_AvatarToSkip()
		{
			JSonWriter.WriteToJsonFile(AvatarsToSkipPath, AvatarsToSkip);
		}

		public static void RefreshAll()
		{
			try
			{
				Refresh_termsToToggleOn();
				Refresh_termsToToggleOff();
				Refresh_AvatarsToSkip();

			}
			catch(Exception e)
			{
				ModConsole.DebugErrorExc(e);
			}
			if (LewdifyLists != null)
			{
				LewdifyLists.SetButtonText(ListButtonText);
			}
		}


		public static string ListButtonText
		{
			get
			{
				return $"Terms To Enable: {TermsToToggleOn.Count}\n" +
					   $"Terms To Disable: {TermsToToggleOff.Count}\n" +
					   $"Avatars to Skip: {AvatarsToSkip.Count}";
			}

		}


		public static void Refresh_termsToToggleOn()
		{
			ModConsole.DebugLog($"Path is set to : {TermsToEnableOnPath}");

			if (File.Exists(TermsToEnableOnPath))
			{
				List<string> list = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(TermsToEnableOnPath));
				foreach (var item in list)
				{
					// Duplicate Check.
					ModConsole.DebugLog($"Found Term : {item}");
					if (!TermsToToggleOn.Contains(item.ToLower()))
					{
						ModConsole.DebugLog($"Registered Term in TermsToToggleOn : {item}");
						TermsToToggleOn.Add(item.ToLower());
					}
					else
					{
						ModConsole.DebugLog($"Found Duplicated Term in TermsToToggleOn : {item}");
					}
				}
				Save_TermsToToggleOn();
			}
			else
			{
				File.Create(TermsToEnableOnPath);
			}
		}

		public static void Refresh_termsToToggleOff()
		{
			ModConsole.DebugLog($"Path is set to : {TermsToEnableOffPath}");

			if (File.Exists(TermsToEnableOffPath))
			{
				List<string> list = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(TermsToEnableOffPath));
				foreach (var item in list)
				{
					ModConsole.DebugLog($"Found Term : {item}");
					if (!TermsToToggleOff.Contains(item.ToLower()))
					{
						ModConsole.DebugLog($"Registered Term in TermsToToggleOff : {item}");
						TermsToToggleOff.Add(item.ToLower());
					}
					else
					{
						ModConsole.DebugLog($"Found Duplicated Term in TermsToToggleOff : {item}");
					}
				}
				Save_TermsToToggleOff();
			}
			else
			{
				File.Create(TermsToEnableOffPath);
			}
		}


		public static void Refresh_AvatarsToSkip()
		{
			ModConsole.DebugLog($"Path is set to : {AvatarsToSkipPath}");

			if (File.Exists(AvatarsToSkipPath))
			{
				List<string> list = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(AvatarsToSkipPath));
				foreach (var item in list)
				{
					ModConsole.DebugLog($"Found Term : {item}");
					if (!AvatarsToSkip.Contains(item))
					{
						ModConsole.DebugLog($"Registered Term in AvatarsToSkip : {item}");
						AvatarsToSkip.Add(item);
					}
					else
					{
						ModConsole.DebugLog($"Found Duplicated Term in AvatarsToSkip : {item}");
					}
				}
				Save_AvatarToSkip();
			}
			else
			{
				File.Create(AvatarsToSkipPath);
			}
		}
	}
}
