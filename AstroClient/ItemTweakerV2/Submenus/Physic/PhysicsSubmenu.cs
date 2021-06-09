using AstroClient.Components;
using AstroClient.Extensions;
using AstroClient.ItemTweakerV2.Selector;
using RubyButtonAPI;
using UnityEngine;

namespace AstroClient.ItemTweakerV2.Submenus
{
	public class PhysicsSubmenu : Tweaker_Events
	{
		public static void Init_PhysicSubMenu(QMTabMenu menu, float x, float y, bool btnHalf)
		{
			var main = new QMNestedButton(menu, x, y, "Physics", "Item Physics Editor Menu!", null, null, null, null, btnHalf);
			GravityToggler = new QMSingleToggleButton(main, 1, 0, "Use Gravity", () => { var item = Tweaker_Object.GetGameObjectToEdit();  item.RigidBody_Set_Gravity(false); if (SmartKinematicEnabled) { if (!item.Will_It_fall_throught()) { item.RigidBody_Set_isKinematic(false); } }  }, "No Gravity", () => {  var item = Tweaker_Object.GetGameObjectToEdit();  item.RigidBody_Set_Gravity(false); if(SmartKinematicEnabled) { if(!item.Will_It_fall_throught()) { item.RigidBody_Set_isKinematic(false); } }  }, "Toggle Object Gravity", Color.green, Color.red, null, false, true); 			KinematicToggler = new QMSingleToggleButton(main, 1, 0.5f, "Kinematic", () => { Tweaker_Object.GetGameObjectToEdit().RigidBody_Set_isKinematic(true); }, "Not Kinematic", () => { Tweaker_Object.GetGameObjectToEdit().RigidBody_Set_isKinematic(false); }, "Toggle Object Kinematic", Color.green, Color.red, null, false, true);
			new QMSingleToggleButton(main, 2, 0.5f, "Smart Kinematic Toggler", () => {  }, "Smart Kinematic Toggler", () => {  }, "Toggle Smart Kinematic Toggler (Check if Object won't fall throught before toggling kinematic with gravity !)", Color.green, Color.red, null, false, true);

			CollisionsToggler = new QMSingleToggleButton(main, 1, 1, "Use Collisions", () => { Tweaker_Object.GetGameObjectToEdit().RigidBody_Set_DetectCollisions(true); }, "No Collisions", () => { Tweaker_Object.GetGameObjectToEdit().RigidBody_Set_DetectCollisions(false); }, "Toggle Object Collisions", Color.green, Color.red, null, false, true);
			ConstraintsSubmenu.Init_ConstraintsSubmenu(main, 1, 1.5f, true);
			new QMSingleButton(main, 1, 2f, "Restore Rigidbody", () => { Tweaker_Object.GetGameObjectToEdit().RigidBody_RestoreOriginalBody(); }, "Restore Default RigidBody Config.", null, null, true);
			ForcesSubmenu.Init_ForceSubMenu(main, 4, 0, true);

		
		}




		public override void OnRigidBodyController_OnUpdate(RigidBodyController control)
		{
			UpdateProperties(control); // Might hit perf idk.
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
		private static QMSingleToggleButton SmartKinematicToggler;

		private static bool _SmartKinematicEnabled;
		public static bool SmartKinematicEnabled
		{
			get
			{
				return _SmartKinematicEnabled;
			}
			set
			{
				if(SmartKinematicToggler != null)
				{
					SmartKinematicToggler.SetToggleState(value);
				}
				_SmartKinematicEnabled = value;
			}
	}
}