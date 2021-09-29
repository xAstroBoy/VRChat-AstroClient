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
    using Color = System.Drawing.Color;
    internal class StreamerTags : GameEvents
    {
        internal override void OnStreamerJoined(Player player)
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
                    player.AddSingleTag(SystemColors.LimeGreen, UnityEngine.Color.white, "Streamer");
                    switch (userid)
                    {
                        case Streamers.StarNovaKitty:
                            player.AddSingleTag(SystemColors.Pink, UnityEngine.Color.white, "A Sweet Kitty"); ;
                            break;

                        case Streamers.Cambly:
                            player.AddSingleTag(SystemColors.Turquoise, UnityEngine.Color.white, "A Clumsy Cute Birb ");
                            break;

                        case Streamers.Lolathon:
                            player.AddSingleTag(SystemColors.OrangeRed, UnityEngine.Color.white, "Clown & Prankster");
                            break;
                        case Streamers.PATTIIIIIIII:
                            player.AddSingleTag(SystemColors.Gold, UnityEngine.Color.white, "Golden Toast Protector!");
                            break;
                        case Streamers.Ratchet232:
                            player.AddSingleTag(SystemColors.Red, UnityEngine.Color.white, "Official Psycho And cutie!");
                            break;
                        case Streamers.Thor_ChanVR:
                            player.AddSingleTag(SystemColors.Gold, UnityEngine.Color.white, "Official VRChat goddess!");
                            break;
                        case Streamers.Pud_Pud:
                            player.AddSingleTag(SystemColors.ForestGreen, UnityEngine.Color.white, "Sensible Squeaky panda and Cute!");
                            break;
                        case Streamers.Ruqaa:
                            player.AddSingleTag(SystemColors.CornflowerBlue, UnityEngine.Color.white, "Cute Bunny!");
                            break;
                        case Streamers.Nifty:
                            player.AddSingleTag(SystemColors.MediumPurple, UnityEngine.Color.white, "The Legendary Pan Bonker! (Give Her Hugs tho)");
                            break;

                        default:
                            break;
                    }
                }
            }
        }

    }
}

