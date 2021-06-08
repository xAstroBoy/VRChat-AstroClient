using AstroClient.Components;
using AstroClient.ItemTweakerV2.Selector;
using RubyButtonAPI;
using System;
using UnityEngine;
using AstroClient.Extensions;

namespace AstroClient.ItemTweakerV2.Submenus
{
	public class PhysicsSubmenu : ObjectSelectorHelper
    {

		public static void Init_PhysicSubMenu(QMNestedButton menu, float x, float y, bool btnHalf)
		{
			var main = new QMNestedButton(menu, x, y, "Physics", "Item Physics Editor Menu!", null, null, null, null, btnHalf);
			GravityToggler = new QMSingleToggleButton(main, 1, 0, "Use Gravity", () => { Selector_Utils.GetGameObjectToEdit().Set_Gravity(true); }, "No Gravity", () => { Selector_Utils.GetGameObjectToEdit().Set_Gravity(false); }, "Toggle Object Gravity", Color.green, Color.red, null, false, true);
			KinematicToggler = new QMSingleToggleButton(main, 1, 0.5f, "Kinematic", () => {Selector_Utils.GetGameObjectToEdit().Set_isKinematic(true);  }, "Not Kinematic", () => { Selector_Utils.GetGameObjectToEdit().Set_isKinematic(false); }, "Toggle Object Kinematic", Color.green, Color.red, null, false, true);
			CollisionsToggler = new QMSingleToggleButton(main, 1, 1, "Use Collisions", () => {Selector_Utils.GetGameObjectToEdit().Set_DetectCollisions(true);  }, "No Collisions", () => { Selector_Utils.GetGameObjectToEdit().Set_DetectCollisions(false); }, "Toggle Object Collisions", Color.green, Color.red, null, false, true);
			ConstraintsSubmenu.Init_ConstraintsSubmenu(main, 1, 1.5f, true);


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

		public override void OnLevelLoaded()
		{
			Reset();
		}


		private static QMSingleToggleButton GravityToggler;
		private static QMSingleToggleButton KinematicToggler;
		private static QMSingleToggleButton CollisionsToggler;
	}
}