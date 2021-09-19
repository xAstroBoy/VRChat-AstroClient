namespace AstroClient.Streamer
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
    using System.Reflection;
    using VRC;

    public class StreamerProtector : GameEvents
    {


        public override void OnApplicationLateStart()
        {
            Streamers structValue = new Streamers();
            foreach (var field in typeof(Streamers).GetFields())
            {
                StreamerIDs.Add(field.GetValue(structValue).ToString());
            }
            ModConsole.Log($"Registered {StreamerIDs.Count()} Streamers.");
        }

        public static EventHandler<PlayerEventArgs> Event_OnStreamerJoined;

        public static EventHandler<PlayerEventArgs> Event_OnStreamerLeft;

        public static bool IsExploitsAllowed => IsAStreamerPresent();

        private static List<string> StreamerIDs { get; } = new List<string>(); 


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
                        Event_OnStreamerJoined.SafetyRaise(new PlayerEventArgs(player));
                        if (!StreamersInInstance.Contains(player))
                        {
                            StreamersInInstance.Add(player);
                            if (Bools.IsDeveloper)
                            {
                                CheetosHelpers.SendHudNotification($"Streamer : {apiuser.displayName} Joined!");
                                ModConsole.Warning($"Streamer : {apiuser.displayName} Joined!");



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