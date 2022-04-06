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

                Log.Debug("Creating new Loading Screen!");
                step = 1;
                LoadingScreenAssets.CurrentLoadingScreen = CreateGameObject(LoadScreenPrefabs.loadScreenPrefab, new Vector3(400, 400, 400), "UserInterface/MenuContent/Popups/", "LoadingPopup");
                step = 2;
                LoginScreenAssets.CurrentLoginScreen = CreateGameObject(LoadScreenPrefabs.loginPrefab, new Vector3(0.5f, 0.5f, 0.5f), "UserInterface/", "LoadingBackground_TealGradient_Music");
                // newCube = CreateGameObject(newCube, new Vector3(0.5f, 0.5f, 0.5f), "UserInterface/", "LoadingBackground_TealGradient_Music");

                Log.Debug("Disabling original GameObjects");

                // Disable original objects from loading screen
                step = 3;
                if (VRChat_LoadingScreenObjects.VRChat_SkyCube != null)
                {
                    Log.Debug("Disabling Default SkyCube");

                    VRChat_LoadingScreenObjects.VRChat_SkyCube.GetOrAddComponent<Disabler>();
                    VRChat_LoadingScreenObjects.VRChat_SkyCube.active = false;
                }
                else
                {
                    ModConsole.DebugError($"VRChat_SkyCube  is Null! Can't Toggle it");
                }

                step = 4;
                if (VRChat_LoadingScreenObjects.VRChat_bubbles != null)
                {
                    Log.Debug("Disabling Bubbles");

                    VRChat_LoadingScreenObjects.VRChat_bubbles.GetOrAddComponent<Disabler>();
                    VRChat_LoadingScreenObjects.VRChat_bubbles.active = false;
                }
                else
                {
                    ModConsole.DebugError($"VRChat_bubbles  is Null! Can't Toggle it");
                }
                step = 5;
                if (VRChat_LoadingScreenObjects.VRChat_originalLoadingAudio != null)
                {
                    Log.Debug("Disabling Original Loading Audio");

                    VRChat_LoadingScreenObjects.VRChat_originalLoadingAudio.GetOrAddComponent<Disabler>();
                    VRChat_LoadingScreenObjects.VRChat_originalLoadingAudio.active = false;
                }
                else
                {
                    ModConsole.DebugError($"VRChat_originalLoadingAudio  is Null! Can't Toggle it");
                }

                step = 6;

                // Disable original objects from login screen
                if (VRChat_LoadingScreenObjects.VRChat_originalStartScreenAudio != null)
                {
                    Log.Debug("Disabling Original Start Screen Audio");

                    VRChat_LoadingScreenObjects.VRChat_originalStartScreenAudio.GetOrAddComponent<Disabler>();
                    VRChat_LoadingScreenObjects.VRChat_originalStartScreenAudio.active = false;
                }
                else
                {
                    ModConsole.DebugError($"VRChat_originalStartScreenAudio  is Null! Can't Toggle it");
                }

                step = 7;
                if (VRChat_LoadingScreenObjects.VRChat_originalStartScreenSkyCube != null)
                {
                    Log.Debug("Disabling Original Start Screen Skycube");

                    VRChat_LoadingScreenObjects.VRChat_originalStartScreenSkyCube.GetOrAddComponent<Disabler>();
                    VRChat_LoadingScreenObjects.VRChat_originalStartScreenSkyCube.active = false;
                }
                else
                {
                    ModConsole.DebugError($"VRChat_originalStartScreenSkyCube  is Null! Can't Toggle it");
                }

                step = 8;
                if (VRChat_LoadingScreenObjects.VRChat_loginBubbles != null)
                {
                    Log.Debug("Disabling Login Bubbles");
                    VRChat_LoadingScreenObjects.VRChat_loginBubbles.GetOrAddComponent<Disabler>();
                    VRChat_LoadingScreenObjects.VRChat_loginBubbles.active = false;
                }
                else
                {
                    ModConsole.DebugError($"VRChat_loginBubbles  is Null! Can't Toggle it");
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
                Log.Debug("Creating " + obj.name);
                step = 1;
                var UIRoot = GameObjectFinder.Find(rootDest);
                if (UIRoot != null)
                {
                    Log.Debug($"Found Root : {rootDest}");
                    step = 2;
                    var requestedParent = UIRoot.transform.Find(parent);
                    if (requestedParent != null)
                    {
                        step = 3;
                        Log.Debug($"Found Parent :  {parent}");
                        var newObject = Object.Instantiate(obj, requestedParent, false).Cast<GameObject>();
                        if (newObject != null)
                        {
                            step = 4;
                            Log.Debug($"Spawned Object!");
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
