namespace AstroClient.SyncPhysicExt
{
	using UnityEngine;

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
				instance.Method_Public_Void_PDM_2();
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