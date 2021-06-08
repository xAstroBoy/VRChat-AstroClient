namespace AstroClient.ItemTweakerV2.Submenus.ScrollMenus
{
	using AstroClient.Components;
	using AstroClient.Extensions;
	using AstroClient.GameObjectDebug;
	using AstroClient.ItemTweakerV2.Selector;
	using AstroClient.variables;
	using AstroLibrary;
	using AstroLibrary.Extensions;
	using RubyButtonAPI;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	using UnityEngine;
	using VRC.SDK3.Components;
	using VRC.SDKBase;
	using VRC.Udon.Common.Interfaces;
	using Color = UnityEngine.Color;


	class PrefabSpawnerScrollMenu
	{

		public static void Init_PrefabSpawnerQMScroll(QMTabMenu main, float x, float y, bool btnHalf)
		{
			var menu = new QMNestedButton(main, x, y, "Spawn Prefabs", "Spawn World Prefabs", null, null, null, null, btnHalf);
			var prefabQMScroll = new QMScrollMenu(menu);
			prefabQMScroll.SetAction(delegate
			{
				foreach (var prefab in WorldUtils.Get_Prefabs())
				{
					prefabQMScroll.Add(
					new QMSingleButton(prefabQMScroll.BaseMenu, 0, 0, $"Spawn {prefab.name}", delegate
					{
						var broadcast = VRC_EventHandler.VrcBroadcastType.Always;
						var prefabinfo = prefab.name;
						var position = LocalPlayerUtils.GetPlayerBoneTransform(HumanBodyBones.RightHand).position;
						var Rotation = prefab.transform.rotation;

						//ModConsole.DebugLog($"Attempting to broadcast  {broadcast} a Spawn Prefab {prefabinfo}, in Vector3 {position.ToString()}, Rotation : {Rotation.ToString()}");
						//RPC_Experiments.SendSpawnobject(prefab);
						var newprefab = Networking.Instantiate(broadcast, prefabinfo, position, Rotation);
						if (newprefab != null)
						{
							SpawnerSubmenu.RegisterPrefab(newprefab);
							Tweaker_Object.SetObjectToEdit(newprefab);
						}
					}, $"Spawn {prefab.name}"));
				}
			});
		}
	}
}
