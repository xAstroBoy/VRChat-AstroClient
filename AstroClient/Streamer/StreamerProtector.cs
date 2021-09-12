namespace AstroClient.Cheetos
{
    using AstroClient.Variables;
    using AstroClientCore.Events;
    using AstroLibrary;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VRC;

    public class StreamerProtector : GameEvents
    {

        public static EventHandler<PlayerEventArgs> Event_OnStreamerJoined;

        public static EventHandler<PlayerEventArgs> Event_OnStreamerLeft;


        public static bool IsExploitsAllowed => IsAStreamerPresent();

        public static List<string> StreamerIDs { get; } = new List<string>()
        {
        "usr_c22cc758-27ce-40e6-94c9-a4e290b55de5", // StarNovaKitty
        "usr_03d6cba2-a1d7-45b8-b46e-419ccbc18dda", // Ruqa
        "usr_c2f3c043-f9d5-4907-b6fd-2d02bb79e863", // SoulunaMia
        "usr_b22748cd-de1c-4586-9bcc-33c51acc453d", // LondonLad
        "usr_2d8fdf16-6470-4322-9696-88df092bf2f8", // The Great Fish
        "usr_bf4846e6-e208-47cd-9837-a2ba3b98c688", // Lolathon
        "usr_da67e7e6-1398-4fb3-8fcd-c1378dfe55f3", // MimiQu
        "usr_03a485cc-1dde-41aa-aa17-29c9a06d5310", // Thor_ChanVR
        "usr_d7e5a8c7-9c39-4baa-80cc-137d6ef404d9", // Ratchet232
        "usr_3ff766cf-ddee-4fed-b321-aa3bdd2f9aa7", // Pud Pud
        "usr_f3c3cb44-9f1d-4bcd-8c1d-d361dfa160fa", // Nifty☆
        "usr_adf03ad7-5810-4d20-bf95-6320dcbb74ea", // Jryoko
        "usr_81fe2da1-e841-4a1e-a46d-cea447c1b413", // YouMe
        "usr_22b75801-bf0f-4464-b002-4b9b86252196", // PATTIIIIIIII
        "usr_7c9eb849-4f62-446f-980b-9e000a1b238e", // minikatttttt
        "usr_d4d6ea8a-8ad7-4d67-af81-d58a26449cca", // MrDummy_NL
        "usr_8a3eb8c4-5d4a-41cd-8489-ef23e319f711", // Naisiri Nao
        };


        public static bool IsAStreamerPresent()
        {
            return StreamersInInstance.Count() != 0;
        }


        public override void OnPlayerJoined(Player player)
        {
            if (player != null)
            {
                var apiuser = player.GetAPIUser();
                if (apiuser != null)
                {
                    var userid = apiuser.id;
                    if (StreamerIDs.Contains(userid))
                    {
                        Event_OnStreamerLeft.SafetyRaise(new PlayerEventArgs(player));
                        if (!StreamersInInstance.Contains(player))
                        {
                            StreamersInInstance.Add(player);
                            if (Bools.IsDeveloper)
                            {
                                CheetosHelpers.SendHudNotification($"Streamer : {apiuser.displayName} Joined!");
                                ModConsole.Warning($"Streamer : {apiuser.displayName} Joined!");
                                var tag = player.AddSingleTag();
                                if (tag != null)
                                {
                                    tag.Tag_Color = UnityEngine.Color.yellow;
                                    tag.Label_TextColor = UnityEngine.Color.white;
                                    tag.Label_Text = "Streamer";
                                }
                                if (userid == "usr_c22cc758-27ce-40e6-94c9-a4e290b55de5")
                                {
                                    var KittyTag = player.AddSingleTag();
                                    if(KittyTag != null)
                                    {
                                        KittyTag.Tag_Color = new UnityEngine.Color(255, 192, 203);
                                        KittyTag.Label_TextColor = UnityEngine.Color.white;
                                        KittyTag.Label_Text = "A Sweet Kitty";
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public override void OnPlayerLeft(Player player)
        {
            if (player != null)
            {
                var apiuser = player.GetAPIUser();
                if (apiuser != null)
                {
                    var userid = apiuser.id;
                    if (StreamerIDs.Contains(userid))
                    {
                        Event_OnStreamerLeft.SafetyRaise(new PlayerEventArgs(player));

                        if (StreamersInInstance.Contains(player))
                        {
                            StreamersInInstance.Remove(player);
                            if (Bools.IsDeveloper)
                            {
                                CheetosHelpers.SendHudNotification($"Streamer : {apiuser.displayName} Left!");
                                ModConsole.Warning($"Streamer : {apiuser.displayName} Left!");
                            }
                        }
                    }
                }
            }
        }


        public override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            StreamersInInstance.Clear();
        }



        public static List<Player> StreamersInInstance { get; private set; } = new List<Player>();
    }
}