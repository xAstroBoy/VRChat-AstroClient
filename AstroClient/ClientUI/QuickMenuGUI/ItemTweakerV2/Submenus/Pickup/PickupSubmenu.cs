﻿using AstroClient.ClientActions;

namespace AstroClient.ClientUI.Menu.ItemTweakerV2.Submenus.Pickup
{
    using System;
    using AstroMonos.Components.Tools;
    using Selector;
    using Tools.Extensions.Components_exts;
    using UnityEngine;
    using VRC.SDKBase;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.AstroButtonAPI.Tools;
    using xAstroBoy.AstroButtonAPI.WingsAPI;
    using xAstroBoy.Utility;

    internal class PickupSubmenu : AstroEvents
    {
        private static QMNestedButton PickupEditor { get; set; }
        internal override void RegisterToEvents()
        {
            TweakerEventActions.OnPickupControllerSelected += OnPickupController_Selected;
            TweakerEventActions.OnPickupControllerPropertyChanged += OnPickupController_PropertyChanged;
            TweakerEventActions.OnPickupController_OnUpdate += OnPickupController_OnUpdate;

        }
        internal static void Init_PickupSubMenu(QMTabMenu menu, float x, float y, bool btnHalf)
        {
            PickupEditor = new QMNestedButton(menu, x, y, "Pickup Property", "Pickup Property Editor Menu!", null, null, null, null, btnHalf);

            _ = new QMSingleButton(PickupEditor, 1, 0, "Pickup Orientation", null, "Pickup Orientation", null, null, true);
            Pickup_PickupOrientation_prop_any = new QMSingleButton(PickupEditor, 1, 0.5f, "Any", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Pickup_Set_PickupOrientation(VRC_Pickup.PickupOrientation.Any); }), "", null, null, true);
            Pickup_PickupOrientation_prop_Grip = new QMSingleButton(PickupEditor, 1, 1f, "Grip", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Pickup_Set_PickupOrientation(VRC_Pickup.PickupOrientation.Grip); }), "", null, null, true);
            Pickup_PickupOrientation_prop_Gun = new QMSingleButton(PickupEditor, 1, 1.5f, "Gun", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Pickup_Set_PickupOrientation(VRC_Pickup.PickupOrientation.Gun); }), "", null, null, true);

            var autohold = new QMSingleButton(PickupEditor, 2, 0, "Pickup AutoHoldMode", null, "Pickup AutoHoldMode", null, null, true);

            Pickup_AutoHoldMode_prop_AutoDetect = new QMSingleButton(PickupEditor, 2, 0.5f, "AutoDetect", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Pickup_Set_AutoHoldMode(VRC_Pickup.AutoHoldMode.AutoDetect); }), "", null, null, true);
            Pickup_AutoHoldMode_prop_Yes = new QMSingleButton(PickupEditor, 2, 1f, "Yes", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Pickup_Set_AutoHoldMode(VRC_Pickup.AutoHoldMode.Yes); }), "", null, null, true);
            Pickup_AutoHoldMode_prop_No = new QMSingleButton(PickupEditor, 2, 1.5f, "No", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Pickup_Set_AutoHoldMode(VRC_Pickup.AutoHoldMode.No); }), "", null, null, true);
            InitProximitySliderSubmenu(PickupEditor, 3, 0, true);
            Pickup_allowManipulationWhenEquipped = new QMToggleButton(PickupEditor, 4, 0, "Allow Manipulation Equip", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Pickup_Set_allowManipulationWhenEquipped(true); }), "Disallow Manipulation Equip", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Pickup_Set_allowManipulationWhenEquipped(false); }), "Control Manipulation Equip property", null, null, null);
            Pickup_pickupable = new QMToggleButton(PickupEditor, 4, 1, "Pickupable", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Pickup_Set_Pickupable(true); }), "Not Pickupable", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Pickup_Set_Pickupable(false); }), "Control Pickupable Property", null, null, null);
            Pickup_DisallowTheft = new QMToggleButton(PickupEditor, 4, 2, "Block Theft", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Pickup_Set_DisallowTheft(true); }), "Allow Theft", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Pickup_Set_DisallowTheft(false); }), "Control DisallowTheft property", null, null, null);
        }

        internal static void InitProximitySliderSubmenu(QMNestedButton menu, float x, float y, bool btnHalf)
        {
            var slider = new QMNestedButton(menu, x, y, "Proximity", "Pickup Proximity Slider Editor!", null, null, null, null, btnHalf);
            PickupProximitySlider = new QMSlider(QuickMenuUtils.QuickMenu.transform.Find(slider.GetMenuName()), "Proximity : ", delegate (float value)
            {
                Tweaker_Object.GetGameObjectToEdit().Pickup_Set_proximity((int)value);
            }, "Set Pickup Proximity",  5, 1000, false, true);
            PickupProximitySlider.gameObject.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
        }

        private void OnPickupController_Selected(PickupController control)
        {
            UpdatePickupButtons(control);
        }

        private void OnPickupController_PropertyChanged(PickupController control)
        {
            UpdatePickupButtons(control);
        }

        private void OnPickupController_OnUpdate(PickupController control)
        {
            UpdatePickupButtons(control);
        }

        // TODO : Support Nulls (Reset mechanism)
        private static void UpdatePickupButtons(PickupController controller)
        {
            if (controller != null)
            {
                if (controller.HasPickupComponent())
                {
                    if (HasPickupComponent != null)
                    {
                        HasPickupComponent.SetTextColor(Color.green);
                    }
                    if (Pickup_IsEditMode != null)
                    {
                        if (controller.EditMode)
                        {
                            Pickup_IsEditMode.SetButtonText("Edit Mode : ON");
                            Pickup_IsEditMode.SetTextColor(Color.green);
                        }
                        else
                        {
                            Pickup_IsEditMode.SetButtonText("Edit Mode : OFF");
                            Pickup_IsEditMode.SetTextColor(Color.red);
                        }
                    }
                    if (Pickup_allowManipulationWhenEquipped != null)
                    {
                        Pickup_allowManipulationWhenEquipped.SetToggleState(controller.allowManipulationWhenEquipped);
                    }
                    if (Pickup_DisallowTheft != null)
                    {
                        Pickup_DisallowTheft.SetToggleState(controller.DisallowTheft);
                    }
                    if (Pickup_pickupable != null)
                    {
                        Pickup_pickupable.SetToggleState(controller.pickupable);
                    }
                    if (Pickup_PickupOrientation_prop_any != null)
                    {
                        if (controller.orientation == VRC_Pickup.PickupOrientation.Any)
                        {
                            Pickup_PickupOrientation_prop_any.SetTextColor(Color.green);
                        }
                        else
                        {
                            Pickup_PickupOrientation_prop_any.SetTextColor(Color.red);
                        }
                    }
                    if (Pickup_PickupOrientation_prop_Grip != null)
                    {
                        if (controller.orientation == VRC_Pickup.PickupOrientation.Grip)
                        {
                            Pickup_PickupOrientation_prop_Grip.SetTextColor(Color.green);
                        }
                        else
                        {
                            Pickup_PickupOrientation_prop_Grip.SetTextColor(Color.red);
                        }
                    }
                    if (Pickup_PickupOrientation_prop_Gun != null)
                    {
                        if (controller.orientation == VRC_Pickup.PickupOrientation.Gun)
                        {
                            Pickup_PickupOrientation_prop_Gun.SetTextColor(Color.green);
                        }
                        else
                        {
                            Pickup_PickupOrientation_prop_Gun.SetTextColor(Color.red);
                        }
                    }
                    if (Pickup_AutoHoldMode_prop_AutoDetect != null)
                    {
                        if (controller.AutoHold == VRC_Pickup.AutoHoldMode.AutoDetect)
                        {
                            Pickup_AutoHoldMode_prop_AutoDetect.SetTextColor(Color.green);
                        }
                        else
                        {
                            Pickup_AutoHoldMode_prop_AutoDetect.SetTextColor(Color.red);
                        }
                    }
                    if (Pickup_AutoHoldMode_prop_Yes != null)
                    {
                        if (controller.AutoHold == VRC_Pickup.AutoHoldMode.Yes)
                        {
                            Pickup_AutoHoldMode_prop_Yes.SetTextColor(Color.green);
                        }
                        else
                        {
                            Pickup_AutoHoldMode_prop_Yes.SetTextColor(Color.red);
                        }
                    }
                    if (Pickup_AutoHoldMode_prop_No != null)
                    {
                        if (controller.AutoHold == VRC_Pickup.AutoHoldMode.No)
                        {
                            Pickup_AutoHoldMode_prop_No.SetTextColor(Color.green);
                        }
                        else
                        {
                            Pickup_AutoHoldMode_prop_No.SetTextColor(Color.red);
                        }
                    }
                    //if (PickupProximitySlider != null)
                    //{
                    //    PickupProximitySlider.SetValue(controller.proximity);
                    //}
                    return;
                }
                //else
                //{
                //    Log.Debug($"Unable to Find PickupController on Object : {controller.ButtonObject.name}");
                //}
            }

            HasPickupComponent.SetTextColor(Color.red);
            if (Pickup_IsEditMode != null)
            {
                Pickup_IsEditMode.SetButtonText("Edit Mode : OFF");
                Pickup_IsEditMode.SetTextColor(Color.red);
            }
            if (Pickup_allowManipulationWhenEquipped != null)
            {
                Pickup_allowManipulationWhenEquipped.SetToggleState(false);
            }
            if (Pickup_DisallowTheft != null)
            {
                Pickup_DisallowTheft.SetToggleState(false);
            }
            if (Pickup_pickupable != null)
            {
                Pickup_pickupable.SetToggleState(false);
            }
            if (Pickup_PickupOrientation_prop_any != null)
            {
                Pickup_PickupOrientation_prop_any.SetTextColor(Color.red);
            }
            if (Pickup_PickupOrientation_prop_Grip != null)
            {
                Pickup_PickupOrientation_prop_Grip.SetTextColor(Color.red);
            }
            if (Pickup_PickupOrientation_prop_Gun != null)
            {
                Pickup_PickupOrientation_prop_Gun.SetTextColor(Color.red);
            }
            if (Pickup_AutoHoldMode_prop_AutoDetect != null)
            {
                Pickup_AutoHoldMode_prop_AutoDetect.SetTextColor(Color.red);
            }
            if (Pickup_AutoHoldMode_prop_Yes != null)
            {
                Pickup_AutoHoldMode_prop_Yes.SetTextColor(Color.red);
            }
            if (Pickup_AutoHoldMode_prop_No != null)
            {
                Pickup_AutoHoldMode_prop_No.SetTextColor(Color.red);
            }
            if (PickupProximitySlider != null)
            {
                PickupProximitySlider.SetValue(0);
            }
        }

        internal static void InitWings(QMWings main)
        {
            PickupEditorWings = new QMWings(PickupEditor, main, "Pickup Modifier", "Modify Pickup Properties", null);

            HasPickupComponent = new QMWingSingleButton(PickupEditorWings, "Force Pickup Component", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Pickup_Set_ForceComponent(); }), "Forces Pickup component in case there's none.");
            Pickup_IsEditMode = new QMWingSingleButton(PickupEditorWings, "Edit Mode", null, "Shows if Pickup properties are currently being overriden.");
            new QMWingSingleButton(PickupEditorWings, "Reset Properties", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Pickup_RestoreOriginalProperties(); }), "Revert Pickup Properties Edits. (disabling editmode)");

        }


        internal static QMWings PickupEditorWings;
        internal static QMWingSingleButton HasPickupComponent { get; private set; }
        internal static QMWingSingleButton Pickup_IsEditMode { get; private set; }

        internal static QMSingleButton Pickup_PickupOrientation_prop_any { get; private set; }
        internal static QMSingleButton Pickup_PickupOrientation_prop_Grip { get; private set; }
        internal static QMSingleButton Pickup_PickupOrientation_prop_Gun { get; private set; }

        internal static QMSingleButton Pickup_AutoHoldMode_prop_AutoDetect { get; private set; }
        internal static QMSingleButton Pickup_AutoHoldMode_prop_Yes { get; private set; }
        internal static QMSingleButton Pickup_AutoHoldMode_prop_No { get; private set; }

        internal static QMToggleButton Pickup_allowManipulationWhenEquipped { get; private set; }
        internal static QMToggleButton Pickup_pickupable { get; private set; }
        internal static QMToggleButton Pickup_DisallowTheft { get; private set; }

        internal static QMSlider PickupProximitySlider { get; private set; }
    }
}