namespace AstroClient.Cheetos
{
    #region Imports

    using System;
    using System.Reflection;
    using System.Text;
    using Constants;
    using HarmonyLib;

    #endregion Imports

    internal class AstroPatch
    {
        private Type type;

        private string PatchIdentifier { get; } = "AstroPatch";
        internal MethodInfo TargetMethod_MethodInfo { get; set; }

        internal MethodBase TargetMethod_MethodBase { get; set; }

        internal HarmonyMethod Prefix { get; set; }
        internal HarmonyMethod PostFix { get; set; }
        internal HarmonyMethod Transpiler { get; set; }
        internal HarmonyMethod Finalizer { get; set; }

        internal HarmonyMethod IlManipulator { get; set; }
        internal Harmony Instance { get; set; }
        private static bool HasThrownException { get; set; } = false;
        private static bool ShowErrorOnConsole { get; set; } = true;

        internal string TargetPath_MethodInfo => $"{TargetMethod_MethodInfo?.DeclaringType?.FullName}.{TargetMethod_MethodInfo?.Name}";
        internal string TargetPath_base => $"{TargetMethod_MethodInfo?.DeclaringType?.FullName}.{TargetMethod_MethodBase.Name}";

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

                return patchtype.ToString();
            }
        }

        internal AstroPatch(MethodInfo TargetMethod, HarmonyMethod Prefix = null, HarmonyMethod PostFix = null, HarmonyMethod Transpiler = null, HarmonyMethod Finalizer = null, HarmonyMethod ILmanipulator = null, bool showErrorOnConsole = true)
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
                    ModConsole.Error($"[{PatchIdentifier}] TargetMethod is NULL");
                }
                else
                {
                    if (Bools.IsDeveloper)
                    {
                        ModConsole.Error($"[{PatchIdentifier}] Failed to Patch {TargetMethod.DeclaringType?.FullName}.{TargetMethod?.Name} because {FailureReason}.");
                    }
                    else
                    {
                        ModConsole.Error($"[{PatchIdentifier}] Failed to Patch {TargetMethod.Name}");
                    }
                }

                return;
            }

            this.TargetMethod_MethodInfo = TargetMethod;
            this.Prefix = Prefix;
            this.PostFix = PostFix;
            this.Transpiler = Transpiler;
            this.Finalizer = Finalizer;
            this.IlManipulator = ILmanipulator;
            ShowErrorOnConsole = showErrorOnConsole;
            Instance = new Harmony($"{PatchIdentifier}: {TargetPath_MethodInfo}, {PatchType}");
            DoPatch_info(this);
        }

        internal AstroPatch(MethodBase TargetMethod, HarmonyMethod Prefix = null, HarmonyMethod PostFix = null, HarmonyMethod Transpiler = null, HarmonyMethod Finalizer = null, HarmonyMethod ILmanipulator = null, bool showErrorOnConsole = true)
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
                    ModConsole.Error($"[{PatchIdentifier}] TargetMethod is NULL");
                }
                else
                {
                    if (Bools.IsDeveloper)
                    {
                        ModConsole.Error($"[{PatchIdentifier}] Failed to Patch {TargetMethod.DeclaringType?.FullName}.{TargetMethod?.Name} because {FailureReason}.");
                    }
                    else
                    {
                        ModConsole.Error($"[{PatchIdentifier}] Failed to Patch {TargetMethod.Name}");
                    }
                }

                return;
            }

            this.TargetMethod_MethodBase = TargetMethod;
            this.Prefix = Prefix;
            this.PostFix = PostFix;
            this.Transpiler = Transpiler;
            this.Finalizer = Finalizer;
            this.IlManipulator = ILmanipulator;
            ShowErrorOnConsole = showErrorOnConsole;
            this.Instance = new Harmony($"{PatchIdentifier}: {TargetPath_base}, {PatchType}");
            DoPatch_base(this);
        }

        private static void DoPatch_info(AstroPatch patch)
        {
            try
            {
                patch.Instance.Patch(patch.TargetMethod_MethodInfo, patch.Prefix, patch.PostFix, patch.Transpiler, patch.Finalizer, patch.IlManipulator);
            }
            catch (Exception e)
            {
                HasThrownException = true;
                if (ShowErrorOnConsole)
                {
                    ModConsole.ErrorExc(e);
                }
            }
            finally
            {
                if (!HasThrownException)
                {
                    if (Bools.IsDeveloper)
                    {
                        ModConsole.DebugLog($"[{patch.PatchIdentifier}] Patched {patch.TargetPath_MethodInfo} | with {patch.PatchType}");
                    }
                    else
                    {
                        ModConsole.DebugLog($"[{patch.PatchIdentifier}] Patched {patch.TargetMethod_MethodInfo?.Name}");
                    }
                }
                else
                {
                    if (Bools.IsDeveloper)
                    {
                        ModConsole.Error($"[{patch.PatchIdentifier}] Failed At {patch.TargetPath_MethodInfo} | with {patch.PatchType}");
                    }
                    else
                    {
                        ModConsole.Error($"[{patch.PatchIdentifier}] Failed At {patch.TargetMethod_MethodInfo?.Name}");
                    }
                }
            }
        }
        private static void DoPatch_base(AstroPatch patch)
        {
            try
            {
                patch.Instance.Patch(patch.TargetMethod_MethodBase, patch.Prefix, patch.PostFix, patch.Transpiler, patch.Finalizer, patch.IlManipulator);
            }
            catch (Exception e)
            {
                HasThrownException = true;
                if (ShowErrorOnConsole)
                {
                    ModConsole.ErrorExc(e);
                }
            }
            finally
            {
                if (!HasThrownException)
                {
                    if (Bools.IsDeveloper)
                    {
                        ModConsole.DebugLog($"[{patch.PatchIdentifier}] Patched {patch.TargetMethod_MethodBase} | with {patch.PatchType}");
                    }
                    else
                    {
                        ModConsole.DebugLog($"[{patch.PatchIdentifier}] Patched {patch.TargetMethod_MethodBase?.Name}");
                    }
                }
                else
                {
                    if (Bools.IsDeveloper)
                    {
                        ModConsole.Error($"[{patch.PatchIdentifier}] Failed At {patch.TargetMethod_MethodBase} | with {patch.PatchType}");
                    }
                    else
                    {
                        ModConsole.Error($"[{patch.PatchIdentifier}] Failed At {patch.TargetMethod_MethodBase?.Name}");
                    }
                }
            }
        }
    }
}