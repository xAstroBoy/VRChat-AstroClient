namespace AstroClientCore.Events
{
    using Photon.Realtime;
    using System;

    internal class ScreenEventArgs : EventArgs
    {
        internal VRCUiPage page;

        internal ScreenEventArgs(VRCUiPage page)
        {
            this.page = page;
        }
    }
}