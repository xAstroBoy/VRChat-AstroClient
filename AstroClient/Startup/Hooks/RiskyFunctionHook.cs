using AstroClient.ClientActions;
using UnityEngine.Networking;

namespace AstroClient.Startup.Hooks
{
    using System;
    using System.Reflection;
    using Cheetos;
    using HarmonyLib;
    using Tools.Extensions;
    using System.Collections.Generic;
    using System.Net;
    using VRC.Core;
    using xAstroBoy.Utility;

    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class RiskyFunctionHook : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnRoomLeft += OnRoomLeft;
            ClientEventActions.OnSceneLoaded += OnSceneLoaded;
        }

        internal static bool IsWorldTagPatched { get; private set; } = false;
        internal static List<string> OriginalWorldTags { get; private set; } = new List<string>();

        private static string AllowedResponse { get; } = "https://raw.githubusercontent.com/xKiraiChan/xKiraiChan/master/allowed.txt";
        internal override void ExecutePriorityPatches()
        {
            new AstroPatch(typeof(WebRequest).GetMethod(nameof(WebRequest.CreateHttp), new Type[1] { typeof(Uri) }), GetPatch(nameof(CreateHTTPPatch_Uri)));
            new AstroPatch(typeof(WebRequest).GetMethod(nameof(WebRequest.CreateHttp), new Type[1] { typeof(string) }), GetPatch(nameof(CreateHTTPPatch_String)));

            new AstroPatch(typeof(WebClient).GetMethod(nameof(WebClient.DownloadString), new Type[1] { typeof(string) }), GetPatch(nameof(DownloadStringPatch)));
            MiscUtils.DelayFunction(10f, () =>
            {
                new AstroPatch(typeof(UnityWebRequest).GetMethod(nameof(UnityWebRequest.Get), new Type[1] { typeof(string) }), GetPatch(nameof(DownloadStringPatch)));
                new AstroPatch(typeof(UnityWebRequest).GetMethod(nameof(UnityWebRequest.Get), new Type[1] { typeof(Uri) }), GetPatch(nameof(CreateHTTPPatch_Uri)));
            });
            new AstroPatch(typeof(RoomManager).GetMethod(nameof(RoomManager.Method_Public_Static_Boolean_ApiWorld_ApiWorldInstance_String_Int32_0)), GetPatch(nameof(ApiWorldTagPatch)));

        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(RiskyFunctionHook).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        private void OnRoomLeft()
        {
            IsWorldTagPatched = false;
            OriginalWorldTags.Clear();
        }

        private static void DownloadStringPatch(ref string __0)
        {
            if (__0.ToLower().Contains("riskyfuncs"))
            {
                Log.Warn($"A Mod is Checking for Risky Function Checks, Redirecting URL : {__0}, to : {AllowedResponse}");
                __0 = AllowedResponse;
            }
        }

        private static void CreateHTTPPatch_Uri(ref Uri __0)
        {
            if (__0.AbsoluteUri.ToLower().Contains("riskyfuncs"))
            {
                Log.Warn($"A Mod is Checking for Risky Function Checks, Redirecting URL : {__0.AbsoluteUri}, to : {AllowedResponse}");
                __0 = new Uri(AllowedResponse);
            }
        }
        private static void CreateHTTPPatch_String(ref string __0)
        {
            if (__0.ToLower().Contains("riskyfuncs"))
            {
                Log.Warn($"A Mod is Checking for Risky Function Checks, Redirecting URL : {__0}, to : {AllowedResponse}");
                __0 = AllowedResponse;
            }
        }
        private static void ApiWorldTagPatch(ref ApiWorld __0)
        {
            if (__0 != null)
            {
                if (__0.tags != null)
                {
                    if (__0.tags.Count != 0)
                    {
                        var newTags = new Il2CppSystem.Collections.Generic.List<string>();
                        foreach (string text in __0.tags)
                        {
                            bool ignore = false;
                            if (text.ToLower().Contains("game") || text.ToLower().Contains("club"))
                            {
                                if (!IsWorldTagPatched)
                                {
                                    IsWorldTagPatched = true;
                                }
                                Log.Debug($"Removed Tag : {text} in ApiWorld to bypass RiskyFunction Detection");
                                ignore = true;
                            }
                            if(!ignore)
                            {
                                newTags.System_Collections_IList_Add(text);
                            }
                            OriginalWorldTags.Add(text);
                        }
                        if(IsWorldTagPatched)
                        {
                            __0.tags = newTags;
                        }

                    }
                }
            }

        }
        private void OnSceneLoaded(int buildIndex, string sceneName)
        {
            if (UnityEngine.GameObject.Find("eVRCRiskFuncEnable") == null)
                UnityEngine.Object.DontDestroyOnLoad(new UnityEngine.GameObject("eVRCRiskFuncEnable"));

            if (UnityEngine.GameObject.Find("UniversalRiskyFuncEnable") == null)
                UnityEngine.Object.DontDestroyOnLoad(new UnityEngine.GameObject("UniversalRiskyFuncEnable"));

            UnityEngine.GameObject disabler;
            if ((disabler = UnityEngine.GameObject.Find("eVRCRiskFuncDisable")) != null)
                UnityEngine.Object.Destroy(disabler);

            if ((disabler = UnityEngine.GameObject.Find("UniversalRiskyFuncDisable")) != null)
                UnityEngine.Object.Destroy(disabler);


        }
    }
}