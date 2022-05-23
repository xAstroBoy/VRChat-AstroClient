namespace AstroClient.Tools.UdonEditor
{
    internal static class UdonCustomEventsLists
    {
        /// <summary>
        /// These are mostly generated from vrchat Udon SDK, They are very likely not spammed at all.
        /// </summary>
        internal static readonly string[] VRChatUdonSDKEvents = {
            "_interact",
            "_onPickupUseDown",
            "_onStationEntered",
            "_onStationExited",
            "_onPickupUseUp",
            "_onTriggerEnter",
            "_onTriggerExit",
            "_onTriggerStay",
            "_onPlayerTriggerEnter",
            "_onPlayerTriggerExit",
            "_onPickupUseDown",
            "_onPickupUseUp",
            "_onPickup",
            "_onDrop",
            "_onDeserialization",
            "_onDisable",
            "_onEnable",
            "_onOwnershipTransferred",
            "_start",
            "_onMouseDown",
            "_onMouseUp",
            "_onPlayerJoined",
            "_onPlayerLeft",
        };
        /// <summary>
        /// All possible events that are VRChat Udon SDK generated, but they will be spammy.
        /// </summary>
        internal static readonly string[] VRChatUdonSDKUpdateEvents = {
            "_lateUpdate",
            "_update",
            "_Update",
            "_fixedUpdate",
            
        };
        /// <summary>
        /// Known World based Events that are 100% spammy.
        /// </summary>
        internal static readonly string[] WorldKnownsSpammyKeys = {
            "_Tick",
            "_SnailUpdate",
            "_BrokeredUpdate",
            "_UnregisterSubscription",
            "_SlowObjectSyncUpdate",
        };

    }
}