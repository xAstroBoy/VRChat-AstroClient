namespace AstroClient.ItemTweakerV2.Submenus
{
    using AstroClient.Components;
    using AstroClient.ItemTweakerV2.Selector;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using RubyButtonAPI;
    using System;
    using UnityEngine;

    internal class ForcesSubmenu : Tweaker_Events
    {
        internal static void Init_ForceSubMenu(QMNestedButton menu, float x, float y, bool btnHalf)
        {
            var ForceSubMenu = new QMNestedButton(menu, x, y, "Forces", "You have the Force! Dont abuse it! <3!", null, null, null, null, btnHalf);

            Pickup_IsHeldStatus = new QMSingleButton(ForceSubMenu, 0, -1.5f, "Held : No", null, "See if Pickup is held or not.", null, null, true);

            Pickup_CurrentObjectHolder = new QMSingleButton(ForceSubMenu, 0, -1, "Current holder : null", null, "Who is the current object Holder.", null, null, false);
            Pickup_CurrentObjectHolder.SetResizeTextForBestFit(true);

            Pickup_CurrentObjectOwner = new QMSingleButton(ForceSubMenu, 5, -1, "Current Owner : null", null, "Who is the current object owner.", null, null, false);
            Pickup_CurrentObjectOwner.SetResizeTextForBestFit(true);

            ForceAmnt1 = new QMSingleButton(ForceSubMenu, 0, 0, "Force : " + Force, () => { Force = DefaultForce; }, string.Empty, null, null);
            SpinForceAmnt1 = new QMSingleButton(ForceSubMenu, 0, 1, "Spin Force : " + SpinForce, () => { SpinForce = DefaultSpinForce; }, string.Empty, null, null);

            QMNestedButton ForceAddControl = new QMNestedButton(ForceSubMenu, 5, 0, "Tweak Force Amounts", "Force Tweaker Menu!", null, null, null, null);

            ForceAmnt2 = new QMSingleButton(ForceAddControl, 0, 0, "Force : " + Force, () => { Force = DefaultForce; }, string.Empty, null, null);
            SpinForceAmnt2 = new QMSingleButton(ForceAddControl, 0, 1, "Spin Force : " + SpinForce, () => { SpinForce = DefaultSpinForce; }, string.Empty, null, null);

            ForceSlider = new QMSlider(QuickMenuUtils.QuickMenu.transform.Find(ForceAddControl.GetMenuName()), "Force Power :", 150, -720, delegate (float value)
            {
                Force = (int)value;
            }, DefaultForce, 1000, 1, true);
            ForceSlider.Slider.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
            ForceSlider.SetTextLabel("");
            Force = DefaultForce;

            SpinForceSlider = new QMSlider(QuickMenuUtils.QuickMenu.transform.Find(ForceAddControl.GetMenuName()), "Spin Power : ", 150, -1120, delegate (float value)
            {
                SpinForce = (int)value;
            }, DefaultSpinForce, 1000, 1, true);
            SpinForceSlider.Slider.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
            SpinForceSlider.SetTextLabel("");
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

        internal override void OnPickupController_OnUpdate(PickupController control)
        {
            if (control != null)
            {
                if (Pickup_IsHeldStatus != null)
                {
                    Pickup_IsHeldStatus.SetButtonText(control.Get_IsHeld_ButtonText());
                    Pickup_IsHeldStatus.SetTextColor(control.Get_IsHeld_ButtonColor());
                }
                if (Pickup_CurrentObjectOwner != null)
                {
                    Pickup_CurrentObjectOwner.SetButtonText(control.Get_PickupOwner_ButtonText());
                }
                if (Pickup_CurrentObjectHolder != null)
                {
                    Pickup_CurrentObjectHolder.SetButtonText(control.Get_IsHeldBy_ButtonText());
                }
            }
        }

        private static QMSingleButton Pickup_IsHeldStatus { get; set; }
        private static QMSingleButton Pickup_CurrentObjectHolder { get; set; }
        private static QMSingleButton Pickup_CurrentObjectOwner { get; set; }
        internal static QMSlider ForceSlider { get; private set; }
        internal static QMSlider SpinForceSlider { get; private set; }

        internal static QMSingleButton ForceAmnt1;

        internal static QMSingleButton ForceAmnt2;
        internal static QMSingleButton SpinForceAmnt1;
        internal static QMSingleButton SpinForceAmnt2;

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
                if (ForceAmnt2 != null)
                {
                    ForceAmnt2.SetButtonText("Force : " + value.ToString());
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
                if (SpinForceAmnt2 != null)
                {
                    SpinForceAmnt2.SetButtonText("Spin Force : " + SpinForce.ToString());
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