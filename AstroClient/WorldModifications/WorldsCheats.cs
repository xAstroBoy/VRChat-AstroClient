using AstroClient.WorldModifications.WorldHacks.Ostinyo;

namespace AstroClient.WorldModifications
{
    #region Imports

    using ClientResources;
    using ClientResources.Loaders;
    using WorldHacks;
    using WorldHacks.Jar.AmongUS;
    using WorldHacks.Jar.KitchenCooks;
    using WorldHacks.Jar.Murder2;
    using WorldHacks.Jar.Murder4;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    #endregion Imports

    internal class WorldsCheats : AstroEvents
    {
        internal static void InitButtons(int index)
        {
            QMGridTab WorldCheats = new QMGridTab(index, "WorldCheats Menu", null, null, null, Icons.thief_sprite);
            Murder2Cheats.Murder2CheatsButtons(WorldCheats);
            Murder4Cheats.Murder4CheatsButtons(WorldCheats);
            AmongUSCheats.AmongUSCheatsButtons(WorldCheats);
            KitchenCooksCheats.InitCheatsMenu(WorldCheats);
            //VRChatHub.InitButtons(WorldCheats);
            //FreezeTag.InitButtons(WorldCheats, 1, 2, true);
            AimFactory.InitButtons(WorldCheats);
            BOMBERio.InitButtons(WorldCheats);
            BClubWorld.InitButtons(WorldCheats);
            JustHParty.InitButtons(WorldCheats);
            VoidClub.InitButtons(WorldCheats);
            FBTHeaven.InitButtons(WorldCheats);
            SuperTowerDefense.InitButtons(WorldCheats);
            //PoolParlor.InitButtons(WorldCheats);
            UdonTycoon.InitButtons(WorldCheats);
            ClickerGame.InitButtons(WorldCheats);
            PuttPuttPond.InitButtons(WorldCheats);
            GhostGame.InitButtons(WorldCheats);
        }
    }
}