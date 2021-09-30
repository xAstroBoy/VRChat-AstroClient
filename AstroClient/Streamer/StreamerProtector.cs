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

    internal class StreamerProtector : GameEvents
    {


        internal override void OnApplicationLateStart()
        {
            Streamers structValue = new Streamers();
            foreach (var field in typeof(Streamers).GetFields())
            {
                StreamerIDs.Add(field.GetValue(structValue).ToString());
            }
            ModConsole.Log($"Registered {StreamerIDs.Count()} Streamers.");
        }

        internal static EventHandler<PlayerEventArgs> Event_OnStreamerJoined;

        internal static EventHandler<PlayerEventArgs> Event_OnStreamerLeft;

        internal static bool IsExploitsAllowed => IsAStreamerPresent();

        private static List<string> StreamerIDs { get; } = new List<string>(); 


        internal static bool IsAStreamerPresent()
        {
            return StreamersInInstance.Count() != 0;
        }

        internal override void OnPlayerJoined(Player player)
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
                        }
                    }
                }
            }
        }

        internal override void OnPlayerLeft(Player player)
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
                        }
                    }
                }
            }
        }

        internal override void OnRoomLeft()
        {
            StreamersInInstance.Clear();
        }

        internal static List<Player> StreamersInInstance { get; private set; } = new List<Player>();
    }
}