namespace AstroClient.ItemTweakerV2.Submenus
{
	using AstroClient.Components;
	using AstroClient.Extensions;
	using AstroClient.ItemTweakerV2.Selector;
	using AstroClient.ItemTweakerV2.Submenus.ScrollMenus;
	using AstroLibrary.Extensions;
	using RubyButtonAPI;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;

	public class ObjectInfoSubMenu : Tweaker_Events
	{
		public static void Init_ObjectInfoSubMenu(QMTabMenu menu, float x, float y, bool btnHalf)
		{
			var main = new QMNestedButton(menu, x, y, "Object info", "Object Info Menu!", null, null, null, null, btnHalf);

			new QMSingleButton(menu, 1, 0f, "Copy Local Position.", () => { Tweaker_Object.GetGameObjectToEdit().CopyLocalPosition(); }, "Copies Object Current Local Position in clipboard.", null, Color.yellow, true);
			new QMSingleButton(menu, 1, 0.5f, "Copy Position.", () => { Tweaker_Object.GetGameObjectToEdit().CopyPosition(); }, "Copies Object Current Position in clipboard.", null, Color.yellow, true);
			new QMSingleButton(menu, 1, 1f, "Copy Rotation.", () => { Tweaker_Object.GetGameObjectToEdit().CopyRotation(); }, "Copies Object Current Rotation in clipboard.", null, Color.yellow, true);
			new QMSingleButton(menu, 1, 1.5f, "Copy Object Path.", () => { Tweaker_Object.GetGameObjectToEdit().CopyPath(); }, "Copies Object Current Path in clipboard.", null, Color.yellow, true);




			CurrentObjectCoordsBtn = new QMSingleButton(menu, 4, -1, "", null, "Shows Object Coords", null, null, false);
			CurrentObjectCoordsBtn.ToggleBtnImage(false);
			CurrentObjectCoordsBtn.SetResizeTextForBestFit(true);
		}



		public static QMSingleButton CurrentObjectCoordsBtn;



		public override void On_New_GameObject_Selected(GameObject obj)
		{
			// TODO: Update New visible buttons
		}

		public override void OnRigidBodyController_OnUpdate(RigidBodyController control)
		{
			if(CurrentObjectCoordsBtn != null)
			{
				CurrentObjectCoordsBtn.SetButtonText(
					$"X:{control.transform.position.x}\n" +
					$"Y:{control.transform.position.y}\n" +
					$"Z:{control.transform.position.z}\n");
			}


		}

	}
}