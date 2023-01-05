using AstroClient.ClientActions;
using AstroClient.ClientUI.QuickMenuGUI.ESP;
using AstroClient.Spawnables;

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
            AMUtils.AddToModsFolder("Jetpacks", () =>
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
                CustomSubMenu.AddToggle("Sit On Jetpack Spawn", AstroJetPack.SitOnJetpackOnSpawn, value => AstroJetPack.SitOnJetpackOnSpawn = value);
                //CustomSubMenu.AddSubMenu("Jetpack", () =>
                //{
                //});
                //CustomSubMenu.AddButton("Spawn 8 Ball", () =>
                //{
                //    EightBall.Spawn();
                //}, null);
                CustomSubMenu.AddToggle("Adjust Based of avatar size", AstroJetPack.AdjustBasedOffAvatarSize, value => AstroJetPack.AdjustBasedOffAvatarSize = value);
                CustomSubMenu.AddToggle("Disable Thruster Slowdown", AstroJetPack.DisableThrusterSlowDown, value => AstroJetPack.DisableThrusterSlowDown = value);


            });

            Log.Write("Spawnable Module is ready!", Color.Green);
        }
    }
}