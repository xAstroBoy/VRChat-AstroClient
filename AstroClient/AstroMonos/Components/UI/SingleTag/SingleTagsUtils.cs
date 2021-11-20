namespace AstroClient.AstroMonos.Components.UI.SingleTag
{
    #region Imports

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnhollowerBaseLib.Attributes;
    using VRC;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;

    #endregion Imports

    internal class SingleTagsUtils : AstroEvents
    {
        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            TagStackingMechanism.Clear();
        }

        //internal override void OnPlayerLeft(Player player)
        //{
        //    var entry = GetEntry(player);
        //    if (entry != null)
        //    {
        //        RemoveCounter(entry);
        //    }
        //}

        internal static TagStacker GetEntry(Player player)
        {
            return TagStackingMechanism.Where(x => x.Player == player).DefaultIfEmpty(null).First();
        }

        private static readonly bool DebugMode = false;
        internal static void Debug(string msg)
        {
            if (DebugMode)
            {
                ModConsole.DebugLog($"SingleTagsUtils Debug : {msg}");
            }
        }
        // TODO : MERGE THIS IN THE STARTING PROCESS OF SINGLETAG AND MAKE IT EASIER AS .AddComponent<SINGLETAG>() instead of using this!

        internal static List<TagStacker> GetAssignedTagsToPlayer(Player player)
        {
            List<TagStacker> AssignedTags = new List<TagStacker>();
            if (player != null)
            {
                foreach (var tag in TagStackingMechanism)
                {
                    if (tag != null && tag.Player != null)
                    {
                        if (tag.Player == player) AssignedTags.Add(tag);
                    }
                }
            }
            return AssignedTags;
        }

        internal static List<TagStacker> TagStackingMechanism { get; } = new List<TagStacker>();

        internal static void RemoveCounter(TagStacker entry)
        {
            if (entry != null)
            {
                if (TagStackingMechanism.Contains(entry)) _ = TagStackingMechanism.Remove(entry);
            }
        }



    }
}