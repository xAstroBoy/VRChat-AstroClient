﻿namespace AstroClientCore.Events
{
    using System;
    using VRC.Core;

    internal class OnAvatarDownloadArgs : EventArgs
    {
        internal ApiAvatar Avatar;

        internal OnAvatarDownloadArgs(ApiAvatar avatar)
        {
            Avatar = avatar;
        }
    }
}