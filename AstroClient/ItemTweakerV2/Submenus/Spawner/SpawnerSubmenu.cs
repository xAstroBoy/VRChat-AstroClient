namespace AstroClient.ItemTweakerV2.Submenus
{
	using AstroClient.Components;
	using AstroClient.Extensions;
	using AstroClient.ItemTweakerV2.Selector;
	using AstroClient.variables;
	using AstroLibrary.Extensions;
	using RubyButtonAPI;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;
	using VRC.SDKBase;
	using Color = UnityEngine.Color;

	public class SpawnerSubmenu : Tweaker_Events
	{

		public override void OnLevelLoaded()
		{
			SpawnedPrefabs.Clear();
			ClonedObjects.Clear();
			UpdateSpawnedPrefabsBtn();

		}



		public static string GetSpawnedPrefabText
		{
			get
			{
				return "Spawned Prefabs : " + SpawnedPrefabs.Count();
			}
		}

		public static string GetClonesPickupText
		{
			get
			{
				return "Pickup Clones : " + ClonedObjects.Count();
			}
		}

		public static void UpdateSpawnedPickupsBtn()
		{
			if (SpawnedPickupsCounter != null)
			{
				SpawnedPickupsCounter.SetButtonText(GetClonesPickupText);
				SpawnedPickupsCounter.SetToolTip(GetClonesPickupText);
			}
		}

		public static void UpdateSpawnedPrefabsBtn()
		{
			if (SpawnedPrefabsCounter != null)
			{
				SpawnedPrefabsCounter.SetButtonText(GetSpawnedPrefabText);
				SpawnedPrefabsCounter.SetToolTip(GetSpawnedPrefabText);
			}
		}


		public static void RegisterPrefab(GameObject obj)
		{
			if (obj != null)
			{
				if (!SpawnedPrefabs.Contains(obj))
				{
					SpawnedPrefabs.Add(obj);
				}
				UpdateSpawnedPrefabsBtn();
			}
		}


		public static void KillSpawnedPrefabs()
		{
			foreach (var prefab in SpawnedPrefabs)
			{
				if (prefab != null)
				{
					if (!prefab.DestroyMeOnline())
					{
						prefab.DestroyMeLocal();
					}
				}
			}
			SpawnedPrefabs.Clear();
			UpdateSpawnedPrefabsBtn();
		}




		public static List<GameObject> SpawnedPrefabs = new List<GameObject>();
		public static List<GameObject> ClonedObjects = new List<GameObject>();


		public static QMSingleButton SpawnedPickupsCounter;
		public static QMSingleButton SpawnedPrefabsCounter;


	}
}