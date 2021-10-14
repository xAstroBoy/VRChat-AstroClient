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
                    string patch = $"PostFix Patch : {PostFix.method?.DeclaringType?.FullName}.{PostFix.method?.Name}";
                    if (patchtype.Length != 0)
                    {
                        patchtype.AppendLine(patch);
                    }
                    else
                    {
                        patchtype.Append(patch);
                    }
                }
                if (Prefix != null)
                {
                    string patch = $"Prefix Patch : {Prefix.method?.DeclaringType?.FullName}.{Prefix.method?.Name}";
                    if (patchtype.Length != 0)
                    {
                        patchtype.AppendLine(patch);
                    }
                    else
                    {
                        patchtype.Append(patch);
                    }
                }
                if (Transpiler != null)
                {
                    string patch = $"Transpiler Patch : {Transpiler.method?.DeclaringType?.FullName}.{Transpiler.method?.Name}";
                    if (patchtype.Length != 0)
                    {
                        patchtype.AppendLine(patch);
                    }
                    else
                    {
                        patchtype.Append(patch);
                    }
                }
                if (Finalizer != null)
                {
                    string patch = $"Finalizer Patch : {Finalizer.method?.DeclaringType?.FullName}.{Finalizer.method?.Name}";
                    if (patchtype.Length != 0)
                    {
                        patchtype.AppendLine(patch);
                    }
                    else
                    {
                        patchtype.Append(patch);
                    }

                }
                if (IlManipulator != null)
                {
                    string patch = $"IlManipulator Patch : {IlManipulator.method?.DeclaringType?.FullName}.{IlManipulator.method?.Name}";
                    if (patchtype.Length != 0)
                    {
                        patchtype.AppendLine(patch);
                    }
                    else
                    {
                        patchtype.Append(patch);
                    }
                }
                if (patchtype.Length == 0)
                {
                    return "Failed to Read Patch.";
                }
                else
                {
                    return patchtype.ToString();
                }
            }
        }

        internal AstroPatch(MethodInfo TargetMethod, HarmonyMethod Prefix = null, HarmonyMethod PostFix = null, HarmonyMethod Transpiler = null , HarmonyMethod Finalizer = null , HarmonyMethod ILmanipulator = null)
        {
            if (TargetMethod == null || (Prefix == null && PostFix == null && Transpiler == null && Finalizer == null && ILmanipulator == null))
            {
                StringBuilder FailureReason = new StringBuilder();
                if (Prefix == null)
                {
                    string reason = "Prefix Method is null"; 
                    if (FailureReason.Length != 0)
                    {
                        FailureReason.AppendLine(reason);
                    }
                    else
                    {
                        FailureReason.Append(reason);
                    }
                }
                if (PostFix == null)
                {
                    string reason = "PostFix Method is null";
                    if (FailureReason.Length != 0)
                    {
                        FailureReason.AppendLine(reason);
                    }
                    else
                    {
                        FailureReason.Append(reason);
                    }

                }
                if (Transpiler == null)
                {
                    string reason = "Transpiler Method is null";
                    if (FailureReason.Length != 0)
                    {
                        FailureReason.AppendLine(reason);
                    }
                    else
                    {
                        FailureReason.Append(reason);
                    }
                }
                if (Finalizer == null)
                {
                    string reason = "Finalizer Method is null";
                    if (FailureReason.Length != 0)
                    {
                        FailureReason.AppendLine(reason);
                    }
                    else
                    {
                        FailureReason.Append(reason);
                    }

                }
                if (ILmanipulator == null)
                {
                    string reason = "ILmanipulator Method is null";
                    if (FailureReason.Length != 0)
                    {
                        FailureReason.AppendLine(reason);
                    }
                    else
                    {
                        FailureReason.Append(reason);
                    }

                }
                if (TargetMethod != null)
                {
                    ModConsole.Error("[AstroPatch] TargetMethod is NULL");
                }
                else
                {
                    if (Bools.IsDeveloper)
                    {
                        ModConsole.Error($"[AstroPatch] Failed to Patch {TargetMethod.DeclaringType.FullName}.{TargetMethod.Name} because {FailureReason.ToString()}.");
                    }
                    else
                    {
                        ModConsole.Error($"[AstroPatch] Failed to Patch {TargetMethod?.Name}");
                    }
                }
                return;
            }

            this.TargetMethod = TargetMethod;
            this.Prefix = Prefix;
            this.PostFix = PostFix;
            this.Transpiler = Transpiler;
            this.Finalizer = Finalizer;
            this.IlManipulator = ILmanipulator;
            Instance = new HarmonyLib.Harmony($"AstroPatch: {TargetPath}, {PatchType}");
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
                    ModConsole.DebugLog($"[AstroPatch] Patched {patch.TargetMethod?.Name}");
                }
            }
        }
    }
}
