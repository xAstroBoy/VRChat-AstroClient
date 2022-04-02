using Photon.Pun;

namespace AstroClient.AstroEventArgs
{
    using System;
    using VRC;

    internal class OnOwnerShipTransferredEventArgs : EventArgs
    {
        internal PhotonView instance;
        internal int PhotonID;

        internal OnOwnerShipTransferredEventArgs(PhotonView instance, int PhotonID)
        {
            this.instance = instance;
            this.PhotonID = PhotonID;
        }
    }
}