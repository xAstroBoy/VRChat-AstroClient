using System;
using System.Collections;
using System.Collections.Generic;
using AstroClient.ClientActions;
using AstroClient.febucci;
using AstroClient.xAstroBoy;
using AstroClient.xAstroBoy.AstroButtonAPI.Tools;
using AstroClient.xAstroBoy.Utility;
using MelonLoader;
using TMPro;
using UnhollowerBaseLib.Attributes;
using UnityEngine;
using UnityEngine.XR;

using UserEventCarousel = MonoBehaviourPublicObusQu1VaObQu12StUnique;
using UserEventCell = MonoBehaviourPublicTMteCaSiImdiCoUnique;


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
                        if(carousel != null)
                        {
                            if(carousel.field_Private_List_1_MonoBehaviourPublicTMteCaSiImdiCoUnique_1.Count != 0)
                            {
                                return _ActiveCarousel = carousel;
                            }
                        }
                    }

                }
                return _ActiveCarousel;
            }
        }
        private static Transform _User_Event_Carousel { get; set; }

        internal static Transform User_Event_Carousel
        {
            get
            {
                if(_User_Event_Carousel == null)
                {
                    return _User_Event_Carousel = ActiveCarousel.transform;
                }
                return _User_Event_Carousel;
            }
        }



        //private void EnlargeCarousels(GameObject Carousel)
        //{
            
        //}

        internal  static void WriteHudMessage(string Text)
        {
            if(ActiveCarousel != null)
            {
                ActiveCarousel.Method_Private_Void_String_Sprite_0(Text, ClientResources.Loaders.Icons.planet_sprite);
            }
        }


    }
}