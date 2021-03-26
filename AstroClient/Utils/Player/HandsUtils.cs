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

namespace AstroClient
{
    public class HandsUtils : Overridables
    {
        public static string GetObjectToEditName
        {
            get
            {
                if (GameObjectToEdit != null)
                {
                    return GameObjectToEdit.name;
                }
                else
                {
                    return "Not Selected Yet";
                }
            }
        }

        public static void DropObject(GameObject obj)
        {
            if (GetSelfVRCPlayerApi() != null)
            {
                var lefthand = GetSelfVRCPlayerApi().GetPickupInHand(VRC.SDKBase.VRC_Pickup.PickupHand.Left);
                var righthand = GetSelfVRCPlayerApi().GetPickupInHand(VRC.SDKBase.VRC_Pickup.PickupHand.Right);
                if (lefthand != null)
                {
                    if (lefthand.gameObject == obj)
                    {
                        lefthand.Drop();
                    }
                }
                if (righthand != null)
                {
                    if (righthand.gameObject == obj)
                    {
                        righthand.Drop();
                    }
                }
            }
        }

        public static void SetEditLock(bool status)
        {
            if (GameObjectToEdit != null)
            {
                ObjectToEditLock = status;
                LockHoldItem.setToggleState(status);
            }
        }

        public override void OnLevelLoaded()
        {
            SetEditLock(false);
            if (GameObjToEdit != null)
            {
                UpdateCapturedObject(null);
            }
            if (GameObjectToEdit != null)
            {
                GameObjectToEdit = null;
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

        public static GameObject GetHoldGameObject()
        {
            if (GetSelfVRCPlayerApi() != null)
            {
                var lefthand = GetSelfVRCPlayerApi().GetPickupInHand(VRC.SDKBase.VRC_Pickup.PickupHand.Left);
                var righthand = GetSelfVRCPlayerApi().GetPickupInHand(VRC.SDKBase.VRC_Pickup.PickupHand.Right);
                if (righthand != null)
                {
                    if (righthand.gameObject != null)
                    {
                        return righthand.gameObject;
                    }
                }
                else if (lefthand != null)
                {
                    if (lefthand.gameObject != null)
                    {
                        return lefthand.gameObject;
                    }
                }
            }
            return null;
        }

        public static GameObject GetLeftHoldObject()
        {
            if (GetSelfVRCPlayerApi() != null)
            {
                var lefthand = GetSelfVRCPlayerApi().GetPickupInHand(VRC.SDKBase.VRC_Pickup.PickupHand.Left);
                if (lefthand != null)
                {
                    if (lefthand.gameObject != null)
                    {
                        return lefthand.gameObject;
                    }
                }
            }
            return null;
        }

        public static GameObject GetRightHoldObject()
        {
            if (GetSelfVRCPlayerApi() != null)
            {
                var RightHand = GetSelfVRCPlayerApi().GetPickupInHand(VRC.SDKBase.VRC_Pickup.PickupHand.Right);
                if (RightHand != null)
                {
                    if (RightHand.gameObject != null)
                    {
                        return RightHand.gameObject;
                    }
                }
            }
            return null;
        }

        public static GameObject SetObjectToEditWithPath(string objpath)
        {
            var obj = GameObjectFinder.Find(objpath);
            if (obj != null)
            {
                ModConsole.Log("Path is valid, Found Gameobject obj : " + obj.name + "Using path " + objpath);
                GameObjectToEdit = obj;
                return obj;
            }
            else
            {
                return null;
            }
        }

        public static void SetObjectToEdit(GameObject obj)
        {
            if (ObjectToEditLock)
            {
                return;
            }
            GameObjectToEdit = obj;
        }

        // DONT CALL THIS ON COMPONENTS OR ONUPDATE, CALL THE OBJECT DIRECTLY!
        public static GameObject GetGameObjectToEdit()
        {
            try
            {
                if (!ObjectToEditLock)
                {
                    var item = GetHoldGameObject();
                    if (item != null)
                    {
                        GameObjectToEdit = item;
                    }
                    return GameObjectToEdit;
                }
                else
                {
                    return GameObjectToEdit;
                }
            }
            catch
            {
                return GameObjectToEdit;
            }
        }

        public static void UpdateCapturedObject(GameObject obj)
        {
            if (obj != null)
            {
                if (GameObjToEdit != null)
                {
                    GameObjToEdit.setButtonText("Editing: " + obj.name);
                    GameObjToEdit.setToolTip("Editing: " + obj.name);
                }
                if (GameObjMenu.GameObjMenuObjectToEdit != null)
                {
                    GameObjMenu.GameObjMenuObjectToEdit.setButtonText("Editing: " + obj.name);
                    GameObjMenu.GameObjMenuObjectToEdit.setToolTip("Editing: " + obj.name);
                }
                UpdateCapturedButtonColor(obj.active);
            }
            else
            {
                if (GameObjToEdit != null)
                {
                    GameObjToEdit.setButtonText("Pick a Gameobject to start!");
                    GameObjToEdit.setToolTip("Pick a Gameobject to start!");
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
                GameObjToEdit.setTextColor(Color.green);
            }
            else
            {
                GameObjToEdit.setTextColor(Color.red);
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
                    if (GameObjectToEdit != null)
                    {
                        if (GameObjectToEdit.GetComponent<VRChatESP>() == null)
                        {
                            GameObjectToEdit.AddComponent<VRChatESP>();
                        }
                    }
                }
                else
                {
                    if (GameObjectToEdit != null)
                    {
                        if (GameObjectToEdit.GetComponent<VRChatESP>() != null)
                        {
                            if (GameObjectESP.isMurderItemsESPActivated)
                            {
                                if (GameObjectESP.MurderESPItems != null && GameObjectESP.MurderESPItems.Count() != 0)
                                {
                                    if (GameObjectESP.MurderESPItems.Contains(GameObjectToEdit))
                                    {
                                        if (!GameObjectESP.isMurderItemsESPActivated)
                                        {
                                            UnityEngine.Object.Destroy(GameObjectToEdit.GetComponent<VRChatESP>());
                                        }
                                    }
                                }
                            }
                            else
                            {
                                UnityEngine.Object.Destroy(GameObjectToEdit.GetComponent<VRChatESP>());
                            }
                        }
                    }
                }
                _CurrentSelectedItemEnabledESP = value;
            }
        }

        private static GameObject _ObjectToEdit;

        public static GameObject GameObjectToEdit
        {
            get
            {
                return _ObjectToEdit;
            }
            set
            {
                if (_ObjectToEdit == value)
                {
                    return;
                }
                if (_ObjectToEdit != null)
                {


                    VRChatESP installedESP = _ObjectToEdit.GetComponent<VRChatESP>();
                    if (installedESP != null)
                    {
                        if (GameObjectESP.isMurderItemsESPActivated)
                        {
                            if (GameObjectESP.MurderESPItems != null && GameObjectESP.MurderESPItems.Count() != 0)
                            {
                                if (GameObjectESP.MurderESPItems.Contains(_ObjectToEdit))
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

                _ObjectToEdit = value;
                if (CurrentSelectedItemEnabledESP)
                {
                    if (value != null)
                    {
                        VRChatESP esp = value.GetComponent<VRChatESP>();
                        if (esp == null)
                        {
                            esp = value.AddComponent<VRChatESP>();
                        }
                    }
                }
                
                RigidBodyController RigidBodyController = value.GetComponent<RigidBodyController>();
                if (RigidBodyController == null)
                {
                    RigidBodyController = value.AddComponent<RigidBodyController>();
                    if (RigidBodyController != null)
                    {
                        RigidBodyController.EditMode = false;
                    }
                }

                PickupController PickupController = value.GetComponent<PickupController>();
                if (PickupController == null)
                {
                    PickupController = value.AddComponent<PickupController>();
                    if (PickupController != null)
                    {
                        PickupController.EditMode = false;
                    }
                }

                CrazyObjectManager.UpdateTimeButton(value);
                ObjectSpinnerManager.UpdateSpinnerButton(value);
                ObjectSpinnerManager.UpdateTimerButton(value);
                RocketManager.UpdateButton(value);
                ItemTweakerMain.CheckIfContainsPickupProperties(value);
                ItemTweakerMain.SetActiveButtonStatus(value);
                UpdateCapturedObject(value);
                ItemTweakerMain.UpdateTargetButtons();
                ItemTweakerMain.UpdateTeleportToMeBtns();
            }
        }

        public static bool ObjectToEditLock = false;
        public static QMSingleButton GameObjToEdit;
        public static QMSingleToggleButton LockHoldItem;
    }
}