namespace AstroClientCore.Patching
{
	using AstroLibrary.Console;
	using Harmony;
	using System;
	using System.Reflection;

	public class Patch
	{
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
		}

		public void DoPatch()
		{
			try
			{
				ModConsole.DebugLog($"[Patches] Patching {TargetMethod.DeclaringType.FullName}.{TargetMethod.Name} | with AstroClient {PrefixMethod?.method.Name}{PostfixMethod?.method.Name}");
				Instance.Patch(TargetMethod, PrefixMethod, PostfixMethod);
			}
			catch (Exception e)
			{
				ModConsole.Error($"[Patches] Failed At {TargetMethod?.Name} | {PrefixMethod?.method.Name} | with AstroClient {PostfixMethod?.method.Name}");
				ModConsole.Error(e.Message);
				ModConsole.ErrorExc(e);
			}
		}

		public void UnDoPatches()
		{
			try
			{
				Instance.UnpatchAll();
			}
			catch (Exception e)
			{
				ModConsole.Error($"[Patches] Failed At {TargetMethod?.Name} | {PrefixMethod?.method.Name} | {PostfixMethod?.method.Name}");
				ModConsole.ErrorExc(e);
			}
		}
	}
}
