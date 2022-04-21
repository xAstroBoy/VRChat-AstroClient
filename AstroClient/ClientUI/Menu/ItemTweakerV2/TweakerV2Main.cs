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
            QMGridTab menu = new QMGridTab(index, "Item Tweaker", null, null, null, Icons.box_sprite);

            // Outside Area

            PhysicsSubmenu.Init_PhysicSubMenu(menu);
            PickupSubmenu.Init_PickupSubMenu(menu);
            ScaleSubmenu.Init_ScaleSubMenu(menu);

            //GameObjMenu.InitTogglerMenu(menu, 3, 0f, true); // TODO : Make a better one!
            ObjectInfoSubMenu.Init_ObjectInfoSubMenu(menu);
            _ = new QMSingleButton(menu, "Teleport to Object", new Action(() => { GameObjectMenu.TeleportPlayerToPickup(Tweaker_Object.GetGameObjectToEdit()); }), "Teleport to object.", Color.white);
            _ = new QMSingleButton(menu,  "Respawn Object", new Action(() => { GameObjectMenu.RestoreOriginalLocation(Tweaker_Object.GetGameObjectToEdit(), false); }), "Reset Object Position.",Color.white);
            PickupSelectionScrollMenu.InitButtons(menu);
            WorldObjectsScrollMenu.InitButtons(menu);
            VRC_TriggersScrollMenu.InitButtons(menu);
            VRC_InteractableScrollMenu.InitButtons(menu);
            if (Bools.IsDeveloper)
            {
                UdonScrollMenu.InitButtons(menu);
            }

            ComponentSubMenu.Init_ComponentSubMenu(menu);
            SpawnerSubmenu.Init_SpawnerSubmenu(menu);

            _ = new QMSingleButton(menu,  "Drop Object", new Action(() => { Tweaker_Object.GetGameObjectToEdit().TryTakeOwnership(); }), "Make Whatever Player, drop the object.", Color.white);
            AntiTheftInteractor = new QMToggleButton(menu, "AntiTheft ON", () => { Tweaker_Object.GetGameObjectToEdit().Pickup_Set_AntiTheft(true); }, "AntiTheft OFF", () => { Tweaker_Object.GetGameObjectToEdit().Pickup_Set_AntiTheft(false); }, "Toggles PickupController WIP antitheft");
            ProtectionInteractor = new QMToggleButton(menu, "Interaction block ON", () => { Tweaker_Object.GetGameObjectToEdit().Pickup_AllowOnlySelfToGrab(true); }, "Interaction block OFF", () => { Tweaker_Object.GetGameObjectToEdit().Pickup_AllowOnlySelfToGrab(false); }, "Prevents Others from interacting with the object");
            ObjectActiveToggle = new QMToggleButton(menu,  "Enabled", () => { Tweaker_Object.GetGameObjectToEdit().SetActive(true); }, "Disabled", () => { Tweaker_Object.GetGameObjectToEdit().SetActive(false); }, "Toggles SetActive");
            new QMToggleButton(menu,  "Selected Item ESP : ON", () => { EspHandler.TweakerESPEnabled = true; }, "Selected Item ESP : OFF", () => { EspHandler.TweakerESPEnabled = false; }, "Toggles Selected item ESP");

            LockHoldItem = new QMToggleButton(menu, "Lock ON", () => { Tweaker_Object.LockItem = true; }, "Lock OFF", () => { Tweaker_Object.LockItem = false; }, "Lock the Held object (prevents the mod from grabbing a new holding object)");
            ObjectToEditBtn = new QMSingleButton(menu, "None", new Action(() => { _ = Tweaker_Object.GetGameObjectToEdit(); }), "GameObject To Edit", Color.white);

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

        internal static QMToggleButton LockHoldItem;
        internal static QMSingleButton ObjectToEditBtn;
        internal static QMToggleButton ObjectActiveToggle;
        internal static QMToggleButton ProtectionInteractor;
        internal static QMToggleButton AntiTheftInteractor;
    }
}