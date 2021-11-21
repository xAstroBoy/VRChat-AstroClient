namespace AstroClient.Tools.Input
{
    internal class InputUtils
    {
        internal static bool IsImputJumpCalled => VRCInputManager.field_Private_Static_Dictionary_2_String_VRCInput_0["Jump"].prop_Boolean_0;

        internal static bool IsInputJumpPressed => VRCInputManager.field_Private_Static_Dictionary_2_String_VRCInput_0["Jump"].prop_Single_0 == 1;

        internal static bool IsImputUseLeftCalled => VRCInputManager.field_Private_Static_Dictionary_2_String_VRCInput_0["UseLeft"].prop_Boolean_0;

        internal static bool IsInputUseLeftPressed => VRCInputManager.field_Private_Static_Dictionary_2_String_VRCInput_0["UseLeft"].prop_Single_0 == 1;

        internal static bool IsImputGrabLeftCalled => VRCInputManager.field_Private_Static_Dictionary_2_String_VRCInput_0["GrabLeft"].prop_Boolean_0;

        internal static bool IsInputGrabLeftPressed => VRCInputManager.field_Private_Static_Dictionary_2_String_VRCInput_0["GrabLeft"].prop_Single_0 == 1;

        internal static bool IsImputDropLeftCalled => VRCInputManager.field_Private_Static_Dictionary_2_String_VRCInput_0["DropLeft"].prop_Boolean_0;

        internal static bool IsInputDropLeftPressed => VRCInputManager.field_Private_Static_Dictionary_2_String_VRCInput_0["DropLeft"].prop_Single_0 == 1;

        internal static bool IsImputUseRightCalled => VRCInputManager.field_Private_Static_Dictionary_2_String_VRCInput_0["UseRight"].prop_Boolean_0;

        internal static bool IsInputUseRightPressed => VRCInputManager.field_Private_Static_Dictionary_2_String_VRCInput_0["UseRight"].prop_Single_0 == 1;

        internal static bool IsImputGrabRightCalled => VRCInputManager.field_Private_Static_Dictionary_2_String_VRCInput_0["GrabRight"].prop_Boolean_0;

        internal static bool IsInputGrabRightPressed => VRCInputManager.field_Private_Static_Dictionary_2_String_VRCInput_0["GrabRight"].prop_Single_0 == 1;

        internal static bool IsImputDropRightCalled => VRCInputManager.field_Private_Static_Dictionary_2_String_VRCInput_0["DropRight"].prop_Boolean_0;

        internal static bool IsInputDropRightPressed => VRCInputManager.field_Private_Static_Dictionary_2_String_VRCInput_0["DropRight"].prop_Single_0 == 1;


        internal static VRCInput GrabRight = VRCInputManager.field_Private_Static_Dictionary_2_String_VRCInput_0["GrabRight"];

        internal static VRCInput GrabLeft = VRCInputManager.field_Private_Static_Dictionary_2_String_VRCInput_0["GrabLeft"];
    }
}