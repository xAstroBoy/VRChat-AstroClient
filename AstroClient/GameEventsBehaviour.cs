namespace AstroClient
{
	using AstroClient.Startup.Hooks;
	using System;
	using UnhollowerBaseLib.Attributes;
	using UnityEngine;
	using VRC;
	using VRC.SDKBase;

	public class GameEventsBehaviour : MonoBehaviour
	{
		public GameEventsBehaviour(IntPtr obj0) : base(obj0)
		{
			Main.Event_OnLevelLoaded += Internal_OnLevelLoaded;
			NetworkManagerHooks.Event_OnPlayerJoin += Internal_OnPlayerJoined;
			NetworkManagerHooks.Event_OnPlayerLeft += Internal_OnPlayerLeft;
			SpawnEmojiRPCHook.Event_SpawnEmojiRPC += Internal_SpawnEmojiRPC;
			TriggerEventHook.Event_VRC_EventDispatcherRFC_triggerEvent += Internal_VRC_EventDispatcherRFC_triggerEvent;
			AvatarManagerHook.Event_OnAvatarSpawn += Internal_OnAvatarSpawn;
			RPCEventHook.Event_OnUdonSyncRPC += Internal_OnUdonSyncRPCEvent;
		}

		private void Internal_OnLevelLoaded(object sender, EventArgs e)
		{
			OnLevelLoaded();
		}

		[HideFromIl2Cpp]
		private void Internal_OnPlayerLeft(object sender, PlayerEventArgs e)
		{
			OnPlayerLeft(e.player);
		}

		[HideFromIl2Cpp]
		private void Internal_OnPlayerJoined(object sender, PlayerEventArgs e)
		{
			OnPlayerJoined(e.player);
		}

		[HideFromIl2Cpp]
		private void Internal_SpawnEmojiRPC(object sender, SpawnEmojiArgs e)
		{
			SpawnEmojiRPC(e.player, e.Emoji);
		}

		[HideFromIl2Cpp]
		private void Internal_VRC_EventDispatcherRFC_triggerEvent(object sender, VRC_EventDispatcherRFC_TriggerEventArgs e)
		{
			VRC_EventDispatcherRFC_triggerEvent(e.VRC_EventHandler, e.VrcEvent, e.VrcBroadcastType, e.UnknownInt, e.UnknownFloat);
		}

		[HideFromIl2Cpp]
		private void Internal_OnAvatarSpawn(object sender, OnAvatarSpawnArgs e)
		{
			OnAvatarSpawn(e.Avatar, e.VRC_AvatarDescriptor, e.state);
		}

		[HideFromIl2Cpp]
		private void Internal_OnUdonSyncRPCEvent(object sender, UdonSyncRPCEventArgs e)
		{
			OnUdonSyncRPCEvent(e.sender, e.obj, e.action);

		}

		[HideFromIl2Cpp]
		public virtual void OnPlayerLeft(VRC.Player player)
		{
		}

		[HideFromIl2Cpp]
		public virtual void OnLevelLoaded()
		{
		}

		[HideFromIl2Cpp]
		public virtual void OnPlayerJoined(VRC.Player player)
		{
		}

		[HideFromIl2Cpp]
		public virtual void SpawnEmojiRPC(VRCPlayer player, int emoji)
		{
		}

		[HideFromIl2Cpp]
		public virtual void VRC_EventDispatcherRFC_triggerEvent(VRC_EventHandler VRC_EventHandler, VRC_EventHandler.VrcEvent VrcEvent, VRC_EventHandler.VrcBroadcastType VrcBroadcastType, int UnknownInt, float UnknownFloat)
		{
		}

		[HideFromIl2Cpp]
		public virtual void OnAvatarSpawn(GameObject avatar, VRC.SDKBase.VRC_AvatarDescriptor DescriptorObj, bool state)
		{
		}

		[HideFromIl2Cpp]
		public virtual void OnUdonSyncRPCEvent(Player sender, GameObject obj, string action)
		{
		}
	}
}