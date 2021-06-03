namespace AstroClient.Startup.Hooks
{
	using AstroLibrary.Console;
	using Harmony;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	using System.Text;
	using System.Threading.Tasks;
	using VRC.Core;
	using VRC.Management;

	public class AntiVoteKick : GameEvents
	{
		private HarmonyInstance harmony;


		public override void ExecutePriorityPatches()
		{
			//HookModerationKick();
		}

		private void HookModerationKick()
		{
			if (harmony == null)
			{
				harmony = HarmonyInstance.Create(BuildInfo.Name + " AntiKick");
			}
			ModConsole.DebugLog("Hooking Kick...");
			harmony.Patch(typeof(ModerationManager).GetMethod(nameof(ModerationManager.Method_Public_Void_APIUser_String_0), BindingFlags.Public | BindingFlags.Instance), new HarmonyMethod(typeof(AntiVoteKick).GetMethod(nameof(Antikick), BindingFlags.Public | BindingFlags.Static)));
		}

		public static bool Antikick(APIUser __0, string __1)
		{
				ModConsole.Log("Blocked A Kick Against You!", System.Drawing.Color.CornflowerBlue);
				return false;
		}

	}
}
