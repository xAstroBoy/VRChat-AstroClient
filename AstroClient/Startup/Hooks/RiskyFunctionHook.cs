namespace AstroClient.Startup.Hooks
{
    using System;
    using System.Reflection;
    using Cheetos;
    using Harmony;
    using Tools.Extensions;
    using System.Collections.Generic;
    using System.Net;

    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class RiskyFunctionHook : AstroEvents
    {

        private static string AllowedResponse { get; } = "https://raw.githubusercontent.com/xKiraiChan/xKiraiChan/master/allowed.txt";
        internal override void ExecutePriorityPatches()
        {
            new AstroPatch(typeof(WebRequest).GetMethod(nameof(WebRequest.CreateHttp), new Type[1] { typeof(Uri) }), GetPatch(nameof(CreateHTTPPatch)));
            new AstroPatch(typeof(WebClient).GetMethod(nameof(WebClient.DownloadString), new Type[1] { typeof(string) }), GetPatch(nameof(DownloadStringPatch)));
        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(RiskyFunctionHook).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        private static void DownloadStringPatch(ref string __0)
        {
            if (__0.ToLower().Contains("riskyfuncs"))
            {
                ModConsole.DebugWarning($"A Mod is Checking for Integrity Checks, Redirecting URL : {__0}, to : {AllowedResponse}");
                __0 = AllowedResponse;
            }
        }

        private static void CreateHTTPPatch(ref Uri __0)
        {
            if (__0.AbsoluteUri.ToLower().Contains("riskyfuncs"))
            {
                ModConsole.DebugWarning($"A Mod is Checking for Integrity Checks, Redirecting URL : {__0.AbsoluteUri}, to : {AllowedResponse}");
                __0 = new Uri(AllowedResponse);
            }
        }
        // TODO : Download emm trash and check what tags to remove out before world loads (To skip all the checks lmao)
        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            // Patch and remove certain tags.

        }

        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            if (UnityEngine.GameObject.Find("eVRCRiskFuncEnable") == null)
                ModConsole.DebugLog("Spawned EmmVRC Risky Function Enabler!");
            UnityEngine.Object.DontDestroyOnLoad(new UnityEngine.GameObject("eVRCRiskFuncEnable"));

            if (UnityEngine.GameObject.Find("UniversalRiskyFuncEnable") == null)
            {
                ModConsole.DebugLog("Spawned Universal Risky Function Enabler!");
                UnityEngine.Object.DontDestroyOnLoad(new UnityEngine.GameObject("UniversalRiskyFuncEnable"));
            }

            var EmmVRCDisabler = UnityEngine.GameObject.Find("eVRCRiskFuncDisable");
            if (EmmVRCDisabler != null)
            {
                ModConsole.DebugLog("Found eVRCRiskFuncDisable, Destroying!");
                EmmVRCDisabler.DestroyMeLocal();
            }
            var UniversalDisabler = UnityEngine.GameObject.Find("UniversalRiskyFuncDisable");
            if (UniversalDisabler != null)
            {
                ModConsole.DebugLog("Found UniversalRiskyFuncDisable, Destroying!");
                UniversalDisabler.DestroyMeLocal();
            }

        }
    }
}