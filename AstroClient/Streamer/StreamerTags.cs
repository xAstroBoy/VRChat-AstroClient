using AstroClient.AstroMonos.Components.ESP;
using AstroClient.ClientActions;

namespace AstroClient.Streamer
{
    using System.Collections;
    using System.Drawing;
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
                MiscUtils.DelayFunction(10f, () =>
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
                    if (WorldIdentifier.IsAStreamer(apiuser.id))
                    {

                        player.AddSingleTag("Streamer", SystemColors.Orange);
                        switch (apiuser.id)
                        {
                            case Streamers.StarNovaKitty:
                                player.AddSingleTag("<rainb>A Sweet Kitty</rainb>", Color.FromArgb(155, 79, 232)); ;
                                break;
                            case Streamers.minikatttttt:
                                player.AddSingleTag("<wave>A Sensible Mini!</wave>", Color.FromArgb(13, 181, 164)); ;
                                break;
                            case Streamers.Cambly:
                                player.AddSingleTag("A Clumsy Birb", Color.FromArgb(96, 132, 240));
                                break;
                            case Streamers.CyberChimp:
                                ChangeColorESP(player,Color.FromArgb(255, 115, 0));
                                break;

                            case Streamers.Lolathon:
                                player.AddSingleTag("Clown & Prankster", Color.FromArgb(255, 115, 0));
                                ChangeColorESP(player, Color.FromArgb(255, 115, 0));
                                break;
                            case Streamers.PATTIIIIIIII:
                                player.AddSingleTag("Golden Toast Protector!", Color.FromArgb(255, 202, 66));
                                break;
                            case Streamers.Ratchet232:
                                player.AddSingleTag("<shake a=0.1>Mad Doggo!</shake>", Color.FromArgb(140, 35, 35));
                                break;
                            case Streamers.Thor_ChanVR:
                                player.AddSingleTag("VRChat God!", Color.FromArgb(194, 138, 17));
                                break;
                            case Streamers.Pud_Pud:
                                player.AddSingleTag("Sensible Squeaky panda!", Color.FromArgb(4, 138, 4));
                                break;
                            case Streamers.Ruqaa:
                                player.AddSingleTag("Wolf Girl!", Color.FromArgb(142, 13, 217));
                                break;
                            case Streamers.Nifty:
                                player.AddSingleTag("The Legendary Pan Bonker!", Color.FromArgb(166, 143, 12));
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

