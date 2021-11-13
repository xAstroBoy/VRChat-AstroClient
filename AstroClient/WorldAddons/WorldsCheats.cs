namespace AstroClient.Worlds
{
    #region Imports

    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using AstroButtonAPI;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Finder;
    using CheetoLibrary;
    using UnityEngine;
    using Variables;
    using World.Hub;
    using WorldAddons;

    #endregion Imports

    internal class WorldsCheats : GameEvents
    {
        internal static void InitButtons(int index)
        {
            QMGridTab WorldCheats = new QMGridTab(index, "WorldCheats Menu", null, null, null, CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.thief.png"));
            Murder2Cheats.Murder2CheatsButtons(WorldCheats);
            Murder4Cheats.Murder4CheatsButtons(WorldCheats);
            AmongUSCheats.AmongUSCheatsButtons(WorldCheats);
            VRChatHub.InitButtons(WorldCheats);
            //FreezeTag.InitButtons(WorldCheats, 1, 2, true);
            AimFactory.InitButtons(WorldCheats);
            BOMBERio.InitButtons(WorldCheats);
            BClubWorld.InitButtons(WorldCheats);
            JustHParty.InitButtons(WorldCheats);
            VoidClub.InitButtons(WorldCheats);
            FBTHeaven.InitButtons(WorldCheats);
            SuperTowerDefense.InitButtons(WorldCheats);
            PoolParlor.InitButtons(WorldCheats);
            UdonTycoon.InitButtons(WorldCheats);
        }
    }
}