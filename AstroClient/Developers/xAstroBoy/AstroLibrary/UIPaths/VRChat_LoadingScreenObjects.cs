namespace AstroClient.xAstroBoy.UIPaths
{
    using AstroButtonAPI.Tools;
    using UnityEngine;
    using xAstroBoy;

    internal class VRChat_LoadingScreenObjects
    {

        private static GameObject _VRChat_UIRoot;
        internal static GameObject VRChat_UIRoot
        {
            get
            {
                if (_VRChat_UIRoot == null)
                {
                    return _VRChat_UIRoot = GameObjectFinder.Find("UserInterface/MenuContent/Popups/LoadingPopup");
                }
                return _VRChat_UIRoot;
            }
        }

        private static GameObject _VRChat_SkyCube;
        internal static GameObject VRChat_SkyCube
        {
            get
            {
                if (VRChat_UIRoot == null) return null;
                if (_VRChat_SkyCube == null)
                {
                    return _VRChat_SkyCube = VRChat_UIRoot.transform.FindObject("3DElements/LoadingBackground_TealGradient/SkyCube_Baked").gameObject;
                }
                return _VRChat_SkyCube;
            }
        }

        private static GameObject _VRChat_bubbles;
        internal static GameObject VRChat_bubbles
        {
            get
            {
                if (VRChat_UIRoot == null) return null;

                if (_VRChat_bubbles == null)
                {
                    return _VRChat_bubbles = VRChat_UIRoot.transform.FindObject("3DElements/LoadingBackground_TealGradient/_FX_ParticleBubbles").gameObject;
                }
                return _VRChat_bubbles;
            }
        }

        private static GameObject _VRChat_loginBubbles;
        internal static GameObject VRChat_loginBubbles
        {
            get
            {
                if (_VRChat_loginBubbles == null)
                {
                    return _VRChat_loginBubbles = GameObjectFinder.Find("UserInterface/LoadingBackground_TealGradient_Music/_FX_ParticleBubbles");
                }
                return _VRChat_loginBubbles;
            }
        }

        private static GameObject _VRChat_StartScreen;
        internal static GameObject VRChat_StartScreen
        {
            get
            {
                if (_VRChat_StartScreen == null)
                {
                    return _VRChat_StartScreen = GameObjectFinder.Find("UserInterface/LoadingBackground_TealGradient_Music");
                }
                return _VRChat_StartScreen;
            }
        }

        private static GameObject _VRChat_originalStartScreenAudio;
        internal static GameObject VRChat_originalStartScreenAudio
        {
            get
            {
                if (_VRChat_originalStartScreenAudio == null)
                {
                    return _VRChat_originalStartScreenAudio = GameObjectFinder.Find("UserInterface/LoadingBackground_TealGradient_Music/LoadingSound");
                }
                return _VRChat_originalStartScreenAudio;
            }
        }

        private static GameObject _VRChat_originalStartScreenSkyCube;
        internal static GameObject VRChat_originalStartScreenSkyCube
        {
            get
            {
                if (_VRChat_originalStartScreenSkyCube == null)
                {
                    return _VRChat_originalStartScreenSkyCube = GameObjectFinder.Find("UserInterface/LoadingBackground_TealGradient_Music/SkyCube_Baked");
                }
                return _VRChat_originalStartScreenSkyCube;
            }
        }

        private static GameObject _VRChat_LoadingBackground;
        internal static GameObject VRChat_LoadingBackground
        {
            get
            {
                if (VRChat_UIRoot == null) return null;

                if (_VRChat_LoadingBackground == null)
                {
                    return _VRChat_LoadingBackground = VRChat_UIRoot.transform.FindObject("LoadingBackground(Clone)").gameObject;
                }
                return _VRChat_LoadingBackground;
            }
        }
        private static GameObject _VRChat_InfoPanel;
        internal static GameObject VRChat_InfoPanel
        {
            get
            {
                if (VRChat_UIRoot == null) return null;

                if (_VRChat_InfoPanel == null)
                {
                    return _VRChat_InfoPanel = VRChat_UIRoot.transform.FindObject("3DElements/LoadingInfoPanel").gameObject;
                }
                return _VRChat_InfoPanel;
            }
        }

        private static GameObject _VRChat_originalLoadingAudio;
        internal static GameObject VRChat_originalLoadingAudio
        {
            get
            {
                if (VRChat_UIRoot == null) return null;

                if (_VRChat_originalLoadingAudio == null)
                {
                    return _VRChat_originalLoadingAudio = VRChat_UIRoot.transform.FindObject("LoadingSound").gameObject;
                }
                return _VRChat_originalLoadingAudio;
            }
        }

    }
}
