﻿namespace AstroClient.ClientUI.QuickMenuButtons
{
    using System;
    using AstroButtonAPI;
    using AstroLibrary.Extensions;
    using GameObjectDebug;

    internal class WorldPickupsBtn
    {
        internal static void InitButtons(QMTabMenu menu, float x, float y, bool btnHalf)
        {
            var sub = new QMNestedButton(menu, x, y, "Pickup Control", "Pickup Control", null, null, null, null, btnHalf);
            _ = new QMSingleButton(sub, 1, 0, "Reveal all world pickups", new Action(GameObjectMenu.EnableAllWorldPickups), "Enables all world pickups!", null, null);
            _ = new QMSingleButton(sub, 2, 0, "Hide all world pickups", new Action(GameObjectMenu.DisableAllWorldPickups), "Disables all world pickups!", null, null);
            new QMSingleButton(sub, 3, 0, "Restore Original pickups pos (Revert Rigidbody Edits)", () => { GameObjectMenu.TeleportPickupsToTheirDefaultPosition(true); }, "Restores all Pickups Original Position!", null, null, true);
            new QMSingleButton(sub, 3, 0.5f, "Restore Original pickups pos (Dont Revert Rigidbody Edits)", () => { GameObjectMenu.TeleportPickupsToTheirDefaultPosition(false); }, "Restores all Pickups Original Position!", null, null, true);
            _ = new QMSingleButton(sub, 1, 1, "Clear QPens Drawing Globally", new Action(QVPensUtils.ResetQPensGlobal), "Clears QPens Globally", null, null);
            _ = new QMSingleButton(sub, 2, 1, "Allow Theft Globally", () => { WorldUtils_Old.Get_Pickups().Pickup_Set_DisallowTheft(false); }, "Allows Theft", null, null, true);
            _ = new QMSingleButton(sub, 2, 1.5f, "Disallow Theft Globally", () => { WorldUtils_Old.Get_Pickups().Pickup_Set_DisallowTheft(true); }, "Blocks Theft", null, null, true);
            _ = new QMSingleButton(sub, 3, 1f, "Enable World Gravity On kinematic Pickups", () => { ObjectMiscOptions.DisablePickupKinematic(true); }, "Kinematic Remover", null, null, true);
            _ = new QMSingleButton(sub, 3, 1.5f, "Enable Gravity 0G On kinematic Pickups ", () => { ObjectMiscOptions.DisablePickupKinematic(false); }, "Kinematic Remover", null, null, true);
        }
    }
}