//using System.Threading.Tasks;

namespace AstroClient.ClientUI.LoadingScreen.Settings
{
    using Assets;
    using AstroMonos.Components.Tools;
    using xAstroBoy.UIPaths;
    using xAstroBoy.Utility;
    using ConfigManager = Config.ConfigManager;

    internal class BetterLoadingScreenSettings
    {
        internal static bool ModSounds
        {
            get
            {
                return ConfigManager.LoadingScreen.ModSounds;
            }
            set
            {
                ConfigManager.LoadingScreen.ModSounds = value;
                if (LoadingScreenAssets.LoadScreenMod_MenuMusic != null)
                {
                    LoadingScreenAssets.LoadScreenMod_MenuMusic.SetActive(value);
                }

                if (LoadingScreenAssets.LoadScreenMod_SpaceSound != null)
                {
                    LoadingScreenAssets.LoadScreenMod_SpaceSound.gameObject.SetActive(value);
                }

                if (VRChat_LoadingScreenObjects.VRChat_originalLoadingAudio != null)
                {
                    if (!value)
                    {
                        ModConsole.DebugLog("Activating Original Loading Audio");

                        VRChat_LoadingScreenObjects.VRChat_originalLoadingAudio.RemoveComponent<Disabler>();
                        VRChat_LoadingScreenObjects.VRChat_originalLoadingAudio.SetActive(true);
                    }
                    else
                    {
                        ModConsole.DebugLog("Disabling Original Loading Audio");
                        VRChat_LoadingScreenObjects.VRChat_originalLoadingAudio.GetOrAddComponent<Disabler>();
                        VRChat_LoadingScreenObjects.VRChat_originalLoadingAudio.SetActive(false);

                    }
                }
                else
                {
                    ModConsole.DebugError($"VRChat_originalLoadingAudio  is Null! Can't Toggle it");
                }
            }
        }

        internal static bool WarpTunnel
        {
            get
            {
                return ConfigManager.LoadingScreen.WarpTunnel;
            }
            set
            {
                ConfigManager.LoadingScreen.WarpTunnel = value;
                if (LoadingScreenAssets.LoadScreenMod_Tunnel != null)
                {
                    LoadingScreenAssets.LoadScreenMod_Tunnel.SetActive(value);
                }
            }
        }


        internal static bool ShowLoadingMessages
        {
            get
            {
                return ConfigManager.LoadingScreen.ShowLoadingMessages;
            }
            set
            {
                ConfigManager.LoadingScreen.ShowLoadingMessages = value;

                if (VRChat_LoadingScreenObjects.VRChat_InfoPanel != null)
                {
                    if (value)
                    {
                        ModConsole.DebugLog("Enabling Loading Screen InfoPanel ");

                        VRChat_LoadingScreenObjects.VRChat_InfoPanel.RemoveComponent<Disabler>();
                        VRChat_LoadingScreenObjects.VRChat_InfoPanel.SetActive(true);

                    }
                    else
                    {
                        ModConsole.DebugLog("Disabling Loading Screen InfoPanel ");

                        VRChat_LoadingScreenObjects.VRChat_InfoPanel.GetOrAddComponent<Disabler>();
                        VRChat_LoadingScreenObjects.VRChat_InfoPanel.SetActive(false);
                    }
                }
                else
                {
                    ModConsole.DebugError($"VRChat_InfoPanel  is Null! Can't Toggle it");
                }
            }
        }


        internal static bool VRCLogo
        {
            get
            {
                return ConfigManager.LoadingScreen.VrcLogo;
            }
            set
            {
                ConfigManager.LoadingScreen.VrcLogo = value;
                if (LoadingScreenAssets.LoadScreenMod_VRCLogo != null)
                {
                    LoadingScreenAssets.LoadScreenMod_VRCLogo.SetActive(value);
                }
            }
        }

        internal static bool SecretMeme
        {
            get
            {
                return ConfigManager.LoadingScreen.SecretMeme;
            }
            set
            {
                ConfigManager.LoadingScreen.SecretMeme = value;
                if (LoadingScreenAssets.LoadScreenMod_AprilFools != null)
                {
                    LoadingScreenAssets.LoadScreenMod_AprilFools.SetActive(value);
                }
                if (value)
                {
                    VRCLogo = false;
                }
                else
                {
                    VRCLogo = true;
                }
            }
        }

	}
}
