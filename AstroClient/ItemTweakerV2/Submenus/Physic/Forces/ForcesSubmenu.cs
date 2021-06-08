using AstroClient.Components;
using AstroClient.ItemTweakerV2.Selector;
using RubyButtonAPI;
using System;
using UnityEngine;
using AstroClient.Extensions;

namespace AstroClient.ItemTweakerV2.Submenus
{
	public class ForcesSubmenu : ObjectSelectorHelper
    {

		public static void Init_ForcesSubmenu(QMTabMenu menu, float x, float y, bool btnHalf)
		{
			var main = new QMNestedButton(menu, x, y, "Forces", "Item Forces Editor Menu!", null, null, null, null, btnHalf);


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