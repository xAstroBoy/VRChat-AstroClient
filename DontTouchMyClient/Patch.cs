namespace DontTouchMyClient.Patcher
{
	using AstroLibrary.Console;
	using HarmonyLib;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;

	public class Patch
    {
        private static int GetRandomInt()
        {
            System.Random random = new System.Random();
            return random.Next(15, 20);
        }

        private static string StringGen()
        {
            System.Random random = new System.Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_";
            return new string(chars.Select((char c) => chars[random.Next(chars.Length)]).Take(GetRandomInt()).ToArray());
        }



        private static readonly List<Patch> Patches = new List<Patch>();
        public MethodInfo TargetMethod { get; set; }
        public HarmonyMethod PrefixMethod { get; set; }
        public HarmonyMethod PostfixMethod { get; set; }
        public Harmony Instance { get; set; }

        public Patch(MethodInfo targetMethod, HarmonyMethod Before = null, HarmonyMethod After = null)
        {
            if (targetMethod == null || (Before == null && After == null))
            {
                ModConsole.Error("[Patches] TargetMethod is NULL or Pre And PostFix are Null");
                return;
            }
            Instance = new Harmony(StringGen());
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
					ModConsole.ErrorExc(e);
				}
			}
			ModConsole.DebugLog($"[Patches] Done! Patched {Patches.Count} Methods!");
		}
	}
}
