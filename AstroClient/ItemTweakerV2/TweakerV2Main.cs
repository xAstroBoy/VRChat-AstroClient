namespace AstroClient.ItemTweakerV2
{
    using System;
    using System.Reflection;
    using AstroButtonAPI;
    using AstroLibrary.Extensions;
    using AstroMonos.Components.Tools;
    using CheetoLibrary;
    using GameObjectDebug;
    using Handlers;
    using Selector;
    using Submenus;
    using Submenus.ScrollMenus;
    using UnityEngine;
    using Variables;
    using VRC;

    internal class TweakerV2Main : Tweaker_Events
    {
        internal static void Init_TweakerV2Main(int index)
        {
            QMTabMenu menu = new QMTabMenu(index, "Item Tweaker", null, null, null, CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.box.png"));

            // Outside Area

            Pickup_IsHeldStatus = new QMSingleButton(menu, -1, -1f, "Held : No", null, "See if Pickup is held or not.", null, null, true);

            Pickup_CurrentObjectHolder = new QMSingleButton(menu, -1, -0.5f, "Current holder : null", null, "Who is the current object Holder.", null, null, false);

            Pickup_CurrentObjectOwner = new QMSingleButton(menu, -1, 0.5f, "Current Owner : null", null, "Who is the current object owner.", null, null, false);

            TeleportToMe = new QMSingleButton(menu, -1, 1.5f, ButtonStringExtensions.Generate_TeleportToMe_ButtonText(null), new Action(() => { Tweaker_Object.GetGameObjectToEdit().TeleportToMe(); }), ButtonStringExtensions.Generate_TeleportToMe_ButtonText(null), null, null);

            TeleportToTarget = new QMSingleButton(menu, -1, 2.5f, ButtonStringExtensions.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.SelectedObject, TargetSelector.CurrentTarget), new Action(() => { Tweaker_Object.GetGameObjectToEdit().TeleportToTarget(); }), ButtonStringExtensions.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.SelectedObject, TargetSelector.CurrentTarget), null, null);

            PhysicsSubmenu.Init_PhysicSubMenu(menu, 2, 0, true);
            PickupSubmenu.Init_PickupSubMenu(menu, 2, 0.5f, true);
            ScaleSubmenu.Init_ScaleSubMenu(menu, 2, 1, true);

            GameObjMenu.InitTogglerMenu(menu, 3, 0f, true);
            ObjectInfoSubMenu.Init_ObjectInfoSubMenu(menu, 3, 0.5f, true);
            _ = new QMSingleButton(menu, 3, 1f, "Teleport to Object", new Action(() => { GameObjectMenu.TeleportPlayerToPickup(Tweaker_Object.GetGameObjectToEdit()); }), "Teleport to object.", null, null, true);
            _ = new QMSingleButton(menu, 3, 1.5f, "Respawn Object", new Action(() => { GameObjectMenu.RestoreOriginalLocation(Tweaker_Object.GetGameObjectToEdit(), false); }), "Reset Object Position.", null, null, true);
            PickupSelectionScrollMenu.Init_PickupSelectionQMScroll(menu, 3, 2, true);
            WorldObjectsScrollMenu.Init_WorldObjectScrollMenu(menu, 3, 2.5f, true);
            VRC_TriggersScrollMenu.Init_VRC_TriggersScrollMenu(menu, 4, 0, true);
            VRC_InteractableScrollMenu.Init_VRC_InteractableScrollMenu(menu, 4, 0.5f, true);
            if (Bools.IsDeveloper)
            {
                UdonScrollMenu.Init_Internal_UdonEvents(menu, 4, 1, true);
            }

            ComponentSubMenu.Init_ComponentSubMenu(menu, 4, 1.5f, true);
            SpawnerSubmenu.Init_SpawnerSubmenu(menu, 4, 2f, true);

            _ = new QMSingleButton(menu, 1, 0f, "Drop Object", new Action(() => { Tweaker_Object.GetGameObjectToEdit().TryTakeOwnership(); }), "Make Whatever Player, drop the object.", null, Color.cyan, true);
            AntiTheftInteractor = new QMSingleToggleButton(menu,1, 0.5f, "AntiTheft ON", () => { Tweaker_Object.GetGameObjectToEdit().Pickup_Set_AntiTheft(true); }, "AntiTheft OFF", () => { Tweaker_Object.GetGameObjectToEdit().Pickup_Set_AntiTheft(false); }, "Toggles PickupController WIP antitheft", Color.green, Color.red, null, false, true);

            ProtectionInteractor = new QMSingleToggleButton(menu, 1, 1, "Interaction block ON", () => { Tweaker_Object.GetGameObjectToEdit().Pickup_AllowOnlySelfToGrab(true); }, "Interaction block OFF", () => { Tweaker_Object.GetGameObjectToEdit().Pickup_AllowOnlySelfToGrab(false); }, "Prevents Others from interacting with the object", Color.green, Color.red, null, false, true);
            ObjectActiveToggle = new QMSingleToggleButton(menu, 1, 1.5f, "Enabled", () => { Tweaker_Object.GetGameObjectToEdit().SetActive(true); }, "Disabled", () => { Tweaker_Object.GetGameObjectToEdit().SetActive(false); }, "Toggles SetActive", Color.green, Color.red, null, false, true);
            new QMSingleToggleButton(menu, 2, 1.5f, "Selected Item ESP : ON", () => { EspHandler.TweakerESPEnabled = true; }, "Selected Item ESP : OFF", () => { EspHandler.TweakerESPEnabled = false; }, "Toggles Selected item ESP", Color.green, Color.red, null, false, true);
            LockHoldItem = new QMSingleToggleButton(menu, 2, 2.5f, "Lock ON", () => { Tweaker_Object.LockItem = true; }, "Lock OFF", () => { Tweaker_Object.LockItem = false; }, "Lock the Held object (prevents the mod from grabbing a new holding object)", Color.green, Color.red, null, false, true);
            ObjectToEditBtn = new QMSingleButton(menu, 1, 2f, "None", new Action(() => { _ = Tweaker_Object.GetGameObjectToEdit(); }), "GameObject To Edit", null, null);

            // TODO: remake teleport buttons <3

            _ = new QMSingleButton(menu, 5, -0.5f, "DANGER : Destroy item.", new Action(() => { Tweaker_Object.GetGameObjectToEdit().DestroyObject(); }), "Destroys Object , You need to reload the world to restore it back.", null, Color.red, true);
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

        internal override void On_New_GameObject_Selected(GameObject obj)
        {
            UpdateCapturedObject(obj);
            if (TeleportToTarget != null)
            {
                TeleportToTarget.SetButtonText(ButtonStringExtensions.Generate_TeleportToTarget_ButtonText(obj, TargetSelector.CurrentTarget));
                TeleportToTarget.SetToolTip(ButtonStringExtensions.Generate_TeleportToTarget_ButtonText(obj, TargetSelector.CurrentTarget));
            }
            if (TeleportToMe != null)
            {
                TeleportToMe.SetButtonText(obj.Generate_TeleportToMe_ButtonText());
                TeleportToMe.SetToolTip(obj.Generate_TeleportToMe_ButtonText());
            }
        }



        internal override void OnPickupController_Selected(PickupController control)
        {
            if (ProtectionInteractor != null)
            {
                ProtectionInteractor.SetToggleState(control.AllowOnlySelfToGrab);
            }
            if(AntiTheftInteractor != null)
            {
                AntiTheftInteractor.SetToggleState(control.AntiTheft);
            }
        }

        internal override void OnTargetSet(Player player)
        {
            if (TeleportToTarget != null)
            {
                TeleportToTarget.SetButtonText(ButtonStringExtensions.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.SelectedObject, player));
                TeleportToTarget.SetToolTip(ButtonStringExtensions.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.SelectedObject, player));
            }
        }

        internal override void OnSelectedObject_Enabled()
        {
            ObjectActiveToggle.SetToggleState(true);
            if (ObjectToEditBtn != null)
            {
                ObjectToEditBtn.SetTextColor(Color.green);
            }
            if (GameObjMenu.GameObjMenuObjectToEdit != null)
            {
                GameObjMenu.GameObjMenuObjectToEdit.SetTextColor(Color.green);
            }
        }

        internal override void OnSelectedObject_Disabled()
        {
            ObjectActiveToggle.SetToggleState(false);
            if (ObjectToEditBtn != null)
            {
                ObjectToEditBtn.SetTextColor(Color.red);
            }
            if (GameObjMenu.GameObjMenuObjectToEdit != null)
            {
                GameObjMenu.GameObjMenuObjectToEdit.SetTextColor(Color.red);
            }
        }

        internal override void OnSelectedObject_Destroyed()
        {
            Reset();
        }

        internal override void OnSceneLoaded(int buildIndex, string sceneName)
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
                if (GameObjMenu.GameObjMenuObjectToEdit != null)
                {
                    GameObjMenu.GameObjMenuObjectToEdit.SetButtonText("Editing: " + obj.name);
                    GameObjMenu.GameObjMenuObjectToEdit.SetToolTip("Editing: " + obj.name);
                }
            }
            else
            {
                if (ObjectToEditBtn != null)
                {
                    ObjectToEditBtn.SetButtonText("Pick a Gameobject to start!");
                    ObjectToEditBtn.SetToolTip("Pick a Gameobject to start!");
                    ObjectToEditBtn.SetTextColor(Color.white);
                }
                if (GameObjMenu.GameObjMenuObjectToEdit != null)
                {
                    GameObjMenu.GameObjMenuObjectToEdit.SetButtonText("Pick a Gameobject to start!");
                    GameObjMenu.GameObjMenuObjectToEdit.SetToolTip("Pick a Gameobject to start!");
                    GameObjMenu.GameObjMenuObjectToEdit.SetTextColor(Color.white);
                }
            }
        }

        internal static QMSingleButton TeleportToMe;

        internal static QMSingleButton TeleportToTarget;

        internal static QMSingleToggleButton LockHoldItem;
        internal static QMSingleButton ObjectToEditBtn;
        internal static QMSingleToggleButton ObjectActiveToggle;
        internal static QMSingleToggleButton ProtectionInteractor;
        internal static QMSingleToggleButton AntiTheftInteractor;

        private static QMSingleButton Pickup_IsHeldStatus { get; set; }
        private static QMSingleButton Pickup_CurrentObjectHolder { get; set; }
        private static QMSingleButton Pickup_CurrentObjectOwner { get; set; }
    }
}