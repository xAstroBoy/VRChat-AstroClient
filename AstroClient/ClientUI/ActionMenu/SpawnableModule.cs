using AstroClient.ClientActions;
using AstroClient.ClientUI.QuickMenuGUI.ESP;
using AstroClient.Spawnables.Enderpearl;

namespace AstroClient.ClientUI.ActionMenu
{
    using System.Drawing;
    using Gompoc.ActionMenuAPI.Api;

    internal class SpawnableModule : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnApplicationStart += OnApplicationStart;
        }

        private void OnApplicationStart()
        {
            AMUtils.AddToModsFolder("Spawnables", () =>
            {
                CustomSubMenu.AddButton("Spawn VR Jetpack", () =>
                {
                    AstroJetPack.SpawnVRJetpack();
                }, null);
                CustomSubMenu.AddButton("Spawn Desktop Jetpack", () =>
                {
                    AstroJetPack.SpawnDesktopJetpack();
                }, null);
                CustomSubMenu.AddButton("Exit Jetpack Seat", () =>
                {
                    AstroJetPack.ExitJetpacks();
                }, null);

                //CustomSubMenu.AddSubMenu("Jetpack", () =>
                //{
                //});
                //CustomSubMenu.AddButton("Spawn 8 Ball", () =>
                //{
                //    EightBall.Spawn();
                //}, null);


            });

            Log.Write("Spawnable Module is ready!", Color.Green);
        }
    }
}