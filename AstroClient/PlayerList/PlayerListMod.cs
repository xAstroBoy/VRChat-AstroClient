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
            ListPositionManager.Init();
            MenuManager.Init();
            EntrySortManager.Init();
            PlayerEntry.EntryInit();
            LocalPlayerEntry.EntryInit();
        }


        internal override void VRChat_OnUiManagerInit()
        {

            // TODO: Add opacity options, maybe color too, (maybe even for each stage of ping and fps??)
            // TODO: add indicator for those in hearing distance

            MenuManager.LoadAssetBundle();

            // Initialize submenu for the list 
            //MenuManager.CreateMainSubMenu();


            // TODO: Make this AstroButtonAPI (Port Entire MenuManager TO AstroButtonAPI)
            // MenuManager.OnUiManagerInit();
            // MenuManager.CreateSortPages();
            // MenuManager.CreateSubMenus();
            // MenuManager.CreateGeneralInfoSubMenus();
            // MenuManager.AdjustSubMenus();

            // This is kinda a mess but whatever
            MenuManager.AddMenuListeners();


            PlayerListConfig.OnConfigChange(false);
            ModConsole.DebugLog("PlayerList UI Initialized!");
        }




        
    }
}
