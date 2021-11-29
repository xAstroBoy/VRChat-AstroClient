namespace AstroClient.AstroEventArgs
{
    using System;
    using UnityEngine;

    internal class ColorEventArgs : EventArgs
    {
        internal Color Color;

        internal ColorEventArgs(Color Color)
        {
            this.Color = Color;
        }
    }
}