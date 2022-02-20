namespace AstroClient.AstroEventArgs
{
    using System;
    using VRC;

    internal class OnRawAudioEventArgs : EventArgs
    {
        internal VRCPlayer player;
        internal float[] RawAudio;
        internal int sample_rate;

        internal OnRawAudioEventArgs(VRCPlayer player, float[] RawAudio, int sample_rate)
        {
            this.player = player;
            this.RawAudio = RawAudio;
            this.sample_rate = sample_rate;
        }
    }
}