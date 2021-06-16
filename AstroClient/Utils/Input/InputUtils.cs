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

		public static bool IsImputUseLeftCalled()
		{
			return VRCInputManager.field_Private_Static_Dictionary_2_String_VRCInput_0["UseLeft"].prop_Boolean_0;
		}

		public static bool IsInputUseLeftPressed()
		{
			return VRCInputManager.field_Private_Static_Dictionary_2_String_VRCInput_0["UseLeft"].prop_Single_0 == 1;
		}

		public static bool IsImputGrabLeftCalled()
		{
			return VRCInputManager.field_Private_Static_Dictionary_2_String_VRCInput_0["GrabLeft"].prop_Boolean_0;
		}

		public static bool IsInputGrabLeftPressed()
		{
			return VRCInputManager.field_Private_Static_Dictionary_2_String_VRCInput_0["GrabLeft"].prop_Single_0 == 1;
		}


		public static bool IsImputDropLeftCalled()
		{
			return VRCInputManager.field_Private_Static_Dictionary_2_String_VRCInput_0["DropLeft"].prop_Boolean_0;
		}

		public static bool IsInputDropLeftPressed()
		{
			return VRCInputManager.field_Private_Static_Dictionary_2_String_VRCInput_0["DropLeft"].prop_Single_0 == 1;
		}

		public static bool IsImputUseRightCalled()
		{
			return VRCInputManager.field_Private_Static_Dictionary_2_String_VRCInput_0["UseRight"].prop_Boolean_0;
		}

		public static bool IsInputUseRightPressed()
		{
			return VRCInputManager.field_Private_Static_Dictionary_2_String_VRCInput_0["UseRight"].prop_Single_0 == 1;
		}

		public static bool IsImputGrabRightCalled()
		{
			return VRCInputManager.field_Private_Static_Dictionary_2_String_VRCInput_0["GrabRight"].prop_Boolean_0;
		}

		public static bool IsInputGrabRightPressed()
		{
			return VRCInputManager.field_Private_Static_Dictionary_2_String_VRCInput_0["GrabRight"].prop_Single_0 == 1;
		}


		public static bool IsImputDropRightCalled()
		{
			return VRCInputManager.field_Private_Static_Dictionary_2_String_VRCInput_0["DropRight"].prop_Boolean_0;
		}

		public static bool IsInputDropRightPressed()
		{
			return VRCInputManager.field_Private_Static_Dictionary_2_String_VRCInput_0["DropRight"].prop_Single_0 == 1;
		}




	}
}