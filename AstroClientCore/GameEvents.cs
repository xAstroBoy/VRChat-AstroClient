namespace AstroClientCore
{
	using AstroClientCore.Events;
	using AstroClientCore.Managers;
	using System;
	using UnityEngine;
	using VRC;
	using VRC.SDKBase;

	// thanks TO Cheeto aka Craig on discord, he's been really helpful!
	public class GameEvents
	{
		public GameEvents()
		{
			// ML Events
			EventManager.ApplicationQuit += Internal_OnApplicationQuit;
			EventManager.Update += Internal_OnUpdate;
			EventManager.LateUpdate += Internal_OnLateUpdate;
			EventManager.UiManagerInit += Internal_VRChat_OnUiManagerInit;
			EventManager.LevelLoaded += Internal_OnLevelLoaded;
			EventManager.PhotonPlayerJoined += Internal_OnPhotonPlayerJoined;
			EventManager.PhotonPlayerLeft += Internal_OnPhotonPlayerLeft;

			//// PATCHES

			//// HOOKS
			//OnWorldRevealHook.Event_OnWorldReveal += Internal_OnWorldReveal;
			//SpawnEmojiRPCHook.Event_SpawnEmojiRPC += Internal_SpawnEmojiRPC;
			//TriggerEventHook.Event_VRC_EventDispatcherRFC_triggerEvent += Internal_VRC_EventDispatcherRFC_triggerEvent;

			//RPCEventHook.Event_OnUdonSyncRPC += Internal_OnUdonSyncRPCEvent;

			//AvatarManagerHook.Event_OnAvatarSpawn += Internal_OnAvatarSpawn;

			//NetworkManagerHooks.Event_OnPlayerJoin += Internal_OnPlayerJoined;
			//NetworkManagerHooks.Event_OnPlayerLeft += Internal_OnPlayerLeft;

			//CheetosHooks.Event_OnPhotonJoin += Internal_OnPhotonPlayerJoined;
			//CheetosHooks.Event_OnPhotonLeft += Internal_OnPhotonPlayerLeft;
		}

		private void Internal_OnApplicationStart(object sender, EventArgs e)
		{
			OnApplicationStart();
		}

		private void Internal_OnApplicationQuit(object sender, EventArgs e)
		{
			OnApplicationQuit();
		}

		private void Internal_VRChat_OnUiManagerInit(object sender, EventArgs e)
		{
			VRChat_OnUiManagerInit();
		}

		private void Internal_OnUpdate(object sender, EventArgs e)
		{
			OnUpdate();
		}

		private void Internal_OnLateUpdate(object sender, EventArgs e)
		{
			OnLateUpdate();
		}

		private void Internal_OnLevelLoaded(object sender, EventArgs e)
		{
			OnLevelLoaded();
		}

		//private void Internal_OnPlayerLeft(object sender, PlayerEventArgs e)
		//{
		//	OnPlayerLeft(e.player);
		//}

		//private void Internal_OnPlayerJoined(object sender, PlayerEventArgs e)
		//{
		//	OnPlayerJoined(e.player);
		//}

		private void Internal_OnPhotonPlayerLeft(object sender, PhotonPlayerEventArgs e)
		{
			OnPhotonLeft(e.player);
		}

		private void Internal_OnPhotonPlayerJoined(object sender, PhotonPlayerEventArgs e)
		{
			OnPhotonJoined(e.player);
		}

		//private void Internal_SpawnEmojiRPC(object sender, SpawnEmojiArgs e)
		//{
		//	SpawnEmojiRPC(e.player, e.Emoji);
		//}

		//private void Internal_OnWorldReveal(object sender, OnWorldRevealArgs e)
		//{
		//	OnWorldReveal(e.ID, e.Name, e.AssetUrl);
		//}

		//private void Internal_VRC_EventDispatcherRFC_triggerEvent(object sender, VRC_EventDispatcherRFC_TriggerEventArgs e)
		//{
		//	VRC_EventDispatcherRFC_triggerEvent(e.VRC_EventHandler, e.VrcEvent, e.VrcBroadcastType, e.UnknownInt, e.UnknownFloat);
		//}

		//private void Internal_OnUdonSyncRPCEvent(object sender, UdonSyncRPCEventArgs e)
		//{
		//	OnUdonSyncRPCEvent(e.sender, e.obj, e.action);
		//}

		//private void Internal_OnAvatarSpawn(object sender, OnAvatarSpawnArgs e)
		//{
		//	OnAvatarSpawn(e.Avatar, e.VRC_AvatarDescriptor, e.state);
		//}

		public virtual void VRChat_OnUiManagerInit()
		{
		}

		public virtual void ExecutePriorityPatches()
		{
		}

		public virtual void OnApplicationStart()
		{
		}

		public virtual void OnApplicationQuit()
		{
		}

		public virtual void OnUpdate()
		{
		}

		public virtual void OnLateUpdate()
		{
		}

		public virtual void OnRayCast(RaycastHit hit)
		{
		}

		public virtual void OnLevelLoaded()
		{
		}

		public virtual void OnPlayerLeft(Player player)
		{
		}

		public virtual void OnPlayerJoined(Player player)
		{
		}

		public virtual void OnPhotonLeft(Photon.Realtime.Player player)
		{
		}

		public virtual void OnPhotonJoined(Photon.Realtime.Player player)
		{
		}

		public virtual void SpawnEmojiRPC(VRCPlayer player, int emoji)
		{
		}

		public virtual void VRC_EventDispatcherRFC_triggerEvent(VRC_EventHandler VRC_EventHandler, VRC_EventHandler.VrcEvent VrcEvent, VRC_EventHandler.VrcBroadcastType VrcBroadcastType, int UnknownInt, float UnknownFloat)
		{
		}

		public virtual void OnAvatarSpawn(GameObject avatar, VRC_AvatarDescriptor DescriptorObj, bool state)
		{
		}

		public virtual void OnUdonSyncRPCEvent(Player sender, GameObject obj, string action)
		{
		}

		public virtual void OnWorldReveal(string id, string Name, string AssetURL)
		{
		}
	}
}