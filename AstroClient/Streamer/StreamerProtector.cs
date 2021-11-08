namespace AstroClient.Streamer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AstroClientCore.Events;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using CodeDebugTools;
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
            return StreamersInInstance != 0;
        }

        internal override void OnPlayerJoined(Player player)
        {
            CodeDebug.StopWatchDebug("StreamerProtector OnPlayerJoined", new Action(() =>
            {
                MiscUtils.DelayFunction(2f, new Action(() =>
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
                                StreamersInInstance++;
                            }
                        }
                    }


                }));

            }));
        }


        internal override void OnPlayerLeft(Player player)
        {


            CodeDebug.StopWatchDebug("StreamerProtector OnPlayerLeft", new Action(() =>
            {
                MiscUtils.DelayFunction(2f, new Action(() =>
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

                                StreamersInInstance--;
                            }
                        }
                    }
                }));
            }));
        }

        internal override void OnRoomLeft()
        {
            StreamersInInstance = 0;
        }

        internal static int StreamersInInstance;
    }
}