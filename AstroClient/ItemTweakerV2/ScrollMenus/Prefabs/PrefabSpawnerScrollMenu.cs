namespace AstroClient.ItemTweakerV2.Submenus.ScrollMenus
{
	using AstroClient.ItemTweakerV2.Selector;
	using AstroLibrary.Extensions;
	using RubyButtonAPI;
	using UnityEngine;
	using VRC.SDKBase;

	internal class PrefabSpawnerScrollMenu
	{
		public static void Init_PrefabSpawnerQMScroll(QMNestedButton main, float x, float y, bool btnHalf)
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
						var position = Utils.LocalPlayer.GetPlayer().Get_Player_Bone_Position(HumanBodyBones.RightHand);
						var Rotation = prefab.transform.rotation;

						if (position != null)
						{
							//ModConsole.DebugLog($"Attempting to broadcast  {broadcast} a Spawn Prefab {prefabinfo}, in Vector3 {position.ToString()}, Rotation : {Rotation.ToString()}");
							//RPC_Experiments.SendSpawnobject(prefab);
							var newprefab = Networking.Instantiate(broadcast, prefabinfo, position.Value, Rotation);
							if (newprefab != null)
							{
								SpawnerSubmenu.RegisterPrefab(newprefab);
								Tweaker_Object.SetObjectToEdit(newprefab);
							}
						}
					}, $"Spawn {prefab.name}"));
				}
			});
		}
	}
}