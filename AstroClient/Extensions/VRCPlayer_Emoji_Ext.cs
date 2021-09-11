namespace AstroLibrary.Extensions
{
    public static class VRCPlayer_Emoji_Ext
    {
        public static float Get_Emoji_Cooldown(this VRCPlayer instance)
        {
            return instance.field_Private_Single_4;
        }

        public static void Set_Emoji_Cooldown(this VRCPlayer instance, float value)
        {
            if (instance != null)
            {
                instance.field_Private_Single_4 = value;
            }
        }
    }
}