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

			new QMSingleButton(main, 1, 1f, "Copy Position.", () => { Tweaker_Object.GetGameObjectToEdit().CopyPosition(); }, "Copies Object Current Position in clipboard.", null, Color.yellow, true);
			new QMSingleButton(main, 1, 2f, "Copy Rotation.", () => { Tweaker_Object.GetGameObjectToEdit().CopyRotation(); }, "Copies Object Current Rotation in clipboard.", null, Color.yellow, true);
			new QMSingleButton(main, 1, 3f, "Copy Local Position.", () => { Tweaker_Object.GetGameObjectToEdit().CopyLocalPosition(); }, "Copies Object Current Local Position in clipboard.", null, Color.yellow, true);
			new QMSingleButton(main, 1, 4f, "Copy Object Path.", () => { Tweaker_Object.GetGameObjectToEdit().CopyPath(); }, "Copies Object Current Path in clipboard.", null, Color.yellow, true);




			CurrentObjectCoordsBtn = new QMSingleButton(main, 4, 1, "", null, "Shows Object Position", null, null, false);
			CurrentObjectCoordsBtn.ToggleBtnImage(false);
			CurrentObjectCoordsBtn.SetResizeTextForBestFit(true);


			CurrentObjectRotation = new QMSingleButton(main, 4, 0, "", null, "Shows Object Rotation", null, null, false);
			CurrentObjectRotation.ToggleBtnImage(false);
			CurrentObjectRotation.SetResizeTextForBestFit(true);


			CurrentObjectLocalPosition = new QMSingleButton(main, 4, 0, "", null, "Shows Object Local Position", null, null, false);
			CurrentObjectLocalPosition.ToggleBtnImage(false);
			CurrentObjectLocalPosition.SetResizeTextForBestFit(true);


			CurrentObjectPath = new QMSingleButton(main, 4, 0, "", null, "Shows Object Path", null, null, false);
			CurrentObjectPath.ToggleBtnImage(false);
			CurrentObjectPath.SetResizeTextForBestFit(true);
		}



		public static QMSingleButton CurrentObjectCoordsBtn;
		public static QMSingleButton CurrentObjectRotation;
		public static QMSingleButton CurrentObjectLocalPosition;
		public static QMSingleButton CurrentObjectPath;



		public override void On_New_GameObject_Selected(GameObject obj)
		{
			if (obj != null)
			{
				if (CurrentObjectPath != null)
				{
					CurrentObjectPath.SetButtonText(obj.GetPath());
				}
			}
		}

		public override void OnRigidBodyController_OnUpdate(RigidBodyController control)
		{
			if (control != null)
			{
				if (CurrentObjectCoordsBtn != null)
				{
					CurrentObjectCoordsBtn.SetButtonText(
						$"X:{control.transform.position.x}\n" +
						$"Y:{control.transform.position.y}\n" +
						$"Z:{control.transform.position.z}\n");
				}
				if (CurrentObjectRotation != null)
				{
					CurrentObjectRotation.SetButtonText(
						$"X:{control.transform.rotation.x}\n" +
						$"Y:{control.transform.rotation.y}\n" +
						$"Z:{control.transform.rotation.z}\n" +
						$"W:{control.transform.rotation.w}");
				}
				if (CurrentObjectLocalPosition != null)
				{
					CurrentObjectLocalPosition.SetButtonText(
						$"X:{control.transform.localPosition.x}\n" +
						$"Y:{control.transform.localPosition.y}\n" +
						$"Z:{control.transform.localPosition.z}\n");
				}
			}
		}

	}
}