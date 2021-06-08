namespace AstroClient.ItemTweakerV2.Submenus
{
	using AstroClient.Components;
	using AstroClient.Extensions;
	using AstroClient.GameObjectDebug;
	using AstroClient.ItemTweakerV2.Selector;
	using AstroClient.variables;
	using AstroLibrary;
	using AstroLibrary.Extensions;
	using RubyButtonAPI;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	using UnityEngine;
	using VRC.SDK3.Components;
	using VRC.SDKBase;
	using VRC.Udon.Common.Interfaces;
	using Color = UnityEngine.Color;


	public class PickupSubmenu : ObjectSelectorHelper
	{

		public static void Init_PickupSubMenu(QMNestedButton menu, float x, float y, bool btnHalf)
		{
			var PickupEditor = new QMNestedButton(menu, x, y, "Pickup Property", "Pickup Property Editor Menu!", null, null, null, null, btnHalf);
            HasPickupComponent = new QMSingleButton(PickupEditor, 0, -1f, "Force Pickup Component", new Action(() => { Pickup.ForcePickupComponentPresence(Selector_Utils.GetGameObjectToEdit()); }), "Forces Pickup component in case there's none.", null, null, true);
            Pickup_IsEditMode = new QMSingleButton(PickupEditor, 0, -0.5f, "Edit Mode : OFF", null, "Shows if Pickup properties are currently being overriden.", null, null, true);

            new QMSingleButton(PickupEditor, 0, 0, "Reset Properties", new Action(() => { Pickup.RestoreOriginalProperty(Selector_Utils.GetGameObjectToEdit()); }), "Revert Pickup Properties Edits. (disabling editmode)", null, null, true);
            Pickup_IsHeld = new QMSingleButton(PickupEditor, 0, 0.5f, "Held : No", null, "See if Pickup is held or not.", null, null, true);
            Pickup_CurrentObjOwner = new QMSingleButton(PickupEditor, 0, 1f, "Current Owner : null", null, "Who is the current object owner.", null, null, false);
            Pickup_CurrentObjOwner.SetResizeTextForBestFit(true);
            Pickup_CurrentObjHolder = new QMSingleButton(PickupEditor, -1, 1f, "Current Holder : null", null, "Who is Holding the object.", null, null, false);
            Pickup_CurrentObjHolder.SetResizeTextForBestFit(true);

            new QMSingleButton(PickupEditor, 1, 0, "Pickup Orientation", null, "Pickup Orientation", null, null, true);
            Pickup_PickupOrientation_prop_any = new QMSingleButton(PickupEditor, 1, 0.5f, "Any", new Action(() => { Pickup.SetPickupOrientation(Selector_Utils.GetGameObjectToEdit(), VRC_Pickup.PickupOrientation.Any); }), "", null, null, true);
            Pickup_PickupOrientation_prop_Grip = new QMSingleButton(PickupEditor, 1, 1f, "Grip", new Action(() => { Pickup.SetPickupOrientation(Selector_Utils.GetGameObjectToEdit(), VRC_Pickup.PickupOrientation.Grip); }), "", null, null, true);
            Pickup_PickupOrientation_prop_Gun = new QMSingleButton(PickupEditor, 1, 1.5f, "Gun", new Action(() => { Pickup.SetPickupOrientation(Selector_Utils.GetGameObjectToEdit(), VRC_Pickup.PickupOrientation.Gun); }), "", null, null, true);

            var autohold = new QMSingleButton(PickupEditor, 2, 0, "Pickup AutoHoldMode", null, "Pickup AutoHoldMode", null, null, true);
            autohold.SetResizeTextForBestFit(true);

            Pickup_AutoHoldMode_prop_AutoDetect = new QMSingleButton(PickupEditor, 2, 0.5f, "AutoDetect", new Action(() => { Pickup.SetAutoHoldMode(Selector_Utils.GetGameObjectToEdit(), VRC_Pickup.AutoHoldMode.AutoDetect); }), "", null, null, true);
            Pickup_AutoHoldMode_prop_Yes = new QMSingleButton(PickupEditor, 2, 1f, "Yes", new Action(() => { Pickup.SetAutoHoldMode(Selector_Utils.GetGameObjectToEdit(), VRC_Pickup.AutoHoldMode.Yes); }), "", null, null, true);
            Pickup_AutoHoldMode_prop_No = new QMSingleButton(PickupEditor, 2, 1.5f, "No", new Action(() => { Pickup.SetAutoHoldMode(Selector_Utils.GetGameObjectToEdit(), VRC_Pickup.AutoHoldMode.No); }), "", null, null, true);
            InitProximitySliderSubmenu(PickupEditor, 3, 0, true);
            Pickup_allowManipulationWhenEquipped = new QMToggleButton(PickupEditor, 4, 0, "Allow Manipulation Equip", new Action(() => { Pickup.SetallowManipulationWhenEquipped(Selector_Utils.GetGameObjectToEdit(), true); }), "Disallow Manipulation Equip", new Action(() => { Pickup.SetallowManipulationWhenEquipped(Selector_Utils.GetGameObjectToEdit(), false); }), "Control Manipulation Equip property", null, null, null);
            Pickup_pickupable = new QMToggleButton(PickupEditor, 4, 1, "Pickupable", new Action(() => { Pickup.SetPickupable(Selector_Utils.GetGameObjectToEdit(), true); }), "Not Pickupable", new Action(() => { Pickup.SetPickupable(Selector_Utils.GetGameObjectToEdit(), false); }), "Control Pickupable Property", null, null, null);
            Pickup_DisallowTheft = new QMToggleButton(PickupEditor, 4, 2, "Allow Theft", new Action(() => { Pickup.SetDisallowTheft(Selector_Utils.GetGameObjectToEdit(), true); }), "Block Theft", new Action(() => { Pickup.SetDisallowTheft(Selector_Utils.GetGameObjectToEdit(), false); }), "Control DisallowTheft property", null, null, null);
        }

        public static void InitProximitySliderSubmenu(QMNestedButton menu, float x, float y, bool btnHalf)
        {
            var slider = new QMNestedButton(menu, x, y, "Proximity", "Value Slider Editor!", null, null, null, null, btnHalf);
            PickupProximitySlider = new QMSlider(Utils.QuickMenu.transform.Find(slider.GetMenuName()), "Proximity : ", 250, -720, delegate (float value)
{
    Pickup.SetProximity(Selector_Utils.GetGameObjectToEdit(), (int)value);
}, 5, 1000, 0, true);
            PickupProximitySlider.Slider.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
        }


		public static QMSingleButton HasPickupComponent;

		public static QMSingleButton Pickup_PickupOrientation_prop_any;
		public static QMSingleButton Pickup_PickupOrientation_prop_Grip;
		public static QMSingleButton Pickup_PickupOrientation_prop_Gun;

		public static QMSingleButton Pickup_AutoHoldMode_prop_AutoDetect;
		public static QMSingleButton Pickup_AutoHoldMode_prop_Yes;
		public static QMSingleButton Pickup_AutoHoldMode_prop_No;

		public static QMToggleButton Pickup_allowManipulationWhenEquipped;
		public static QMToggleButton Pickup_pickupable;
		public static QMToggleButton Pickup_DisallowTheft;

		public static QMSingleButton Pickup_IsEditMode;
		public static QMSingleButton Pickup_IsHeld;
		public static QMSingleButton Pickup_CurrentObjOwner;
		public static QMSingleButton Pickup_CurrentObjHolder;
		public static QMSlider PickupProximitySlider;


	}
}
