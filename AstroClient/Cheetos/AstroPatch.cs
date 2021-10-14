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
                if (PostFix != null)
                {
                    return $"PostFix Patch : {PostFix.method?.DeclaringType?.FullName}.{PostFix.method?.Name}";
                }
                else if (Prefix != null)
                {
                    return $"Prefix Patch : {Prefix.method?.DeclaringType?.FullName}.{Prefix.method?.Name}";
                }
                else if (Transpiler != null)
                {
                    return $"Transpiler Patch : {Transpiler.method?.DeclaringType?.FullName}.{Transpiler.method?.Name}";
                }
                else if (Finalizer != null)
                {
                    return $"Finalizer Patch : {Finalizer.method?.DeclaringType?.FullName}.{Finalizer.method?.Name}";

                }
                else if (IlManipulator != null)
                {
                    return $"IlManipulator Patch : {IlManipulator.method?.DeclaringType?.FullName}.{IlManipulator.method?.Name}";
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
                    reason.Append("Prefix Method is null");
                }
                if (PostFix == null)
                {
                    reason.Append("Postfix Method is null");
                }
                else if(Transpiler == null)
                {
                    reason.Append("Transpiler Method is null");

                }
                else if (Finalizer == null)
                {
                    reason.Append("Finalizer Method is null");

                }
                else if (ILmanipulator == null)
                {
                    reason.Append("ILmanipulator Method is null");

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
