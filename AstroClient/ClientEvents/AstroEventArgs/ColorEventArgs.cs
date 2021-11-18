﻿namespace AstroClient.AstroEventArgs
{
    using System;

    internal class ColorEventArgs : EventArgs
    {
        internal UnityEngine.Color Color;

        internal ColorEventArgs(UnityEngine.Color Color)
        {
            this.Color = Color;
        }
    }
}