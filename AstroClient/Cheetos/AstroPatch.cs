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
    using AstroLibrary.Extensions;
    #endregion Imports

    internal class AstroPatch
    {
        internal MethodInfo TargetMethod { get; set; }
        internal HarmonyMethod Prefix { get; set; }
        internal HarmonyMethod PostFix { get; set; }
        internal HarmonyMethod Transpiler { get; set; }
        internal HarmonyMethod Finalizer { get; set; }

        internal HarmonyMethod IlManipulator { get; set; }
        internal HarmonyLib.Harmony Instance { get; set; }


        internal string TargetPath
        {
            get
            {
                return $"{TargetMethod?.DeclaringType?.FullName}.{TargetMethod.Name}";
            }
        }
        internal string PatchType
        {
            get
            {
                StringBuilder patchtype = new StringBuilder();
                if (PostFix != null)
                {
                    patchtype.AppendLine($"PostFix Patch : {PostFix.method?.DeclaringType?.FullName}.{PostFix.method?.Name}");
                }
                if (Prefix != null)
                {
                    patchtype.AppendLine($"Prefix Patch : {Prefix.method?.DeclaringType?.FullName}.{Prefix.method?.Name}");
                }
                if (Transpiler != null)
                {
                    patchtype.AppendLine($"Transpiler Patch : {Transpiler.method?.DeclaringType?.FullName}.{Transpiler.method?.Name}");
                }
                if (Finalizer != null)
                {
                    patchtype.AppendLine($"Finalizer Patch : {Finalizer.method?.DeclaringType?.FullName}.{Finalizer.method?.Name}");

                }
                if (IlManipulator != null)
                {
                    patchtype.AppendLine($"IlManipulator Patch : {IlManipulator.method?.DeclaringType?.FullName}.{IlManipulator.method?.Name}");
                }

                return "Failed to Read Patch.";
            }
        }

        internal AstroPatch(MethodInfo TargetMethod, HarmonyMethod Prefix = null, HarmonyMethod PostFix = null, HarmonyMethod Transpiler = null , HarmonyMethod Finalizer = null , HarmonyMethod ILmanipulator = null)
        {
            if (TargetMethod == null || (Prefix == null && PostFix == null && Transpiler == null && Finalizer == null && ILmanipulator == null))
            {
                StringBuilder reason = new StringBuilder();
                if (Prefix == null)
                {
                    reason.AppendLine("Prefix Method is null");
                }
                if (PostFix == null)
                {
                    reason.AppendLine("Postfix Method is null");
                }
                if(Transpiler == null)
                {
                    reason.AppendLine("Transpiler Method is null");

                }
                if (Finalizer == null)
                {
                    reason.AppendLine("Finalizer Method is null");

                }
                if (ILmanipulator == null)
                {
                    reason.AppendLine("ILmanipulator Method is null");

                }
                if (TargetMethod != null)
                {

                    ModConsole.Error("[AstroPatch] TargetMethod is NULL");
                }
                else
                {
                    ModConsole.Error($"[AstroPatch] Failed to Patch {TargetMethod.DeclaringType.FullName}.{TargetMethod.Name} because {reason.ToString()}.");
                }
                return;
            }

            this.TargetMethod = TargetMethod;
            this.Prefix = Prefix;
            this.PostFix = PostFix;
            this.Transpiler = Transpiler;
            this.Finalizer = Finalizer;
            this.IlManipulator = ILmanipulator;
            Instance = new HarmonyLib.Harmony($"AstroPatch: {TargetPath}, {PatchType.ToString()}");
            DoPatch(this);
        }

        internal static void DoPatch(AstroPatch patch)
        {
            try
            {
                patch.Instance.Patch(patch.TargetMethod, patch.Prefix, patch.PostFix, patch.Transpiler, patch.Finalizer, patch.IlManipulator);
            }
            catch (Exception e)
            {
                if (Bools.IsDeveloper)
                {
                    
                    ModConsole.Error($"[AstroPatch] Failed At {patch.TargetPath} | with AstroClient {patch.PatchType}");
                }
                else
                {
                    ModConsole.Error($"[AstroPatch] Failed At {patch.TargetMethod?.Name}");
                }
                ModConsole.ErrorExc(e);
            }
            finally
            {
                if (Bools.IsDeveloper)
                {
                    ModConsole.DebugLog($"[AstroPatch] Patched {patch.TargetPath} | with {patch.PatchType}");
                }
                else
                {
                    ModConsole.DebugLog($"[AstroPatch] Patched {patch.TargetMethod.Name}");
                }
            }
        }
    }
}
