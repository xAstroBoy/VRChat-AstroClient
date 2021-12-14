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
                    _VoiceDotDisabled = GameObject.Find("UserInterface/UnscaledUI/HudContent/Hud/VoiceDotParent/VoiceDotDisabled").transform;
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

        private static Transform _QuickMenuElements;

        internal static Transform QuickMenuElements
        {
            get
            {
                if (_QuickMenuElements == null)
                {
                    return _QuickMenuElements = GameObjectFinder.Find("UserInterface/QuickMenu/QuickMenu_NewElements").transform;
                }
                return _QuickMenuElements;
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