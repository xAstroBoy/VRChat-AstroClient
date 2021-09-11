namespace AstroClient.Udon
{
    using VRC.Udon;

    public static class UdonUnpacker_Utils_ext
    {
        public static DisassembledUdonBehaviour DisassembleUdonBehaviour(this UdonBehaviour udon)
        {
            return UdonUnpacker_Utils.DisassembleUdonBehaviour(udon);
        }
    }
}