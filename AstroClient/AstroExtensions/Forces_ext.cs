namespace AstroClient.Extensions
{
	using UnityEngine;
	using static AstroClient.Forces;

	public static class ForcesExtensions
	{
		public static void KillForces(this GameObject obj)
		{
			RemoveForces(obj, TakeOwnership);
		}


		public static void Left(this GameObject obj)
		{
			ApplyLeftForce(obj, TakeOwnership);
		}

		public static void Right(this GameObject obj)
		{
			ApplyRightForce(obj, TakeOwnership);
		}

		public static void Foward(this GameObject obj)
		{
			ApplyFowardForce(obj, TakeOwnership);
		}

		public static void Backward(this GameObject obj)
		{
			ApplyBackwardsForce(obj, TakeOwnership);
		}

		public static void Push(this GameObject obj)
		{
			PushObject(obj, TakeOwnership);
		}

		public static void Pull(this GameObject obj)
		{
			PullObject(obj, TakeOwnership);
		}

		public static void SpinX(this GameObject obj)
		{
			SpinObjectX(obj, TakeOwnership);
		}

		public static void SpinY(this GameObject obj)
		{
			SpinObjectY(obj, TakeOwnership);
		}

		public static void SpinZ(this GameObject obj)
		{
			SpinObjectZ(obj, TakeOwnership);
		}

		public static void KillForces(this GameObject obj, bool TakeOwnership)
		{
			RemoveForces(obj, TakeOwnership);
		}


		public static void Left(this GameObject obj, bool TakeOwnership)
		{
			ApplyLeftForce(obj, TakeOwnership);
		}

		public static void Right(this GameObject obj, bool TakeOwnership)
		{
			ApplyRightForce(obj, TakeOwnership);
		}

		public static void Foward(this GameObject obj, bool TakeOwnership)
		{
			ApplyFowardForce(obj, TakeOwnership);
		}

		public static void Backward(this GameObject obj, bool TakeOwnership)
		{
			ApplyBackwardsForce(obj, TakeOwnership);
		}

		public static void Push(this GameObject obj, bool TakeOwnership)
		{
			PushObject(obj, TakeOwnership);
		}

		public static void Pull(this GameObject obj, bool TakeOwnership)
		{
			PullObject(obj, TakeOwnership);
		}

		public static void SpinX(this GameObject obj, bool TakeOwnership)
		{
			SpinObjectX(obj, TakeOwnership);
		}

		public static void SpinY(this GameObject obj, bool TakeOwnership)
		{
			SpinObjectY(obj, TakeOwnership);
		}

		public static void SpinZ(this GameObject obj, bool TakeOwnership)
		{
			SpinObjectZ(obj, TakeOwnership);
		}

	}
}