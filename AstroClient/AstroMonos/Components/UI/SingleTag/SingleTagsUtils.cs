namespace AstroClient.AstroMonos.Components.UI.SingleTag
{
    #region Imports

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
            Counter.Clear();
        }

        //internal override void OnPlayerLeft(Player player)
        //{
        //    var entry = GetEntry(player);
        //    if (entry != null)
        //    {
        //        RemoveCounter(entry);
        //    }
        //}

        internal static PlayerTagCounter GetEntry(Player player)
        {
            return Counter.Where(x => x.Player == player).DefaultIfEmpty(null).First();
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

        internal static List<PlayerTagCounter> GetAssignedTagsToPlayer(Player player)
        {
            List<PlayerTagCounter> AssignedTags = new List<PlayerTagCounter>();
            if (player != null)
            {
                foreach (var tag in Counter)
                {
                    if (tag != null && tag.Player != null)
                    {
                        if (tag.Player == player) AssignedTags.Add(tag);
                    }
                }
            }
            return AssignedTags;
        }

        internal static List<PlayerTagCounter> Counter = new List<PlayerTagCounter>();

        internal static void RemoveCounter(PlayerTagCounter entry)
        {
            if (entry != null)
            {
                if (Counter.Contains(entry)) _ = Counter.Remove(entry);
            }
        }

        internal class PlayerTagCounter
        {
            internal Player Player { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
            internal int AssignedStack { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

            internal PlayerTagCounter(Player user, int stack)
            {
                this.Player = user;
                AssignedStack = stack;
            }
        }
    }
}