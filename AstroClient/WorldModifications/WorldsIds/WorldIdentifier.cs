using System.Collections.Generic;
using AstroClient.ClientActions;

namespace AstroClient.WorldModifications.WorldsIds
{
    internal class WorldIdentifier : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnApplicationLateStart += OnApplicationLateStart;
            ClientEventActions.OnWorldReveal += OnWorldReveal;
        }

        internal static bool ShowWorldCheatActionMenu { get; private set; } = false;

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if(WorldIds.Count == 0) return;
            ShowWorldCheatActionMenu = WorldIds.Contains(id);
        }

        private void OnApplicationLateStart()
        {
            WorldIds structValue = new WorldIds();
            foreach (var field in typeof(WorldIds).GetFields())
            {
                WorldIds.Add(field.GetValue(structValue).ToString());
            }
        }

        private static List<string> WorldIds { get; } = new List<string>();

        internal static bool IsAStreamer(string UserID)
        {
            return WorldIds.Contains(UserID);
        }

    }
}