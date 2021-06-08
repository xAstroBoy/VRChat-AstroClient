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

		public static void Init_PhysicSubMenu(QMTabMenu menu, float x, float y, bool btnHalf)
		{
			var main = new QMNestedButton(menu, x, y, "Physics", "Item Physics Editor Menu!", null, null, null, null, btnHalf);
			GravityToggler = new QMSingleToggleButton(main, 1, 0, "Use Gravity", () => { CurrentController.Set_Gravity(true); }, "No Gravity", () => { CurrentController.Set_Gravity(false); }, "Toggle Object Gravity", Color.green, Color.red, null, false, true);
			KinematicToggler = new QMSingleToggleButton(main, 1, 0.5f, "Kinematic", () => {CurrentController.Set_isKinematic(true);  }, "Not Kinematic", () => { CurrentController.Set_isKinematic(false); }, "Toggle Object Kinematic", Color.green, Color.red, null, false, true);
			CollisionsToggler = new QMSingleToggleButton(main, 1, 1, "Use Collisions", () => {CurrentController.Set_DetectCollisions(true);  }, "No Collisions", () => { CurrentController.Set_DetectCollisions(false); }, "Toggle Object Collisions", Color.green, Color.red, null, false, true);


		}

		public override void OnRigidBodyController_PropertyChanged(RigidBodyController control)
		{
			if (control != null)
			{
				if (control == CurrentController)
				{
					if(GravityToggler.GetToggleState() != control.useGravity)
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
		}






		// TODO: Make a Event that checks When is on the tweaker and it gives the component the focus needed.
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


		private static QMSingleToggleButton GravityToggler;
		private static QMSingleToggleButton KinematicToggler;
		private static QMSingleToggleButton CollisionsToggler;


		private static RigidBodyController? CurrentController;



	}
}