using VRC;

namespace AstroClient.xAstroBoy.UIPaths
{
    using UnityEngine;

    internal class UserInterfaceObjects
    {


        private static Transform _VoiceDotDisabled;

        internal static Transform VoiceDotDisabled
        {
            get
            {
                if (_VoiceDotDisabled == null)
                {
                    _VoiceDotDisabled = GameObject.Find("UserInterface/UnscaledUI/HudContent_Old/Hud/VoiceDotParent/VoiceDotDisabled").transform;
                }

                return _VoiceDotDisabled;
            }
        }
        private static Transform _ScreenFade;

        internal static Transform ScreenFade
        {
            get
            {
                if (_ScreenFade == null)
                {
                    _ScreenFade = GameObjectFinder.Find("UserInterface/PlayerDisplay/BlackFade/inverted_sphere").transform;
                }

                return _ScreenFade;
            }
        }
        private static SimpleAvatarPedestal _MainAvatar_Pedestral;

        internal static SimpleAvatarPedestal MainAvatar_Pedestral
        {
            get
            {
                if (_MainAvatar_Pedestral == null)
                {
                    _MainAvatar_Pedestral = AvatarPreviewBase_MainAvatar.GetComponentInChildren<SimpleAvatarPedestal>(true);
                }

                return _MainAvatar_Pedestral;
            }
        }
        private static SimpleAvatarPedestal _FallbackAvatar_Pedestral;

        internal static SimpleAvatarPedestal FallbackAvatar_Pedestral
        {
            get
            {
                if (_FallbackAvatar_Pedestral == null)
                {
                    _FallbackAvatar_Pedestral = AvatarPreviewBase_FallbackAvatar.GetComponentInChildren<SimpleAvatarPedestal>(true);
                }

                return _FallbackAvatar_Pedestral;
            }
        }
        private static Transform _AvatarPreviewBase_MainAvatar;

        internal static Transform AvatarPreviewBase_MainAvatar
        {
            get
            {
                if (_AvatarPreviewBase_MainAvatar == null)
                {
                    _AvatarPreviewBase_MainAvatar = GameObjectFinder.Find("UserInterface/MenuContent/Screens/Avatar/AvatarPreviewBase/MainRoot").transform;
                }

                return _AvatarPreviewBase_MainAvatar;
            }
        }

        private static Transform _AvatarPreviewBase_FallbackAvatar;

        internal static Transform AvatarPreviewBase_FallbackAvatar
        {
            get
            {
                if (_AvatarPreviewBase_FallbackAvatar == null)
                {
                    _AvatarPreviewBase_FallbackAvatar = GameObjectFinder.Find("UserInterface/MenuContent/Screens/Avatar/AvatarPreviewBase/FallbackRoot").transform;
                }

                return _AvatarPreviewBase_FallbackAvatar;
            }
        }


        private static Transform _BigMenuElements;

        internal static Transform BigMenuElements
        {
            get
            {
                if (_BigMenuElements == null)
                {
                    return _BigMenuElements = GameObjectFinder.Find("UserInterface/MenuContent/Backdrop/Backdrop").transform;;
                }
                return _BigMenuElements;
            }
        }



    }
}