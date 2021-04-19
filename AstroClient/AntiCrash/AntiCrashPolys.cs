using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using AstroClient.ConsoleUtils;
using AstroClient.extensions;
using AstroClient.Finder;
using AstroClient.Variables;
using VRC.SDKBase;
using UnityEngine.UI;

namespace AstroClient.AntiCrash
{
	class AntiCrashPolys
	{
#if DEBUG
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
#endif

    }
}
