namespace AstroClient.Tools.Extensions
{
    internal static class VRCPlayer_Ext
    {
        internal static float Get_emojiCooldownTime(this VRCPlayer instance)
        {
            return instance.field_Private_Single_4;
        }

        internal static void Set_emojiCooldownTime(this VRCPlayer instance, float emojiCooldownTime)
        {
            if (instance != null)
            {
                instance.field_Private_Single_4 = emojiCooldownTime;
            }
        }

        internal static float Get_RespawnHeightY(this VRCPlayer instance)
        {
            return instance.field_Private_Single_2;
        }

        internal static void Set_RespawnHeightY(this VRCPlayer instance, float RespawnHeightY)
        {
            if (instance != null)
            {
                instance.field_Private_Single_2 = RespawnHeightY;
            }
        }

    }
}