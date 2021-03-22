namespace AstroClient
{
    using AstroClient.components;
    using AstroClient.ConsoleUtils;
    using AstroClient.Startup.Hooks;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Instrumentation;
    using System.Text;
    using System.Threading.Tasks;
    using UnityEngine;
    using VRC.SDKBase;


    // thanks TO Cheeto aka Craig on discord, he's been really helpful!
    public class Overridables // TODO: GET A BETTER NAME
    {
        public static Overridables Instance;

        public Overridables()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            // ML Events
            Main.Event_OnApplicationStart += Internal_OnApplicationStart;
            Main.Event_OnUpdate += Internal_OnUpdate;
            Main.Event_LateUpdate += Internal_OnLateUpdate;
            Main.Event_VRChat_OnUiManagerInit += Internal_VRChat_OnUiManagerInit;
            // PATCHES

            // HOOKS 
            OnWorldRevealHook.Event_OnWorldReveal += Internal_OnWorldReveal;
            SpawnEmojiRPCHook.Event_SpawnEmojiRPC += Internal_SpawnEmojiRPC;
            TriggerEventHook.Event_VRC_EventDispatcherRFC_triggerEvent += Internal_VRC_EventDispatcherRFC_triggerEvent;
            AvatarManagerHook.Event_OnAvatarSpawn += Internal_VRC_EventDispatcherRFC_triggerEvent;

            NetworkManagerHooks.Event_OnPlayerJoin += Internal_OnPlayerJoined;
            NetworkManagerHooks.Event_OnPlayerLeft += Internal_OnPlayerLeft;
        }

        private void Internal_OnApplicationStart(object sender, EventArgs e)
        {
            OnApplicationStart();
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

        private void internal_OnLevelLoaded(object sender, EventArgs e)
        {

            // TODO : REMOVE AND MERGE INTO THE COMPONENT DIRECTLY

            OrbitManager.OnLevelLoad();
            PlayerWatcherManager.OnLevelLoad();
            PlayerAttackerManager.OnLevelLoad();
            RocketManager.OnLevelLoad();
            CrazyObjectManager.OnLevelLoad();
            ItemInflaterManager.OnLevelLoad();
            ObjectSpinnerManager.OnLevelLoad();


            OnLevelLoaded();
        }

        private void Internal_OnPlayerLeft(object sender, PlayerEventArgs e)
        {
            OnPlayerLeft(e.player);
        }

        private void Internal_OnPlayerJoined(object sender, PlayerEventArgs e)
        {
            OnPlayerJoined(e.player);
        }

        private void Internal_SpawnEmojiRPC(object sender, SpawnEmojiArgs e)
        {
            SpawnEmojiRPC(e.player, e.Emoji);
        }


        private void Internal_OnWorldReveal(object sender, EventArgs e)
        {
            OnWorldReveal();
            ModConsole.Log("You entered this world : " + WorldUtils.GetWorldName(), System.Drawing.Color.Goldenrod);
            ModConsole.Log("World ID : " + WorldUtils.GetWorldID(), System.Drawing.Color.Goldenrod);
            ModConsole.Log("World Asset URL : " + WorldUtils.GetWorldAssetURL(), System.Drawing.Color.Goldenrod);
        }

        private void Internal_VRC_EventDispatcherRFC_triggerEvent(object sender, VRC_EventDispatcherRFC_TriggerEventArgs e)
        {
            VRC_EventDispatcherRFC_triggerEvent(e.VRC_EventHandler, e.VrcEvent, e.VrcBroadcastType, e.UnknownInt, e.UnknownFloat);
        }

        private void Internal_OnAvatarSpawn(object sender, OnAvatarSpawnArgs e)
        {
            OnAvatarSpawn(e.Avatar, e.VRC_AvatarDescriptor, e.state);
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

        public virtual void OnLevelLoaded()
        {

        }



        public virtual void OnPlayerLeft(VRC.Player player)
        {

        }

        public virtual void OnPlayerJoined(VRC.Player player)
        {

        }

        public virtual void SpawnEmojiRPC(VRCPlayer player,  int emoji)
        {

        }


        public virtual void VRC_EventDispatcherRFC_triggerEvent(VRC_EventHandler VRC_EventHandler, VRC_EventHandler.VrcEvent VrcEvent, VRC_EventHandler.VrcBroadcastType VrcBroadcastType, int UnknownInt, float UnknownFloat)
        {

        }

        public virtual void OnAvatarSpawn(GameObject avatar, VRC.SDKBase.VRC_AvatarDescriptor DescriptorObj, bool state)
        {

        }

        public virtual void OnWorldReveal()
        {

        }


    }

}
