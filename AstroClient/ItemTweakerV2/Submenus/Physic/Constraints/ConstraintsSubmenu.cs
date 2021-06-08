using AstroClient.Components;
using AstroClient.Extensions;
using AstroClient.ItemTweakerV2.Selector;
using RubyButtonAPI;
using System;
using UnityEngine;

namespace AstroClient.ItemTweakerV2.Submenus
{
	public class ConstraintsSubmenu : Tweaker_Events
	{
		public static void Init_ConstraintsSubmenu(QMNestedButton menu, float x, float y, bool btnHalf)
		{
			var ConstraintMenu = new QMNestedButton(menu, x, y, "Constraints", "Item Constraint Editor Menu!", null, null, null, null, btnHalf);
			Constraint_X_Toggle = new QMToggleButton(ConstraintMenu, 1, 0, "Block X Movement", new Action(() => { Tweaker_Object.GetGameObjectToEdit().RigidBody_Add_Constraint(RigidbodyConstraints.FreezePositionX); }), "Unlock X Movement", new Action(() => { Tweaker_Object.GetGameObjectToEdit().RigidBody_Remove_Constraint(RigidbodyConstraints.FreezePositionX); }), "Control Current Object Constraints!", null, null, null, false);
			Constraint_Y_Toggle = new QMToggleButton(ConstraintMenu, 2, 0, "Block Y Movement", new Action(() => { Tweaker_Object.GetGameObjectToEdit().RigidBody_Add_Constraint(RigidbodyConstraints.FreezePositionY); }), "Unlock Y Movement", new Action(() => { Tweaker_Object.GetGameObjectToEdit().RigidBody_Remove_Constraint(RigidbodyConstraints.FreezePositionY); }), "Control Current Object Constraints!", null, null, null, false);
			Constraint_Z_Toggle = new QMToggleButton(ConstraintMenu, 3, 0, "Block Z Movement", new Action(() => { Tweaker_Object.GetGameObjectToEdit().RigidBody_Add_Constraint(RigidbodyConstraints.FreezePositionZ); }), "Unlock Z Movement", new Action(() => { Tweaker_Object.GetGameObjectToEdit().RigidBody_Remove_Constraint(RigidbodyConstraints.FreezePositionZ); }), "Control Current Object Constraints!", null, null, null, false);
			new QMSingleButton(ConstraintMenu, 4, 0, "Freeze Position", new Action(() => { Tweaker_Object.GetGameObjectToEdit().RigidBody_Add_Constraint(RigidbodyConstraints.FreezePosition); }), null, null, null, false);

			Constraint_Rot_X_Toggle = new QMToggleButton(ConstraintMenu, 1, 1, "Block X Rotation", new Action(() => { Tweaker_Object.GetGameObjectToEdit().RigidBody_Add_Constraint(RigidbodyConstraints.FreezeRotationX); }), "Unlock X Rotation", new Action(() => { Tweaker_Object.GetGameObjectToEdit().RigidBody_Remove_Constraint(RigidbodyConstraints.FreezeRotationX); }), "Control Current Object Constraints!", null, null, null, false);
			Constraint_Rot_Y_Toggle = new QMToggleButton(ConstraintMenu, 2, 1, "Block Y Rotation", new Action(() => { Tweaker_Object.GetGameObjectToEdit().RigidBody_Add_Constraint(RigidbodyConstraints.FreezeRotationY); }), "Unlock Y Rotation", new Action(() => { Tweaker_Object.GetGameObjectToEdit().RigidBody_Remove_Constraint(RigidbodyConstraints.FreezeRotationY); }), "Control Current Object Constraints!", null, null, null, false);
			Constraint_Rot_Z_Toggle = new QMToggleButton(ConstraintMenu, 3, 1, "Block Z Rotation", new Action(() => { Tweaker_Object.GetGameObjectToEdit().RigidBody_Add_Constraint(RigidbodyConstraints.FreezeRotationZ); }), "Unlock Z Rotation", new Action(() => { Tweaker_Object.GetGameObjectToEdit().RigidBody_Remove_Constraint(RigidbodyConstraints.FreezeRotationZ); }), "Control Current Object Constraints!", null, null, null, false);
			new QMSingleButton(ConstraintMenu, 4, 1, "Freeze Rotation", new Action(() => { Tweaker_Object.GetGameObjectToEdit().RigidBody_Add_Constraint(RigidbodyConstraints.FreezeRotation); }), null, null, null, false);
			new QMSingleButton(ConstraintMenu, 1, 2, "Remove all Object Constraints", new Action(() => { Tweaker_Object.GetGameObjectToEdit().RigidBody_Remove_All_Constraints(); }), "Delete all object Constraints", null, null);
		}

		public override void OnRigidBodyController_PropertyChanged(RigidBodyController control)
		{
			UpdateButtonsFromController(control);
		}

		public static void UpdateButtonsFromController(RigidBodyController control)
		{
			if (control != null)
			{
				if (!UpdateFreezeAllConstraints(control.Constraints))
				{
					UpdatePositionConstraints(control.Constraints);
					UpdateRotationSection(control.Constraints);
				}
			}
		}

		public static void Reset()
		{
			Update_Constraint_X_Toggle(false);
			Update_Constraint_Y_Toggle(false);
			Update_Constraint_Z_Toggle(false);
			Update_Constraint_Rot_X_Toggle(false);
			Update_Constraint_Rot_Y_Toggle(false);
			Update_Constraint_Rot_Z_Toggle(false);
		}

		public override void OnSelectedObject_Destroyed()
		{
			Reset();
		}

		public override void OnLevelLoaded()
		{
			Reset();
		}

		public override void OnRigidBodyControllerSelected(RigidBodyController control)
		{
			UpdateButtonsFromController(control);
		}

		public static bool UpdateFreezeAllConstraints(RigidbodyConstraints constraints)
		{
			if (constraints.HasFlag(RigidbodyConstraints.FreezeAll))
			{
				Update_Constraint_X_Toggle(true);
				Update_Constraint_Y_Toggle(true);
				Update_Constraint_Z_Toggle(true);
				Update_Constraint_Rot_X_Toggle(true);
				Update_Constraint_Rot_Y_Toggle(true);
				Update_Constraint_Rot_Z_Toggle(true);
				return true;
			}
			return false;
		}

		public static void UpdatePositionConstraints(RigidbodyConstraints constraints)
		{
			if (constraints.HasFlag(RigidbodyConstraints.FreezeAll))
			{
				return;
			}

			if (constraints.HasFlag(RigidbodyConstraints.FreezePosition))
			{
				Update_Constraint_X_Toggle(true);
				Update_Constraint_Y_Toggle(true);
				Update_Constraint_Z_Toggle(true);
			}
			else
			{
				Update_Constraint_X_Toggle(constraints.HasFlag(RigidbodyConstraints.FreezePositionX));
				Update_Constraint_Y_Toggle(constraints.HasFlag(RigidbodyConstraints.FreezePositionY));
				Update_Constraint_Z_Toggle(constraints.HasFlag(RigidbodyConstraints.FreezePositionZ));
			}
		}

		public static void UpdateRotationSection(RigidbodyConstraints constraints)
		{
			if (constraints.HasFlag(RigidbodyConstraints.FreezeAll))
			{
				return;
			}
			if (constraints.HasFlag(RigidbodyConstraints.FreezeRotation))
			{
				Update_Constraint_Rot_X_Toggle(true);
				Update_Constraint_Rot_Y_Toggle(true);
				Update_Constraint_Rot_Z_Toggle(true);
			}
			else
			{
				Update_Constraint_Rot_X_Toggle(constraints.HasFlag(RigidbodyConstraints.FreezeRotationX));
				Update_Constraint_Rot_Y_Toggle(constraints.HasFlag(RigidbodyConstraints.FreezeRotationY));
				Update_Constraint_Rot_Z_Toggle(constraints.HasFlag(RigidbodyConstraints.FreezeRotationZ));
			}
		}

		public static void Update_Constraint_Rot_X_Toggle(bool status)
		{
			if (Constraint_Rot_X_Toggle != null) { Constraint_Rot_X_Toggle.SetToggleState(status); }
		}

		public static void Update_Constraint_Rot_Y_Toggle(bool status)
		{
			if (Constraint_Rot_Y_Toggle != null) { Constraint_Rot_Y_Toggle.SetToggleState(status); }
		}

		public static void Update_Constraint_Rot_Z_Toggle(bool status)
		{
			if (Constraint_Rot_Z_Toggle != null) { Constraint_Rot_Z_Toggle.SetToggleState(status); }
		}

		public static void Update_Constraint_X_Toggle(bool status)
		{
			if (Constraint_X_Toggle != null) { Constraint_X_Toggle.SetToggleState(status); }
		}

		public static void Update_Constraint_Y_Toggle(bool status)
		{
			if (Constraint_Y_Toggle != null) { Constraint_Y_Toggle.SetToggleState(status); }
		}

		public static void Update_Constraint_Z_Toggle(bool status)
		{
			if (Constraint_Z_Toggle != null) { Constraint_Z_Toggle.SetToggleState(status); }
		}

		private static QMToggleButton Constraint_Rot_X_Toggle;
		private static QMToggleButton Constraint_Rot_Y_Toggle;
		private static QMToggleButton Constraint_Rot_Z_Toggle;

		private static QMToggleButton Constraint_X_Toggle;
		private static QMToggleButton Constraint_Y_Toggle;
		private static QMToggleButton Constraint_Z_Toggle;
	}
}