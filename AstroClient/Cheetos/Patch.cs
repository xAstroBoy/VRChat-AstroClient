namespace AstroClient
{
    #region Imports

    using AstroLibrary.Console;
    using Harmony;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;

    #endregion Imports

    internal class Patch
    {
        internal MethodInfo TargetMethod { get; set; }
        internal HarmonyMethod PrefixMethod { get; set; }
        internal HarmonyMethod PostfixMethod { get; set; }
        internal HarmonyLib.Harmony Instance { get; set; }

        internal Patch(MethodInfo targetMethod, HarmonyMethod Before = null, HarmonyMethod After = null)
        {
            if (targetMethod == null || (Before == null && After == null))
            {
                ModConsole.Error("[Patches] TargetMethod is NULL or Pre And PostFix are Null");
                return;
            }
            Instance = new HarmonyLib.Harmony($"Patch:{targetMethod.DeclaringType.FullName}.{targetMethod.Name}");
            TargetMethod = targetMethod;
            PrefixMethod = Before;
            PostfixMethod = After;
            DoPatch(this);
        }

        internal static void DoPatch(Patch patch)
        {
            try
            {
                patch.Instance.Patch(patch.TargetMethod, patch.PrefixMethod, patch.PostfixMethod);
            }
            catch (Exception e)
            {
                ModConsole.Error($"[Patches] Failed At {patch.TargetMethod?.Name} | {patch.PrefixMethod?.method.Name} | with AstroClient {patch.PostfixMethod?.method.Name}");
                ModConsole.Error(e.Message);
                ModConsole.ErrorExc(e);
            }
            finally
            {
                ModConsole.DebugLog($"[Patches] Patched {patch.TargetMethod.DeclaringType.FullName}.{patch.TargetMethod.Name} | with AstroClient {patch.PrefixMethod?.method.Name}{patch.PostfixMethod?.method.Name}");
            }
        }
    }
}
