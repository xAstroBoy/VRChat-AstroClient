namespace AstroClient
{
    using System;
    using UnityEngine;
    using VRC.SDKBase;
    using static VRC.SDKBase.VRC_SceneDescriptor;

    internal class OnTeleportRPCArgs : EventArgs
    {
        public Vector3 Position;
        public Quaternion Rotation;
        public VRC_SceneDescriptor.SpawnOrientation SpawnOrientation;
        public bool UnknownBool;
        public int UnknownInt;

        public OnTeleportRPCArgs(Vector3 position, Quaternion Rotation, SpawnOrientation SpawnOrientation, bool UnknownBool, int UnknownInt)
        {
            this.Position = position;
            this.Rotation = Rotation;
            this.SpawnOrientation = SpawnOrientation;
            this.UnknownBool = UnknownBool;
            this.UnknownInt = UnknownInt;
        }
    }
}