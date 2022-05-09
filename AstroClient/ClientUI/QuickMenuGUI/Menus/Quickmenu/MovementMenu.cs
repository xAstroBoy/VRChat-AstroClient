using AstroClient.ClientActions;

namespace AstroClient.ClientUI.Menu.Menus.Quickmenu
{
    #region Imports

    using AstroClient.Tools.Extensions;
    using Config;
    using Spawnables.Enderpearl;
    using System;
    using Tools.Player.Movement;
    using Tools.Player.Movement.Exploit;
    using Tools.Player.Movement.QuickMenu;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.Utility;

    #endregion Imports

    internal class MovementMenu : AstroEvents
    {

        internal static Action OnNoFallHeightLimitToggled { get; set; }

        internal override void RegisterToEvents()
        {
            ClientEventActions.OnRoomLeft += OnRoomLeft;
        }

        private void OnRoomLeft()
        {
            NoFallHeightLimit = false;
        }

        internal static void InitButtons(QMGridTab menu)
        {
            var temp = new QMNestedGridMenu(menu, "Movement Options", "Control Your Movements");
            JumpModifier.UnlimitedJumpToggle = new QMToggleButton(temp, "Unlimited Jumps", new Action(() => { JumpModifier.IsUnlimitedJumpActive = true; }), new Action(() => { JumpModifier.IsUnlimitedJumpActive = false; }), "Allows you to Unlimited jump");
            JumpModifier.UnlimitedJumpToggle.SetToggleState(ConfigManager.Movement.UnlimitedJump);
            JumpModifier.RocketJumpToggle = new QMToggleButton(temp, "Rocket Jump", new Action(() => { JumpModifier.IsRocketJumpActive = true; }), new Action(() => { JumpModifier.IsRocketJumpActive = false; }), "Allows you to Unlimited jump");
            JumpModifier.RocketJumpToggle.SetToggleState(ConfigManager.Movement.RocketJump);

            JumpModifier.JumpOverrideToggle = new QMToggleButton(temp, "Jump Override", new Action(() => { JumpModifier.IsJumpOverriden = true; }), new Action(() => { JumpModifier.IsJumpOverriden = false; }), "Allows you to Bypass jump Block in certain worlds.", null, null, null, false);
            QMFreeze.FreezePlayerOnQMOpenToggle = new QMToggleButton(temp, "Freeze On QM open", () => { QMFreeze.FreezePlayerOnQMOpen = true; }, () => { QMFreeze.FreezePlayerOnQMOpen = false; }, "Freeze Player On QuickMenu Open event.", null, null, null, false);
            QMFreeze.FreezePlayerOnQMOpenToggle.SetToggleState(ConfigManager.Movement.QMFreeze);
            new QMSingleButton(temp, "Spawn Enderpearl", () => { AstroEnderPearl.SpawnEnderPearl(); }, "Spawn a EnderPearl.");

            ToggleGhost = new QMToggleButton(temp, "Ghost", () => { MovementSerializer.SerializerActivated = true; }, () => { MovementSerializer.SerializerActivated = false; }, "Enable/Disable Ghost");
            ToggleGhost.SetToggleState(MovementSerializer.SerializerActivated);

            ToggleGhost = new QMToggleButton(temp, "Ghost", () => { MovementSerializer.SerializerActivated = true; }, () => { MovementSerializer.SerializerActivated = false; }, "Enable/Disable Ghost");
            ToggleGhost.SetToggleState(MovementSerializer.SerializerActivated);

            ToggleNoFallHeightLimiter = new QMToggleButton(temp, "Disable Fall Height Limit", () => { NoFallHeightLimit = true; }, () => { NoFallHeightLimit = false; }, "Disables Height Limit fall, allowing you to fall below default limit set by the scene");
            //ToggleFly = new QMToggleButton(SubMenu, -0.6f, -1, "Fly", () => { Flight.FlyEnabled = true; }, "Fly", () => { Flight.FlyEnabled = false; }, "Enable/Disable Flight", UnityEngine.Color.green, UnityEngine.Color.red, null, Flight.FlyEnabled, true);
            //ToggleNoClip = new QMToggleButton(SubMenu, -0.6f, -0.5f, "NoClip", () => { Flight.NoClipEnabled = true; }, "NoClip", () => { Flight.NoClipEnabled = false; }, "Enable/Disable NoClip", UnityEngine.Color.green, UnityEngine.Color.red, null, Flight.NoClipEnabled, true);
        }

        internal static QMToggleButton ToggleFly;

        internal static QMToggleButton ToggleNoClip;

        internal static QMToggleButton ToggleGhost;
        internal static QMToggleButton ToggleNoFallHeightLimiter;

        private static bool _NoFallHeightLimit = false;

        internal static bool NoFallHeightLimit
        {
            get => _NoFallHeightLimit;
            set
            {
                if (GameInstances.CurrentUser != null)
                {
                    if (value)
                    {
                        // this is more than enought lol
                        SceneUtils.Set_Scene_RespawnHeightY(-99999);
                        GameInstances.CurrentUser.Set_RespawnHeightY(-99999); 
                    }
                    else
                    {
                        SceneUtils.Restore_DefaultRespawnHeightY();
                        GameInstances.CurrentUser.Set_RespawnHeightY(SceneUtils.RespawnHeightY);
                    }
                }
                else
                {
                    value = false;
                }
                _NoFallHeightLimit = value;
                if(ToggleNoFallHeightLimiter != null)
                {
                    ToggleNoFallHeightLimiter.SetToggleState(value);
                }
                OnNoFallHeightLimitToggled.SafetyRaise();
            }
        }
    }
}