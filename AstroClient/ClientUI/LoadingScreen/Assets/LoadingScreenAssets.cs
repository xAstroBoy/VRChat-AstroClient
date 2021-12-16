namespace AstroClient.ClientUI.LoadingScreen.Assets
{
    using UnityEngine;
    using xAstroBoy;

    internal class LoadingScreenAssets
    {

        private static GameObject _CurrentLoadingScreen;

        internal static GameObject CurrentLoadingScreen
        {
            get
            {
                return _CurrentLoadingScreen;
            }
            set
            {
                _CurrentLoadingScreen = value;
                if (value != null)
                {
                    _LoadScreenMod_MenuMusic = null;
                    _LoadScreenMod_SpaceSound = null;
                    _LoadScreenMod_SkyCube = null;
                    _LoadScreenMod_Stars = null;
                    _LoadScreenMod_Tunnel = null;
                    _LoadScreenMod_VRCLogo = null;
                    _LoadScreenMod_AprilFools = null;
                }
            }
        }




        private static GameObject _LoadScreenMod_MenuMusic;
        internal static GameObject LoadScreenMod_MenuMusic
        {
            get
            {
                if (_LoadScreenMod_MenuMusic == null)
                {
                    return _LoadScreenMod_MenuMusic = CurrentLoadingScreen.transform.FindObject("MenuMusic").gameObject;
                }
                return _LoadScreenMod_MenuMusic;
            }
        }


        private static GameObject _LoadScreenMod_SpaceSound;
        internal static GameObject LoadScreenMod_SpaceSound
        {
            get
            {
                if (_LoadScreenMod_SpaceSound == null)
                {
                    return _LoadScreenMod_SpaceSound = CurrentLoadingScreen.transform.FindObject("SpaceSound").gameObject;
                }
                return _LoadScreenMod_SpaceSound;
            }
        }

        private static GameObject _LoadScreenMod_SkyCube;
        internal static GameObject LoadScreenMod_SkyCube
        {
            get
            {
                if (_LoadScreenMod_SkyCube == null)
                {
                    return _LoadScreenMod_SkyCube = CurrentLoadingScreen.transform.FindObject("SkyCube").gameObject;
                }
                return _LoadScreenMod_SkyCube;
            }
        }
        private static GameObject _LoadScreenMod_Stars;
        internal static GameObject LoadScreenMod_Stars
        {
            get
            {
                if (_LoadScreenMod_Stars == null)
                {
                    return _LoadScreenMod_Stars = CurrentLoadingScreen.transform.FindObject("Stars").gameObject;
                }
                return _LoadScreenMod_Stars;
            }
        }

        private static GameObject _LoadScreenMod_Tunnel;
        internal static GameObject LoadScreenMod_Tunnel
        {
            get
            {
                if (_LoadScreenMod_Tunnel == null)
                {
                    return _LoadScreenMod_Tunnel = CurrentLoadingScreen.transform.FindObject("Tunnel").gameObject;
                }
                return _LoadScreenMod_Tunnel;
            }
        }
        private static GameObject _LoadScreenMod_VRCLogo;
        internal static GameObject LoadScreenMod_VRCLogo
        {
            get
            {
                if (_LoadScreenMod_VRCLogo == null)
                {
                    return _LoadScreenMod_VRCLogo = CurrentLoadingScreen.transform.FindObject("VRCLogo").gameObject;
                }
                return _LoadScreenMod_VRCLogo;
            }
        }

        private static GameObject _LoadScreenMod_AprilFools;
        internal static GameObject LoadScreenMod_AprilFools
        {
            get
            {
                if (_LoadScreenMod_AprilFools == null)
                {
                    return _LoadScreenMod_AprilFools = CurrentLoadingScreen.transform.FindObject("meme").gameObject;
                }
                return _LoadScreenMod_AprilFools;
            }
        }


    }
}
