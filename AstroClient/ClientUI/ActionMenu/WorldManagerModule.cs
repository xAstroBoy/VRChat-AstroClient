using AstroClient.ClientActions;
using AstroClient.Tools.ObjectEditor;

namespace AstroClient.ClientUI.ActionMenu
{
    using Gompoc.ActionMenuAPI.Api;
    using System.Drawing;

    internal class WorldManagerModule : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnApplicationStart += OnApplicationStart;
        }

        private void OnApplicationStart()
        {
            AMUtils.AddToModsFolder("World Pickup Control", () =>
            {
                CustomSubMenu.AddButton("Restore Original pickups pos", () =>
                {
                    GameObjectMenu.TeleportPickupsToTheirDefaultPosition(false);
                }, null, false);
                CustomSubMenu.AddButton("Restore Original pickups pos & Revert Rigidbody Edits", () =>
                {
                    GameObjectMenu.TeleportPickupsToTheirDefaultPosition(true);
                }, null, false);
                CustomSubMenu.AddButton("Enable World Gravity On kinematic Pickups", () =>
                {
                    ObjectMiscOptions.DisablePickupKinematic(true);
                }, null, false);
                CustomSubMenu.AddButton("Enable Gravity 0G On kinematic Pickups", () =>
                {
                    ObjectMiscOptions.DisablePickupKinematic(false);
                }, null, false);
                CustomSubMenu.AddButton("Enable World Gravity on All Pickups", () =>
                {
                    ObjectMiscOptions.SetGravityOnWorldPickups(true);
                }, null, false);
                CustomSubMenu.AddButton("Disable Gravity on All Pickups", () =>
                {
                    ObjectMiscOptions.SetGravityOnWorldPickups(false);
                }, null, false);

                //CustomSubMenu.AddSubMenu("Pickups Controls", () =>
                //{

                //}, null, false, null);
            });

            Log.Write("ESP Module is ready!", Color.Green);
        }
    }
}