namespace AstroClient.ClientUI.Menu.ItemTweakerV2
{
    using System;
    using AstroMonos.Components.Tools;
    using ClientResources;
    using ClientResources.Loaders;
    using Constants;
    using Handlers;
    using ScrollMenus.Pickup;
    using ScrollMenus.Udon;
    using ScrollMenus.VRC_Interactable;
    using ScrollMenus.VRC_Triggers;
    using ScrollMenus.WorldObjects;
    using Selector;
    using Submenus.Components;
    using Submenus.ObjectInfoSubMenu;
    using Submenus.Physic;
    using Submenus.Pickup;
    using Submenus.Scale;
    using Submenus.Spawner;
    using Tools.Extensions;
    using Tools.Extensions.Components_exts;
    using Tools.ObjectEditor;
    using UnityEngine;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    internal class TweakerV2Main : Tweaker_Events
    {
        internal static void Init_TweakerV2Main(int index)
        {
            QMTabMenu menu = new QMTabMenu(index, "Item Tweaker", null, null, null, Icons.box_sprite);

            // Outside Area

            PhysicsSubmenu.Init_PhysicSubMenu(menu, 2, 0, true);
            PickupSubmenu.Init_PickupSubMenu(menu, 2, 0.5f, true);
            ScaleSubmenu.Init_ScaleSubMenu(menu, 2, 1.5f, true);

            //GameObjMenu.InitTogglerMenu(menu, 3, 0f, true); // TODO : Make a better one!
            ObjectInfoSubMenu.Init_ObjectInfoSubMenu(menu, 3, 0.5f, true);
            _ = new QMSingleButton(menu, 3, 1f, "Teleport to Object", new Action(() => { GameObjectMenu.TeleportPlayerToPickup(Tweaker_Object.GetGameObjectToEdit()); }), "Teleport to object.", null, null, true);
            _ = new QMSingleButton(menu, 3, 1.5f, "Respawn Object", new Action(() => { GameObjectMenu.RestoreOriginalLocation(Tweaker_Object.GetGameObjectToEdit(), false); }), "Reset Object Position.", null, null, true);
            PickupSelectionScrollMenu.InitButtons(menu, 3, 2, true);
            WorldObjectsScrollMenu.InitButtons(menu, 3, 2.5f, true);
            VRC_TriggersScrollMenu.InitButtons(menu, 4, 0, true);
            VRC_InteractableScrollMenu.InitButtons(menu, 4, 0.5f, true);
            if (Bools.IsDeveloper)
            {
                UdonScrollMenu.InitButtons(menu, 4, 1, true);
            }

            ComponentSubMenu.Init_ComponentSubMenu(menu, 4, 1.5f, true);
            SpawnerSubmenu.Init_SpawnerSubmenu(menu, 4, 2f, true);

            _ = new QMSingleButton(menu, 1, -0.5f, "Drop Object", new Action(() => { Tweaker_Object.GetGameObjectToEdit().TryTakeOwnership(); }), "Make Whatever Player, drop the object.", null, Color.white, true);
            AntiTheftInteractor = new QMSingleToggleButton(menu, 1, 0.5f, "AntiTheft ON", () => { Tweaker_Object.GetGameObjectToEdit().Pickup_Set_AntiTheft(true); }, "AntiTheft OFF", () => { Tweaker_Object.GetGameObjectToEdit().Pickup_Set_AntiTheft(false); }, "Toggles PickupController WIP antitheft", Color.green, Color.red, null, false, true);
            ProtectionInteractor = new QMSingleToggleButton(menu, 1, 1, "Interaction block ON", () => { Tweaker_Object.GetGameObjectToEdit().Pickup_AllowOnlySelfToGrab(true); }, "Interaction block OFF", () => { Tweaker_Object.GetGameObjectToEdit().Pickup_AllowOnlySelfToGrab(false); }, "Prevents Others from interacting with the object", Color.green, Color.red, null, false, true);
            ObjectActiveToggle = new QMSingleToggleButton(menu, 1, 1.5f, "Enabled", () => { Tweaker_Object.GetGameObjectToEdit().SetActive(true); }, "Disabled", () => { Tweaker_Object.GetGameObjectToEdit().SetActive(false); }, "Toggles SetActive", Color.green, Color.red, null, false, true);
            new QMSingleToggleButton(menu, 2, 1.5f, "Selected Item ESP : ON", () => { EspHandler.TweakerESPEnabled = true; }, "Selected Item ESP : OFF", () => { EspHandler.TweakerESPEnabled = false; }, "Toggles Selected item ESP", Color.green, Color.red, null, false, true);

            LockHoldItem = new QMSingleToggleButton(menu, 2, 2.5f, "Lock ON", () => { Tweaker_Object.LockItem = true; }, "Lock OFF", () => { Tweaker_Object.LockItem = false; }, "Lock the Held object (prevents the mod from grabbing a new holding object)", Color.green, Color.red, null, false, true);
            ObjectToEditBtn = new QMSingleButton(menu, 1, 2f, "None", new Action(() => { _ = Tweaker_Object.GetGameObjectToEdit(); }), "GameObject To Edit", null, null);

            TweakerWings.InitTweakerWings();
        }

        internal override void On_New_GameObject_Selected(GameObject obj)
        {
            UpdateCapturedObject(obj);
        }

        internal override void OnPickupController_Selected(PickupController control)
        {
            if (ProtectionInteractor != null)
            {
                ProtectionInteractor.SetToggleState(control.AllowOnlySelfToGrab);
            }
            if (AntiTheftInteractor != null)
            {
                AntiTheftInteractor.SetToggleState(control.AntiTheft);
            }
        }

        internal override void OnSelectedObject_Enabled()
        {
            ObjectActiveToggle.SetToggleState(true);
            if (ObjectToEditBtn != null)
            {
                ObjectToEditBtn.SetTextColor(Color.green);
            }
            //if (GameObjMenu.GameObjMenuObjectToEdit != null)
            //{
            //    GameObjMenu.GameObjMenuObjectToEdit.SetTextColor(Color.green);
            //}
        }

        internal override void OnSelectedObject_Disabled()
        {
            ObjectActiveToggle.SetToggleState(false);
            if (ObjectToEditBtn != null)
            {
                ObjectToEditBtn.SetTextColor(Color.red);
            }
            //if (GameObjMenu.GameObjMenuObjectToEdit != null)
            //{
            //    GameObjMenu.GameObjMenuObjectToEdit.SetTextColor(Color.red);
            //}
        }

        internal override void OnSelectedObject_Destroyed()
        {
            Reset();
        }

        internal override void OnRoomLeft()
        {
            Reset();
        }

        internal static void Reset()
        {
            Tweaker_Object.LockItem = false;
            Tweaker_Selector.SelectedObject = null;
        }

        internal static void UpdateCapturedObject(GameObject obj)
        {
            if (obj != null)
            {
                if (ObjectToEditBtn != null)
                {
                    ObjectToEditBtn.SetButtonText("Editing: " + obj.name);
                    ObjectToEditBtn.SetToolTip("Editing: " + obj.name);
                }
                //if (GameObjMenu.GameObjMenuObjectToEdit != null)
                //{
                //    GameObjMenu.GameObjMenuObjectToEdit.SetButtonText("Editing: " + obj.name);
                //    GameObjMenu.GameObjMenuObjectToEdit.SetToolTip("Editing: " + obj.name);
                //}
            }
            else
            {
                if (ObjectToEditBtn != null)
                {
                    ObjectToEditBtn.SetButtonText("Pick a Gameobject to start!");
                    ObjectToEditBtn.SetToolTip("Pick a Gameobject to start!");
                    ObjectToEditBtn.SetTextColor(Color.white);
                }
                //if (GameObjMenu.GameObjMenuObjectToEdit != null)
                //{
                //    GameObjMenu.GameObjMenuObjectToEdit.SetButtonText("Pick a Gameobject to start!");
                //    GameObjMenu.GameObjMenuObjectToEdit.SetToolTip("Pick a Gameobject to start!");
                //    GameObjMenu.GameObjMenuObjectToEdit.SetTextColor(Color.white);
                //}
            }
        }

        internal static QMSingleToggleButton LockHoldItem;
        internal static QMSingleButton ObjectToEditBtn;
        internal static QMSingleToggleButton ObjectActiveToggle;
        internal static QMSingleToggleButton ProtectionInteractor;
        internal static QMSingleToggleButton AntiTheftInteractor;
    }
}