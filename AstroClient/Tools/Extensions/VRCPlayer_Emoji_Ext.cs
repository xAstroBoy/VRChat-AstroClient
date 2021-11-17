namespace AstroClient.Tools.Extensions
{
    internal static class VRCPlayer_Emoji_Ext
    {
        internal static float Get_Emoji_Cooldown(this VRCPlayer instance)
        {
            return instance.field_Private_Single_4;
        }

        internal static void Set_Emoji_Cooldown(this VRCPlayer instance, float value)
        {
            if (instance != null)
            {
                instance.field_Private_Single_4 = value;
            }
        }
    }
}