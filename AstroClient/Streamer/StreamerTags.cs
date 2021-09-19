﻿namespace AstroClient.Streamer
{
    using AstroClient.Variables;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using VRC;
    using Color = System.Drawing.Color;
    public class StreamerTags : GameEvents
    {
        public override void OnStreamerJoined(Player player)
        {
            if(!Bools.IsDeveloper)
            {
                return;
            }
            if (player != null)
            {
                var apiuser = player.GetAPIUser();
                if (apiuser != null)
                {
                    var userid = apiuser.id;
                    player.AddSingleTag(UnityEngine.Color.yellow, UnityEngine.Color.white, "Streamer");
                    switch (userid)
                    {
                        case Streamers.StarNovaKitty:
                            player.AddSingleTag(Color.Pink.ToUnityEngineColor(), UnityEngine.Color.white, "A Sweet Kitty"); ;
                            break;

                        case Streamers.Cambly:
                            player.AddSingleTag(Color.PaleTurquoise.ToUnityEngineColor(), UnityEngine.Color.white, "A Clumsy Birb");
                            break;

                        case Streamers.Lolathon:
                            player.AddSingleTag(Color.OrangeRed.ToUnityEngineColor(), UnityEngine.Color.white, "Clown & Prankster");
                            break;
                        case Streamers.PATTIIIIIIII:
                            player.AddSingleTag(Color.Gold.ToUnityEngineColor(), UnityEngine.Color.white, "Golden Toast Protector!");
                            break;
                        case Streamers.Ratchet232:
                            player.AddSingleTag(Color.Red.ToUnityEngineColor(), UnityEngine.Color.white, "Official Psycho And cutie!");
                            break;
                        case Streamers.Thor_ChanVR:
                            player.AddSingleTag(Color.LightGoldenrodYellow.ToUnityEngineColor(), UnityEngine.Color.white, "Official VRChat goddess!");
                            break;
                        case Streamers.Pud_Pud:
                            player.AddSingleTag(Color.ForestGreen.ToUnityEngineColor(), UnityEngine.Color.white, "Sensible Squeaky panda and Cute!");
                            break;
                        case Streamers.Nifty:
                            player.AddSingleTag(Color.Lavender.ToUnityEngineColor(), UnityEngine.Color.white, "The Legendary Pan Bonker! (Give Her Hugs tho)");
                            break;

                        default:
                            break;
                    }
                }
            }
        }

    }
}

