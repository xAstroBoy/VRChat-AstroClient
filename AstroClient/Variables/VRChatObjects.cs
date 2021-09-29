namespace AstroClient.Variables
{
    using AstroLibrary.Finder;
    using UnityEngine;

    internal class VRChatObjects_Old : GameEvents
    {
        internal override void VRChat_OnUiManagerInit()
        {
            _ = AvatarPreviewBase_FallbackAvatar;
            _ = _AvatarPreviewBase_MainAvatar;
        }

        internal override void OnLateUpdate()
        {
            if (ScreenFade != null)
            {
                if (ScreenFade.active)
                {
                    ScreenFade.SetActive(false);
                }
            }
        }

        private static GameObject _ScreenFade;

        internal static  GameObject ScreenFade
        {
            get
            {
                if (_ScreenFade == null)
                {
                    _ScreenFade = GameObjectFinder.Find("UserInterface/PlayerDisplay/BlackFade/inverted_sphere");
                }

                return _ScreenFade;
            }
        }

        private static Transform _AvatarPreviewBase_MainAvatar;

        internal static  Transform AvatarPreviewBase_MainAvatar
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

        internal static  Transform AvatarPreviewBase_FallbackAvatar
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
    }
}