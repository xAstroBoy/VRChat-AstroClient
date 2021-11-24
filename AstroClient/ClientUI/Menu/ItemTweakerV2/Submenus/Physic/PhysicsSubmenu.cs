namespace AstroClient.ClientUI.Menu.ItemTweakerV2.Submenus.Physic
{
    using AstroMonos.Components.Tools;
    using Constraints;
    using Forces;
    using Selector;
    using Tools.Extensions.Components_exts;
    using UnityEngine;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    internal class PhysicsSubmenu : Tweaker_Events
    {
        internal static void Init_PhysicSubMenu(QMTabMenu menu, float x, float y, bool btnHalf)
        {
            var main = new QMNestedGridMenu(menu, x, y, "Physics", "Item Physics Editor Menu!", null, null, null, null, btnHalf);

            GravityToggler = new QMToggleButton(main, "Use Gravity", () => { Modified_SetGravity(true); }, "No Gravity", () => { Modified_SetGravity(false); }, "Toggle Object Gravity");
            KinematicToggler = new QMToggleButton(main, "Kinematic", () => { Tweaker_Object.GetGameObjectToEdit().RigidBody_Set_isKinematic(true); }, "Not Kinematic", () => { Tweaker_Object.GetGameObjectToEdit().RigidBody_Set_isKinematic(false); }, "Toggle Object Kinematic");
            SmartKinematicToggler = new QMToggleButton(main,"Smart Kinematic Toggler", () => { SmartKinematicEnabled = true; }, "Smart Kinematic Toggler", () => { SmartKinematicEnabled = false; }, "Toggle Smart Kinematic Toggler (Check if Object won't fall throught before toggling kinematic with gravity !)");

            CollisionsToggler = new QMToggleButton(main, "Use Collisions", () => { Tweaker_Object.GetGameObjectToEdit().RigidBody_Set_DetectCollisions(true); }, "No Collisions", () => { Tweaker_Object.GetGameObjectToEdit().RigidBody_Set_DetectCollisions(false); }, "Toggle Object Collisions");
            ConstraintsSubmenu.Init_ConstraintsSubmenu(main);
            new QMSingleButton(main, "Restore Rigidbody", () => { Tweaker_Object.GetGameObjectToEdit().RigidBody_RestoreOriginalBody(); }, "Restore Default RigidBody Config.");

            ColliderEditor.ColliderEditor.Init_ColliderEditor(main, true);

            ForcesSubmenu.Init_ForceSubMenu(main, 4, 0, true);
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

        internal override void OnRigidBodyController_PropertyChanged(RigidBodyController control)
        {
            UpdateProperties(control);
        }

        internal override void OnRigidBodyController_Selected(RigidBodyController control)
        {
            UpdateProperties(control);
        }

        internal override void OnRigidBodyController_OnUpdate(RigidBodyController control)
        {
            UpdateProperties(control);
        }

        private void UpdateProperties(RigidBodyController control)
        {
            if (control != null)
            {
                GravityToggler.SetToggleState(control.useGravity);
                KinematicToggler.SetToggleState(control.isKinematic);
                CollisionsToggler.SetToggleState(control.detectCollisions);
            }
        }

        private void Reset()
        {
            GravityToggler.SetToggleState(false);
            KinematicToggler.SetToggleState(false);
            CollisionsToggler.SetToggleState(false);
        }

        internal override void OnSelectedObject_Destroyed()
        {
            Reset();
        }

        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            Reset();
        }

        private static QMToggleButton GravityToggler;
        private static QMToggleButton KinematicToggler;
        private static QMToggleButton CollisionsToggler;
        private static QMToggleButton SmartKinematicToggler;

        private static bool _SmartKinematicEnabled;

        internal static bool SmartKinematicEnabled
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