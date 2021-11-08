namespace AstroClientCore.Events
{
    using System;
    using VRC.Core;

    internal class VRCInputArgs : EventArgs
    {
        internal bool isClicked;
        internal bool isDown;
        internal bool isUp;

        internal VRCInputArgs(bool isClicked, bool isDown, bool isUp)
        {
            this.isClicked = isClicked;
            this.isDown = isDown;
            this.isUp = isUp;
        }
    }
}