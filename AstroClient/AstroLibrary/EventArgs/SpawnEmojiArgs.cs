namespace AstroClient
{
    using System;

    internal class SpawnEmojiArgs : EventArgs
    {
        internal VRCPlayer player;

        internal int Emoji;

        internal SpawnEmojiArgs(VRCPlayer player, int emoji)
        {
            this.player = player;
            this.Emoji = emoji;
        }
    }
}