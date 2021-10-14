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
    using System.Text;

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
            if (TargetMethod == null || (PrefixMethod == null && PostfixMethod == null && TranspilerMethod == null && FinalizerMethod == null && IlManipulatorMethod == null))
            {
                StringBuilder reason = new StringBuilder();
                if(PostfixMethod == null)
                {
                    reason.Append("Postfix Method is null");
                }
                else if(TranspilerMethod == null)
                {
                    reason.Append("TranspilerMethod Method is null");

                }
                else if (FinalizerMethod == null)
                {
                    reason.Append("FinalizerMethod Method is null");

                }
                else if (IlManipulatorMethod == null)
                {
                    reason.Append("IlManipulatorMethod Method is null");

                }
                if (TargetMethod != null)
                {

                    ModConsole.Error("[AstroPatch] TargetMethod is NULL");
                }
                else
                {
                    ModConsole.Error($"[AstroPatch] Failed to Patch {TargetMethod.DeclaringType.FullName}.{TargetMethod.Name} because {reason.ToString()} .");
                }
                return;
            }
            StringBuilder patchname = new StringBuilder();
            if (PostfixMethod != null)
            {
                patchname.Append($"PostFix Patch : {PostfixMethod?.method.DeclaringType.FullName}.{PostfixMethod?.method.Name}");
            }
            else if (TranspilerMethod != null)
            {
                patchname.Append($"Transpiler Patch : {TranspilerMethod?.method.DeclaringType.FullName}.{TranspilerMethod?.method.Name}");

            }
            else if (FinalizerMethod != null)
            {
                patchname.Append($"Finalizer Patch : {FinalizerMethod?.method.DeclaringType.FullName}.{FinalizerMethod?.method.Name}");

            }
            else if (IlManipulatorMethod != null)
            {
                patchname.Append($"ILManipulator Patch : {IlManipulatorMethod?.method.DeclaringType.FullName}.{IlManipulatorMethod?.method.Name}");
            }

            Instance = new HarmonyLib.Harmony($"AstroPatch:{TargetMethod.DeclaringType.FullName}.{TargetMethod.Name}, {patchname.ToString()}");
            patchname.Clear();
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
                    StringBuilder patchtype = new StringBuilder();
                    if (patch.PostfixMethod != null)
                    {
                        patchtype.Append($"PostFix Patch : {patch.PostfixMethod?.method.DeclaringType.FullName}.{patch.PostfixMethod?.method.Name}");
                    }
                    else if (patch.TranspilerMethod != null)
                    {
                        patchtype.Append($"Transpiler Patch : {patch.TranspilerMethod?.method.DeclaringType.FullName}.{patch.TranspilerMethod?.method.Name}");

                    }
                    else if (patch.FinalizerMethod != null)
                    {
                        patchtype.Append($"Finalizer Patch : {patch.FinalizerMethod?.method.DeclaringType.FullName}.{patch.FinalizerMethod?.method.Name}");

                    }
                    else if (patch.IlManipulatorMethod != null)
                    {
                        patchtype.Append($"ILManipulator Patch : {patch.IlManipulatorMethod?.method.DeclaringType.FullName}.{patch.IlManipulatorMethod?.method.Name}");
                    }
                    ModConsole.Error($"[AstroPatch] Failed At {patch.TargetMethod?.Name} | {patch.PrefixMethod?.method.Name} | with AstroClient {patch.PostfixMethod?.method.Name}");
                    patchtype.Clear();
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
                    StringBuilder patchtype = new StringBuilder();
                    if (patch.PostfixMethod != null)
                    {
                        patchtype.Append($"PostFix Patch : {patch.PostfixMethod?.method.DeclaringType.FullName}.{patch.PostfixMethod?.method.Name}");
                    }
                    else if (patch.TranspilerMethod != null)
                    {
                        patchtype.Append($"Transpiler Patch : {patch.TranspilerMethod?.method.DeclaringType.FullName}.{patch.TranspilerMethod?.method.Name}");

                    }
                    else if (patch.FinalizerMethod != null)
                    {
                        patchtype.Append($"Finalizer Patch : {patch.FinalizerMethod?.method.DeclaringType.FullName}.{patch.FinalizerMethod?.method.Name}");

                    }
                    else if (patch.IlManipulatorMethod != null)
                    {
                        patchtype.Append($"ILManipulator Patch : {patch.IlManipulatorMethod?.method.DeclaringType.FullName}.{patch.IlManipulatorMethod?.method.Name}");
                    }

                    ModConsole.DebugLog($"[Patches] Patched {patch.TargetMethod.DeclaringType.FullName}.{patch.TargetMethod.Name} | with AstroClient {patchtype.ToString()}");
                    patchtype.Clear();
                }
                else
                {
                    ModConsole.DebugLog($"[Patches] Patched {patch.TargetMethod.DeclaringType.FullName}.{patch.TargetMethod.Name}");
                }
            }
        }
    }
}
