using AstroLibrary.Console;
using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DontTouchMyClient.Patcher
{
	public class Patch
	{
		private static int GetRandomInt()
		{
			System.Random random = new System.Random();
			return random.Next(15, 20);
		}

		private static string StringGen(int length)
		{
			System.Random random = new System.Random();
			string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_";
			return new string(chars.Select((char c) => chars[random.Next(chars.Length)]).Take(length).ToArray());
		}

		private static readonly List<Patch> Patches = new List<Patch>();
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
			Instance = HarmonyInstance.Create(StringGen(GetRandomInt()));
			TargetMethod = targetMethod;
			PrefixMethod = Before;
			PostfixMethod = After;
			Patches.Add(this);
		}

		public static void DoPatches()
		{
			foreach (var patch in Patches)
			{
				try
				{
					if (patch != null)
					{
						new PatchProcessor(patch.Instance, new List<MethodBase>
						{
							patch.TargetMethod
						}, patch.PrefixMethod, patch.PostfixMethod, null).Patch();
					}
				}
				catch
				{
					ModConsole.Error($"[Patches] Failed At {patch.TargetMethod?.Name} | {patch.PrefixMethod?.method.Name} | with {patch.PostfixMethod?.method.Name} , Full Method : {patch.TargetMethod.FullDescription()}");
				}
			}

			ModConsole.Log($"[Patches] Done! Patched {Patches.Count} Methods!");
		}
	}
}
