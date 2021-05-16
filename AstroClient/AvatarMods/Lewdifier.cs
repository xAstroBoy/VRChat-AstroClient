namespace AstroClient.AvatarMods
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using UnityEngine;
	using AstroClient.Extensions;
	using AstroLibrary.Console;

	public class Lewdifier : GameEvents
	{


		public override void OnApplicationStart()
		{
			RefreshAll();
		}




		public static List<string> TermsToToggleOn { get; private set; } = new List<string>();
		public static List<string> TermsToToggleOff { get; private set; } = new List<string>();
		public static List<string> AvatarsToSkip { get; private set; } = new List<string>();


		private static string TermsToEnableOnPath { get; } = Environment.CurrentDirectory + @"\AstroClient\Lewdify\TermsToEnable.json";
		private static string TermsToEnableOffPath { get; } = Environment.CurrentDirectory + @"\AstroClient\Lewdify\TermsToDisable.json";
		private static string AvatarsToSkipPath { get; } = Environment.CurrentDirectory + @"\AstroClient\Lewdify\IgnoredAvatars.json";


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
				return $"Terms To Enable : {TermsToToggleOn.Count}\n" +
					   $"Terms To Disable : {TermsToToggleOff.Count}\n" +
					   $"Avatars to Skip : {AvatarsToSkip.Count}";
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
			}
			else
			{
				File.Create(AvatarsToSkipPath);
			}
		}


		public static bool LewdifyTermsToTurnOff(List<Transform> avataritems)
		{
			bool flag = false;
			if (avataritems.Count() != 0)
			{
				foreach(var item in avataritems)
				{
					foreach (var childitem in item.Get_All_Childs())
					{
						ModConsole.DebugLog($"Checking {childitem.name} in TermsToToggleOff");
						if (TermsToToggleOff.Contains(childitem.name.ToLower()))
						{
							ModConsole.DebugLog($"{childitem.name} Found in TermsToToggleOff", System.Drawing.Color.Green);

							flag = true;
							if (AvatarModifier.ForceLewdify)
							{
								childitem.DestroyMeLocal();
							}
							else
							{
								var parent = childitem.Get_root_of_avatar_child();
								if(parent != null)
								{
									ModConsole.DebugLog($"Got root of  {childitem.name} , Root is : {parent.name}");

									foreach (var animator in parent.GetComponentsInChildren<Animator>(true))
									{
										if (animator != null)
										{
											if (animator.enabled)
											{
												animator.enabled = false;
											}
										}
									}
								}
								if (childitem.gameObject.active)
								{
									childitem.gameObject.SetActiveRecursively(false);
								}
							}
						}
					}
				}
			}
			return flag;
		}

		public static bool LewdifyTermsToToggleOn(List<Transform> avataritems)
		{
			bool flag = false;
			if (avataritems.Count() != 0)
			{
				foreach (var item in avataritems)
				{
					foreach (var childitem in item.Get_All_Childs())
					{
						ModConsole.DebugLog($"Checking {childitem.name} in TermsToToggleOn");

						if (TermsToToggleOn.Contains(childitem.name.ToLower()))
						{
							ModConsole.DebugLog($"{childitem.name} Found in TermsToToggleOn", System.Drawing.Color.Green);

							flag = true;
							var parent = childitem.Get_root_of_avatar_child();
							ModConsole.DebugLog($"Got root of  {childitem.name} , Root is : {parent.name}");

							if (parent != null)
							{
								ModConsole.DebugLog($"Enabling Parent.. {parent.name}...");

								if (!parent.gameObject.active)
								{
									parent.gameObject.active = true;
								}
								if (!childitem.gameObject.active)
								{
									childitem.gameObject.SetActiveRecursively(true);
								}

								ModConsole.DebugLog($"Enabling Animators of {parent.name}...");

								foreach (var animator in parent.GetComponentsInChildren<Animator>(true))
								{
									if (animator != null)
									{
										if (!animator.enabled)
										{
											animator.enabled = true;
										}
									}
								}
							}

						}
					}
				}
			}
			return flag;
		}





	}
}
