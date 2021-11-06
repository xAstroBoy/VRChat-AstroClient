namespace AstroClientCore.Events
{
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