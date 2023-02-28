using AstroClient.ClientActions;
using AstroClient.Spawnables;
using AstroClient.xAstroBoy.Utility;

namespace AstroClient.ClientUI.ActionMenu
{
    using Gompoc.ActionMenuAPI.Api;
    using System.Drawing;

    internal class SpawnableModule : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnApplicationStart += OnApplicationStart;
        }

        private void OnApplicationStart()
        {
            AMUtils.AddToModsFolder("Spawnable Items", () =>
            {
                CustomSubMenu.AddButton("Spawn Space Shuttle", () =>
                {
                    AstroJetPack.SpawnSpaceShuttle();
                }, ClientResources.Loaders.Icons.shuttle);

                CustomSubMenu.AddSubMenu("Jetpacks", () =>
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
                    CustomSubMenu.AddToggle("Adjust Based of avatar size", AstroJetPack.AdjustBasedOffAvatarSize, value => AstroJetPack.AdjustBasedOffAvatarSize = value);
                    CustomSubMenu.AddToggle("Disable Thruster Slowdown", AstroJetPack.DisableThrusterSlowDown, value => AstroJetPack.DisableThrusterSlowDown = value);

                    CustomSubMenu.AddButton($"Increase Jetpack Force Current : {AstroJetPack.Jetpack_Force_Current}", () =>
                    {
                        AstroJetPack.SetJetpackMovementForce(AstroJetPack.Jetpack_Force_Current + AstroJetPack.Jetpack_Force_Default);
                    }, null);
                    CustomSubMenu.AddButton($"Increase Thruster Force Current : {AstroJetPack.Thruster_Force_Current}", () =>
                    {
                        AstroJetPack.SetThrusterMovementForce(AstroJetPack.Thruster_Force_Current + AstroJetPack.Thruster_Force_Default);
                    }, null);
                    CustomSubMenu.AddButton($"Set Jetpacks Default Speeds", () =>
                    {
                        AstroJetPack.RestoreJetpackForces();
                    }, null);
                });

                CustomSubMenu.AddSubMenu("Grapples", () =>
                {
                    CustomSubMenu.AddButton("Spawn Grapple", () =>
                    {
                        if (GameInstances.LocalPlayer.IsInVR())
                        {
                            Grapple.SpawnVR();
                        }
                        else
                        {
                            // currently not implemented .
                        }
                    }, null);
                    CustomSubMenu.AddToggle("Pickup Tether Grab", Grapple.ManipulateRigidbodies, value => Grapple.ManipulateRigidbodies = value);


                });
            }, ClientResources.Loaders.Icons.shuttle);

            Log.Write("Spawnable Module is ready!", Color.Green);
        }
    }
}