namespace AstroClient.Variables
{
	using AstroClient.Variables;
	using AstroLibrary.Finder;
	using UnityEngine;
	using AstroLibrary.Extensions;
	using AstroClient.Components;
	public class VRChatObjects : GameEvents
    {

		public override void VRChat_OnUiManagerInit()
		{
			if(ScreenFade != null)
			{
				ScreenFade.GetOrAddComponent<TweakerListener>().OnEnabled += new System.Action(() => { ScreenFade.SetActive(false); });
			}
		}




		private static GameObject _ScreenFade;

        public static GameObject ScreenFade
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

		public static Transform AvatarPreviewBase_MainAvatar
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

		public static Transform AvatarPreviewBase_FallbackAvatar
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