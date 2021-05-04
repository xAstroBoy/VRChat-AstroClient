namespace AstroClient.SyncPhysicExt
{
	using UnityEngine;
	using SyncPhysics = MonoBehaviour1PublicPiOb1ObBoRiBoNuObRiUnique;

	public static class SyncPhysicsExt
	{
		public static void RefreshProperties(this SyncPhysics instance)
		{
			if (instance != null)
			{
				instance.Method_Public_Void_PDM_1();
			}
		}

		public static void RespawnItem(this SyncPhysics instance)
		{
			if (instance != null)
			{
				instance.Method_Public_Void_2();
			}
		}

		public static Rigidbody GetRigidBody(this SyncPhysics instance)
		{
			if (instance != null)
			{
				return instance.field_Private_Rigidbody_0;
			}
			return null;
		}
	}
}