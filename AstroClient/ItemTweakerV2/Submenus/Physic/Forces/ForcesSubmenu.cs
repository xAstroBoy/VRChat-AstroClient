using AstroClient.Components;
using AstroClient.ItemTweakerV2.Selector;
using RubyButtonAPI;
using System;
using UnityEngine;
using AstroClient.Extensions;
using AstroLibrary.Extensions;

namespace AstroClient.ItemTweakerV2.Submenus
{
	public class ForcesSubmenu : ObjectSelectorHelper
    {

		public static void ForceSubMenu(QMTabMenu menu, float x, float y, bool btnHalf)
		{
			var ForceSubMenu = new QMNestedButton(menu, x, y, "Forces", "You have the Force! Dont abuse it! <3!", null, null, null, null, btnHalf);

			Forces_Pickup_IsHeld = new QMSingleButton(ForceSubMenu, 0, -1.5f, "Held : No", null, "See if Pickup is held or not.", null, null, true);

			Forces_CurrentObjHolder = new QMSingleButton(ForceSubMenu, 0, -1, "Current holder : null", null, "Who is the current object Holder.", null, null, false);
			Forces_CurrentObjHolder.SetResizeTextForBestFit(true);

			Forces_SelPickup_CurrentObjOwner = new QMSingleButton(ForceSubMenu, 5, -1, "Current Owner : null", null, "Who is the current object owner.", null, null, false);
			Forces_SelPickup_CurrentObjOwner.SetResizeTextForBestFit(true);

			ForceAmnt1 = new QMSingleButton(ForceSubMenu, 0, 0, "Force : " + Force, () =>{Force = DefaultForce;}, string.Empty, null, null);
			SpinForceAmnt1 = new QMSingleButton(ForceSubMenu, 0, 1, "Spin Force : " + SpinForce, () =>{SpinForce = DefaultSpinForce;}, string.Empty, null, null);

			QMNestedButton ForceAddControl = new QMNestedButton(ForceSubMenu, 5, 0, "Tweak Force Amounts", "Force Tweaker Menu!", null, null, null, null);

			ForceAmnt2 = new QMSingleButton(ForceAddControl, 0, 0, "Force : " + Force, () =>{Force = DefaultForce;}, string.Empty, null, null);
			SpinForceAmnt2 = new QMSingleButton(ForceAddControl, 0, 1, "Spin Force : " + SpinForce, () =>{SpinForce = DefaultSpinForce;}, string.Empty, null, null);

			ForceSlider = new QMSlider(Utils.QuickMenu.transform.Find(ForceAddControl.GetMenuName()), "Force Power :", 150, -720, delegate (float value)
			{
				Force = (int)value;
			}, DefaultForce, 1000, 1, true);
			ForceSlider.Slider.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
			ForceSlider.SetTextLabel("");
			Forces.ResetForcesVar();

			SpinForceSlider = new QMSlider(Utils.QuickMenu.transform.Find(ForceAddControl.GetMenuName()), "Spin Power : ", 150, -1120, delegate (float value)
			{
				SpinForce = (int)value;
			}, DefaultSpinForce, 1000, 1, true);
			SpinForceSlider.Slider.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
			SpinForceSlider.SetTextLabel("");

			new QMSingleButton(ForceSubMenu, 5, 1, "Kill Any Object Forces", new Action(() => { Selector_Utils.GetGameObjectToEdit().KillForces(); }), "Kill Obj Forces", null, null);
			var right = new QMSingleButton(ForceSubMenu, 4, 2, "→", new Action(() => { Selector_Utils.GetGameObjectToEdit().Right(); }), string.Empty, null, null);
			var left = new QMSingleButton(ForceSubMenu, 2, 2, "←", new Action(() => { Selector_Utils.GetGameObjectToEdit().Left(); }), string.Empty, null, null);
			var foward = new QMSingleButton(ForceSubMenu, 3, 1, "↑", new Action(() => { Selector_Utils.GetGameObjectToEdit().Foward(); }), string.Empty, null, null);
			var backward = new QMSingleButton(ForceSubMenu, 3, 2, "↓", new Action(() => { Selector_Utils.GetGameObjectToEdit().Backward(); }), string.Empty, null, null);

			new QMSingleButton(ForceSubMenu, 1, 0, "Push", new Action(() => { Selector_Utils.GetGameObjectToEdit().Push(); }), string.Empty, null, null);
			new QMSingleButton(ForceSubMenu, 2, 0, "Pull", new Action(() => { Selector_Utils.GetGameObjectToEdit().Pull(); }), string.Empty, null, null);
			new QMSingleButton(ForceSubMenu, 1, 1, "Rotate X", new Action(() => { Selector_Utils.GetGameObjectToEdit().SpinX(); }), string.Empty, null, null);
			new QMSingleButton(ForceSubMenu, 2, 1, "Rotate Y", new Action(() => { Selector_Utils.GetGameObjectToEdit().SpinY(); }), string.Empty, null, null);
			new QMSingleButton(ForceSubMenu, 1, 2, "Rotate Z", new Action(() => { Selector_Utils.GetGameObjectToEdit().SpinZ(); }), string.Empty, null, null);
		}


		public override void OnRigidBodyController_PropertyChanged(RigidBodyController control)
		{
		}






		public override void OnRigidBodyControllerSelected(RigidBodyController control)
		{
		}



		public override void OnSelectedObject_Destroyed()
		{
		}

		public override void OnLevelLoaded()
		{
		}



		public static QMSingleButton Forces_Pickup_IsHeld { get; private set; }
		public static QMSingleButton Forces_CurrentObjHolder { get; private set; }
		public static QMSingleButton Forces_SelPickup_CurrentObjOwner { get; private set; }
		public static QMSlider ForceSlider { get; private set; }
		public static QMSlider SpinForceSlider { get; private set; }

		public static QMSingleButton ForceAmnt1;

		public static QMSingleButton ForceAmnt2;
		public static QMSingleButton SpinForceAmnt1;
		public static QMSingleButton SpinForceAmnt2;


		private static float _Force;
		private static float Force
		{
			get
			{
				return _Force;
			}
			set
			{
				_Force = value;
				if (ForceAmnt1 != null)
				{
					ForceAmnt1.SetButtonText("Force : " + value.ToString());
				}
				if (ForceAmnt2 != null)
				{
					ForceAmnt2.SetButtonText("Force : " + value.ToString());
				}
				if (ForceSlider != null)
				{
					ForceSlider.SetValue(value);
				}
			}
		}
		private static float _SpinForce;
		private static float SpinForce
		{
			get
			{
				return _SpinForce;
			}
			set
			{
				_SpinForce = value;
				if (SpinForceAmnt1 != null)
				{
					SpinForceAmnt1.SetButtonText("Spin Force : " + SpinForce.ToString());
				}
				if (SpinForceAmnt2 != null)
				{
					SpinForceAmnt2.SetButtonText("Spin Force : " + SpinForce.ToString());
				}

				if (SpinForceSlider != null)
				{
					SpinForceSlider.SetValue(value);
				}
			}
		}

		public static readonly float DefaultForce = 1f;
		public static readonly float DefaultSpinForce = 100f;



	}
}