using AstroClient.ClientActions;

namespace AstroClient.Streamer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    using Tools.Extensions;
    using VRC;
    using xAstroBoy.Utility;

    internal class StreamerIdentifier : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnApplicationLateStart += OnApplicationLateStart;
        }

        private void OnApplicationLateStart()
        {
            Streamers structValue = new Streamers();
            foreach (var field in typeof(Streamers).GetFields())
            {
                StreamerIDs.Add(field.GetValue(structValue).ToString());
            }

            Log.Write($"Registered {StreamerIDs.Count()} Streamers.");
        }

        private static List<string> StreamerIDs { get; } = new List<string>();

        internal static bool IsAStreamer(string UserID)
        {
            return StreamerIDs.Contains(UserID);
        }

    }
}