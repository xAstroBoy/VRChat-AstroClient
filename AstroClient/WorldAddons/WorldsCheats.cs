namespace AstroClient.WorldAddons
{
    #region Imports

    using ClientResources;
    using Supported_Worlds;
    using Supported_Worlds.Jar_Worlds;
    using xAstroBoy.AstroButtonAPI;

    #endregion Imports

    internal class WorldsCheats : AstroEvents
    {
        internal static void InitButtons(int index)
        {
            QMGridTab WorldCheats = new QMGridTab(index, "WorldCheats Menu", null, null, null, ClientResources.thief_sprite);
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