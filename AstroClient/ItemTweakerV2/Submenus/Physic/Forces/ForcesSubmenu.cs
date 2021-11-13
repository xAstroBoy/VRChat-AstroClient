namespace AstroClient.ItemTweakerV2.Submenus
{
    using AstroButtonAPI;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using Selector;
    using System;

    internal class ForcesSubmenu : Tweaker_Events
    {
        internal static void Init_ForceSubMenu(QMNestedGridMenu menu, float x, float y, bool btnHalf)
        {
            var ForceSubMenu = new QMNestedButton(menu, x, y, "Forces", "You have the Force! Dont abuse it! <3!", null, null, null, null, btnHalf);

            ForceAmnt1 = new QMSingleButton(ForceSubMenu, 0, 0, "Force : " + Force, () => { Force = DefaultForce; }, string.Empty, null, null);
            SpinForceAmnt1 = new QMSingleButton(ForceSubMenu, 0, 1, "Spin Force : " + SpinForce, () => { SpinForce = DefaultSpinForce; }, string.Empty, null, null);

            QMNestedGridMenu ForceAddControl = new QMNestedGridMenu(ForceSubMenu, 5, 0, "Tweak Force Amounts", "Force Tweaker Menu!", null, null, null, null);

            ForceSlider = new QMSlider(ForceAddControl.ButtonsMenu.transform, "Force Power :", delegate (float value)
            {
                Force = (int)value;
            }, "Change Force", 1000, DefaultForce, true);
            Force = DefaultForce;

            SpinForceSlider = new QMSlider(ForceAddControl.ButtonsMenu.transform, "Spin Power : ", delegate (float value)
            {
                SpinForce = (int)value;
            }, "Change Spin Force", 1000, DefaultForce, true);
            SpinForce = DefaultSpinForce;

            _ = new QMSingleButton(ForceSubMenu, 5, 1, "Kill Any Object Forces", new Action(() => { Tweaker_Object.GetGameObjectToEdit().KillForces(); }), "Kill Obj Forces", null, null);
            var right = new QMSingleButton(ForceSubMenu, 4, 2, "→", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Right(); }), string.Empty, null, null);
            var left = new QMSingleButton(ForceSubMenu, 2, 2, "←", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Left(); }), string.Empty, null, null);
            var foward = new QMSingleButton(ForceSubMenu, 3, 1, "↑", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Foward(); }), string.Empty, null, null);
            var backward = new QMSingleButton(ForceSubMenu, 3, 2, "↓", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Backward(); }), string.Empty, null, null);

            _ = new QMSingleButton(ForceSubMenu, 1, 0, "Push", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Push(); }), string.Empty, null, null);
            _ = new QMSingleButton(ForceSubMenu, 2, 0, "Pull", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Pull(); }), string.Empty, null, null);
            _ = new QMSingleButton(ForceSubMenu, 1, 1, "Rotate X", new Action(() => { Tweaker_Object.GetGameObjectToEdit().SpinX(); }), string.Empty, null, null);
            _ = new QMSingleButton(ForceSubMenu, 2, 1, "Rotate Y", new Action(() => { Tweaker_Object.GetGameObjectToEdit().SpinY(); }), string.Empty, null, null);
            _ = new QMSingleButton(ForceSubMenu, 1, 2, "Rotate Z", new Action(() => { Tweaker_Object.GetGameObjectToEdit().SpinZ(); }), string.Empty, null, null);
        }

        internal static QMSlider ForceSlider { get; private set; }
        internal static QMSlider SpinForceSlider { get; private set; }

        internal static QMSingleButton ForceAmnt1;
        internal static QMSingleButton SpinForceAmnt1;

        private static float _Force;

        internal static float Force
        {
            get
            {
                return _Force;
            }
            set
            {
                _Force = value;
                if (ForceAmnt1 != null)
                {
                    ForceAmnt1.SetButtonText("Force : " + value.ToString());
                }
                if (ForceSlider != null)
                {
                    ForceSlider.SetValue(value);
                }
            }
        }

        private static float _SpinForce;

        internal static float SpinForce
        {
            get
            {
                return _SpinForce;
            }
            set
            {
                _SpinForce = value;
                if (SpinForceAmnt1 != null)
                {
                    SpinForceAmnt1.SetButtonText("Spin Force : " + SpinForce.ToString());
                }
                if (SpinForceSlider != null)
                {
                    SpinForceSlider.SetValue(value);
                }
            }
        }

        internal static readonly float DefaultForce = 1f;
        internal static readonly float DefaultSpinForce = 100f;
    }
}