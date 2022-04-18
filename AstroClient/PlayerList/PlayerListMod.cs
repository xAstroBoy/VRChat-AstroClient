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

        internal static bool HasUIX => MelonHandler.Mods.Any(x => x.Info.Name.Equals("UI Expansion Kit"));

        internal override void OnApplicationStart()
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


        internal override void VRChat_OnUiManagerInit()
        {




            PlayerListConfig.OnConfigChange(false);
            Log.Debug("PlayerList UI Initialized!");
        }




        
    }
}
