namespace AstroClient.AstroMonos.Components.UI.SingleTag
{
    using System.Collections.Generic;
    using UnhollowerBaseLib.Attributes;
    using VRC;

    internal class TagStacker
    {
        internal Player Player { get; set; }
        internal List<SingleTag> AssignedTags { get; set; } = new List<SingleTag>();

        internal TagStacker(Player Player)
        {
            this.Player = Player;
        }
    }
}