namespace AstroClient
{
	public class InputUtils
    {
        public static bool IsImputJumpCalled()
        {
            return VRCInputManager.field_Private_Static_Dictionary_2_String_VRCInput_0["Jump"].prop_Boolean_0;
        }

        public static bool IsInputJumpPressed()
        {
            return VRCInputManager.field_Private_Static_Dictionary_2_String_VRCInput_0["Jump"].prop_Single_0 == 1;
        }
    }
}