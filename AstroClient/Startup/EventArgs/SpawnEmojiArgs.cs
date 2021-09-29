namespace AstroClient
{
    using System;

    internal class SpawnEmojiArgs : EventArgs
    {
        public VRCPlayer player;

        public int Emoji;

        public SpawnEmojiArgs(VRCPlayer player, int emoji)
        {
            this.player = player;
            this.Emoji = emoji;
        }
    }
}