//using System.Threading.Tasks;

namespace AstroClient.ClientUI.LoadingScreen
{
    using System;
    using Assets;
    using AstroClient;
    using AstroClient.xAstroBoy.Utility;
    using AstroMonos.Components.Tools;
    using Mono.CSharp;
    using Prefabs;
    using Settings;
    using Tools.Extensions;
    using UnityEngine;
    using xAstroBoy;
    using xAstroBoy.UIPaths;
    using ConfigManager = Config.ConfigManager;
    using Object = UnityEngine.Object;

    internal class BetterLoadingScreen : AstroEvents
    {

        internal override void VRChat_OnUiManagerInit()
        {
            int step = 0;
            try
            {

                ModConsole.DebugLog("Creating new Loading Screen!");
                step = 1;
                LoadingScreenAssets.CurrentLoadingScreen = CreateGameObject(LoadScreenPrefabs.loadScreenPrefab, new Vector3(400, 400, 400), "UserInterface/MenuContent/Popups/", "LoadingPopup");
                step = 2;
                LoginScreenAssets.CurrentLoginScreen = CreateGameObject(LoadScreenPrefabs.loginPrefab, new Vector3(0.5f, 0.5f, 0.5f), "UserInterface/", "LoadingBackground_TealGradient_Music");
                // newCube = CreateGameObject(newCube, new Vector3(0.5f, 0.5f, 0.5f), "UserInterface/", "LoadingBackground_TealGradient_Music");

                ModConsole.DebugLog("Destroying original GameObjects");

                // Disable original objects from loading screen
                step = 3;
                if (VRChat_LoadingScreenObjects.VRChat_SkyCube != null)
                {
                    ModConsole.DebugLog("Destroying Default SkyCube");
                    VRChat_LoadingScreenObjects.VRChat_SkyCube.DestroyMeLocal(false);
                }
                else
                {
                    ModConsole.DebugError($"VRChat_SkyCube  is Null! Can't Destroy it");
                }

                step = 4;
                if (VRChat_LoadingScreenObjects.VRChat_bubbles != null)
                {
                    ModConsole.DebugLog("Destroying Bubbles");

                    VRChat_LoadingScreenObjects.VRChat_bubbles.DestroyMeLocal(false);
                }
                else
                {
                    ModConsole.DebugError($"VRChat_bubbles  is Null! Can't Destroy it");
                }
                step = 5;
                if (VRChat_LoadingScreenObjects.VRChat_originalLoadingAudio != null)
                {
                    ModConsole.DebugLog("Destroying Original Loading Audio");

                    VRChat_LoadingScreenObjects.VRChat_originalLoadingAudio.DestroyMeLocal(false);
                }
                else
                {
                    ModConsole.DebugError($"VRChat_originalLoadingAudio  is Null! Can't Destroy it");
                }

                step = 6;

                // Disable original objects from login screen
                if (VRChat_LoadingScreenObjects.VRChat_originalStartScreenAudio != null)
                {
                    ModConsole.DebugLog("Destroying Original Start Screen Audio");

                    VRChat_LoadingScreenObjects.VRChat_originalStartScreenAudio.DestroyMeLocal(false);
                }
                else
                {
                    ModConsole.DebugError($"VRChat_originalStartScreenAudio  is Null! Can't Destroy it");
                }

                step = 7;
                if (VRChat_LoadingScreenObjects.VRChat_originalStartScreenSkyCube != null)
                {
                    ModConsole.DebugLog("Destroying Original Start Screen Skycube");
                    VRChat_LoadingScreenObjects.VRChat_originalStartScreenSkyCube.DestroyMeLocal(false);

                }
                else
                {
                    ModConsole.DebugError($"VRChat_originalStartScreenSkyCube  is Null! Can't Destroy it");
                }

                step = 8;
                if (VRChat_LoadingScreenObjects.VRChat_loginBubbles != null)
                {
                    ModConsole.DebugLog("Destroying Login Bubbles");
                    VRChat_LoadingScreenObjects.VRChat_loginBubbles.DestroyMeLocal(false);
                }
                else
                {
                    ModConsole.DebugError($"VRChat_loginBubbles  is Null! Can't Destroy it");
                }

                step = 9;
                BetterLoadingScreenSettings.ModSounds = ConfigManager.LoadingScreen.ModSounds;
                step = 10;
                BetterLoadingScreenSettings.WarpTunnel = ConfigManager.LoadingScreen.WarpTunnel;
                step = 11;
                BetterLoadingScreenSettings.ShowLoadingMessages = ConfigManager.LoadingScreen.ShowLoadingMessages;
                step = 12;
                BetterLoadingScreenSettings.VRCLogo = ConfigManager.LoadingScreen.VrcLogo;
                step = 13;
                BetterLoadingScreenSettings.SecretMeme = ConfigManager.LoadingScreen.SecretMeme;
            }
            catch (Exception e)
            {
                ModConsole.DebugError($"Failed At step {step}");
                ModConsole.ErrorExc(e);
            }
        }

        private GameObject CreateGameObject(GameObject obj, Vector3 scale, string rootDest, string parent)
        {
            int step = 0;
            try
            {
                ModConsole.DebugLog("Creating " + obj.name);
                step = 1;
                var UIRoot = GameObjectFinder.Find(rootDest);
                if (UIRoot != null)
                {
                    ModConsole.DebugLog($"Found Root : {rootDest}");
                    step = 2;
                    var requestedParent = UIRoot.transform.Find(parent);
                    if (requestedParent != null)
                    {
                        step = 3;
                        ModConsole.DebugLog($"Found Parent :  {parent}");
                        var newObject = Object.Instantiate(obj, requestedParent, false).Cast<GameObject>();
                        if (newObject != null)
                        {
                            step = 4;
                            ModConsole.DebugLog($"Spawned Object!");
                            newObject.transform.parent = requestedParent;
                            newObject.transform.localScale = scale;
                            return newObject;
                        }
                    }
                    else
                    {
                        ModConsole.Error($"Failed to Find Parent : {parent}");
                    }
                }
                else
                {
                    ModConsole.Error($"Failed to Find Root : {rootDest}");
                }

            }
            catch (Exception e)
            {
                ModConsole.DebugError($"Failed At step {step}");
                ModConsole.ErrorExc(e);
            }
            return null;
        }
    }
}
