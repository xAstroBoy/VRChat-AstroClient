namespace AstroClient.AstroEventArgs
{
    using System;
    using UnityEngine;
    using VRC.SDKBase;
    using static VRC.SDKBase.VRC_SceneDescriptor;

    internal class OnTeleportRPCArgs : EventArgs
    {
        internal Vector3 Position;
        internal Quaternion Rotation;
        internal VRC_SceneDescriptor.SpawnOrientation SpawnOrientation;
        internal bool UnknownBool;
        internal int UnknownInt;

        internal OnTeleportRPCArgs(Vector3 position, Quaternion Rotation, SpawnOrientation SpawnOrientation, bool UnknownBool, int UnknownInt)
        {
            this.Position = position;
            this.Rotation = Rotation;
            this.SpawnOrientation = SpawnOrientation;
            this.UnknownBool = UnknownBool;
            this.UnknownInt = UnknownInt;
        }
    }
}