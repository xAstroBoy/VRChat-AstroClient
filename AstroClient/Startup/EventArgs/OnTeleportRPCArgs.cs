namespace AstroClient
{
	using System;
	using UnityEngine;
	using VRC.SDKBase;
	using static VRC.SDKBase.VRC_SceneDescriptor;

	public class OnTeleportRPCArgs : EventArgs
	{
		public Vector3 Position;
		public Quaternion Rotation;
		public VRC_SceneDescriptor.SpawnOrientation SpawnOrientation;
		public bool UnknownBool;
		public Int32 UnknownInt;

		public OnTeleportRPCArgs(Vector3 position, Quaternion Rotation, SpawnOrientation SpawnOrientation, bool UnknownBool, Int32 UnknownInt)
		{
			this.Position = position;
			this.Rotation = Rotation;
			this.SpawnOrientation = SpawnOrientation;
			this.UnknownBool = UnknownBool;
			this.UnknownInt = UnknownInt;
		}
	}
}