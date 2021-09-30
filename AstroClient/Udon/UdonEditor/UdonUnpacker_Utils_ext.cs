namespace AstroClient.Udon
{
    using VRC.Udon;

    internal static class UdonUnpacker_Utils_ext
    {
        internal static DisassembledUdonBehaviour DisassembleUdonBehaviour(this UdonBehaviour udon)
        {
            return UdonUnpacker_Utils.DisassembleUdonBehaviour(udon);
        }
    }
}