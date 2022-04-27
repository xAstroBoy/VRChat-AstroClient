using AstroClient.ClientActions;

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
        internal override void RegisterToEvents()
        {
            ClientEventActions.Event_OnRoomLeft += OnRoomLeft;
        }

        private void OnRoomLeft()
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

        internal static bool isDebugModeStack = false;

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