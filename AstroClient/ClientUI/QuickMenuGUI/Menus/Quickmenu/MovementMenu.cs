﻿namespace AstroClient.ClientUI.Menu.Menus.Quickmenu
{
    #region Imports

    using System;
    using Config;
    using Spawnables.Enderpearl;
    using Tools.Player.Movement;
    using Tools.Player.Movement.Exploit;
    using Tools.Player.Movement.QuickMenu;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    #endregion Imports

    internal static class MovementMenu
    {
        internal static void InitButtons(QMGridTab menu)
        {
            var temp = new QMNestedGridMenu(menu, "Movement Options", "Control Your Movements");
            JumpModifier.UnlimitedJumpToggle = new QMToggleButton(temp, 1, 0, "Unlimited Jumps", new Action(() => { JumpModifier.IsUnlimitedJumpActive = true; }), new Action(() => { JumpModifier.IsUnlimitedJumpActive = false; }), "Allows you to Unlimited jump");
            JumpModifier.UnlimitedJumpToggle.SetToggleState(ConfigManager.Movement.UnlimitedJump);
            JumpModifier.RocketJumpToggle = new QMToggleButton(temp, 1, 0.5f, "Rocket Jump", new Action(() => { JumpModifier.IsRocketJumpActive = true; }), new Action(() => { JumpModifier.IsRocketJumpActive = false; }), "Allows you to Unlimited jump");
            JumpModifier.RocketJumpToggle.SetToggleState(ConfigManager.Movement.RocketJump);

            JumpModifier.JumpOverrideToggle = new QMToggleButton(temp, 2, 0, "Jump Override", new Action(() => { JumpModifier.IsJumpOverriden = true; }), new Action(() => { JumpModifier.IsJumpOverriden = false; }), "Allows you to Bypass jump Block in certain worlds.", null, null, null, false);
            QMFreeze.FreezePlayerOnQMOpenToggle = new QMToggleButton(temp, 3, 0, "Freeze On QM open", () => { QMFreeze.FreezePlayerOnQMOpen = true; }, () => { QMFreeze.FreezePlayerOnQMOpen = false; }, "Freeze Player On QuickMenu Open event.", null, null, null, false);
            QMFreeze.FreezePlayerOnQMOpenToggle.SetToggleState(ConfigManager.Movement.QMFreeze);
            new QMSingleButton(temp, 2, 1f, "Spawn Enderpearl", () => { AstroEnderPearl.SpawnEnderPearl(); }, "Spawn a EnderPearl.", null, null, true);

            ToggleGhost = new QMToggleButton(temp, 0f, 0f, "Ghost", () => { MovementSerializer.SerializerActivated = true; }, () => { MovementSerializer.SerializerActivated = false; }, "Enable/Disable Ghost");
            ToggleGhost.SetToggleState(MovementSerializer.SerializerActivated);

            //ToggleFly = new QMToggleButton(SubMenu, -0.6f, -1, "Fly", () => { Flight.FlyEnabled = true; }, "Fly", () => { Flight.FlyEnabled = false; }, "Enable/Disable Flight", UnityEngine.Color.green, UnityEngine.Color.red, null, Flight.FlyEnabled, true);
            //ToggleNoClip = new QMToggleButton(SubMenu, -0.6f, -0.5f, "NoClip", () => { Flight.NoClipEnabled = true; }, "NoClip", () => { Flight.NoClipEnabled = false; }, "Enable/Disable NoClip", UnityEngine.Color.green, UnityEngine.Color.red, null, Flight.NoClipEnabled, true);
        }

        internal static QMToggleButton ToggleFly;

        internal static QMToggleButton ToggleNoClip;

        internal static QMToggleButton ToggleGhost;
    }
}