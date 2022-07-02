namespace AstroClient.Tools.Input
{
    internal class InputUtils
    {

        /// <summary>
        /// Use  <see cref="VRCInputs"/> strict to find the desired vrchat input system.
        /// </summary>
        /// <param name="name"></param>
        internal static VRCInput GetInput(string name)
        {
            return VRCInputManager.field_Private_Static_Dictionary_2_String_VRCInput_0[name];
        }

    }
}