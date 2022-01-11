namespace AstroClient.Tools.UdonEditor
{
    using VRC.Udon;

    internal static class UdonUnpacker_Utils_ext
    {
        internal static RawUdonBehaviour ToRawUdonBehaviour(this UdonBehaviour udon)
        {
            return UdonUnpacker_Utils.ToRawUdonBehaviour(udon);
        }
    }
}