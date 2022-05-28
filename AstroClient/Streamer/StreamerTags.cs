using AstroClient.ClientActions;

namespace AstroClient.Streamer
{
    using System.Collections;
    using System.Drawing;
    using AstroMonos.Components.ESP.Player;
    using Constants;
    using MelonLoader;
    using Tools.Extensions;
    using VRC;
    using xAstroBoy.Utility;
    using SystemColors = Tools.Colors.SystemColors;

    internal class StreamerTags : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnPlayerJoin += OnPlayerJoined;
        }

        private void OnPlayerJoined(Player player)
        {
            MelonCoroutines.Start(AddTag(player));
        }

        private void ChangeColorESP(Player player, Color NewColor)
        {
            if (player == null) return;
            if (player.GetAPIUser().isFriend) return;
            if (player.GetAPIUser().HasBlockedYou()) return;
            var esp = player.GetComponent<PlayerESP>();
            if (esp != null)
            {
                MiscUtils.DelayFunction(3f, () =>
                {
                    esp.UseCustomColor = true;
                    esp.ChangeColor(NewColor);
                });
            }

        }

        private IEnumerator AddTag(Player player)
        {
            if (player != null)
            {
                var apiuser = player.GetAPIUser();
                if (apiuser != null)
                {
                    if (StreamerIdentifier.IsAStreamer(apiuser.id))
                    {

                        player.AddSingleTag(SystemColors.Orange, "Streamer");
                        switch (apiuser.id)
                        {
                            case Streamers.StarNovaKitty:
                                player.AddSingleTag(Color.FromArgb(155, 79, 232), "A Sweet Kitty"); ;
                                break;
                            case Streamers.minikatttttt:
                                player.AddSingleTag(Color.FromArgb(13, 181, 164), "A Sensible Mini!"); ;
                                break;
                            case Streamers.Cambly:
                                player.AddSingleTag(Color.FromArgb(96, 132, 240), "A Clumsy Birb");
                                break;
                            case Streamers.CyberChimp:
                                ChangeColorESP(player,Color.FromArgb(255, 115, 0));
                                break;

                            case Streamers.Lolathon:
                                player.AddSingleTag(Color.FromArgb(255, 115, 0), "Clown & Prankster");
                                ChangeColorESP(player, Color.FromArgb(255, 115, 0));
                                break;
                            case Streamers.PATTIIIIIIII:
                                player.AddSingleTag(Color.FromArgb(255, 202, 66), "Golden Toast Protector!");
                                break;
                            case Streamers.Ratchet232:
                                player.AddSingleTag(Color.FromArgb(140, 35, 35), "Mad Doggo!");
                                break;
                            case Streamers.Thor_ChanVR:
                                player.AddSingleTag(Color.FromArgb(194, 138, 17), "VRChat God!");
                                break;
                            case Streamers.Pud_Pud:
                                player.AddSingleTag(Color.FromArgb(4, 138, 4), "Sensible Squeaky panda!");
                                break;
                            case Streamers.Ruqaa:
                                player.AddSingleTag(Color.FromArgb(142, 13, 217), "Bnuuy!");
                                break;
                            case Streamers.Nifty:
                                player.AddSingleTag(Color.FromArgb(166, 143, 12), "The Legendary Pan Bonker!");
                                break;
                            default:
                                break;
                        }
                    }
                    yield return null;
                }
                yield return null;
            }
            yield return null;
        }
    }
}

