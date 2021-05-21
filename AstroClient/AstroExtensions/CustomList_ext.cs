namespace AstroClient.Extensions
{
	using System.Linq;
	using UnityEngine;
	using static AstroClient.variables.CustomLists;

	public static class CustomList_ext
	{
		public static void RemoveObjFromCustomLists(this GameObject obj)
		{
			var objectcollider = ColliderCheck.FirstOrDefault(item => item.TargetObj == obj);
			var objectRigidBody = RigidBodyCheck.FirstOrDefault(item => item.TargetObj == obj);
			if (objectcollider != null)
			{
				if (ColliderCheck.Contains(objectcollider))
				{
					ColliderCheck.Remove(objectcollider);
				}
			}
			if (objectRigidBody != null)
			{
				if (RigidBodyCheck.Contains(objectRigidBody))
				{
					RigidBodyCheck.Remove(objectRigidBody);
				}
			}
		}

		public static int GetOriginalLightMapIndex(this GameObject obj)
		{
			return RendererSaverIndex.Where(x => x.TargetObj == obj).Select(x => x.OriglightmapIndex).DefaultIfEmpty(-999999999).First();
		}

		public static bool RenderisSaved(this GameObject obj)
		{
			return RendererSaverIndex.Where(x => x.TargetObj == obj).Select(x => x.IsSavedObj).DefaultIfEmpty(false).First();
		}
	}
}