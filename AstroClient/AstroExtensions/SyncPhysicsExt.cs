namespace AstroClient.SyncPhysicExt
{
	using UnityEngine;

	public static class SyncPhysicsExt
	{

		// SyncPhysics = MonoBehaviour1PublicPiOb1ObBoRiBoNuObRiUnique
		public static void RefreshProperties(this MonoBehaviour1PublicPiOb1ObBoRiBoNuObRiUnique instance)
		{
			if (instance != null)
			{
				instance.Method_Public_Void_PDM_1();
			}
		}

		public static void RespawnItem(this MonoBehaviour1PublicPiOb1ObBoRiBoNuObRiUnique instance)
		{
			if (instance != null)
			{
				instance.Method_Public_Void_2();
			}
		}

		public static Rigidbody GetRigidBody(this MonoBehaviour1PublicPiOb1ObBoRiBoNuObRiUnique instance)
		{
			if (instance != null)
			{
				return instance.field_Private_Rigidbody_0;
			}
			return null;
		}
	}
}