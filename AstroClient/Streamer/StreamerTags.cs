namespace AstroClient.Streamer
{
    using System.Drawing;
    using AstroMonos.Components.ESP.Player;
    using Constants;
    using Tools.Extensions;
    using VRC;
    using xAstroBoy.Utility;
    using SystemColors = Tools.Colors.SystemColors;

    internal class StreamerTags : AstroEvents
    {
        internal override void OnStreamerJoined(Player player)
        {
            if (!Bools.IsDeveloper)
            {
                return;
            }
            if (player != null)
            {
                var apiuser = player.GetAPIUser();
                if (apiuser != null)
                {
                    var userid = apiuser.id;
                    player.AddSingleTag(Color.FromArgb(117, 82, 32), "Streamer");
                    switch (userid)
                    {
                        case Streamers.StarNovaKitty:
                            player.AddSingleTag(Color.FromArgb(155, 79, 232), "A Sweet Kitty"); ;
                            break;
                        case Streamers.minikatttttt:
                            player.AddSingleTag(Color.FromArgb(13, 181, 164), "A Sensible Cutie!"); ;
                            break;
                        case Streamers.Cambly:
                            player.AddSingleTag(Color.FromArgb(96, 132, 240), "A Clumsy Cute Birb ");
                            break;
                        case Streamers.Lolathon:
                            player.AddSingleTag(Color.FromArgb(255, 115, 0), "Clown & Prankster");

                            if (player.GetAPIUser().isFriend) return;
                            if (player.GetAPIUser().HasBlockedYou()) return;
                            var esp = player.GetOrAddComponent<PlayerESP>();
                            if (esp != null)
                            {
                                MiscUtils.DelayFunction(0.5f, () =>
                                {
                                    esp.UseCustomColor = true;
                                    esp.ChangeColor(Color.FromArgb(255, 115, 0));
                                });
                            }
                            break;
                        case Streamers.PATTIIIIIIII:
                            player.AddSingleTag(Color.FromArgb(255, 202, 66), "Golden Toast Protector!");
                            break;
                        case Streamers.Ratchet232:
                            player.AddSingleTag(Color.FromArgb(84, 8, 8), "Psycho And cutie!");
                            break;
                        case Streamers.Thor_ChanVR:
                            player.AddSingleTag(Color.FromArgb(194, 138, 17), "VRChat God!");
                            break;
                        case Streamers.Pud_Pud:
                            player.AddSingleTag(Color.FromArgb(4, 138, 4), "Sensible Squeaky panda and Cute!");
                            break;
                        case Streamers.Ruqaa:
                            player.AddSingleTag(Color.FromArgb(142, 13, 217), "Cute Bunny!");
                            break;
                        case Streamers.Nifty:
                            player.AddSingleTag(Color.FromArgb(166, 143, 12), "The Legendary Pan Bonker! (Give Her Hugs tho)");
                            break;
                        default:
                            break;
                    }
                }
            }
        }

    }
}

