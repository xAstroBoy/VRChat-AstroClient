using AstroClient.ClientActions;

namespace AstroClient.PlayerList
{
    using System.Collections;
    using System.Linq;
    using AstroClient;
    using Config;
    using Entries;
    using MelonLoader;
    using UnityEngine;

    internal class PlayerListMod : AstroEvents
    {
        internal static PlayerListMod Instance { get; private set; }

        internal override void RegisterToEvents()
        {
            ClientEventActions.Event_OnApplicationStart += OnApplicationStart;
            ClientEventActions.Event_VRChat_OnUiManagerInit += VRChat_OnUiManagerInit;
        }

        private void OnApplicationStart()
        {
            Instance = this;
            PlayerListConfig.RegisterSettings();
            EntryManager.Init();
            //ListPositionManager.Init();
            MenuManager.Init();
            EntrySortManager.Init();
            PlayerEntry.EntryInit();
            LocalPlayerEntry.EntryInit();
        }


        private void VRChat_OnUiManagerInit()
        {


            // This is kinda a mess but whatever
            EntryManager.AddGeneralInfoEntries();

            PlayerListConfig.OnConfigChange(false);
            Log.Debug("PlayerList UI Initialized!");
        }




        
    }
}
