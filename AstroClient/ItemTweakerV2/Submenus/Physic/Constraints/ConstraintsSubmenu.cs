using AstroClient.Components;
using AstroClient.ItemTweakerV2.Selector;
using RubyButtonAPI;
using System;
using UnityEngine;
using AstroClient.Extensions;

namespace AstroClient.ItemTweakerV2.Submenus
{
	public class ConstraintsSubmenu : ObjectSelectorHelper
    {

		public static void Init_ConstraintsSubmenu(QMTabMenu menu, float x, float y, bool btnHalf)
		{
			var main = new QMNestedButton(menu, x, y, "Constraints", "Item Constraint Editor Menu!", null, null, null, null, btnHalf);


		}

		public override void OnRigidBodyController_PropertyChanged(RigidBodyController control)
		{
			if (control != null)
			{
				if (control == CurrentController)
				{


				}
			}
		}


		public static void ConstraintSubMenu(QMTabMenu menu, float x, float y, bool btnHalf)
		{
			var ConstraintMenu = new QMNestedButton(menu, x, y, "Constraints", "Item Constraints Options", null, null, null, null, btnHalf);
			Forces.Constraint_X_Toggle = new QMToggleButton(ConstraintMenu, 1, 0, "Block X Movement", new Action(() => { Tweaker_Object.GetGameObjectToEdit().AddConstraint(RigidbodyConstraints.FreezePositionX); }), "Unlock X Movement", new Action(() => { Tweaker_Object.GetGameObjectToEdit().RemoveConstraint(RigidbodyConstraints.FreezePositionX); }), "Control Current Object Constraints!", null, null, null, false);
			Forces.Constraint_Y_Toggle = new QMToggleButton(ConstraintMenu, 2, 0, "Block Y Movement", new Action(() => { Tweaker_Object.GetGameObjectToEdit().AddConstraint(RigidbodyConstraints.FreezePositionY); }), "Unlock Y Movement", new Action(() => { Tweaker_Object.GetGameObjectToEdit().RemoveConstraint(RigidbodyConstraints.FreezePositionY); }), "Control Current Object Constraints!", null, null, null, false);
			Forces.Constraint_Z_Toggle = new QMToggleButton(ConstraintMenu, 3, 0, "Block Z Movement", new Action(() => { Tweaker_Object.GetGameObjectToEdit().AddConstraint(RigidbodyConstraints.FreezePositionZ); }), "Unlock Z Movement", new Action(() => { Tweaker_Object.GetGameObjectToEdit().RemoveConstraint(RigidbodyConstraints.FreezePositionZ); }), "Control Current Object Constraints!", null, null, null, false);
			new QMSingleButton(ConstraintMenu, 4, 0, "Freeze Position", new Action(() => { Tweaker_Object.GetGameObjectToEdit().AddConstraint(RigidbodyConstraints.FreezePosition); }), null, null, null, false);

			Forces.Constraint_Rot_X_Toggle = new QMToggleButton(ConstraintMenu, 1, 1, "Block X Rotation", new Action(() => { Tweaker_Object.GetGameObjectToEdit().AddConstraint(RigidbodyConstraints.FreezeRotationX); }), "Unlock X Rotation", new Action(() => { Tweaker_Object.GetGameObjectToEdit().RemoveConstraint(RigidbodyConstraints.FreezeRotationX); }), "Control Current Object Constraints!", null, null, null, false);
			Forces.Constraint_Rot_Y_Toggle = new QMToggleButton(ConstraintMenu, 2, 1, "Block Y Rotation", new Action(() => { Tweaker_Object.GetGameObjectToEdit().AddConstraint(RigidbodyConstraints.FreezeRotationY); }), "Unlock Y Rotation", new Action(() => { Tweaker_Object.GetGameObjectToEdit().RemoveConstraint(RigidbodyConstraints.FreezeRotationY); }), "Control Current Object Constraints!", null, null, null, false);
			Forces.Constraint_Rot_Z_Toggle = new QMToggleButton(ConstraintMenu, 3, 1, "Block Z Rotation", new Action(() => { Tweaker_Object.GetGameObjectToEdit().AddConstraint(RigidbodyConstraints.FreezeRotationZ); }), "Unlock Z Rotation", new Action(() => { Tweaker_Object.GetGameObjectToEdit().RemoveConstraint(RigidbodyConstraints.FreezeRotationZ); }), "Control Current Object Constraints!", null, null, null, false);
			new QMSingleButton(ConstraintMenu, 4, 1, "Freeze Rotation", new Action(() => { Tweaker_Object.GetGameObjectToEdit().AddConstraint(RigidbodyConstraints.FreezeRotation); }), null, null, null, false);

			new QMSingleButton(ConstraintMenu, 1, 2, "Remove all Object Constraints", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Remove_all_constraints(); }), "Delete all object Constraints", null, null);
		}



		public override void OnRigidBodyControllerSelected(RigidBodyController control)
		{
			if(control != null)
			{
				CurrentController = control;
			}
		}



		public override void OnSelectedObject_Destroyed()
		{
			CurrentController = null;
		}

		public override void OnLevelLoaded()
		{
			CurrentController = null;
		}



		private static RigidBodyController? CurrentController;



	}
}