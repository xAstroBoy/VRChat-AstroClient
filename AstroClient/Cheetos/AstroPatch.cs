namespace AstroClient
{
    #region Imports

    using AstroClient.Variables;
    using AstroLibrary.Console;
    using Harmony;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;

    #endregion Imports

    internal class AstroPatch
    {
        internal MethodInfo TargetMethod { get; set; }
        internal HarmonyMethod PrefixMethod { get; set; }
        internal HarmonyMethod PostfixMethod { get; set; }
        internal HarmonyMethod TranspilerMethod { get; set; }
        internal HarmonyMethod FinalizerMethod { get; set; }

        internal HarmonyMethod IlManipulatorMethod { get; set; }
        internal HarmonyLib.Harmony Instance { get; set; }

        internal AstroPatch(MethodInfo TargetMethod, HarmonyMethod PrefixMethod = null, HarmonyMethod PostfixMethod = null, HarmonyMethod TranspilerMethod = null , HarmonyMethod FinalizerMethod = null , HarmonyMethod IlManipulatorMethod = null)
        {
            if (TargetMethod == null || (PrefixMethod == null && PostfixMethod == null))
            {
                ModConsole.Error("[Patches] TargetMethod is NULL or Pre And PostFix are Null");
                return;
            }
            Instance = new HarmonyLib.Harmony($"AstroPatch:{TargetMethod.DeclaringType.FullName}.{TargetMethod.Name}");
            this.TargetMethod = TargetMethod;
            this.PrefixMethod = PrefixMethod;
            this.PostfixMethod = PostfixMethod;
            this.TranspilerMethod = TranspilerMethod;
            this.FinalizerMethod = FinalizerMethod;
            this.IlManipulatorMethod = IlManipulatorMethod;

            DoPatch(this);
        }

        internal static void DoPatch(AstroPatch patch)
        {
            try
            {
                patch.Instance.Patch(patch.TargetMethod, patch.PrefixMethod, patch.PostfixMethod, patch.TranspilerMethod, patch.FinalizerMethod, patch.IlManipulatorMethod);
            }
            catch (Exception e)
            {
                if (Bools.IsDeveloper)
                {
                    ModConsole.Error($"[AstroPatch] Failed At {patch.TargetMethod?.Name} | {patch.PrefixMethod?.method.Name} | with AstroClient {patch.PostfixMethod?.method.Name}");
                }
                else
                {
                    ModConsole.Error($"[AstroPatch] Failed At {patch.TargetMethod?.Name}");
                }
                ModConsole.Error(e.Message);
                ModConsole.ErrorExc(e);
            }
            finally
            {
                if (Bools.IsDeveloper)
                {
                    ModConsole.DebugLog($"[Patches] Patched {patch.TargetMethod.DeclaringType.FullName}.{patch.TargetMethod.Name} | with AstroClient {patch.PrefixMethod?.method.Name}{patch.PostfixMethod?.method.Name}");
                }
                else
                {
                    ModConsole.DebugLog($"[Patches] Patched {patch.TargetMethod.DeclaringType.FullName}.{patch.TargetMethod.Name}");
                }
            }
        }
    }
}
