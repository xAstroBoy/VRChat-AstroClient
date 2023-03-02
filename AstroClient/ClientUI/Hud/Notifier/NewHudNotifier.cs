using AstroClient.xAstroBoy.AstroButtonAPI.Tools;
using System.Linq;
using UnityEngine;
using HudComponent = MonoBehaviourPublicObnoObmousCaObhuGaCaUnique;
using UserEventCarousel = MonoBehaviourPublicObusQu1VaObQu12StUnique;

namespace AstroClient.ClientUI.Hud.Notifier
{
    internal class NewHudNotifier : AstroEvents
    {
        private static UserEventCarousel _ActiveCarousel { get; set; }

        internal static UserEventCarousel ActiveCarousel
        {
            get
            {
                if (_ActiveCarousel == null)
                {
                    foreach (var carousel in Resources.FindObjectsOfTypeAll<UserEventCarousel>())
                    {
                        if (carousel != null)
                        {
                            if (carousel.field_Private_List_1_MonoBehaviourPublicTMteCaSiImdiCoUnique_1.Count != 0)
                            {
                                return _ActiveCarousel = carousel;
                            }
                        }
                    }
                }
                return _ActiveCarousel;
            }
        }

        private static HudComponent _instance;

        public static HudComponent Instance
        {
            get
            {
                if (_instance == null)
                {
                    var found = Resources.FindObjectsOfTypeAll<HudComponent>();
                    if (found != null && found.Any()) _instance = found.First();
                }
                return _instance;
            }
        }

        private static Transform _self;

        public static Transform HudMenu
        {
            get
            {
                if (_self == null)
                {
                    _self = Instance?.transform;
                }
                return _self;
            }
        }

        private static Transform _vrCanvas;

        public static Transform VRCanvas
        {
            get
            {
                if (_vrCanvas == null)
                {
                    _vrCanvas = HudMenu?.gameObject.FindUIObject("VR Canvas").transform;
                }
                return _vrCanvas;
            }
        }

        private static Transform _userEventCarousel;

        public static Transform UserEventCarousel
        {
            get
            {
                if (_userEventCarousel == null)
                {
                    _userEventCarousel = VRCanvas?.gameObject.FindUIObject("User Event Carousel").transform;
                }
                return _userEventCarousel;
            }
        }

        internal static void WriteHudMessage(string Text)
        {
            if (ActiveCarousel != null)
            {
                VRCanvas.gameObject.SetActive(true);
                ActiveCarousel.Method_Public_Void_String_Sprite_0(Text, ClientResources.Loaders.Icons.planet_sprite);
            }
        }
    }
}