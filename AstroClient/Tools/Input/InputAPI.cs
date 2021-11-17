namespace AstroClient.Tools.Input
{
    internal static class InputAPI
    {

        //internal static string Name_1(this VRCInput instance)
        //{
        //    return instance?.field_Private_String_0;
        //}

        internal static string Name(this VRCInput instance)
        {
            return instance?.prop_String_0;
        }

        internal static bool isClicked(this VRCInput instance)
        {
            return instance.prop_Single_0 == 1;
        }

        internal static bool isDown(this VRCInput instance)
        {
            return instance.field_Private_Boolean_0;
        }

        internal static bool isUp(this VRCInput instance)
        {
            return instance.prop_Boolean_1;
        }

    }
}