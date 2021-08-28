namespace AstroClient.Udon
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using VRC.Udon;

    public static class UdonUnpacker_Utils_ext
    {
        public static DisassembledUdonBehaviour DisassembleUdonBehaviour(this UdonBehaviour udon)
        {
            return UdonUnpacker_Utils.DisassembleUdonBehaviour(udon);
        }

    }
}
