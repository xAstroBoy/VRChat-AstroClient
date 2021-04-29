namespace AstroClient.AntiCrash
{
	using AstroClient.ConsoleUtils;
	using UnityEngine;

	internal class AntiCrashPolys
	{
		internal static int count_polys(Renderer r)
		{
			int num = 0;
			SkinnedMeshRenderer skinnedMeshRenderer = r as SkinnedMeshRenderer;
			if (skinnedMeshRenderer != null)
			{
				if (skinnedMeshRenderer.sharedMesh == null)
				{
					return 0;
				}
				num += count_poly_meshes(skinnedMeshRenderer.sharedMesh);
			}
			return num;
		}

		private static int count_poly_meshes(Mesh sourceMesh)
		{
			if (!sourceMesh.isReadable)
			{
				UnityEngine.Object.Destroy(sourceMesh);
				ModConsole.AntiCrash("An Unreadable Mesh Was Destroyed!");
			}
			int num = 0;
			for (int i = 0; i < sourceMesh.subMeshCount; i++)
			{
				num += sourceMesh.GetTriangles(i).Length / 3;
			}
			return num;
		}
	}
}