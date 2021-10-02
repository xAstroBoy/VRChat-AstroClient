namespace AstroLibrary.Utility
{
    using AstroLibrary.Extensions;
    using VRC.Core;

    public static class AvatarUtils
    {
        #region Extensions
        public static bool IsAvatarID(this string id)
        {
            return id.IsNotNullOrEmptyOrWhiteSpace() && id.StartsWith("avtr_");
        }
        #endregion

        public static ApiAvatar GetApiAvatar(string avatarID)
        {
            if (avatarID.IsAvatarID())
            {
                var avatar = new ApiAvatar { id = avatarID };
                avatar.Fetch();
                return avatar;
            }
            return null;
        }
    }
}
