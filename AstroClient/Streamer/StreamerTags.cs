namespace AstroClient.Streamer
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
                            player.AddSingleTag(new UnityEngine.Color(255, 192, 203), UnityEngine.Color.white, "A Sweet Kitty");
                            break;

                        case Streamers.Cambly:
                            player.AddSingleTag(UnityEngine.Color.blue, UnityEngine.Color.white, "A Clumsy Birb");
                            break;

                        case Streamers.Lolathon:
                            player.AddSingleTag(UnityEngine.Color.red, UnityEngine.Color.white, "Clown & Prankster");
                            break;
                        case Streamers.PATTIIIIIIII:
                            player.AddSingleTag(UnityEngine.Color.yellow, UnityEngine.Color.white, "Dont Touch mah Toast!");
                            break;
                        case Streamers.Ratchet232:
                            player.AddSingleTag(UnityEngine.Color.red, UnityEngine.Color.white, "Official Psycho And cutie!");
                            break;
                        case Streamers.Thor_ChanVR:
                            player.AddSingleTag(UnityEngine.Color.yellow, UnityEngine.Color.white, "Official VRChat goddess!");
                            break;
                        case Streamers.Pud_Pud:
                            player.AddSingleTag(UnityEngine.Color.cyan, UnityEngine.Color.white, "Sensible Squeaky panda and Cute!");
                            break;
                        case Streamers.Nifty:
                            player.AddSingleTag(UnityEngine.Color.green, UnityEngine.Color.white, "The Legendary FryPan Bonker! (Give Her Hugs tho)");
                            break;

                        default:
                            break;
                    }
                }
            }
        }

    }
}

