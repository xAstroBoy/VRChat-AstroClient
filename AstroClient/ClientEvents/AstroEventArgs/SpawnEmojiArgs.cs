namespace AstroClient.AstroEventArgs
{
    using System;

    internal class SpawnEmojiArgs : EventArgs
    {
        internal int Emoji;
        internal VRCPlayer player;

        internal SpawnEmojiArgs(VRCPlayer player, int emoji)
        {
            this.player = player;
            Emoji = emoji;
        }
    }
}