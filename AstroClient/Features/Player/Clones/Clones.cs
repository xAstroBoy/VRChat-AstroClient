namespace AstroClient.Features.Player.Clones
{
	using AstroClient.Extensions;
	using AstroClient.Utils.Player;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
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
