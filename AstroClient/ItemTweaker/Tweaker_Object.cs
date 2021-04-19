using RubyButtonAPI;
using UnityEngine;

#region AstroClient Imports

using AstroClient.components;
using AstroClient.ConsoleUtils;
using AstroClient.Finder;
using AstroClient.AstroUtils.ItemTweaker;
using System.Linq;

#endregion AstroClient Imports

namespace AstroClient.ItemTweaker
{
    public class Tweaker_Object : GameEvents
    {

        public override void OnLevelLoaded()
        {
            DoNotPickOtherItems = false;
            if (TransformToEditBtn != null)
            {
                UpdateCapturedObject(null);
            }
            if (CurrentSelectedObject != null)
            {
                CurrentSelectedObject = null;
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
                if (CurrentSelectedObject != null)
                {
                    return CurrentSelectedObject.name;
                }
                else
                {
                    return "Not Selected Yet";
                }
            }
        }


        public static void UpdateCapturedObject(GameObject obj)
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
                UpdateCapturedButtonColor(obj.active);
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
                if (CurrentSelectedObject == null)
                {
                    value = false;
                }
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
                    if (CurrentSelectedObject != null)
                    {
                        if (CurrentSelectedObject.GetComponent<VRChatESP>() == null)
                        {
                            CurrentSelectedObject.AddComponent<VRChatESP>();
                        }
                    }
                }
                else
                {
                    if (CurrentSelectedObject != null)
                    {
                        if (CurrentSelectedObject.GetComponent<VRChatESP>() != null)
                        {
                            if (GameObjectESP.isMurderItemsESPActivated)
                            {
                                if (GameObjectESP.MurderESPItems != null && GameObjectESP.MurderESPItems.Count() != 0)
                                {
                                    if (GameObjectESP.MurderESPItems.Contains(CurrentSelectedObject))
                                    {
                                        if (!GameObjectESP.isMurderItemsESPActivated)
                                        {
                                            UnityEngine.Object.Destroy(CurrentSelectedObject.GetComponent<VRChatESP>());
                                        }
                                    }
                                }
                            }
                            else
                            {
                                UnityEngine.Object.Destroy(CurrentSelectedObject.GetComponent<VRChatESP>());
                            }
                        }
                    }
                }
                _CurrentSelectedItemEnabledESP = value;
            }
        }

        private static GameObject _CurrentSelectedObject;

        public static GameObject CurrentSelectedObject
        {
            get
            {
                return _CurrentSelectedObject;
            }
            set
            {
                if (_CurrentSelectedObject == value)
                {
                    return;
                }
                if (_CurrentSelectedObject != null)
                {


                    VRChatESP installedESP = _CurrentSelectedObject.GetComponent<VRChatESP>();
                    if (installedESP != null)
                    {
                        if (GameObjectESP.isMurderItemsESPActivated)
                        {
                            if (GameObjectESP.MurderESPItems != null && GameObjectESP.MurderESPItems.Count() != 0)
                            {
                                if (GameObjectESP.MurderESPItems.Contains(_CurrentSelectedObject))
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

                _CurrentSelectedObject = value;
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



        public static GameObject SetObjectToEditWithPath(string objpath)
        {
            var obj = GameObjectFinder.Find(objpath);
            if (obj != null)
            {
                ModConsole.Log("Path is valid, Found Gameobject obj : " + obj.name + "Using path " + objpath);
                CurrentSelectedObject = obj;
                return obj;
            }
            else
            {
                return null;
            }
        }

        public static void SetObjectToEdit(GameObject obj)
        {
            if (DoNotPickOtherItems)
            {
                return;
            }
            CurrentSelectedObject = obj;
        }



        public static GameObject GetGameObjectToEdit()
        {
            try
            {
                if (!DoNotPickOtherItems)
                {
                    var item = PlayerHands.GetHoldTransform();
                    if (item != null)
                    {
                        CurrentSelectedObject = item;
                    }
                    return CurrentSelectedObject;
                }
                else
                {
                    return CurrentSelectedObject;
                }
            }
            catch
            {
                return CurrentSelectedObject;
            }
        }





        public static QMSingleButton TransformToEditBtn;
        public static QMSingleToggleButton LockHoldItem;


    }
}
