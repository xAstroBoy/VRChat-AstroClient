namespace AstroClient.Features.Player.Clones
{
	using AstroClient.Extensions;
	using System.Collections.Generic;
	using UnityEngine;

	public class Clones : GameEvents
	{

		public static void OnLevelLoad()
		{
			ClonesCapsules.Clear();
		}


		public static void SpawnClone()
		{
			ClonesCapsules.Add(PlayerCloner.CloneLocalPlayerAvatar());
		}

		public static void RemoveClones()
		{
			try
			{
				foreach (var clone in ClonesCapsules)
				{
					if (clone != null)
					{
						clone.DestroyMeLocal();
					}
				}
				ClonesCapsules.Clear();
			}
			catch { }
		}

		private static List<GameObject> ClonesCapsules = new List<GameObject>();

	}
}
