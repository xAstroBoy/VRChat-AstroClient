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


		public static List<string> TermsToToggleOn { get; set; } = new List<string>();
		public static List<string> TermsToToggleOff { get; set; } = new List<string>();
		public static List<string> AvatarsToSkip { get; set; } = new List<string>();


		private static string TermsToEnableOnPath { get; } = Environment.CurrentDirectory + @"\AstroClient\Lewdify\TermsToEnable.json";
		private static string TermsToEnableOffPath { get; } = Environment.CurrentDirectory + @"\AstroClient\Lewdify\TermsToDisable.json";
		private static string AvatarsToSkipPath { get; } = Environment.CurrentDirectory + @"\AstroClient\Lewdify\IgnoredAvatars.json";


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
			Refresh_termsToToggleOn();
			Refresh_termsToToggleOff();
			Refresh_AvatarsToSkip();
			if (AvatarModifier.LewdifyLists != null)
			{
				AvatarModifier.LewdifyLists.setButtonText(ListButtonText);
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
			if (File.Exists(TermsToEnableOnPath))
			{
				List<string> list = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(TermsToEnableOnPath));
				foreach (var item in list)
				{
					// Duplicate Check.
					if (!TermsToToggleOn.Contains(item.ToLower()))
					{
						TermsToToggleOn.Add(item.ToLower());
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
			if (File.Exists(TermsToEnableOffPath))
			{
				List<string> list = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(TermsToEnableOffPath));
				foreach (var item in list)
				{
					// Duplicate Check.
					if (!TermsToToggleOff.Contains(item.ToLower()))
					{
						TermsToToggleOff.Add(item.ToLower());
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

			if (File.Exists(AvatarsToSkipPath))
			{
				List<string> list = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(AvatarsToSkipPath));
				foreach (var item in list)
				{
					// Duplicate Check.
					if (!AvatarsToSkip.Contains(item.ToLower()))
					{
						AvatarsToSkip.Add(item.ToLower());
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
