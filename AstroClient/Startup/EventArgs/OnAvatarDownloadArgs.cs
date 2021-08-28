namespace AstroClientCore.Events
{
    using System;
    using VRC.Core;

    public class OnAvatarDownloadArgs : EventArgs
    {
        public ApiAvatar Avatar;

        public OnAvatarDownloadArgs(ApiAvatar avatar)
        {
            Avatar = avatar;
        }
    }
}