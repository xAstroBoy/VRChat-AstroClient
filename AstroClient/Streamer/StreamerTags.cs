namespace AstroClient.Streamer
{
    using System.Drawing;
    using Constants;
    using Tools.Extensions;
    using VRC;
    using xAstroBoy.Utility;
    using SystemColors = Tools.Colors.SystemColors;

    internal class StreamerTags : AstroEvents
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
                    player.AddSingleTag(Color.Lime,  "Streamer");
                    switch (userid)
                    {
                        case Streamers.StarNovaKitty:
                            player.AddSingleTag(Color.Pink,  "A Sweet Kitty"); ;
                            break;
                        case Streamers.minikatttttt:
                            player.AddSingleTag(Color.DeepSkyBlue, "A Sensible Cutie!"); ;
                            break;
                        case Streamers.Cambly:
                            player.AddSingleTag(Color.Turquoise,  "A Clumsy Cute Birb ");
                            break;
                        case Streamers.Lolathon:
                            player.AddSingleTag(Color.OrangeRed,  "Clown & Prankster");
                            break;
                        case Streamers.PATTIIIIIIII:
                            player.AddSingleTag(Color.Gold,  "Golden Toast Protector!");
                            break;
                        case Streamers.Ratchet232:
                            player.AddSingleTag(Color.Red,  "Official Psycho And cutie!");
                            break;
                        case Streamers.Thor_ChanVR:
                            player.AddSingleTag(Color.Gold,  "Official VRChat God!");
                            break;
                        case Streamers.Pud_Pud:
                            player.AddSingleTag(Color.ForestGreen,  "Sensible Squeaky panda and Cute!");
                            break;
                        case Streamers.Ruqaa:
                            player.AddSingleTag(Color.CornflowerBlue,  "Cute Bunny!");
                            break;
                        case Streamers.Nifty:
                            player.AddSingleTag(Color.Gold,  "The Legendary Pan Bonker! (Give Her Hugs tho)");
                            break;
                        default:
                            break;
                    }
                }
            }
        }

    }
}

