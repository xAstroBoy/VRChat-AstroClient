using System;
using AstroClient.Tools.Extensions.Components_exts;
using AstroClient.Tools.ObjectEditor;
using AstroClient.Tools.World;
using AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI;

namespace AstroClient.ClientUI.QuickMenuGUI.Menus.Quickmenu
{
    internal class WorldPickupsBtn
    {
        internal static void InitButtons(QMGridTab menu)
        {
            var sub = new QMNestedGridMenu(menu, "World Pickup Control", "Pickup Control");
            _ = new QMSingleButton(sub, "Reveal all world pickups", new Action(GameObjectMenu.EnableAllWorldPickups), "Enables all world pickups!");
            _ = new QMSingleButton(sub, "Hide all world pickups", new Action(GameObjectMenu.DisableAllWorldPickups), "Disables all world pickups!");

            new QMSingleButton(sub, "Restore Original pickups pos (Revert Rigidbody Edits)", () => { GameObjectMenu.TeleportPickupsToTheirDefaultPosition(true); }, "Restores all Pickups Original Position!");
            new QMSingleButton(sub, "Restore Original pickups pos (Dont Revert Rigidbody Edits)", () => { GameObjectMenu.TeleportPickupsToTheirDefaultPosition(false); }, "Restores all Pickups Original Position!");
           // _ = new QMSingleButton(sub, "Clear QPens Drawing Globally", new Action(QVPensUtils.ResetQPensGlobal), "Clears QPens Globally");
            _ = new QMSingleButton(sub, "Allow Theft Globally", () => { WorldUtils_Old.Get_Pickups().Pickup_Set_DisallowTheft(false); }, "Allows Theft");
            _ = new QMSingleButton(sub, "Disallow Theft Globally", () => { WorldUtils_Old.Get_Pickups().Pickup_Set_DisallowTheft(true); }, "Blocks Theft");

            _ = new QMSingleButton(sub, "Enable World Gravity On kinematic Pickups", () => { ObjectMiscOptions.DisablePickupKinematic(true); }, "Kinematic Remover");
            _ = new QMSingleButton(sub, "Enable Gravity 0G On kinematic Pickups ", () => { ObjectMiscOptions.DisablePickupKinematic(false); }, "Kinematic Remover");

            _ = new QMSingleButton(sub, "Enable World Gravity on All Pickups", () => { ObjectMiscOptions.SetGravityOnWorldPickups(true); }, "Gravity Toggler");
            _ = new QMSingleButton(sub, "Disable Gravity on All Pickups ", () => { ObjectMiscOptions.SetGravityOnWorldPickups(false); }, "Space Mode for all pickups");

            _ = new QMSingleButton(sub, "Pickup Hulk Toss", () => { WorldUtils_Old.Get_Pickups().Pickup_Set_ThrowVelocityBoostScale(9.5f); }, "Toss Pickups with Extreme Velocity!");


        }
    }
}