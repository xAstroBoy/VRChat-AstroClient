namespace AstroClient.ItemTweakerV2.Submenus
{
    using AstroClient.Components;
    using AstroClient.ItemTweakerV2.Selector;
    using AstroLibrary.Extensions;
    using AstroButtonAPI;
    using UnityEngine;

    internal class ObjectInfoSubMenu : Tweaker_Events
    {
        internal static void Init_ObjectInfoSubMenu(QMTabMenu menu, float x, float y, bool btnHalf)
        {
            var main = new QMNestedButton(menu, x, y, "Object info", "Object Info Menu!", null, null, null, null, btnHalf);

            _ = new QMSingleButton(main, 1, 0f, "Copy Position.", () => { Tweaker_Object.GetGameObjectToEdit().CopyPosition(); }, "Copies Object Current Position in clipboard.", null, Color.yellow, true);
            _ = new QMSingleButton(main, 1, 0.5f, "Copy Rotation.", () => { Tweaker_Object.GetGameObjectToEdit().CopyRotation(); }, "Copies Object Current Rotation in clipboard.", null, Color.yellow, true);
            _ = new QMSingleButton(main, 1, 1f, "Copy Local Position.", () => { Tweaker_Object.GetGameObjectToEdit().CopyLocalPosition(); }, "Copies Object Current Local Position in clipboard.", null, Color.yellow, true);
            _ = new QMSingleButton(main, 1, 1.5f, "Copy Local Rotation.", () => { Tweaker_Object.GetGameObjectToEdit().CopyPath(); }, "Copies Object Current Local Rotation in clipboard.", null, Color.yellow, true);
            _ = new QMSingleButton(main, 1, 2, "Copy Object Path.", () => { Tweaker_Object.GetGameObjectToEdit().CopyPath(); }, "Copies Object Current Path in clipboard.", null, Color.yellow, true);

            float Position = 3f;
            float stretch = 1250f;
            CurrentObjectCoordsBtn = new QMSingleButton(main, Position, 0, "", null, "Shows Object Position", null, null, true);
            CurrentObjectCoordsBtn.ToggleBtnImage(false);
            CurrentObjectCoordsBtn.SetResizeTextForBestFit(true);
            CurrentObjectCoordsBtn.GetGameObject().GetComponent<RectTransform>().sizeDelta = new Vector2(CurrentObjectCoordsBtn.GetGameObject().GetComponent<RectTransform>().sizeDelta.x + stretch, CurrentObjectCoordsBtn.GetGameObject().GetComponent<RectTransform>().sizeDelta.y);

            CurrentObjectRotation = new QMSingleButton(main, Position, 0.5f, "", null, "Shows Object Rotation", null, null, true);
            CurrentObjectRotation.ToggleBtnImage(false);
            CurrentObjectRotation.SetResizeTextForBestFit(true);
            CurrentObjectRotation.GetGameObject().GetComponent<RectTransform>().sizeDelta = new Vector2(CurrentObjectRotation.GetGameObject().GetComponent<RectTransform>().sizeDelta.x + stretch, CurrentObjectRotation.GetGameObject().GetComponent<RectTransform>().sizeDelta.y);

            CurrentObjectLocalPosition = new QMSingleButton(main, Position, 1, "", null, "Shows Object Local Position", null, null, true);
            CurrentObjectLocalPosition.ToggleBtnImage(false);
            CurrentObjectLocalPosition.SetResizeTextForBestFit(true);
            CurrentObjectLocalPosition.GetGameObject().GetComponent<RectTransform>().sizeDelta = new Vector2(CurrentObjectLocalPosition.GetGameObject().GetComponent<RectTransform>().sizeDelta.x + stretch, CurrentObjectLocalPosition.GetGameObject().GetComponent<RectTransform>().sizeDelta.y);

            CurrentObjectLocalRotation = new QMSingleButton(main, Position, 1.5f, "", null, "Shows Object Local Rotation", null, null, true);
            CurrentObjectLocalRotation.ToggleBtnImage(false);
            CurrentObjectLocalRotation.SetResizeTextForBestFit(true);
            CurrentObjectLocalRotation.GetGameObject().GetComponent<RectTransform>().sizeDelta = new Vector2(CurrentObjectLocalRotation.GetGameObject().GetComponent<RectTransform>().sizeDelta.x + stretch, CurrentObjectLocalRotation.GetGameObject().GetComponent<RectTransform>().sizeDelta.y);

            CurrentObjectPath = new QMSingleButton(main, Position, 2f, "", null, "Shows Object Path", null, null, true);
            CurrentObjectPath.ToggleBtnImage(false);
            CurrentObjectPath.SetResizeTextForBestFit(true);
            CurrentObjectPath.GetGameObject().GetComponent<RectTransform>().sizeDelta = new Vector2(CurrentObjectPath.GetGameObject().GetComponent<RectTransform>().sizeDelta.x + stretch, CurrentObjectPath.GetGameObject().GetComponent<RectTransform>().sizeDelta.y);
        }

        internal static QMSingleButton CurrentObjectCoordsBtn;
        internal static QMSingleButton CurrentObjectRotation;
        internal static QMSingleButton CurrentObjectLocalPosition;
        internal static QMSingleButton CurrentObjectLocalRotation;
        internal static QMSingleButton CurrentObjectPath;

        internal override void On_New_GameObject_Selected(GameObject obj)
        {
            if (obj != null)
            {
                if (CurrentObjectPath != null)
                {
                    CurrentObjectPath.SetButtonText(obj.GetPath());
                }
            }
        }

        internal override void OnRigidBodyController_OnUpdate(RigidBodyController control)
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

                if (CurrentObjectLocalRotation != null)
                {
                    CurrentObjectLocalRotation.SetButtonText(
                        $"X:{control.transform.localRotation.x} " +
                        $"Y:{control.transform.localRotation.y} " +
                        $"Z:{control.transform.localRotation.z} " +
                        $"W:{control.transform.localRotation.w} ");
                }

                if (CurrentObjectRotation != null)
                {
                    CurrentObjectRotation.SetButtonText(
                        $"X:{control.transform.rotation.x} " +
                        $"Y:{control.transform.rotation.y} " +
                        $"Z:{control.transform.rotation.z} " +
                        $"W:{control.transform.rotation.w} ");
                }
            }
        }
    }
}