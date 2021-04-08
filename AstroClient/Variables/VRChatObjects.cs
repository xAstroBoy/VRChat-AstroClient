using AstroClient.Finder;
using AstroClient.variables;
using UnityEngine;

namespace AstroClient.Variables
{
    public class VRChatObjects : GameEvents
    {
        public override void OnUpdate()
        {
            if (Bools.DisableBlackScreenFade)
            {
                if (VRChatObjects.ScreenFade != null)
                {
                    if (VRChatObjects.ScreenFade.active)
                    {
                        VRChatObjects.ScreenFade.SetActive(false);
                    }
                }
            }
        }

        public static GameObject _ScreenFade;

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
    }
}