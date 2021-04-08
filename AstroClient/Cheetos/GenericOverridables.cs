namespace AstroClient
{
    using AstroClient.ConsoleUtils;
    using AstroClient.Startup.Hooks;
    using System;
    using UnityEngine;
    using VRC;
    using VRC.SDKBase;

    public class GenericOverridables : MonoBehaviour // name?
    {
        public GenericOverridables(IntPtr obj0) : base(obj0)
        {
            NetworkManagerHooks.Event_OnPlayerJoin += Internal_OnPlayerJoined;
            NetworkManagerHooks.Event_OnPlayerLeft += Internal_OnPlayerLeft;

            SpawnEmojiRPCHook.Event_SpawnEmojiRPC += Internal_SpawnEmojiRPC;
            TriggerEventHook.Event_VRC_EventDispatcherRFC_triggerEvent += Internal_VRC_EventDispatcherRFC_triggerEvent;

            AvatarManagerHook.Event_OnAvatarSpawn += Internal_OnAvatarSpawn;
            RPCEventHook.Event_OnUdonSyncRPC += Internal_OnUdonSyncRPCEvent;
        }

        private void Internal_OnPlayerLeft(object sender, PlayerEventArgs e)
        {
            try
            {
                OnPlayerLeft(e.player);
            }
            catch (Exception Exc)
            {
                ModConsole.ErrorExc(Exc);
            }
        }

        private void Internal_OnPlayerJoined(object sender, PlayerEventArgs e)
        {
            try
            {
                OnPlayerJoined(e.player);
            }
            catch (Exception Exc)
            {
                ModConsole.ErrorExc(Exc);
            }
        }

        private void Internal_SpawnEmojiRPC(object sender, SpawnEmojiArgs e)
        {
            try
            {
                SpawnEmojiRPC(e.player, e.Emoji);
            }
            catch (Exception Exc)
            {
                ModConsole.ErrorExc(Exc);
            }
        }

        private void Internal_VRC_EventDispatcherRFC_triggerEvent(object sender, VRC_EventDispatcherRFC_TriggerEventArgs e)
        {
            try
            {
                VRC_EventDispatcherRFC_triggerEvent(e.VRC_EventHandler, e.VrcEvent, e.VrcBroadcastType, e.UnknownInt, e.UnknownFloat);
            }
            catch (Exception Exc)
            {
                ModConsole.ErrorExc(Exc);
            }
        }

        private void Internal_OnAvatarSpawn(object sender, OnAvatarSpawnArgs e)
        {
            try
            {
                OnAvatarSpawn(e.Avatar, e.VRC_AvatarDescriptor, e.state);
            }
            catch (Exception Exc)
            {
                ModConsole.ErrorExc(Exc);
            }
        }

        private void Internal_OnUdonSyncRPCEvent(object sender, UdonSyncRPCEventArgs e)
        {
            try
            {
                OnUdonSyncRPCEvent(e.sender, e.obj, e.action);
            }
            catch (Exception Exc)
            {
                ModConsole.ErrorExc(Exc);
            }
        }

        public virtual void OnPlayerLeft(VRC.Player player)
        {
        }

        public virtual void OnPlayerJoined(VRC.Player player)
        {
        }

        public virtual void SpawnEmojiRPC(VRCPlayer player, int emoji)
        {
        }

        public virtual void VRC_EventDispatcherRFC_triggerEvent(VRC_EventHandler VRC_EventHandler, VRC_EventHandler.VrcEvent VrcEvent, VRC_EventHandler.VrcBroadcastType VrcBroadcastType, int UnknownInt, float UnknownFloat)
        {
        }

        public virtual void OnAvatarSpawn(GameObject avatar, VRC.SDKBase.VRC_AvatarDescriptor DescriptorObj, bool state)
        {
        }

        public virtual void OnUdonSyncRPCEvent(Player sender, GameObject obj, string action)
        {
        }
    }
}