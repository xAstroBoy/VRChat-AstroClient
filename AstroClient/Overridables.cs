namespace AstroClient
{
    using AstroClient.ConsoleUtils;
    using AstroClient.Startup.Hooks;
    using System;
    using UnityEngine;
    using VRC;
    using VRC.SDKBase;

    // thanks TO Cheeto aka Craig on discord, he's been really helpful!
    public class Overridables // TODO: GET A BETTER NAME
    {
        public Overridables()
        {
            try
            {
                // ML Events
                //Main.Event_OnApplicationStart += Internal_OnApplicationStart;
                Main.Event_OnUpdate += Internal_OnUpdate;
                Main.Event_LateUpdate += Internal_OnLateUpdate;
                Main.Event_VRChat_OnUiManagerInit += Internal_VRChat_OnUiManagerInit;
                Main.Event_OnLevelLoaded += internal_OnLevelLoaded;

                // PATCHES

                // HOOKS
                OnWorldRevealHook.Event_OnWorldReveal += Internal_OnWorldReveal;
                SpawnEmojiRPCHook.Event_SpawnEmojiRPC += Internal_SpawnEmojiRPC;
                TriggerEventHook.Event_VRC_EventDispatcherRFC_triggerEvent += Internal_VRC_EventDispatcherRFC_triggerEvent;

                RPCEventHook.Event_OnUdonSyncRPC += Internal_OnUdonSyncRPCEvent;


                AvatarManagerHook.Event_OnAvatarSpawn += Internal_OnAvatarSpawn;

                NetworkManagerHooks.Event_OnPlayerJoin += Internal_OnPlayerJoined;
                NetworkManagerHooks.Event_OnPlayerLeft += Internal_OnPlayerLeft;
            }
            catch (Exception e)
            {
                ModConsole.ErrorExc(e);
            }
        }

        private void Internal_OnApplicationStart(object sender, EventArgs e)
        {
            try
            {
                OnApplicationStart();
            }
            catch (Exception Exc)
            {
                ModConsole.ErrorExc(Exc);
            }
        }

        private void Internal_VRChat_OnUiManagerInit(object sender, EventArgs e)
        {
            try
            {
                VRChat_OnUiManagerInit();
            }
            catch (Exception Exc)
            {
                ModConsole.ErrorExc(Exc);
            }
        }

        private void Internal_OnUpdate(object sender, EventArgs e)
        {
            try
            {
                OnUpdate();
            }
            catch (Exception Exc)
            {
                ModConsole.ErrorExc(Exc);
            }
        }

        private void Internal_OnLateUpdate(object sender, EventArgs e)
        {
            try
            {
                OnLateUpdate();
            }
            catch (Exception Exc)
            {
                ModConsole.ErrorExc(Exc);
            }
        }

        private void internal_OnLevelLoaded(object sender, EventArgs e)
        {
            try
            {
                OnLevelLoaded();
            }
            catch (Exception Exc)
            {
                ModConsole.ErrorExc(Exc);
            }

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

        private void Internal_OnWorldReveal(object sender, OnWorldRevealArgs e)
        {
            try
            {
                OnWorldReveal(e.ID, e.Name, e.AssetUrl);
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

        public virtual void VRChat_OnUiManagerInit()
        {
        }

        public virtual void OnApplicationStart()
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




        public virtual void OnWorldReveal(string id, string Name, string AssetURL)
        {
        }
    }
}