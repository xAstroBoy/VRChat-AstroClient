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

			new QMSingleButton(main, 1, 0f, "Copy Position.", () => { Tweaker_Object.GetGameObjectToEdit().CopyPosition(); }, "Copies Object Current Position in clipboard.", null, Color.yellow, true);
			new QMSingleButton(main, 1, 0.5f, "Copy Rotation.", () => { Tweaker_Object.GetGameObjectToEdit().CopyRotation(); }, "Copies Object Current Rotation in clipboard.", null, Color.yellow, true);
			new QMSingleButton(main, 1, 1f, "Copy Local Position.", () => { Tweaker_Object.GetGameObjectToEdit().CopyLocalPosition(); }, "Copies Object Current Local Position in clipboard.", null, Color.yellow, true);
			new QMSingleButton(main, 1, 1.5f, "Copy Object Path.", () => { Tweaker_Object.GetGameObjectToEdit().CopyPath(); }, "Copies Object Current Path in clipboard.", null, Color.yellow, true);




			CurrentObjectCoordsBtn = new QMSingleButton(main, 2.5f, 0, "", null, "Shows Object Position", null, null, true);
			CurrentObjectCoordsBtn.ToggleBtnImage(false);
			CurrentObjectCoordsBtn.SetResizeTextForBestFit(true);
			CurrentObjectCoordsBtn.GetGameObject().GetComponent<RectTransform>().sizeDelta = new Vector2(CurrentObjectCoordsBtn.GetGameObject().GetComponent<RectTransform>().sizeDelta.x + 200f, CurrentObjectPath.GetGameObject().GetComponent<RectTransform>().sizeDelta.y);


			CurrentObjectRotation = new QMSingleButton(main, 2.5f, 0.5f, "", null, "Shows Object Rotation", null, null, true);
			CurrentObjectRotation.ToggleBtnImage(false);
			CurrentObjectRotation.SetResizeTextForBestFit(true);
			CurrentObjectRotation.GetGameObject().GetComponent<RectTransform>().sizeDelta = new Vector2(CurrentObjectRotation.GetGameObject().GetComponent<RectTransform>().sizeDelta.x + 200f, CurrentObjectPath.GetGameObject().GetComponent<RectTransform>().sizeDelta.y);


			CurrentObjectLocalPosition = new QMSingleButton(main, 2.5f, 1, "", null, "Shows Object Local Position", null, null, true);
			CurrentObjectLocalPosition.ToggleBtnImage(false);
			CurrentObjectLocalPosition.SetResizeTextForBestFit(true);
			CurrentObjectLocalPosition.GetGameObject().GetComponent<RectTransform>().sizeDelta = new Vector2(CurrentObjectLocalPosition.GetGameObject().GetComponent<RectTransform>().sizeDelta.x + 200f, CurrentObjectPath.GetGameObject().GetComponent<RectTransform>().sizeDelta.y);


			CurrentObjectPath = new QMSingleButton(main, 2.5f, 1.5f, "", null, "Shows Object Path", null, null, true);
			CurrentObjectPath.ToggleBtnImage(false);
			CurrentObjectPath.SetResizeTextForBestFit(true);
			CurrentObjectPath.GetGameObject().GetComponent<RectTransform>().sizeDelta = new Vector2(CurrentObjectPath.GetGameObject().GetComponent<RectTransform>().sizeDelta.x + 200f, CurrentObjectPath.GetGameObject().GetComponent<RectTransform>().sizeDelta.y);

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
						$"X:{control.transform.position.x} " +
						$"Y:{control.transform.position.y} " +
						$"Z:{control.transform.position.z} ");
				}
				if (CurrentObjectRotation != null)
				{
					CurrentObjectRotation.SetButtonText(
						$"X:{control.transform.rotation.x} " +
						$"Y:{control.transform.rotation.y} " +
						$"Z:{control.transform.rotation.z} " +
						$"W:{control.transform.rotation.w} ");
				}
				if (CurrentObjectLocalPosition != null)
				{
					CurrentObjectLocalPosition.SetButtonText(
						$"X:{control.transform.localPosition.x} " +
						$"Y:{control.transform.localPosition.y} " +
						$"Z:{control.transform.localPosition.z} ");
				}
			}
		}

	}
}