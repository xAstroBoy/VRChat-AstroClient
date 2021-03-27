using RubyButtonAPI;
using UnityEngine;

#region AstroClient Imports

using AstroClient.components;
using static AstroClient.LocalPlayerUtils;
using AstroClient.ConsoleUtils;
using AstroClient.Finder;
using AstroClient.AstroUtils.ItemTweaker;
using System.Linq;

#endregion AstroClient Imports

namespace AstroClient.ItemTweaker
{
    public class Tweaker_Object : Overridables
    {

        public static void SetEditLock(bool status)
        {
            if (TransformToEdit != null)
            {
                ObjectToEditLock = status;
                LockHoldItem.setToggleState(status);
            }
        }

        public override void OnLevelLoaded()
        {
            SetEditLock(false);
            if (TransformToEditBtn != null)
            {
                UpdateCapturedObject(null);
            }
            if (TransformToEdit != null)
            {
                TransformToEdit = null;
            }
            CurrentSelectedItemEnabledESP = false;
            if (LockHoldItem != null)
            {
                LockHoldItem.setToggleState(false);
            }

            if (LockHoldItem != null)
            {
                LockHoldItem.setToggleState(false);
            }
        }

        public static string GetObjectToEditName
        {
            get
            {
                if (TransformToEdit != null)
                {
                    return TransformToEdit.name;
                }
                else
                {
                    return "Not Selected Yet";
                }
            }
        }


        public static void UpdateCapturedObject(Transform obj)
        {
            if (obj != null)
            {
                if (TransformToEditBtn != null)
                {
                    TransformToEditBtn.setButtonText("Editing: " + obj.name);
                    TransformToEditBtn.setToolTip("Editing: " + obj.name);
                }
                if (GameObjMenu.GameObjMenuObjectToEdit != null)
                {
                    GameObjMenu.GameObjMenuObjectToEdit.setButtonText("Editing: " + obj.name);
                    GameObjMenu.GameObjMenuObjectToEdit.setToolTip("Editing: " + obj.name);
                }
                UpdateCapturedButtonColor(obj.gameObject.active);
            }
            else
            {
                if (TransformToEditBtn != null)
                {
                    TransformToEditBtn.setButtonText("Pick a Gameobject to start!");
                    TransformToEditBtn.setToolTip("Pick a Gameobject to start!");
                }
                if (GameObjMenu.GameObjMenuObjectToEdit != null)
                {
                    GameObjMenu.GameObjMenuObjectToEdit.setButtonText("Pick a Gameobject to start!");
                    GameObjMenu.GameObjMenuObjectToEdit.setToolTip("Pick a Gameobject to start!");
                }
            }
        }

        public static void UpdateCapturedButtonColor(bool isActive)
        {
            if (isActive)
            {
                TransformToEditBtn.setTextColor(Color.green);
            }
            else
            {
                TransformToEditBtn.setTextColor(Color.red);
            }
        }

        private static bool _DoNotPickOtherItems;

        public static bool DoNotPickOtherItems
        {
            get
            {
                return _DoNotPickOtherItems;
            }
            set
            {
                _DoNotPickOtherItems = value;
                if (LockHoldItem != null)
                {
                    LockHoldItem.setToggleState(value);
                }
            }
        }

        private static bool _CurrentSelectedItemEnabledESP = false;

        public static bool CurrentSelectedItemEnabledESP
        {
            get
            {
                return _CurrentSelectedItemEnabledESP;
            }
            set
            {
                _CurrentSelectedItemEnabledESP = value;
                if (value)
                {
                    if (TransformToEdit != null)
                    {
                        if (TransformToEdit.GetComponent<VRChatESP>() == null)
                        {
                            TransformToEdit.gameObject.AddComponent<VRChatESP>();
                        }
                    }
                }
                else
                {
                    if (TransformToEdit != null)
                    {
                        if (TransformToEdit.GetComponent<VRChatESP>() != null)
                        {
                            if (GameObjectESP.isMurderItemsESPActivated)
                            {
                                if (GameObjectESP.MurderESPItems != null && GameObjectESP.MurderESPItems.Count() != 0)
                                {
                                    if (GameObjectESP.MurderESPItems.Contains(TransformToEdit.gameObject))
                                    {
                                        if (!GameObjectESP.isMurderItemsESPActivated)
                                        {
                                            UnityEngine.Object.Destroy(TransformToEdit.GetComponent<VRChatESP>());
                                        }
                                    }
                                }
                            }
                            else
                            {
                                UnityEngine.Object.Destroy(TransformToEdit.GetComponent<VRChatESP>());
                            }
                        }
                    }
                }
                _CurrentSelectedItemEnabledESP = value;
            }
        }

        private static Transform _TransformToEdit;

        public static Transform TransformToEdit
        {
            get
            {
                return _TransformToEdit;
            }
            set
            {
                if (_TransformToEdit == value)
                {
                    return;
                }
                if (_TransformToEdit != null)
                {


                    VRChatESP installedESP = _TransformToEdit.GetComponent<VRChatESP>();
                    if (installedESP != null)
                    {
                        if (GameObjectESP.isMurderItemsESPActivated)
                        {
                            if (GameObjectESP.MurderESPItems != null && GameObjectESP.MurderESPItems.Count() != 0)
                            {
                                if (GameObjectESP.MurderESPItems.Contains(_TransformToEdit.gameObject))
                                {
                                    if (!GameObjectESP.isMurderItemsESPActivated)
                                    {
                                        UnityEngine.Object.Destroy(installedESP);
                                    }
                                }
                            }
                        }
                        else
                        {
                            UnityEngine.Object.Destroy(installedESP);
                        }
                    }
                }

                _TransformToEdit = value;
                if (CurrentSelectedItemEnabledESP)
                {
                    if (value != null)
                    {
                        VRChatESP esp = value.GetComponent<VRChatESP>();
                        if (esp == null)
                        {
                            esp = value.gameObject.AddComponent<VRChatESP>();
                        }
                    }
                }
                
                RigidBodyController RigidBodyController = value.GetComponent<RigidBodyController>();
                if (RigidBodyController == null)
                {
                    RigidBodyController = value.gameObject.AddComponent<RigidBodyController>();
                    if (RigidBodyController != null)
                    {
                        RigidBodyController.EditMode = false;
                    }
                }

                PickupController PickupController = value.GetComponent<PickupController>();
                if (PickupController == null)
                {
                    PickupController = value.gameObject.AddComponent<PickupController>();
                    if (PickupController != null)
                    {
                        PickupController.EditMode = false;
                    }
                }

                CrazyObjectManager.UpdateTimeButton(value.gameObject);
                ObjectSpinnerManager.UpdateSpinnerButton(value.gameObject);
                ObjectSpinnerManager.UpdateTimerButton(value.gameObject);
                RocketManager.UpdateButton(value.gameObject);
                ItemTweakerMain.CheckIfContainsPickupProperties(value.gameObject);
                ItemTweakerMain.SetActiveButtonStatus(value);
                UpdateCapturedObject(value);
                ItemTweakerMain.UpdateTargetButtons();
                ItemTweakerMain.UpdateTeleportToMeBtns();
            }
        }



        public static Transform SetObjectToEditWithPath(string objpath)
        {
            var obj = GameObjectFinder.Find(objpath).transform;
            if (obj != null)
            {
                ModConsole.Log("Path is valid, Found Gameobject obj : " + obj.name + "Using path " + objpath);
                TransformToEdit = obj;
                return obj;
            }
            else
            {
                return null;
            }
        }

        public static void SetObjectToEdit(Transform obj)
        {
            if (ObjectToEditLock)
            {
                return;
            }
            TransformToEdit = obj.transform;
        }



        public static Transform GetTransformToEdit()
        {
            try
            {
                if (!ObjectToEditLock)
                {
                    var item = PlayerHands.GetHoldTransform();
                    if (item != null)
                    {
                        TransformToEdit = item;
                    }
                    return TransformToEdit;
                }
                else
                {
                    return TransformToEdit;
                }
            }
            catch
            {
                return TransformToEdit;
            }
        }

        public static GameObject GetGameObjectToEdit()
        {
            return GetTransformToEdit().gameObject;
        }

        public static Transform CurrentSelectedObject
        {
            get
            {
                return TransformToEdit;
            }
        }


        public static bool ObjectToEditLock = false;


        public static QMSingleButton TransformToEditBtn;
        public static QMSingleToggleButton LockHoldItem;


    }
}
