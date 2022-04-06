namespace AstroClient.Startup.Patches
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Reflection;
    using HarmonyLib;
    using HarmonyLib.Public.Patching;
    using MelonLoader;

    internal class UnchainedMelonLoader : AstroEvents
    {

        private static bool IsfirstScene { get; set; }
        internal static bool AreProtectionsArmed = true;

        private static BindingFlags CurrentFlags { get; } = BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance;

        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            KillVRCMGProtections();
        }

        private void KillVRCMGProtections()
        {
            if (AreProtectionsArmed)
            {
                if (CoreHarmonyInstanceObject == null)
                {
                    var Assembly = typeof(PatchShield).Assembly;
                    if (Assembly != null)
                    {
                        Log.Debug($"Found PatchShield Assembly {Assembly.FullName}");
                        // Let's target ML Core

                        foreach (var type in Assembly.GetTypes())
                        {
                            if (type.FullName == "MelonLoader.Core")
                            {
                                Log.Debug("Found MelonLoader Core!", Color.Green);
                                foreach (var field in type.GetFields(CurrentFlags))
                                {
                                    Log.Debug($"Found Field : {field.Name}");
                                    if (field.Name == "HarmonyInstance")
                                    {
                                        Log.Debug("Found MelonLoader Core HarmonyInstance!");
                                        CoreHarmonyInstanceObject = field.GetValue(null);
                                    }
                                }
                            }

                            if (type.FullName == "HarmonyLib.PatchFunctions")
                            {
                                HarmonyLib_PatchFunctionsType = type;
                            }
                            if (type.FullName == "HarmonyLib.Public.Patching.PatchManager")
                            {
                                PatchManagerType = type;
                            }

                        }
                    }
                }

                if (CoreHarmonyInstanceObject != null)
                {
                    if (MelonLoaderCoreInstance == null)
                    {
                        MelonLoaderCoreInstance = CoreHarmonyInstanceObject as Harmony;
                    }
                }

                if (MelonLoaderCoreInstance != null)
                {
                    Log.Debug("We Got Access to ML Core HarmonyInstance");
                    FuckOffVRCMGShit(MelonLoaderCoreInstance);
                    AreProtectionsArmed = false;
                    Log.Debug("PatchShield should be removed now!");
                }
                DumpMelonHarmonyPatches(MelonLoaderCoreInstance);

            }

        }

        private static Object CoreHarmonyInstanceObject { get; set; }
        private static Type HarmonyLib_PatchFunctionsType { get; set; }
        private static Type PatchManagerType { get; set; }
        private static Harmony MelonLoaderCoreInstance { get; set; }



        internal void FuckOffVRCMGShit(Harmony instance)
        {
            int KnahBonks = 0;
            int RinLovesYouBonks = 0;
            foreach (MethodBase methodBase in instance.GetPatchedMethods().ToList<MethodBase>())
            {
                Patches info = PatchProcessor.GetPatchInfo(methodBase);
                PatchProcessor patchProcessor = new PatchProcessor(null, methodBase);
                if (methodBase.HasMethodBody())
                {
                    info.Postfixes.DoIf((Patch _) => true, delegate (Patch patchInfo)
                    {
                        if (patchInfo.PatchMethod.FullDescription().Contains("MelonLoader.PatchShield"))
                        {
                            KnahBonks++;

                            Log.Debug($"Bonking Knah For his PatchShield x{KnahBonks}", Color.Gold);
                            //Log.Debug($"Removing Patchshield Method : {GetOriginalMethodBase(patchProcessor).FullDescription()}, with {patchInfo.PatchMethod.FullDescription()}");
                            ForceUnpatch(patchProcessor, patchInfo.PatchMethod);
                        }
                        if (patchInfo.PatchMethod.FullDescription().Contains("MelonLoader.Utils.AssemblyVerifier"))
                        {
                            RinLovesYouBonks++;
                            //Log.Debug($"Removing AssemblyVerifier Method : {GetOriginalMethodBase(patchProcessor).FullDescription()}, with {patchInfo.PatchMethod.FullDescription()}");
                            Log.Debug($"Bonking RinLovesYou For his AssemblyVerifier x{RinLovesYouBonks}", Color.Gold);
                            ForceUnpatch(patchProcessor, patchInfo.PatchMethod);
                        }

                    });
                    info.Prefixes.DoIf((Patch _) => true, delegate (Patch patchInfo)
                    {
                        if (patchInfo.PatchMethod.FullDescription().Contains("MelonLoader.PatchShield"))
                        {
                            KnahBonks++;

                            Log.Debug($"Bonking Knah For his PatchShield x{KnahBonks}", Color.Gold);

                            //Log.Debug($"Removing Patchshield Method : {GetOriginalMethodBase(patchProcessor).FullDescription()}, with {patchInfo.PatchMethod.FullDescription()}");
                            ForceUnpatch(patchProcessor, patchInfo.PatchMethod);
                        }
                        if (patchInfo.PatchMethod.FullDescription().Contains("MelonLoader.Utils.AssemblyVerifier"))
                        {
                            RinLovesYouBonks++;
                            //Log.Debug($"Removing AssemblyVerifier Method : {GetOriginalMethodBase(patchProcessor).FullDescription()}, with {patchInfo.PatchMethod.FullDescription()}");
                            Log.Debug($"Bonking RinLovesYou For his AssemblyVerifier x{RinLovesYouBonks}", Color.Gold);
                            ForceUnpatch(patchProcessor, patchInfo.PatchMethod);
                        }

                    });
                }
            }

        }

        internal MethodBase GetOriginalMethodBase(PatchProcessor processor)
        {
            if (processor != null)
            {
                var methodobj = typeof(PatchProcessor).GetField("original", CurrentFlags).GetValue(processor);
                if (methodobj != null)
                {
                    return methodobj as MethodBase; // Fuck them lol 
                }

            }

            return null;
        }




        private MethodInfo Execute_PatchFunction_UpdateWrapper(MethodBase original, PatchInfo patchInfo)
        {
            if (HarmonyLib_PatchFunctionsType != null)
            {
                MethodInfo methodInfo = HarmonyLib_PatchFunctionsType.GetMethod("UpdateWrapper", CurrentFlags);
                var result = methodInfo.Invoke(null, new object[] { original, patchInfo });
                return result as MethodInfo;
            }

            return null;
        }

        private void Execute_PatchManager_AddReplacementOriginal(MethodBase original, MethodInfo replacement)
        {
            if (PatchManagerType != null)
            {
                MethodInfo methodInfo = PatchManagerType.GetMethod("AddReplacementOriginal", CurrentFlags);
                methodInfo.Invoke(null, new object[] {original, replacement});
            }
        }


        internal void ForceUnpatch(PatchProcessor processor, MethodInfo patch)
        {
            var originalMethod = GetOriginalMethodBase(processor);
            if (originalMethod != null)
            {
                PatchInfo patchInfo = originalMethod.ToPatchInfo();
                patchInfo.RemovePatch(patch);
                MethodInfo replacement = Execute_PatchFunction_UpdateWrapper(originalMethod, patchInfo);
                Execute_PatchManager_AddReplacementOriginal(originalMethod, replacement);
            }
        }


        internal void DumpMelonHarmonyPatches(Harmony instance)
        {
            foreach (MethodBase methodBase in instance.GetPatchedMethods().ToList<MethodBase>())
            {
                Patches info = PatchProcessor.GetPatchInfo(methodBase);
                PatchProcessor patchProcessor = new PatchProcessor(null, methodBase);
                if (methodBase.HasMethodBody())
                {
                    info.Postfixes.DoIf((Patch _) => true, delegate (Patch patchInfo)
                    {
                        Log.Debug($"Found a PostFix Patch patching : {GetOriginalMethodBase(patchProcessor).FullDescription()}, with {patchInfo.PatchMethod.FullDescription()}");
                    });
                    info.Prefixes.DoIf((Patch _) => true, delegate (Patch patchInfo)
                    {
                        Log.Debug($"Found a Prefix Patch patching : {GetOriginalMethodBase(patchProcessor).FullDescription()}, with {patchInfo.PatchMethod.FullDescription()}");
                    });
                }
            }

        }


    }
}
