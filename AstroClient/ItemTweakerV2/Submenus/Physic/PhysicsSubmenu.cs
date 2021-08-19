namespace AstroClient.ItemTweakerV2.Submenus
{
	using AstroClient.Components;
	using AstroClient.ItemTweakerV2.Selector;
	using AstroClient.ItemTweakerV2.Submenus.Collider;
	using AstroLibrary.Extensions;
	using RubyButtonAPI;
	using System;
	using UnityEngine;
	using VRC;

	public class PhysicsSubmenu : Tweaker_Events
    {
        public static void Init_PhysicSubMenu(QMTabMenu menu, float x, float y, bool btnHalf)
        {
            var main = new QMNestedButton(menu, x, y, "Physics", "Item Physics Editor Menu!", null, null, null, null, btnHalf);

            Pickup_IsHeldStatus = new QMSingleButton(main, -1, -1f, "Held : No", null, "See if Pickup is held or not.", null, null, true);

            Pickup_CurrentObjectHolder = new QMSingleButton(main, -1, -0.5f, "Current holder : null", null, "Who is the current object Holder.", null, null, false);
            Pickup_CurrentObjectHolder.SetResizeTextForBestFit(true);

            Pickup_CurrentObjectOwner = new QMSingleButton(main, -1, 0.5f, "Current Owner : null", null, "Who is the current object owner.", null, null, false);
            Pickup_CurrentObjectOwner.SetResizeTextForBestFit(true);

            TeleportToMe = new QMSingleButton(main, -1, 1.5f, Button_strings_ext.Generate_TeleportToMe_ButtonText(null), new Action(() => { Tweaker_Object.GetGameObjectToEdit().TeleportToMe(); }), Button_strings_ext.Generate_TeleportToMe_ButtonText(null), null, null);
            TeleportToMe.SetResizeTextForBestFit(true);

            TeleportToTarget = new QMSingleButton(main, -1, 2.5f, Button_strings_ext.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.Component_Get_SelectedObject, TargetSelector.CurrentTarget), new Action(() => { Tweaker_Object.GetGameObjectToEdit().TeleportToTarget(); }), Button_strings_ext.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.Component_Get_SelectedObject, TargetSelector.CurrentTarget), null, null);
            TeleportToTarget.SetResizeTextForBestFit(true);

            GravityToggler = new QMSingleToggleButton(main, 1, 0, "Use Gravity", () => { Modified_SetGravity(true); }, "No Gravity", () => { Modified_SetGravity(false); }, "Toggle Object Gravity", Color.green, Color.red, null, false, true);
            KinematicToggler = new QMSingleToggleButton(main, 1, 0.5f, "Kinematic", () => { Tweaker_Object.GetGameObjectToEdit().RigidBody_Set_isKinematic(true); }, "Not Kinematic", () => { Tweaker_Object.GetGameObjectToEdit().RigidBody_Set_isKinematic(false); }, "Toggle Object Kinematic", Color.green, Color.red, null, false, true);
            SmartKinematicToggler = new QMSingleToggleButton(main, 2, 0.5f, "Smart Kinematic Toggler", () => { SmartKinematicEnabled = true; }, "Smart Kinematic Toggler", () => { SmartKinematicEnabled = false; }, "Toggle Smart Kinematic Toggler (Check if Object won't fall throught before toggling kinematic with gravity !)", Color.green, Color.red, null, false, true);

            CollisionsToggler = new QMSingleToggleButton(main, 1, 1, "Use Collisions", () => { Tweaker_Object.GetGameObjectToEdit().RigidBody_Set_DetectCollisions(true); }, "No Collisions", () => { Tweaker_Object.GetGameObjectToEdit().RigidBody_Set_DetectCollisions(false); }, "Toggle Object Collisions", Color.green, Color.red, null, false, true);
            ConstraintsSubmenu.Init_ConstraintsSubmenu(main, 1, 1.5f, true);
            new QMSingleButton(main, 1, 2f, "Restore Rigidbody", () => { Tweaker_Object.GetGameObjectToEdit().RigidBody_RestoreOriginalBody(); }, "Restore Default RigidBody Config.", null, null, true);

            ColliderEditor.Init_ColliderEditor(main, 2, 0, true);

            ForcesSubmenu.Init_ForceSubMenu(main, 4, 0, true);
        }

        public override void OnPickupController_OnUpdate(PickupController control)
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

        public override void On_New_GameObject_Selected(GameObject obj)
        {
            if (TeleportToTarget != null)
            {
                TeleportToTarget.SetButtonText(Button_strings_ext.Generate_TeleportToTarget_ButtonText(obj, TargetSelector.CurrentTarget));
                TeleportToTarget.SetToolTip(Button_strings_ext.Generate_TeleportToTarget_ButtonText(obj, TargetSelector.CurrentTarget));
            }
            if (TeleportToMe != null)
            {
                TeleportToMe.SetButtonText(obj.Generate_TeleportToMe_ButtonText());
                TeleportToMe.SetToolTip(obj.Generate_TeleportToMe_ButtonText());
            }
        }

        public override void OnTargetSet(Player player)
        {
            if (TeleportToTarget != null)
            {
                TeleportToTarget.SetButtonText(Button_strings_ext.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.Component_Get_SelectedObject, player));
                TeleportToTarget.SetToolTip(Button_strings_ext.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.Component_Get_SelectedObject, player));
            }
        }

        private static void Modified_SetGravity(bool useGravity)
        {
            var item = Tweaker_Object.GetGameObjectToEdit();
            if (item != null)
            {
                item.RigidBody_Set_Gravity(useGravity);
                if (SmartKinematicEnabled)
                {
                    var control = item.GetComponent<RigidBodyController>();
                    if (control != null)
                    {
                        var will_it_fall_throught = control.RigidBody_Will_It_fall_throught();
                        if (!will_it_fall_throught)
                        {
                            item.RigidBody_Set_isKinematic(false);
                        }
                    }
                    SmartKinematicEnabled = false;
                }
            }
        }

        public override void OnRigidBodyController_PropertyChanged(RigidBodyController control)
        {
            UpdateProperties(control);
        }

        public override void OnRigidBodyControllerSelected(RigidBodyController control)
        {
            UpdateProperties(control);
        }

        private void UpdateProperties(RigidBodyController control)
        {
            if (control != null)
            {
                if (GravityToggler.GetToggleState() != control.useGravity)
                {
                    GravityToggler.SetToggleState(control.useGravity);
                }
                if (KinematicToggler.GetToggleState() != control.isKinematic)
                {
                    KinematicToggler.SetToggleState(control.isKinematic);
                }
                if (CollisionsToggler.GetToggleState() != control.DetectCollisions)
                {
                    CollisionsToggler.SetToggleState(control.DetectCollisions);
                }
            }
        }

        private void Reset()
        {
            GravityToggler.SetToggleState(false);
            KinematicToggler.SetToggleState(false);
            CollisionsToggler.SetToggleState(false);
        }

        public override void OnSelectedObject_Destroyed()
        {
            Reset();
        }

        public override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            Reset();
        }

        private static QMSingleToggleButton GravityToggler;
        private static QMSingleToggleButton KinematicToggler;
        private static QMSingleToggleButton CollisionsToggler;
        private static QMSingleToggleButton SmartKinematicToggler;

        public static QMSingleButton TeleportToMe;
        public static QMSingleButton TeleportToTarget;

        private static QMSingleButton Pickup_IsHeldStatus { get; set; }
        private static QMSingleButton Pickup_CurrentObjectHolder { get; set; }
        private static QMSingleButton Pickup_CurrentObjectOwner { get; set; }

        private static bool _SmartKinematicEnabled;

        public static bool SmartKinematicEnabled
        {
            get
            {
                return _SmartKinematicEnabled;
            }
            set
            {
                if (SmartKinematicToggler != null)
                {
                    SmartKinematicToggler.SetToggleState(value);
                }
                _SmartKinematicEnabled = value;
            }
        }
    }
}